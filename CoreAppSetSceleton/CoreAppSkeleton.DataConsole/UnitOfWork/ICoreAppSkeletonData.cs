using CoreAppSkeleton.Data.Common.Repository;
using CoreAppSkeleton.Data.Models;
using System.Threading.Tasks;

namespace CoreAppSkeleton.DataConsole.UnitOfWork
{
    public interface ICoreAppSkeletonData
    {
        IRepository<User> Users { get; }
        IRepository<CoreAppModel> CoreAppModels { get; }
        IDeletableEntityRepository<BlogPost> BlogPosts { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
