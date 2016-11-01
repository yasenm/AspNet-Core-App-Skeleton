using System.Linq;

namespace CoreAppSkeleton.Data.Services.Contracts
{
    public interface IPostService
    {
        IQueryable<TViewModel> GetAll<TViewModel>();
        TViewModel GetById<TViewModel>(int id);
    }
}
