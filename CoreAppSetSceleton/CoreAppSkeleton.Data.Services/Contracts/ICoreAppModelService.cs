using System.Linq;
using System.Threading.Tasks;

namespace CoreAppSkeleton.Data.Services.Contracts
{
    public interface ICoreAppModelService
    {
        IQueryable<TViewModel> GetAll<TViewModel>();

        Task<bool> Add<T>(T viewModel);
    }
}
