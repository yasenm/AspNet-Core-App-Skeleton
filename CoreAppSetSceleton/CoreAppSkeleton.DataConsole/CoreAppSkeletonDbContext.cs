using CoreAppSkeleton.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.IO;

namespace CoreAppSkeleton.DataConsole
{
    public class CoreAppSkeletonDbContext : IdentityDbContext<User>, ICoreAppSkeletonDbContext
    {
        private IConfigurationRoot _config;
        
        public CoreAppSkeletonDbContext()
            : base()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            _config = builder.Build();
        }

        public CoreAppSkeletonDbContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<CoreAppModel> CoreAppModels { get; set; }

        public DbSet<BlogItem> BlogItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }
    }
}
