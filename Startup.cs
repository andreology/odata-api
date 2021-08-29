using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Extensions;
using odata_poc.EntityDataModels;
using odata_poc.DbContexts;

namespace odata_poc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration {get;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<FnmaSystemDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));
            
            services.AddSingleton<FnmaSystemEntityDataModel>();
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                             FnmaSystemEntityDataModel fnmaSystemEntityDataModel)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseODataBatching();

            app.UseRouting();
            
            app.UseAuthorization();

            var oDataBatchHandler = new DefaultODataBatchHandler();
            oDataBatchHandler.MessageQuotas.MaxNestingDepth = 3;
            oDataBatchHandler.MessageQuotas.MaxNestingDepth  = 10;

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapODataRoute( "FnmaSystem OData",
                                         "odata",
                                         fnmaSystemEntityDataModel.GetEntityDataModel(),
                                         oDataBatchHandler).Select()
                                                           .Expand()
                                                           .OrderBy()
                                                           .MaxTop(10)
                                                           .Count()
                                                           .Filter();
            });
        }
    }
}
