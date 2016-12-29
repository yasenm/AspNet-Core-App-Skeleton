using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreAppSkeleton.Web.ViewComponents
{
    public class UserListViewComponent : ViewComponent
    {
        private IUserService _userService;

        public UserListViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _userService.GetAll<UserListViewModel>();
            return View(model);
        }
    }
}
