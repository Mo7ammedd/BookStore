
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using BookStore.DataAcess.Data;
using BookStore.Models;
using BookStore.Utility;

namespace BookStore.DataAccess.DbInitializer {
    public class DbInitializer : IDbInitializer {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db) {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }


        public void Initialize() {


            //migrations if they are not applied
            try {
                if (_db.Database.GetPendingMigrations().Count() > 0) {
                    _db.Database.Migrate();
                }
            }
            catch(Exception ex) { }



            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult()) {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();


                //if roles are not created, then we will create admin user as well
                _userManager.CreateAsync(new ApplicationUser {
                    UserName = "medo.mostafa22255@icloud.com",
                    Email = "medo.mostafa22255@icloud.com",
                    Name = "Mohammed Mostafa",
                    PhoneNumber = "01112961724",
                    StreetAddress = "ismailia",
                    State = "IL",
                    PostalCode = "23422",
                    City = "Egypt"
                }, "Admin123*").GetAwaiter().GetResult();


                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "medo.mostafa22255@icloud.com");
                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            }

            return;
        }
    }
}