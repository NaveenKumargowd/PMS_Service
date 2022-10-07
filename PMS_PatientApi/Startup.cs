using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PMS_UserAPI.Configurations;
using PMS_UserAPI.Data;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_PatientApi
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
            services.AddCors(c =>
            {
                c.AddPolicy("CORS Policy", builder =>
                         builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                        );
            });
            
            services.AddControllers();
            services.AddDbContext<DatabaseContext>(item => item.UseSqlServer
          (Configuration.GetConnectionString("PMSDBConnection")));
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientAllergyRepository, PatientAllergyRepository>();
            services.AddScoped<IEmergencyContactInfoRepository, EmergencyContactInfoRepository>();
            services.AddAutoMapper(typeof(MapperInitializer));
            //services.RegisterInfrastructureServices(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("CORS Policy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
