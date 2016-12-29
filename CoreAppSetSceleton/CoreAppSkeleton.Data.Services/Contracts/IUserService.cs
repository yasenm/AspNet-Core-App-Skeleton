using System.Collections.Generic;

namespace CoreAppSkeleton.Data.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<TViewModel> GetAll<TViewModel>();
        TViewModel GetByUserName<TViewModel>(string username);
    }
}
