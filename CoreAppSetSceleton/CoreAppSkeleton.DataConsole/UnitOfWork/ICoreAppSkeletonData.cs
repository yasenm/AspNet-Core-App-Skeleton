using CoreAppSkeleton.Data.Common.Repository;
using CoreAppSkeleton.Data.Models;
using System.Threading.Tasks;

namespace CoreAppSkeleton.DataConsole.UnitOfWork
{
    public interface ICoreAppSkeletonData
    {
        IRepository<CoreAppModel> CoreAppModels { get; }
        IDeletableEntityRepository<Blog> Blogs { get; }
        IDeletableEntityRepository<Post> Posts { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
