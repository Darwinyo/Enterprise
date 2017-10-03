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

            services.AddSignalR(options => options.Hubs.EnableDetailedErrors = true);

            #region session & caching
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
This API is responsible for every transaction(expose to outside world), also has responsible for bypassing some request (that can't be done with .Net Core) to API Framework.

### Enterprise API Helpers
This Project Contains Consts items for strong typings sake (Avoid Magic Strings), ProxyAPI(Abstract Class for services would like to call inner API).

### Enterprise API Models
is for storing Hubs(SignalR), Responses(Comes from Workflow clients),Settings(MongoDB) POCOs

#### Notes
Since workflow can generate errors for adding .net standard reference. so this project is only intended for workflow data access. 

### Enterprise Framework DataLayers

### Enterprise Framework DataLayers DTOs

### Enterprise Framework Repository

### Enterprise Framework BusinessLogics

### Enterprise Workflows
Workflows Project has all things about WF, such as Activities Codes, Workflows designs./GOTO THIS DOC/
this project has contains Activities(that written in Activity Code)
that calling BusinessLogic to run. Also this project has Workflows that implements some Code Activities,and another workflows.

### Enterprise Workflows Clients
Actually this project is API Project, creating this API main purpose is to invoke Workflows, and fill gaps that Features NET Core can't done. Invoking this API is Service responsibility. This project has also Unit of Work Patterns, Repository patterns, So this project has to define all those project Abstraction. I'm using Unity for Dependencies Injections.
This API is only responsible for Invoking Workflow. and fill some feature gaps (that can't be done with .Net Core) /GOTO THIS DOC/

### Enterprise Workflows Invoker
this project is intended for invoking workflows.

### Enterprise Workflows Helpers
has Consts for strong typings, Encryption Decrpytion Helper, Also Has Converters helpers(of course written with abstraction).

### Enterprise Workflows Models
has Responses model that workflows return.

### Enterprise SignalR 
this project has its own world, this project only responsible for SignalR related stuffs /GOTO THIS DOC/
this project only  store hubs, and its abstractions

#### Notes
these projects using .Net Standard 2.0 , also implements Unit of works Patterns, Repositories Patterns.

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
this project is model for inner select.

### Enterprise Core DataLayers DTOs
this project only storing DTO models. which that useful for selecting item that i only want small piece of colomn,or avoid serialize obj error since my db schema all has relationship.

### Enterprise Core DataLayers
this project is EF project. also i have define mongodb entity in this project.

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
