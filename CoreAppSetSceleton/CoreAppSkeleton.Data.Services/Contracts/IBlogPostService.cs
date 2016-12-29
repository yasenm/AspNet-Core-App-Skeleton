using System.Collections.Generic;
using System.Linq;

namespace CoreAppSkeleton.Data.Services.Contracts
{
    public interface IBlogPostService
    {
        IQueryable<TViewModel> GetAll<TViewModel>();
        TViewModel GetById<TViewModel>(int id);
        ICollection<TViewModel> GetUserBlogPosts<TViewModel>(string username);
    }
}