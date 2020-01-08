using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ManiaGaming.Models.Data;
using ManiaGaming.Models;
using Microsoft.AspNetCore.Authentication;

namespace ManiaGaming.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;

        public LoginController(UserManager<Account> userManager, SignInManager<Account> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registreer(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (returnUrl == null)
                        returnUrl = "Home";
                    return RedirectToAction("Index", returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registreer(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                Account baseaccount = new Account(-1, model.Naam, model.Achternaam, model.Email);
                baseaccount.Huisnummer = model.Huisnummer;
                baseaccount.Postcode = model.Postcode;
                baseaccount.Geboortedatum = model.Geboortedatum;
                var result = await _userManager.CreateAsync(baseaccount, model.Password);
                if (result.Succeeded)
                {

                    await _signInManager.SignInAsync(baseaccount, isPersistent: false);
                    return RedirectToAction(returnUrl);
                }
                ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
            }
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Logout), "Home"); 
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Logout), "Home");
        }

        //AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}