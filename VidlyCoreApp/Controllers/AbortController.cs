using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.Areas.Identity.Data;

namespace VidlyCoreApp.Controllers
{
    public class AbortController : AppBaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AbortController(
            SignInManager<ApplicationUser> signInManager,
            ILogger<AbortController> logger) : base(logger)
        {
            _signInManager = signInManager;
        }

        async private void ForceUserLogout()
        {
            await _signInManager.SignOutAsync();

            string message = $"Attempt User log out. Outcome:{_signInManager.IsSignedIn(User)}";

            Logger.LogInformation(message);
        }

        public IActionResult ApplicationError()
        {
          //  ForceUserLogout();
            return View();
        }
    }
}
