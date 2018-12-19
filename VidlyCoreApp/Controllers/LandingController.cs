using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VidlyCoreApp.Controllers
{
    [Authorize]
    public class LandingController : AppBaseController
    {
        public LandingController(ILogger<LandingController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
