using Microsoft.EntityFrameworkCore;
using CoreAppSkeleton.Data.Models;

namespace CoreAppSkeleton.DataConsole
{
    public interface ICoreAppSkeletonDbContext
    {
        DbSet<CoreAppModel> CoreAppModels { get; set; }
    }
}
