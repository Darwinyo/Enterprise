using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.DataLayers.EnterpriseDB_UserModel;
using Enterprise.API.Models.Settings;
using Enterprise.Repository.Abstract;
using Enterprise.Repository.ProductRepository;
using Enterprise.Repository.HelperRepository;
using Enterprise.Repository.MongoRepository;
using Enterprise.Services.Product.Abstract;
using Enterprise.Services.Product;
using Enterprise.Services.Mongo.Abstract;
using Enterprise.Services.Mongo;
using Enterprise.Services.City.Abstract;
using Enterprise.Services.City;
using Enterprise.Services.Periode.Abstract;
using Enterprise.Services.Periode;
using Enterprise.Services.ProductDetails.Abstract;
using Enterprise.Services.ProductDetails;
using Enterprise.DataLayers.EnterpriseDB_TransactionModel;
using Enterprise.Services.User.Abstract;
using Enterprise.Services.User;
using Enterprise.Repository.UserRepository;
using Enterprise.API.BusinessLogics.User.Abstract;
using Enterprise.API.BusinessLogics.User;
using Enterprise.API.BusinessLogics.City.Abstract;
using Enterprise.API.BusinessLogics.City;
using Enterprise.API.BusinessLogics.Mongo.Abstract;
using Enterprise.API.BusinessLogics.Mongo;
using Enterprise.API.BusinessLogics.Periode.Abstract;
using Enterprise.API.BusinessLogics.Periode;
using Enterprise.API.BusinessLogics.Product.Abstract;
using Enterprise.API.BusinessLogics.Product;
using Enterprise.API.BusinessLogics.ProductDetails.Abstract;
using Enterprise.API.BusinessLogics.ProductDetails;
using Enterprise.Services.Encryption;
using Enterprise.Services.Decryption.Abstract;

namespace Enterprise.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc()
                .AddJsonOptions(
                option => 
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            //AddJsonOptions(options =>
            //options.SerializerSettings.ContractResolver =
            //new DefaultContractResolver());

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

            services.AddDbContext<TransactionContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EnterpriseDB_Transaction")));

            services.AddDbContext<HelperContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EnterpriseDB_Helper")));

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
            services.AddScoped<ITblCityRepository, TblCityRepository>();
            services.AddScoped<ITblPeriodeRepository, TblPeriodeRepository>();
            services.AddScoped<ITblProductHotRepository, TblProductHotRepository>();
            services.AddScoped<ITblProductImageRepository, TblProductImageRepository>();
            services.AddScoped<ITblProductRecommendedRepository, TblProductRecommendedRepository>();
            services.AddScoped<ITblProductSpecsRepository, TblProductSpecsRepository>();
            services.AddScoped<ITblProductVariationsRepository, TblProductVariationsRepository>();
            services.AddScoped<ITblChatRepository, TblChatRepository>();
            services.AddScoped<ITblUserLoginRepository, TblUserLoginRepository>();
            #endregion

            #region services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCommentService, ProductCommentService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductSpecsService, ProductSpecsService>();
            services.AddScoped<IProductVariationService, ProductVariationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IHotProductService, HotProductService>();
            services.AddScoped<IRecommendedProductService, RecommendedProductService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IPeriodeService, PeriodeService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDecryptionService, DecryptionService>();
            #endregion

            #region business logic
            services.AddScoped<ICityBusinessLogic, CityBusinessLogic>();
            services.AddScoped<IChatBusinessLogic, ChatBusinessLogic>();
            services.AddScoped<IProductCommentsBusinessLogic, ProductCommentsBusinessLogic>();
            services.AddScoped<IPeriodeBusinessLogic, PeriodeBusinessLogic>();
            services.AddScoped<ICategoryBusinessLogic, CategoryBusinessLogic>();
            services.AddScoped<IHotProductBusinessLogic, HotProductBusinessLogic>();
            services.AddScoped<IProductBusinessLogic, ProductBusinessLogic>();
            services.AddScoped<IRecommendedProductBusinessLogic, RecommendedProductBusinessLogic>();
            services.AddScoped<IProductImageBusinessLogic, ProductImageBusinessLogic>();
            services.AddScoped<IProductSpecsBusinessLogic, ProductSpecsBusinessLogic>();
            services.AddScoped<IProductVariationBusinessLogic, ProductVariationBusinessLogic>();
            services.AddScoped<IUserLoginBusinessLogic, UserLoginBusinessLogic>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            app.UseWebSockets();
            app.UseCors(builder =>
            builder.AllowAnyOrigin().AllowCredentials().AllowAnyMethod().AllowAnyHeader());
            app.UseSignalR();
            app.UseMvc();
        }
    }
}
