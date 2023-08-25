using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Unit34.WebAPI.Configuration;
using Unit34.WebAPI.Controllers;

namespace Unit34.WebAPI
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        /// <summary>
        /// �������� ������������ �� ����� Json
        /// </summary>
        public IConfiguration Configuration
        { get; } = new ConfigurationBuilder()
            //.AddJsonFile("appsettings.json")
            .AddJsonFile("HomeOptions.json")
            .Build();
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<HomeOptions>(Configuration);
            // Set param by 1
            //services.Configure<HomeOptions>(opt => opt.Area = 127);
            //services.Configure<HomeOptions>(opt =>
            //{
            //    opt.Area = 120;
            //});
            // ��������� ������ ����� (��������� Json-������) 
            //services.Configure<Address>(Configuration.GetSection("Address"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Unit34.WebAPI", Version = "v1" });
            });

            // ���������� �����������
            var assembly = Assembly.GetAssembly(typeof(MappingProfile));
            services.AddAutoMapper(assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Unit34.WebAPI v1"));
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
