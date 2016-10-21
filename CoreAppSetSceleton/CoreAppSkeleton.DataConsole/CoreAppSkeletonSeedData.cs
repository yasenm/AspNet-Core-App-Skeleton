using CoreAppSkeleton.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

namespace CoreAppSkeleton.DataConsole
{
    public class CoreAppSkeletonSeedData
    {
        private CoreAppSkeletonDbContext _context;
        private UserManager<User> _userManager;

        public CoreAppSkeletonSeedData(CoreAppSkeletonDbContext context, UserManager<User> userManager)
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

        private void SeedCoreAppModels()
        {
            if (!this._context.CoreAppModels.Any())
            {

            }
        }
    }
}
