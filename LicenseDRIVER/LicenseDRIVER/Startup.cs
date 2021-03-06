﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Business.Infrastructure;
using Business.Repository;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Services.Student;
using Services.Teacher;
using LicenseDRIVER.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Data.Entities;
using Services.Notification;

namespace LicenseDRIVER
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
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<INotificationService, NotificationService>();


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("Data")));
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddAutoMapper();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name :"404-PageNotFound",
                    template:"{*url}",
                    defaults: new { controller = "PageNotFound", action = "Index" }
    );
            });
            app.UseAuthentication();
        }
    }
}
