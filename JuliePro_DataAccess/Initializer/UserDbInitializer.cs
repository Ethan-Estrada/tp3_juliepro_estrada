using JuliePro_DataAccess;
using JuliePro_Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Initializer
{
    public class UserDbInitializer : IUserDbInitializer
    {
        private readonly JulieProDbContext _db;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserDbInitializer(JulieProDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            var roleStore = new RoleStore<IdentityRole>(_db);

            if (_db.Roles.Any(r => r.Name == AppConstants.SuperAdminRole)) return;

            _roleManager.CreateAsync(new IdentityRole(AppConstants.SuperAdminRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(AppConstants.SuperAdminRole)).GetAwaiter().GetResult();
            IdentityResult identityResult = _roleManager.CreateAsync(new IdentityRole(AppConstants.TrainerRole)).GetAwaiter().GetResult();


            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "Julie@JuliePro.ca",
                Email = "Julie@JuliePro.ca",
                EmailConfirmed = true,
                PhoneNumber = "111111111111"
            }, "Training1234*").GetAwaiter().GetResult();

            IdentityUser user1 = _db.Users.FirstOrDefault(u => u.Email == "Julie@JuliePro.ca");
            _userManager.AddToRoleAsync(user1, AppConstants.SuperAdminRole).GetAwaiter().GetResult();

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "Felix@JuliePro.ca",
                Email = "Felix@JuliePro.ca",
                EmailConfirmed = true,
                PhoneNumber = "111111111111"
            }, "Training1234*").GetAwaiter().GetResult();

            IdentityUser user2 = _db.Users.FirstOrDefault(u => u.Email == "Felix@JuliePro.ca");
            _userManager.AddToRoleAsync(user2, AppConstants.TrainerRole).GetAwaiter().GetResult();

            _userManager.CreateAsync(new IdentityUser
            {
                UserName = "Karine@JuliePro.ca",
                Email = "Karine@JuliePro.ca",
                EmailConfirmed = true,
                PhoneNumber = "111111111111"
            }, "Training1234*").GetAwaiter().GetResult();

            IdentityUser user3 = _db.Users.FirstOrDefault(u => u.Email == "Karine@JuliePro.ca");
            _userManager.AddToRoleAsync(user3, AppConstants.TrainerRole).GetAwaiter().GetResult();

        }

        public Task SeedAsync()
        {
            throw new NotImplementedException();
        }
    }
}
