using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.ViewModels;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CoreAppSkeleton.Web.Controllers
{
    public class BlogPostController : Controller
    {
        private IBlogPostService _blogItemsService;

        public BlogPostController(IBlogPostService blogItemsService)
        {
            _blogItemsService = blogItemsService;
        }

        // GET: /<controller>/
        // make user blog option
        public IActionResult Blog(string author)
        {
            return View("Blog", author);
        }

        public IActionResult Details(int id)
        {
            var model = _blogItemsService.GetById<BlogPostDetailsViewModel>(id);
            return View(model);
        }
    }
}
