using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Cinema.Infrastrucure.Database;
using Cinema.Infrastrucure.Repositories;
using Cinema.Infrastrucure.Services;
using Cinema.Infrastrucure.Settings;
using Cinema.Model.ObjectIdConverter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
            services.AddAuthorization();
            services.AddMemoryCache();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddSingleton<IJwtHandler,JwtHandler>();
            services.AddSingleton(AutoMapperConfiguration.Initialize());
            services.Configure<JWTSettings>(Configuration.GetSection("jwt"));
            services.AddMvc().AddJsonOptions(opt => 
            {
                opt.SerializerSettings.Converters.Add(new ObjectIdConverter());
            });
            //services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.Configure<DatabaseSettings>(options =>
            {
                options.ConnectionString= Configuration.GetSection("MongoDb:ConnectionString").Value; 
                options.Database = Configuration.GetSection("MongoDb:Database").Value;
            });
            
              services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidIssuer = Configuration.GetSection("jwt:issuer").Value,
                            ValidateAudience = false,
                            IssuerSigningKey = JWTSecurityKey.Create(Configuration.GetSection("jwt:key").Value)
                        };
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
                     
            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
