using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace CoreAppSkeleton.Web.Controllers
{
    public class AppController : Controller
    {
        private ICoreAppModelService _coreAppModelService;

        public AppController(ICoreAppModelService coreAppModelService)
        {
            _coreAppModelService = coreAppModelService;
        }

        public IActionResult Index()
        {
            var model = _coreAppModelService.GetAll<CoreAppViewModel>().ToList();

            return View(model);
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
