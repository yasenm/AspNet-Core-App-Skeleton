using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAppSkeleton.Web.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        
        public IActionResult Index(string author)
        {
            IQueryable<BlogSmallListViewModel> result;
            if (string.IsNullOrEmpty(author))
            {
                result = _blogService.GetAll<BlogSmallListViewModel>();
            }
            else
            {
                result = _blogService.GetAllByAuthor<BlogSmallListViewModel>(author);
            }
            return View("Index", result.ToList());
        }
    }
}
