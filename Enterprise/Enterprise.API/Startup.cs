using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Enterprise.Core.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.Core.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.Core.DataLayers.EnterpriseDB_UserModel;
using Enterprise.API.Models.Settings;
using Enterprise.Core.Repository.Abstract;
using Enterprise.Core.Repository.ProductRepository;
using Enterprise.Core.Repository.HelperRepository;
using Enterprise.Core.Repository.MongoRepository;
using Enterprise.Core.Services.Product.Abstract;
using Enterprise.Core.Services.Product;
using Enterprise.Core.Services.Mongo.Abstract;
using Enterprise.Core.Services.Mongo;
using Enterprise.Core.Services.City.Abstract;
using Enterprise.Core.Services.City;
using Enterprise.Core.Services.Periode.Abstract;
using Enterprise.Core.Services.Periode;
using Enterprise.Core.Services.ProductDetails.Abstract;
using Enterprise.Core.Services.ProductDetails;
using Enterprise.Core.DataLayers.EnterpriseDB_TransactionModel;
using Enterprise.Core.Services.User.Abstract;
using Enterprise.Core.Services.User;
using Enterprise.Core.Repository.UserRepository;
using Enterprise.Core.BusinessLogics.User.Abstract;
using Enterprise.Core.BusinessLogics.User;
using Enterprise.Core.BusinessLogics.City.Abstract;
using Enterprise.Core.BusinessLogics.City;
using Enterprise.Core.BusinessLogics.Mongo.Abstract;
using Enterprise.Core.BusinessLogics.Mongo;
using Enterprise.Core.BusinessLogics.Periode.Abstract;
using Enterprise.Core.BusinessLogics.Periode;
using Enterprise.Core.BusinessLogics.Product.Abstract;
using Enterprise.Core.BusinessLogics.Product;
using Enterprise.Core.BusinessLogics.ProductDetails.Abstract;
using Enterprise.Core.BusinessLogics.ProductDetails;
using Enterprise.Core.Services.Encryption;
using Enterprise.Core.Services.Decryption.Abstract;

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
