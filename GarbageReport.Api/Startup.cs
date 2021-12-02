using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using GarbageReport.Infraestructure.Data;
using GarbageReport.Infraestructure;
using GarbageReport.Domain.Entities;
using GarbageReport.Domain.interfaces;
using GarbageReport.Infraestructure.Repositories;
using GarbageReport.Application.Services;
using Microsoft.AspNetCore.Http;
using FluentValidation;
using GarbageReport.Domain.DTOS.Requests;
using GarbageReport.Infraestructure.Validators;


namespace GarbageReport.Api
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GarbageReport.Api", Version = "v1" });
            });


            services.AddDbContext<GarbageReportContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GarbageReport")));

            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped<IDenunciaService, ServicesDenuncia>();
            services.AddScoped<IPOISService, ServicePOI>();
            services.AddScoped<IEventoService, ServiceEvento>();
            

            services.AddTransient<IDenunciaRepository, DenunciaSqlRepository>();
            services.AddTransient<IEventoRepository, EventoSqlRepository>();
            services.AddTransient<IPOISRepository, POISSqlRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IValidator<DenunciaCreateRequest>, DenunciaCreateRequestValidatior>();
            services.AddScoped<IValidator<EventoCreateRequest>, EventoCreateRequestValidatior>();
            services.AddScoped<IValidator<POICreateRequest>, POICreateRequestValidator>();
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GarbageReport.Api v1"));
            }

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
