using Hospitality.Models;
using Hospitality.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitality.Utilities
{

    public class DbInilializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public DbInilializer(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context=context;

        }
        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() >0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw;
            }


            if (!_roleManager.RoleExistsAsync(WebRoles.Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebRoles.Admin))
                    .GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebRoles.Patient))
                    .GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebRoles.Doctor))
                    .GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    Username = "Pramesh",
                    Email  = "Pramesh@gmail.com"

                },"Pramesh").GetAwaiter().GetResult() ;

            }
        }
    }
}
