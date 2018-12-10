using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Cinema.Infrastrucure.Database;
using Cinema.Infrastrucure.Repositories;
using Cinema.Infrastrucure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Formatting = Newtonsoft.Json.Formatting;

namespace Cinema.Webapi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Formatting = Formatting.Indented;
            });
            services.AddCors();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddTransient<IDatabaseContext,DatabaseContext>();
            services.AddSingleton(AutoMapperConfiguration.Initialize());
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.Configure<DatabaseSettings>(options =>
            {
                options.ConnectionString= Configuration.GetSection("MongoDb:ConnectionString").Value; 
                options.Database = Configuration.GetSection("MongoDb:Database").Value;
            });

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x => 
                    x.AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowAnyOrigin()
                     .AllowCredentials());
                     
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
