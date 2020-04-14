using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManger, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManger);
        }

        public static void SeedUsers(UserManager<IdentityUser> userManger)
        {
            if(userManger.FindByNameAsync("admin@localhost.co.za").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@localhost.co.za",
                    Email = "admin@localhost.co.za",
                    EmailConfirmed = true
                };
                var result = userManger.CreateAsync(user, "P@ssword1").Result;
                if(result.Succeeded)
                {
                    userManger.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        public static void SeedRoles( RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }

    }
}
