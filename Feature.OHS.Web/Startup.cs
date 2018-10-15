using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feature.OHS.Web.Domain;
using Feature.OHS.Web.Integration;
using Feature.OHS.Web.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Feature.OHS.Web.Models;
using Feature.OHS.WebInterfaces;

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

            services.AddScoped<IPatientHandler, PatientHandler>();
            services.AddScoped<IStaffHandler, StaffHandler>();
            services.AddScoped<IApiAccessor, ApiAccessor>();
            services.AddScoped<INurseHandler, NurseHandler>();
            services.AddTransient<IDocterHandler, DoctorHandler>();
            services.AddTransient<IFriendHandler, FriendHandler>();
            services.AddTransient<IPersonHandler, PersonHandler>();
            services.AddTransient<INextOfKinHandler, NextOfKinHandler>();
            services.AddTransient<IStaffHandler, StaffHandler>();
            services.AddTransient<IQualificationHandler, QualificationHandler>();
            services.AddTransient<INurseHandler, NurseHandler>();
            services.AddTransient<IContactHandler, ContactHandler>();
            services.AddTransient<IAddressHandler, AddressHandler>();
       
            //services.AddScoped<IP>
            //services.AddDbContext<FeatureOHSWebContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("FeatureOHSWebContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
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
                    template: "{controller=Patient}/{action=Index}/{id?}");
            });
        }
    }
}
