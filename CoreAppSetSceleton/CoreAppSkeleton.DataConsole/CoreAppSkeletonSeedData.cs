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
            await SeedGeneratedBlogModels();
            await SeedGeneratedPostsModels();
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

        private async Task SeedGeneratedBlogModels()
        {
            if (!_context.Blogs.Any())
            {
                if (_context.Users.Any())
                {
                    var users = _context.Users.ToList();

                    for (int i = 0; i < NumberGenerator.RandomNumber(6, 12); i++)
                    {
                        var newBlogItem = new Blog
                        {
                            AuthorId = users[NumberGenerator.RandomNumber(0, users.Count - 1)].Id,
                            CreatedOn = DateTime.Now.AddDays(NumberGenerator.RandomNumber(1, 10)),
                            Summary = StringGenerator.RandomStringWithSpaces(40, 200),
                            Title = StringGenerator.RandomStringWithSpaces(10, 60),
                            Description = StringGenerator.RandomStringWithSpaces(200, 2000),
                        };

                        _context.Blogs.Add(newBlogItem);
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task SeedGeneratedPostsModels()
        {
            if (!_context.Posts.Any())
            {
                if (_context.Users.Any() && _context.Blogs.Any())
                {
                    var users = _context.Users.ToList();
                    var blogs = _context.Blogs.ToList();

                    for (int i = 0; i < NumberGenerator.RandomNumber(6, 12); i++)
                    {
                        var newPostItem = new Post
                        {
                            BlogId = blogs[NumberGenerator.RandomNumber(0, blogs.Count - 1)].Id,
                            AuthorId = users[NumberGenerator.RandomNumber(0, users.Count - 1)].Id,
                            CreatedOn = DateTime.Now.AddDays(NumberGenerator.RandomNumber(1, 10)),
                            Summary = StringGenerator.RandomStringWithSpaces(40, 200),
                            Title = StringGenerator.RandomStringWithSpaces(10, 60),
                            Description = StringGenerator.RandomStringWithSpaces(200, 2000),
                        };

                        _context.Posts.Add(newPostItem);
                    }

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
