using Microsoft.AspNetCore.Builder;
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

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),x=>x.MigrationsAssembly("Business")));
            services.AddMvc();
            services.AddAutoMapper();
            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<DatabaseContext>();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseAuthentication();
        }
    }
}
