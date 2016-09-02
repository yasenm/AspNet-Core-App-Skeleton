using CoreAppSkeleton.Data.ViewModels;
using System.Linq;

namespace CoreAppSkeleton.DataConsole.Repository.Contracts
{
    public interface ICoreModelRepository
    {
        IQueryable<CoreAppViewModel> GetAll();

        CoreAppViewModel GetById(int id);
    }
}
