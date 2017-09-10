﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Enterprise.DataLayers.EnterpriseDB_HelperModel;
using Enterprise.DataLayers.EnterpriseDB_ProductModel;
using Enterprise.DataLayers.EnterpriseDB_UserModel;
using Enterprise.DataLayers.EnterpriseDB_MongoModel;
using Enterprise.API.Models.Settings;
using Enterprise.SignalR.Hubs;
using Newtonsoft.Json.Serialization;
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
            services.AddMvc().
                AddJsonOptions(options =>
                options.SerializerSettings.ContractResolver =
                new DefaultContractResolver());

            services.AddSignalR(options => options.Hubs.EnableDetailedErrors = true);

            #region session&caching
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
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
            app.UseSignalR();
        }
    }
}
