using System.Linq;

namespace CoreAppSkeleton.Data.Services.Contracts
{
    public interface ICoreAppModelService
    {
        IQueryable<TViewModel> GetAll<TViewModel>();
    }
}
