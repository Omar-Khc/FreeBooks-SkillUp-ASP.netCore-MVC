using Domin.Entity;
using Infrastructuree.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domin.Entity.Helper;

namespace Infrastructuree.Seeds
{
    public static class DefaultUser
    {
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaltUser = new ApplicationUser
            {
                UserName = "superadmin@domin.com",
                Email = "superadmin@domin.com",
                Name = "SuperAdmin",
                ImageUser = "480bffc3-6061-470a-8e55-9ed672da1ece.jpg",
                ActiveUser = true,
                EmailConfirmed = true
            };

            var user = userManager.FindByEmailAsync(DefaltUser.Email);
            if (user.Result == null)
            {
                await userManager.CreateAsync(DefaltUser, "admin1234");
                await userManager.AddToRolesAsync(DefaltUser, new List<string> { Roles.SuperAdmin.ToString() });
            }
        }


        public static async Task SeedBasicAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaltUser = new ApplicationUser
            {
                UserName = "Basic@domin.com",
                Email = "Basic@domin.com",
                Name = "Basic",
                ImageUser = "480bffc3-6061-470a-8e55-9ed672da1ece.jpg",
                ActiveUser = true,
                EmailConfirmed = true
            };

            var user = userManager.FindByEmailAsync(DefaltUser.Email);
            if (user.Result == null)
            {
                await userManager.CreateAsync(DefaltUser, "basic1234");
                await userManager.AddToRolesAsync(DefaltUser, new List<string> { Roles.Basic.ToString() });
            }
        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaltUser = new ApplicationUser
            {
                UserName = "Admin@domin.com",
                Email = "Admin@domin.com",
                Name = "Admin",
                ImageUser = "480bffc3-6061-470a-8e55-9ed672da1ece.jpg",
                ActiveUser = true,
                EmailConfirmed = true
            };

            var user = userManager.FindByEmailAsync(DefaltUser.Email);
            if (user.Result == null)
            {
                await userManager.CreateAsync(DefaltUser, "admin1234");
                await userManager.AddToRolesAsync(DefaltUser, new List<string> { Roles.Admin.ToString() });
            }
        }
    }
}
