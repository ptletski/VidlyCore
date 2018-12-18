using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VidlyCoreApp.Controllers
{
    [Authorize]
    public class LandingController : AppBaseController
    {
        public LandingController(ILogger<LandingController> logger) : base(logger)
        {
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ApplicationError()
        {
            return View();
        }
    }
}
