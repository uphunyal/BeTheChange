using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using BeTheChangeFinal.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using BeTheChangeFinal.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using BeTheChangeFinal.Services;

namespace BeTheChangeFinal
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<BeTheChangeContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DataConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
          //Create User and Role if it doesnot exist
          private async Task CreateUserRoles(IServiceProvider serviceProvider)
          {
              var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
              var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();


              //Adding Admin Role
              var roleCheck = await RoleManager.RoleExistsAsync("Admin");
              if (!roleCheck)
              {
                  //create the roles and seed them to the database
                  await RoleManager.CreateAsync(new IdentityRole("Admin"));
              }
              var poweruser = new IdentityUser
              {
                  UserName = "admin",
                  Email = "admin@admin.com",
                  EmailConfirmed = true,
                         

              };

              var user = await UserManager.FindByEmailAsync("admin@admin.com");
              if (user == null)
              {
                  var createpoweruser = await UserManager.CreateAsync(poweruser, "Superuser1!");
                  if (createpoweruser.Succeeded)
                  {
                      await UserManager.AddToRoleAsync(poweruser, "Admin");
                  }

              }
          }
  
       

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            CreateUserRoles(serviceProvider).Wait();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
