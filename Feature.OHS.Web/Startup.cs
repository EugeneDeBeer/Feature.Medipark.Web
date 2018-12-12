﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Authentication;
using Feature.OHS.Web.Domain;
using Feature.OHS.Web.Integration;
using Feature.OHS.Web.Interfaces;
using Feature.OHS.Web.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Feature.OHS.Web
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
            services.AddMvc();

            services.Configure<IntegrationSettings>(Configuration.GetSection("GlobalSettings"));

            services.AddTransient<IPatientHandler, PatientHandler>();
            services.AddTransient<IDoctorHandler, DoctorHandler>();
            services.AddTransient<IServiceAuthentication, ServiceAuthentication>();
            services.AddTransient<IAPIIntegration, APIIntegration>();
            services.AddTransient<INurseHandler, NurseHandler>();

            services.AddTransient<IAppointmentHandler, AppointmentHandler>();
 
            services.AddTransient<IAccountHandler, AccountHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
              //  app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}");

            });
        }
    }
}
