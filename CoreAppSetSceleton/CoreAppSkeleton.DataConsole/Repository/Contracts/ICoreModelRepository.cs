using CoreAppSkeleton.Data.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAppSkeleton.DataConsole.Repository.Contracts
{
    public interface ICoreModelRepository
    {
        IQueryable<CoreAppViewModel> GetAll();

        CoreAppViewModel GetById(int id);

        void Add(CoreAppViewModel postModel);

        Task<bool> SaveChangesAsync();
    }
}
