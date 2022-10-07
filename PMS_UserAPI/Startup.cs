using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PMS_UserAPI.Configurations;
using PMS_UserAPI.Data;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;
using PMS_UserAPI.Repository;
using PMS_UserAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI
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
            var dbHost = "CM1VA785\\SQLEXPRESS";
            var dbName = "pmsdb";
<<<<<<< HEAD
            var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<DatabaseContext>(opt=>opt.UseSqlServer(connectionString));
            
            services.AddAutoMapper(typeof(MapperInitializer));
            
            services.AddControllers();
=======
            var dbPassword = "password_123";
            var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; User ID=sa; Password={dbPassword}";
            services.ConfigureIdentity();//calling from ServiceExtensions Class
            services.ConfigureJWT(Configuration);
            services.Configure<SMTPConfigModel>(Configuration.GetSection("SMTPConfig"));

            services.AddDbContext<DatabaseContext>(opt=>opt.UseSqlServer(connectionString));
            
            services.AddAuthentication();
            
            services.AddAutoMapper(typeof(MapperInitializer));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.DependencyInjection();

            services.AddTransient<IEmailService, EmailService>();

            services.AddScoped<IAuthManager, AuthManager>();

            services.AddCors(c=> 
            {
                c.AddPolicy("CORS Policy", builder =>
                         builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                        );
            });

            services.AddControllers().AddNewtonsoftJson(o =>
                o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PMS_UserAPI", Version = "v1" });
            });
>>>>>>> e065359df20082182afc477e9ae2cedbf6cf7ad5
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PMS_UserAPI v1"));

            app.UseHttpsRedirection();
            app.UseCors("CORS Policy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
