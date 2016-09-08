using CoreAppSkeleton.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoreAppSkeleton.DataConsole
{
    public class CoreAppSkeletonSeedData
    {
        private ICoreAppSkeletonDbContext _context;
        private UserManager<User> _userManager;

        public CoreAppSkeletonSeedData(ICoreAppSkeletonDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedData()
        {
            if (await _userManager.FindByEmailAsync("admin@core.com") == null)
            {
                var user = new User
                {
                    UserName = "admincore",
                    Email = "admin@core.com",

                };

                await _userManager.CreateAsync(user, "P@ssw0rd");
            }
        }
    }
}
