using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace CoreAppSkeleton.Web.Controllers
{
    public class AppController : Controller
    {
        private ICoreAppModelService _coreAppModelService;
        private ILogger<AppController> _logger;

        public AppController(ICoreAppModelService coreAppModelService, ILogger<AppController> logger)
        {
            _coreAppModelService = coreAppModelService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = _coreAppModelService.GetAll<CoreAppViewModel>().ToList();
            _logger.LogError($"THis log comes from {this.GetType()} and has a httpcontext = {HttpContext.Request.Path}");

            return View(model);
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
