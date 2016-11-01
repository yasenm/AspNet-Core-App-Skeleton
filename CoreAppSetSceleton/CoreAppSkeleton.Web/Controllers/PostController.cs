using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.ViewModels;

using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreAppSkeleton.Web.Controllers
{
    public class PostController : Controller
    {
        private IPostService _blogItemsService;

        public PostController(IPostService blogItemsService)
        {
            _blogItemsService = blogItemsService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var result = _blogItemsService.GetAll<PostLinkBigViewModel>().ToList();

            return View(result);
        }
    }
}
