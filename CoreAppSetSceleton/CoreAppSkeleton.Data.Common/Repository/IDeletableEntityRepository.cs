using System.Linq;

namespace CoreAppSkeleton.Data.Common.Repository
{
    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();
    }
}
