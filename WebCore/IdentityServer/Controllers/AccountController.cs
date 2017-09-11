using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityServer.Models;
using IdentityServer.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace IdentityServer.Controllers
{
    public class AccountController : Controller
    {
        //private readonly InMemoryUserLoginService _loginService;
        private readonly ILoginService<ApplicationUser> _loginService;
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(

            //InMemoryUserLoginService loginService,
            ILoginService<ApplicationUser> loginService,
            ILoggerFactory loggerFactory,
            UserManager<ApplicationUser> userManager)
        {
            _loginService = loginService;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _userManager = userManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect(returnUrl);
            }


            return View(new LoginViewModel() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = await _loginService.FindByEmail(model.Username);
                if (await _loginService.ValidateCredentials(user, model.Password))
                {
                    AuthenticationProperties props = null;
                    if (model.RememberLogin)
                    {
                        props = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddYears(10)
                        };
                    };

                    await _loginService.SignIn(user);
                    // make sure the returnUrl is still valid, and if yes - redirect back to authorize endpoint
                    //if (_interaction.IsValidReturnUrl(model.ReturnUrl))
                    //{
                    if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);
                    //}

                    return Redirect("~/");
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }

            // something went wrong, show form with error
            //var vm = await BuildLoginViewModelAsync(model);
            //ViewData["ReturnUrl"] = model.ReturnUrl;
            return View(new LoginViewModel() { ReturnUrl = model.ReturnUrl });
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            return View();
        }
    }
}