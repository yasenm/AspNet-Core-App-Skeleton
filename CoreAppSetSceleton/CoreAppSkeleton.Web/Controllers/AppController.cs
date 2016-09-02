using CoreAppSkeleton.DataConsole;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CoreAppSkeleton.Data.ViewModels;
using AutoMapper.QueryableExtensions;
using CoreAppSkeleton.DataConsole.Repository.Contracts;

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
    }
}
