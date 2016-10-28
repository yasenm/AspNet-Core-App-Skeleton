using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.ViewModels;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreAppSkeleton.Web.Controllers
{
    public class BlogController : Controller
    {
        private IBlogItemsService _blogItemsService;

        public BlogController(IBlogItemsService blogItemsService)
        {
            _blogItemsService = blogItemsService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var result = _blogItemsService.GetAll<BlogItemLingBigViewModel>().ToList();

            return View(result);
        }
    }
}
