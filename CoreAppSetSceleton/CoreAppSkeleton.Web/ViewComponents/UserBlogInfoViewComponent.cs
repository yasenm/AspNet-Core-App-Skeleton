using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreAppSkeleton.Web.ViewComponents
{
    public class UserBlogInfoViewComponent : ViewComponent
    {
        private IUserService _userService;

        public UserBlogInfoViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string username)
        {
            var model = _userService.GetByUserName<UserShortInfoViewModel>(username);
            return View(model);
        }
    }
}
