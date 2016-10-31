using CoreAppSkeleton.Data.Common.Repository;
using CoreAppSkeleton.Data.Models;
using System.Threading.Tasks;

namespace CoreAppSkeleton.DataConsole.UnitOfWork
{
    public interface ICoreAppSkeletonData
    {
        IRepository<CoreAppModel> CoreAppModels { get; }
        IDeletableEntityRepository<BlogItem> BlogItems { get; }
        Task<int> SaveChanges();
    }
}
