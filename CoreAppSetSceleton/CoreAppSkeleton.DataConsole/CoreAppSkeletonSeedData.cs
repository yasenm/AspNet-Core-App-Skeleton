using CoreAppSkeleton.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using CoreAppSkeleton.Common.RandomGenerators;
using System;

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
            await SeedUsers();
            await SeedGeneratedBlogItemsModels();
        }

        private async Task SeedUsers()
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

        private async Task SeedGeneratedBlogItemsModels()
        {
            if (!_context.BlogItems.Any())
            {
                if (_context.Users.Any())
                {
                    var user = _context.Users.FirstOrDefault();

                    for (int i = 0; i < NumberGenerator.RandomNumber(6, 12); i++)
                    {
                        var newBlogItem = new BlogItem
                        {
                            AuthorId = user.Id,
                            CreatedOn = DateTime.Now.AddDays(NumberGenerator.RandomNumber(1, 10)),
                            Summary = StringGenerator.RandomStringWithSpaces(40, 200),
                            Title = StringGenerator.RandomStringWithSpaces(10, 60),
                            Description = StringGenerator.RandomStringWithSpaces(200, 2000),
                        };

                        _context.BlogItems.Add(newBlogItem);
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
