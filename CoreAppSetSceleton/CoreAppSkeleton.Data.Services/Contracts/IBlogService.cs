using System.Linq;

namespace CoreAppSkeleton.Data.Services.Contracts
{
    public interface IBlogService
    {
        IQueryable<T> GetAll<T>();
        IQueryable<T> GetAllByAuthor<T>(string authorName);
    }
}
