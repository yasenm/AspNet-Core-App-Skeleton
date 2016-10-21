using CoreAppSkeleton.DataConsole;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CoreAppSkeleton.Data.Models;
using CoreAppSkeleton.Data.ViewModels.Auth;

namespace CoreAppSkeleton.Web.Controllers
{
    public class AuthController : Controller
    {
        private CoreAppSkeletonDbContext _context;
        private SignInManager<User> _signInManager;

        public AuthController(CoreAppSkeletonDbContext context, SignInManager<User> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "App");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, true, false);

                if (signInResult.Succeeded)
                {
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "App");
                    }
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Username or password incorect!");
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            return RedirectToAction("Index", "App");
        }
    }
}