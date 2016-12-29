using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreAppSkeleton.Web.ViewComponents
{
    public class BlogPostListViewComponent : ViewComponent
    {
        private IBlogPostService _bpService;

        public BlogPostListViewComponent(IBlogPostService bpService)
        {
            _bpService = bpService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string username)
        {
            IEnumerable<BlogSmallListViewModel> result = null;
            if (!string.IsNullOrEmpty(username))
            {
                result = _bpService.GetUserBlogPosts<BlogSmallListViewModel>(username);
            }
            else
            {
                result = _bpService.GetAll<BlogSmallListViewModel>();
            }
            return View(result);
        }
    }
}