using Infrastructuree.Data;
using Infrastructuree.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace WebBooks_SkillUp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BookDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<BookDbContext>();

            builder.Services.AddSession();

            builder.Services.Configure<IdentityOptions>(
                option =>
                {
                    option.Password.RequiredUniqueChars = 0;
                    option.Password.RequireUppercase = false;
                    option.Password.RequireLowercase = false;
                    option.Password.RequiredLength = 8;
                    option.Password.RequireDigit = false;
                    option.Password.RequireNonAlphanumeric = false;
                });

            builder.Services.ConfigureApplicationCookie(
                options =>
                {
                    options.LoginPath = "/Admin/Accounts/Login"; // „”«— ’›Õ…  ”ÃÌ· «·œŒÊ·
                    options.AccessDeniedPath = "/Admin/Accounts/AccessDenied"; // „”«— ’›Õ… —›÷ «·Ê’Ê·
                });



            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Accounts}/{action=Login}/{id?}"
                );
            app.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}
