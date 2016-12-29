using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.ViewModels;

namespace CoreAppSkeleton.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult List()
        {
            var model = _userService.GetAll<UserListViewModel>();
            return ViewComponent("List", model);
        }

        public IActionResult BlogInfo(string author)
        {
            // first check if there is such user if not redirect to error page or show message on this one
            //IQueryable<BlogSmallListViewModel> result;
            //if (string.IsNullOrEmpty(author))
            //{
            //    result = _blogService.GetAll<BlogSmallListViewModel>();
            //}
            //else
            //{
            //    result = _blogService.GetAllByAuthor<BlogSmallListViewModel>(author);
            //}
            return View("Index", author);
        }
    }
}
