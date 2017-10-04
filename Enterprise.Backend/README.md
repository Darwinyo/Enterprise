# Enterprise.Backend

## The structure of projects

We can separate into 5 big modules

- Backend
  - Enterprise.API
    - [Enterprise.API](#enterprise-api)
    - [Enterprise.API.Helpers](#enterprise-api-helpers)
    - [Enterprise.API.Models](#enterprise-api-models)
   - Enterprise.Framework
     - [Enterprise.Framework.DataLayers](#enterprise-framework-datalayers)
     - [Enterprise.Framework.DataLayers.DTOs](#enterprise-framework-datalayers-dtos)
     - [Enterprise.Framework.Repository](#enterprise-framework-repository)
     - [Enterprise.Framework.BusinessLogics](#enterprise-framework-businesslogics)
   - Enterprise.Workflows
     - [Enterprise.Workflows](#enterprise-workflows)
     - [Enterprise.Workflows.Clients](#enterprise-workflows-clients)
     - [Enterprise.Workflows.Invoker](#enterprise-workflows-invoker)
     - [Enterprise.Workflows.Helpers](#enterprise-workflows-helpers)
     - [Enterprise.Workflows.Models](#enterprise-workflows-models)
   - Enterprise.SignalR
     - [Enterprise.SignalR](#enterprise-signalr)
   - Enterprise.Core
     - [Enterprise.Core.BusinessLogics](#enterprise-core-businesslogics)
     - [Enterprise.Core.DataLayers.DTOs.Models](#enterprise-core-datalayers-dtos-models)
     - [Enterprise.Core.DataLayers.DTOs](#enterprise-core-datalayers-dtos)
     - [Enterprise.Core.DataLayers](#enterprise-core-datalayers)
     - [Enterprise.Core.Repository](#enterprise-core-repository)
     - [Enterprise.Core.Services](#enterprise-core-services)


## Projects Roles

### Enterprise API
This Layer only able to calling services. in this project we define our abstraction that we define in every project for Dependencies Injection Purpose (In Startup.cs).
``` C#
// Startup.cs
public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc()
                .AddJsonOptions(
                option => 
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
			// SignalR Config
            services.AddSignalR(options => options.Hubs.EnableDetailedErrors = true);

            #region session & caching
			// This Config Is This App Caching System
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = "localhost";
                option.InstanceName = "EnterpriseCache";
            });
            services.AddSession();
            #endregion

            #region dbcontext
            services.AddDbContext<ProductContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EnterpriseDB_Product")));

            services.AddDbContext<UserContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EnterpriseDB_User")));
			// MongoDB Config
            services.Configure<MongoDBSettings>(option =>
            {
                option.ConnectionString = Configuration.GetSection("MongoConnectionStrings:EnterpriseDB_Mongo:ConnectionString").Value;
                option.Database = Configuration.GetSection("MongoConnectionStrings:EnterpriseDB_Mongo:Database").Value;
            });
            #endregion

            #region repository
            services.AddScoped<ITblProductRepository, TblProductRepository>();
            services.AddScoped<ITblProductCommentsRepository, TblProductCommentsRepository>();
            services.AddScoped<ITblCategoryRepository, TblCategoryRepository>();
            #endregion

            #region services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCommentService, ProductCommentService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            #endregion

            #region business logic
            services.AddScoped<ICityBusinessLogic, CityBusinessLogic>();
            services.AddScoped<IChatBusinessLogic, ChatBusinessLogic>();
            services.AddScoped<IProductCommentsBusinessLogic, ProductCommentsBusinessLogic>();
            #endregion
        }
```
then implements inject those abstractions to constructors
``` C#
// ProductController.cs
namespace Enterprise.API.Controllers.Product
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
		// Like this we inject Services to App
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<TblProduct> Get()
        {
            return _productService.GetAllListProduct();
        }
	}
}

```
Also we calling our Caching system in this project.
``` C#
// UserLoginController.cs
namespace Enterprise.API.Controllers.User
{
    [Route("api/[controller]")]
    public class UserLoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly IDistributedCache _distributedCache;
        public UserLoginController(IUserService userService, IDistributedCache distributedCache)
        {
            _userService = userService;
            _distributedCache = distributedCache;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<UserLoginResponse> Get(string id)
        {
			// Get Cache from Redis
            var value = await _distributedCache.GetAsync(id);
            return JsonConvert.DeserializeObject<UserLoginResponse>(Encoding.UTF8.GetString(value));
        }

        // POST api/values
        [HttpPost]
        public async Task<UserLoginResponse> Post([FromBody]object value)
        {
            JObject jObject = (JObject)value;
            bool rememberMe = Convert.ToBoolean(jObject["rememberme"]?.ToString());
            string userLogin = jObject["userLogin"].ToString();
            string password = jObject["password"].ToString();
            UserLoginResponse userLoginResponse = await _userService.LoginUser(userLogin,password);
            if (rememberMe && userLoginResponse.IsLogged)
            {
				// This will Cache Our UserLogins to Redis
                await _distributedCache.SetAsync(userLoginResponse.UserKey,
                    Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(userLoginResponse)),
                    new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(new TimeSpan(1, 0, 0, 0)));
            }
            return userLoginResponse;
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
			// Remove Cache from Redis
            _distributedCache.RemoveAsync(id);
        }
    }
}

```
And We Do Real time Communication with Server using SignalR via WebSocket
``` C#
// Startup.cs
namespace Enterprise.API
{
	public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
			// Using WebSocket Pipeline
            app.UseWebSockets();
			// Enable Cors => We need it because we completely decouple our frontend, With Backend
            app.UseCors(builder =>
			// this config will change when its ready for production
            builder.AllowAnyOrigin().AllowCredentials().AllowAnyMethod().AllowAnyHeader());
			// Using SignalR
            app.UseSignalR();
            app.UseMvc();
        }
    }
}

// ApiHubController.cs
namespace Enterprise.API.Controllers
{
	// This Abstract Class Inherits Controller Class that used by all APIControllers
    public abstract class ApiHubController<T>:Controller
        where T:Hub
    {
        private readonly IHubContext<T> _hub;
        public IHubConnectionContext<dynamic> Clients { get; private set; }
        public IGroupManager Groups { get; private set; }
        protected ApiHubController(IConnectionManager connectionManager)
        {
            var _hub = connectionManager.GetHubContext<T>();
            Clients = _hub.Clients;
            Groups = _hub.Groups;
        }
    }
}

// ChatController.cs
namespace Enterprise.API.Controllers.Chat
{
    [Route("api/[controller]")]
	// this Controller Inherits from ApiHubController(Custom Abstract Class)
    public class ChatController : ApiHubController<ChatHub>
    {
        private readonly IChatService _chatService;
        
        public ChatController(IChatService chatService, IConnectionManager connectionManager) : base(connectionManager)
        {
            _chatService = chatService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<TblChat> Get(string id)
        {
            return _chatService.GetChatByGroupId(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]object value)
        {
            
            _chatService.InsertChat(value);
            JObject jObject = (JObject)value;
            ChatModel chatModel = new ChatModel
            {
                groupId = jObject["groupId"].ToString(),
                userId = jObject["userId"].ToString(),
                message = jObject["message"].ToString(),
                messageDatetime = (DateTime)jObject["messageDatetime"],
            };
			// this will broadcast to all client, so every clients will get same messages
            Clients.All.Send(chatModel);
        }
    }
}
```
For More Details About SignalR Hub [Click Here](#enterprise-signalr)
This API is responsible for every transaction(expose to outside world), 
also has responsible for bypassing some request (that can't be done with .Net Core) to API Framework By Calling Service.

### Enterprise API Helpers
This Project Contains Consts items for strong typings sake (Avoid Magic Strings), 
``` C#
// WorkflowServiceClient.cs
namespace Enterprise.API.Helpers.Consts
{
	// Define Our Urls for strong Typings
    public class WorkflowServiceClient
    {
        public const string BaseUrl = "http://localhost:8888";
        public const string UserRegistration = "/api/userregistration";
        public const string RecommendedProduct = "/api/recommendedproduct";
        public const string HotProduct = "/api/hotproduct";
        public const string Category = "/api/category";
        public const string Decryption = "/api/decryption";
        public const string InsertProduct = "/api/insertproduct";
    }
}
```
ProxyAPI(Abstract Class for services would like to call inner API).
``` C#
// Bypasser.cs
namespace Enterprise.API.Helpers.ProxyAPI
{
	// Only for Services That has requirement to access Workflow Clients implements this class
    public abstract class Bypasser<T,T1> where T:class
    {
		// Post Actions (Send HttpClient to Workflow Client)
        public async virtual Task<T> PostAction(string url,T1 t1)
        {
            T type;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(WorkflowServiceClient.BaseUrl);
                string content = JsonConvert.SerializeObject(t1);
                var contentData = new StringContent(content, Encoding.UTF8, MediaTypes.Application_Json);
                HttpResponseMessage httpResponseMessage = httpClient.PostAsync(url, contentData).Result;
                type= JsonConvert.DeserializeObject<T>(await httpResponseMessage.Content.ReadAsStringAsync());
            }
            return type;
        }
		// Get Actions (Send HttpClient to Workflow Client)
        public virtual T GetAction(string url)
        {
            T type;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(WorkflowServiceClient.BaseUrl);
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(url).Result;
                type = JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            }
            return type;
        }
    }
}

```

### Enterprise API Models
This Project Store model Hubs(SignalR),
``` C#
// ChatModel.cs
namespace Enterprise.API.Models.Hubs
{
	// POCO Only
    public class ChatModel
    {
        public string userId { get; set; }
        public string message { get; set; }
        public DateTime messageDatetime { get; set; }
        public string groupId { get; set; }
    }
}
```
Responses(Comes from Workflow clients)
 ``` C#
 // RecommendedProductWorkflowResponse.cs
namespace Enterprise.API.Models.Responses
{
    public class RecommendedProductWorkflowResponse
    {
        public IEnumerable<ProductCardDTO> RecommendedProductCards { get; set; }
    }
}
 ```
Settings(MongoDB) POCOs
``` C#
// MongoDBSettings.cs
namespace Enterprise.API.Models.Settings
{
	// config settings used in Startup.cs
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
```
### Enterprise Workflows
Workflows Project has all things about WF, such as Activities Codes, Workflows designs.
``` C#
// RegisterUserActivity.cs
namespace Enterprise.Workflows.Activities.User
{
	//  This Is Code Activity, This will Calls BusinessLogic To Run.
    public sealed class RegisterUserActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<TblUserLogin> UserLogin { get; set; }
        public InArgument<IUserLoginBusinessLogic> UserLoginBusinessLogic { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            IUserLoginBusinessLogic userLoginBusinessLogic = UserLoginBusinessLogic.Get(context);
            TblUserLogin userLogin = UserLogin.Get(context);
            userLogin.UserLoginId = Guid.NewGuid().ToString();
            userLoginBusinessLogic.RegisterUser(userLogin);
            userLoginBusinessLogic.SaveUser();
        }
    }
}
```
Also this project has Workflows that implements some Code Activities,and another workflows.

### Enterprise Workflows Clients
Actually this project is API Project, creating this API main purpose is to invoke Workflows, 
and fill gaps that Features NET Core can't done.
``` C#
// UserRegistrationController.cs
namespace Enterprise.Workflows.Client.Controllers.User
{
    public class UserRegistrationController : ApiController
    {
		// This Project also has Dependencies Injection
        private readonly IUserRegistrationWorkflowInvoker _userWorkflowInvoker;
        public UserRegistrationController(IUserRegistrationWorkflowInvoker userWorkflowInvoker)
        {
            _userWorkflowInvoker = userWorkflowInvoker;
        }
        // POST api/<controller>
		// This will trigger when services calling HttpClient
        public UserRegistrationWorkflowResponse Post([FromBody]object value)
        {
            return  _userWorkflowInvoker.InvokeWorkflow(value);
        }
    }
}
```
This project has also Unit of Work Patterns, Repository patterns, So this project has to define all those project Abstraction.
I'm using Unity for Dependencies Injections.
``` C#
// UnityConfig.cs
namespace Enterprise.Workflows.Client
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

			// Here I Registered my Services that I want to Inject
            #region dbcontext
            container.RegisterType<IUserContext, UserContext>(new HierarchicalLifetimeManager(), new InjectionFactory(x => new UserContext(ConfigurationManager.ConnectionStrings["UserContext"].ConnectionString)));
            container.RegisterType<IProductContext, ProductContext>(new HierarchicalLifetimeManager(), new InjectionFactory(x => new ProductContext(ConfigurationManager.ConnectionStrings["ProductContext"].ConnectionString)));
            #endregion

            #region business logic
            container.RegisterType<IUserLoginBusinessLogic, UserLoginBusinessLogic>();
            container.RegisterType<IUserDetailsBusinessLogic, UserDetailsBusinessLogic>();
            #endregion

            #region invoker
            container.RegisterType<IUserRegistrationWorkflowInvoker, UserRegistrationWorkflowInvoker>();
            container.RegisterType<IHotProductWorkflowInvoker, HotProductWorkflowInvoker>();
            #endregion

            #region repository
            container.RegisterType<ITblUserLoginRepository, TblUserLoginRepository>();
            container.RegisterType<ITblUserDetailsRepository, TblUserDetailsRepository>();
            #endregion

            #region converter
            container.RegisterType<ICategoryConverter, CategoryConverter>();
            container.RegisterType<IHotProductConverter, HotProductConverter>();
            #endregion
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}

// Global.asax
namespace Enterprise.Workflows.Client
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			// Register The Config that i just Define in UnityConfig.cs
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            HttpConfiguration config = GlobalConfiguration.Configuration;
		
			// Config for avoid ReferenceLoop Error
            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}

```
Invoking this API is Service responsibility.
This API is only responsible for Invoking Workflow. and fill some feature gaps (that can't be done with .Net Core)

### Enterprise Workflows Invoker
this project is intended for invoking workflows.
``` C#
// IBaseWorkflowInvoker.cs
namespace Enterprise.Workflows.Invoker.Abstract
{
	// Contract For Every WorkflowInvoker
    public interface IBaseWorkflowInvoker<TResult> where TResult : class
    {
        TResult InvokeWorkflow();
    }
    public interface IBaseWorkflowInvoker<TResult, T1> where TResult : class
    {
        TResult InvokeWorkflow(T1 t1);
    }
    public interface IBaseWorkflowInvoker<TResult, T1, T2> where TResult : class
    {
        TResult InvokeWorkflow(T1 t1,T2 t2);
    }
    public interface IBaseWorkflowInvoker<TResult, T1, T2, T3> where TResult : class
    {
        TResult InvokeWorkflow(T1 t1,T2 t2,T3 t3);
    }
}
// IInvokers.cs
namespace Enterprise.Workflows.Invoker.Abstract
{
	// Implements All Invoker class with BaseInvoker Class
    public interface ICategoryWorkflowInvoker : IBaseWorkflowInvoker<CategoryWorkflowResponse, object> { }
    public interface IHotProductWorkflowInvoker : IBaseWorkflowInvoker<HotProductWorkflowResponse,string> { }
    public interface IInsertProductWorkflowInvoker : IBaseWorkflowInvoker<InsertProductWorkflowResponse, object> { }
    public interface IRecommendedProductWorkflowInvoker : IBaseWorkflowInvoker<RecommendedProductWorkflowResponse, string> { }
    public interface IUserRegistrationWorkflowInvoker : IBaseWorkflowInvoker<UserRegistrationWorkflowResponse, object> { }
}

namespace Enterprise.Workflows.Invoker.User
{
	// Implement IInvokers.cs Abstraction
    public class UserRegistrationWorkflowInvoker : IUserRegistrationWorkflowInvoker
    {
        private readonly IUserLoginBusinessLogic _userLoginBusinessLogic;
        private readonly IUserDetailsBusinessLogic _userDetailsBusinessLogic;
        private readonly IUserRegistrationConverter _userRegistrationConverter;
        public UserRegistrationWorkflowInvoker(UserLoginBusinessLogic userLoginBusinessLogic, IUserDetailsBusinessLogic userDetailsBusinessLogic, IUserRegistrationConverter userRegistrationConverter)
        {
            _userLoginBusinessLogic = userLoginBusinessLogic;
            _userDetailsBusinessLogic = userDetailsBusinessLogic;
            _userRegistrationConverter = userRegistrationConverter;
        }
		// This Method Is Responsible for invoking Activity (Workflows)
        public UserRegistrationWorkflowResponse InvokeWorkflow(object userLogin)
        {
            Activity activity = new UserRegistrationWorkflow()
            {
				// Define Its Arguments
                UserLoginBusinessLogic = new InArgument<IUserLoginBusinessLogic>((x) => _userLoginBusinessLogic),
                UserDetailsBusinessLogic = new InArgument<IUserDetailsBusinessLogic>((x) => _userDetailsBusinessLogic),
                UserLoginObject = new InArgument<object>((x) => userLogin)
            };
			// Simply Invoke Workflow (W/o Bookmarking, Make It Persistance)
            WorkflowInvoker workflowInvoker = new WorkflowInvoker(activity);
            IDictionary<string, object> result = workflowInvoker.Invoke();
            return _userRegistrationConverter.ConvertToResponse(result);
        }
    }
}
```

### Enterprise Workflows Helpers
has Consts for strong typings, Encryption Decrpytion Helper, Also Has Converters helpers(of course written with abstraction).
Go To [Here](Enterprise.Workflow.Helpers/Encryption/EncryptDecrypt.cs) To see Encryption Code

### Enterprise Workflows Models
has Responses model that workflows return.
 ``` C#
 // RecommendedProductWorkflowResponse.cs
namespace Enterprise.Workflows.Models.Responses
{
    public class RecommendedProductWorkflowResponse
    {
        public IEnumerable<ProductCardDTO> RecommendedProductCards { get; set; }
    }
}
 ```

### Enterprise SignalR 
this project has its own world, this project only responsible for SignalR related stuffs
this project only  store hubs, and its abstractions
``` C#
// this Abstractions is FrontEnd Defined Method (For Strong type Sake)
namespace Enterprise.SignalR.Abstract
{
    public interface IChatClient
    {
        Task SetConnectionId(string connectionId);
		// Go to SignalR FrontEnd You will find this method too..
        Task Send(ChatModel chatModel);
    }
}

// ChatHub.cs
namespace Enterprise.SignalR.Hubs
{
    public class ChatHub:Hub<IChatClient>
    {
        public override Task OnConnected()
        {
			// See SignalR FrontEnd Implementations To Know How This Methods Invoked
            return Clients.Client(Context.ConnectionId).SetConnectionId(Context.ConnectionId);
        }
        public Task Subscribe(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }
        public Task Unsubscribe(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }
    }
}
```
#### Notes
Below Project can be seem like duplications.
Well thats right, Since workflow can generate errors for adding .net standard reference.
So Enterprise.Framework (.NET Framework) projects is only intended for workflow data access.
Enterprise.Core (.NET Standard) projects is intended for transaction that doesn't require Workflow to run.

### Enterprise Core BusinessLogics
This layer role is for having some logic for select, insert, anything in DataLayers.
I do Provide All Classes with Abstractions
``` C#
// IProductBusinessLogic
namespace Enterprise.Core.BusinessLogics.Product.Abstract
{
    public interface IProductBusinessLogic
    {
        TblProduct CreateProductItem(object productObject);
        IEnumerable<TblProduct> GetAllListProduct();
        ProductDetailsDTO GetProductDetails(string productId);
        void AddReview(string productId);
    }
}

// ProductBusinessLogic
namespace Enterprise.Core.BusinessLogics.Product
{
    public class ProductBusinessLogic : IProductBusinessLogic
    {
        private readonly ITblProductRepository _productRepository;
        private readonly ICategoryBusinessLogic _categoryBusinessLogic;
        public ProductBusinessLogic(ITblProductRepository productRepository, ICategoryBusinessLogic categoryBusinessLogic)
        {
            _productRepository = productRepository;
            _categoryBusinessLogic = categoryBusinessLogic;
        }
		
        public IEnumerable<TblProduct> GetAllListProduct()
        {
            return _productRepository.GetAll();
        }
	}
}
```
### Enterprise Core DataLayers DTOs Models
this project only contains POCO model for inner select. 
Use Case
``` C#
public ProductDetailsDTO GetProductDetails(string productId)
        {
		// Select Specifics Data By Using Data Transfer Object
		// I'm Using DTO because its strong typings... of course we can do with anonymous Object => new {}
            return _context.TblProduct.Where(x => x.ProductId == productId).Select(x => new ProductDetailsDTO
            {
                ProductFavorite = x.ProductFavorite,
                ProductDescription = x.ProductDescription,
                ProductLocation=x.ProductLocation,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductRating = x.ProductRating,
                ProductReview = x.ProductReview,
                ProductStock = x.ProductStock,
				
				// this is DTOs.Models. Let me Select specific record
                ProductImages = x.TblProductImage.Select(y => new ProductImage
                {
                    PImageId = y.PImageId,
                    ProductImageName = y.ProductImageName,
                    ProductImageSize = y.ProductImageSize,
                    ProductImageUrl = y.ProductImageUrl
                }),
                ProductSpecs = x.TblProductSpecs.Select(y => new ProductSpec
                {
                    ProductSpecTitle = y.ProductSpecTitle,
                    ProductSpecValue = y.ProductSpecValue,
                    PSpecId = y.PSpecId
                }),
                ProductVariations = x.TblProductVariations.Select(y => new ProductVariationItem
                {
                    ProductVariation = y.ProductVariation,
                    PVariationId = y.PVariationId
                })
            }).FirstOrDefault();
        }
```

### Enterprise Core DataLayers DTOs
this project only storing DTO models. which that useful for selecting item that i only want small piece of colomn,
or avoid serialize obj error since my db schema all has relationship.

### Enterprise Core DataLayers
this project is EF project. also i have define mongodb entity in this project.
``` C#
// MongoContext.cs
using EH = Enterprise.API.Helpers;
namespace Enterprise.Core.DataLayers.EnterpriseDB_MongoModel
{
    public partial class MongoContext
    {
        private readonly MongoClient _client;
        private readonly MongoDatabase _database;
        private readonly MongoServer _server;
        public MongoContext(IOptions<MongoDBSettings> option)
        {
            _client = new MongoClient(option.Value.ConnectionString);
            if (_client != null)
            {
#pragma warning disable CS0618 // Type or member is obsolete
                _server = _client.GetServer();
#pragma warning restore CS0618 // Type or member is obsolete
                _database = _server.GetDatabase(option.Value.Database);
            }
        }
        public MongoCollection<TblProductComments> TblProductComments
        {
            get
            {
                return _database.GetCollection<TblProductComments>(EH.Consts.MongoCollections.Tbl_Product_Comments);
            }
        }

        public MongoCollection<TblChat> TblChat
        {
            get
            {
                return _database.GetCollection<TblChat>(EH.Consts.MongoCollections.Tbl_Chat);
            }
        }

        public EntityEntry Entry { get; set; }
    }
}

// TblChat.cs
namespace Enterprise.Core.DataLayers.EnterpriseDB_MongoModel
{
    public class TblChat
    {
        public ObjectId Id { get; set; }
        [BsonElement("User_Id")]
        public string UserId { get; set; }
        [BsonElement("Message")]
        public string Message { get; set; }
        [BsonElement("Message_Datetime")]
        public DateTime MessageDatetime { get; set; }
        [BsonElement("Group_Id")]
        public string GroupId { get; set; }
    }
}
```
Of course this Project also contains MSSQL Contexts

### Enterprise Core Repository
this project is the boiler plate for select, insert, delete, update data in DataLayers. this has abstraction for one entity. and also have abstraction for every tbl in that entity.

``` C#
// IEntityBaseRepository.cs 
namespace Enterprise.Core.Repository.Abstract
{
// This Interface Will be Inherited for every Repository Entity Class
// This Interface Provide Contract That Every Repository Entity Class need to define
    public interface IEntityBaseRepository<T> where T : class, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll();
        int Count();
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        int Commit();
    }
}

// IMongoEntityBaseRepository.cs
namespace Enterprise.Core.Repository.Abstract
{
// This is BaseRepository Abstraction for MongoDB
    public interface IMongoEntityBaseRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll(MongoCollection<T> col);
        long Count(MongoCollection<T> col);
        T GetSingle(MongoCollection<T> col, IMongoQuery query);
        IEnumerable<T> FindBy(MongoCollection<T> col, IMongoQuery query);
        void Add(MongoCollection<T> col, T entity);
        void Update(MongoCollection<T> col, IMongoQuery query, IMongoUpdate update);
        void Delete(MongoCollection<T> col, IMongoQuery query);
    }
}

// IRepositories.cs
namespace Enterprise.Core.Repository.Abstract
{
// Inherits from IEntityBaseRepository
    #region product
    public interface ITblProductRepository : IEntityBaseRepository<TblProduct>
    {
        ProductDetailsDTO GetProductDetails(string productId);
        IEnumerable<TblProduct> GetListProductByListString(List<string> listProductId);
        void AddReview(string productId);
    };
    public interface ITblProductHotRepository : IEntityBaseRepository<TblProductHot> { };
    public interface ITblCategoryRepository : IEntityBaseRepository<TblCategory> { };
    #endregion
	
// MongoDB Repository
    #region mongo
    public interface ITblProductCommentsRepository : IMongoEntityBaseRepository<TblProductComments> { };
    public interface ITblChatRepository : IMongoEntityBaseRepository<TblChat> { };
    #endregion
}
// MongoBaseRepository.cs
namespace Enterprise.Core.Repository.MongoRepository
{
// Implementation Of Contract MongoDB.
// Benefits is we only need to defines this common operations Once.
// Of course we can Override these Method If We Want...
    public class MongoBaseRepository<T> : IMongoEntityBaseRepository<T> where T : class, new()
    {
        protected readonly MongoContext _context;
        public MongoBaseRepository(IOptions<MongoDBSettings> options)
        {
            _context = new MongoContext(options);
        }

        public virtual void Add(MongoCollection<T> col, T entity)
        {
            col.Insert(entity);
        }

        public virtual long Count(MongoCollection<T> col)
        {
            return col.Count();
        }

        public virtual void Delete(MongoCollection<T> col, IMongoQuery query)
        {
            col.Remove(query);
        }

        public virtual IEnumerable<T> FindBy(MongoCollection<T> col, IMongoQuery query)
        {
            return col.Find(query).AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll(MongoCollection<T> col)
        {
            return col.FindAll().AsEnumerable();
        }

        public virtual T GetSingle(MongoCollection<T> col, IMongoQuery query)
        {
            return col.Find(query).FirstOrDefault();
        }

        public virtual void Update(MongoCollection<T> col, IMongoQuery query, IMongoUpdate update)
        {
            col.Update(query, update);
        }
    }
}

// ProductBaseRepository.cs
namespace Enterprise.Core.Repository.ProductRepository
{
// Implementation Contracts MSSQL (EF Core)
// Benefits is we only need to defines this common operations Once.
// Of course we can Override these Method If We Want...
    public class ProductBaseRepository<T> : BaseDispose,IEntityBaseRepository<T> where T : class, new()
    {
        protected readonly ProductContext _context;
        public ProductBaseRepository(ProductContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();
            foreach (var IncludeProperty in includeProperties)
            {
                queryable = queryable.Include(IncludeProperty);
            }
            return queryable.AsEnumerable();
        }

        public virtual int Commit()
        {
            return _context.SaveChanges();
        }

        public virtual int Count()
        {
            return _context.Set<T>().Count();
        }

        public virtual void Delete(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _context.Set<T>().Where(predicate);
            foreach (var entity in entities)
            {
                _context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public override void Dispose()
        {
            base.Dispose(_context);
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return queryable.FirstOrDefault(predicate);
        }

        public virtual void Update(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}

// Implements ProductBaseRepository
namespace Enterprise.Core.Repository.ProductRepository
{
    public class TblProductRepository : ProductBaseRepository<TblProduct>, ITblProductRepository
    {
        public TblProductRepository(ProductContext context) : base(context)
        {
        }
        public ProductDetailsDTO GetProductDetails(string productId)
        {
		// Select Specifics Data By Using Data Transfer Object
		// I'm Using DTO because its strong typings... of course we can do with anonymous Object => new {}
            return _context.TblProduct.Where(x => x.ProductId == productId).Select(x => new ProductDetailsDTO
            {
                ProductFavorite = x.ProductFavorite,
                ProductDescription = x.ProductDescription,
                ProductLocation=x.ProductLocation,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductRating = x.ProductRating,
                ProductReview = x.ProductReview,
                ProductStock = x.ProductStock,
                ProductImages = x.TblProductImage.Select(y => new ProductImage
                {
                    PImageId = y.PImageId,
                    ProductImageName = y.ProductImageName,
                    ProductImageSize = y.ProductImageSize,
                    ProductImageUrl = y.ProductImageUrl
                }),
                ProductSpecs = x.TblProductSpecs.Select(y => new ProductSpec
                {
                    ProductSpecTitle = y.ProductSpecTitle,
                    ProductSpecValue = y.ProductSpecValue,
                    PSpecId = y.PSpecId
                }),
                ProductVariations = x.TblProductVariations.Select(y => new ProductVariationItem
                {
                    ProductVariation = y.ProductVariation,
                    PVariationId = y.PVariationId
                })
            }).FirstOrDefault();
        }
        public IEnumerable<TblProduct> GetListProductByListString(List<string> listProductId)
        {
            var x = base._context.TblProduct.Where(z => listProductId.Contains(z.ProductId)).ToList();
            x.ForEach(z =>
            {
                z.TblProductHot = null;
                z.TblProductRecommended = null;
            });
            return x.AsEnumerable();
        }
        public void AddReview(string productId)
        {
            base._context.Database.ExecuteSqlCommand("EXEC dbo.sp_AddReview @productId={0}",
                productId);
        }
    }
}

// TblProductCommentsRepository.cs
namespace Enterprise.Core.Repository.MongoRepository
{
    // Quick Implementation of MongoBaseRepository.
    public class TblProductCommentsRepository:MongoBaseRepository<TblProductComments>,ITblProductCommentsRepository
    {
        public TblProductCommentsRepository(IOptions<MongoDBSettings> options) : base(options)
        {
        }
    }
}

```

### Enterprise Core Services
this Layer could possibly to call Workflow Client (Become Proxy for Framework API) By Implementing Bypasser Abstract Class or calling BusinessLogic
``` C#
// IProductService.cs
namespace Enterprise.Core.Services.Product.Abstract
{
    public interface IProductService
    {
        Task<InsertProductWorkflowResponse> AddNewProduct(object productObject);
        IEnumerable<TblProduct> GetAllListProduct();
        ProductDetailsDTO GetProductDetails(string productId);
        void AddReview(string productId);
    }
}
// ProductService.cs
namespace Enterprise.Core.Services.Product
{
// This Services Implement Abstract Class (Bypasser) that add Functionality for Bypass Request API
    public class ProductService : Bypasser<InsertProductWorkflowResponse, object>, IProductService
    {
        private readonly IProductBusinessLogic _productBusinessLogic;
        public ProductService(IProductBusinessLogic productBusinessLogic)
        {
            _productBusinessLogic = productBusinessLogic;
        }
        public async Task<InsertProductWorkflowResponse> AddNewProduct(object productObject)
        {
		// this PostAction Calls Workflow Client to Invoke Workflow
            return await PostAction(WorkflowServiceClient.InsertProduct, productObject);
        }

        public void AddReview(string productId)
        {
            _productBusinessLogic.AddReview(productId);
        }

        public IEnumerable<TblProduct> GetAllListProduct()
        {
            return _productBusinessLogic.GetAllListProduct();
        }

        public ProductDetailsDTO GetProductDetails(string productId)
        {
            return _productBusinessLogic.GetProductDetails(productId);
        }
    }
}
```
### Enterprise Framework DataLayers
this Project Pretty Similar with .NET Standard Version. Click [Here](#notes) For Details

### Enterprise Framework DataLayers DTOs
this Project Pretty Similar with .NET Standard Version. Click [Here](#notes) For Details

### Enterprise Framework Repository
this Project Pretty Similar with .NET Standard Version. Click [Here](#notes) For Details

### Enterprise Framework BusinessLogics
this Project Pretty Similar with .NET Standard Version. Click [Here](#notes) For Details

