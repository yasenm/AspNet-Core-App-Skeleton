using Microsoft.EntityFrameworkCore;
using CoreAppSkeleton.Data.Models;

namespace CoreAppSkeleton.DataConsole
{
    public interface ICoreAppSkeletonDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<CoreAppModel> CoreAppModels { get; set; }
        DbSet<BlogItem> BlogItems { get; set; }
    }
}
