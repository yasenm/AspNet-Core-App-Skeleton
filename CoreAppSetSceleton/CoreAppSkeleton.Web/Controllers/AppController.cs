using CoreAppSkeleton.DataConsole.Repository.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace CoreAppSkeleton.Web.Controllers
{
    public class AppController : Controller
    {
        private ICoreModelRepository _coreModelRepo;

        public AppController(ICoreModelRepository coreModelRepo)
        {
            _coreModelRepo = coreModelRepo;
        }

        public IActionResult Index()
        {
            var model = _coreModelRepo.GetAll().ToList();

            return View(model);
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
