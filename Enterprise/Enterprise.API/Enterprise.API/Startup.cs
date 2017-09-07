using System;
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
            services.AddMvc();

            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = "localhost";
                option.InstanceName = "EnterpriseCache";
            });

            services.AddSession();

            services.AddDbContext<ProductContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EnterpriseDB_Product")));

            services.AddDbContext<UserContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EnterpriseDB_User")));

            services.AddDbContext<HelperContext>(option => option.UseSqlServer(Configuration.GetConnectionString("EnterpriseDB_Helper")));

            services.Configure<MongoDBSettings>(option =>
            {
                option.ConnectionString = Configuration.GetSection("MongoConnectionStrings:EnterpriseDB_Mongo:ConnectionString").Value;
                option.Database = Configuration.GetSection("MongoConnectionStrings:EnterpriseDB_Mongo:Database").Value;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            app.UseCors(builder =>
            builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
        }
    }
}
