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
            //_context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                await SeedUsers();
                await SeedGeneratedPostsModels();
            }
        }

        private async Task SeedUsers()
        {
            if (!_userManager.Users.Any())
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

                for (int i = 0; i < NumberGenerator.RandomNumber(6, 12); i++)
                {
                    var user = new User
                    {
                        UserName = StringGenerator.RandomStringWithSpaces(4, 20),
                        Email = StringGenerator.RandomStringWithoutSpaces(2, 7) + "@core.com",
                        ShortBio = StringGenerator.RandomStringWithSpaces(30, 200),
                        Bio = StringGenerator.RandomStringWithSpaces(100, 2000)
                    };

                    await _userManager.CreateAsync(user, "P@ssw0rd");
                }
            }
        }

        private async Task SeedGeneratedPostsModels()
        {
            if (!_context.BlogPosts.Any())
            {
                if (_context.Users.Any())
                {
                    var users = _context.Users.ToList();

                    for (int i = 0; i < NumberGenerator.RandomNumber(20, 40); i++)
                    {
                        var newPostItem = new BlogPost
                        {
                            AuthorId = users[NumberGenerator.RandomNumber(0, users.Count - 1)].Id,
                            CreatedOn = DateTime.Now.AddDays(NumberGenerator.RandomNumber(1, 10)),
                            Summary = StringGenerator.RandomStringWithSpaces(40, 200),
                            Title = StringGenerator.RandomStringWithSpaces(10, 60),
                            Description = StringGenerator.RandomStringWithSpaces(200, 2000),
                        };

                        _context.BlogPosts.Add(newPostItem);
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
