using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.ViewModels;

namespace VidlyCoreApp.Controllers
{
    [Authorize]
    public class VendorsController : AppBaseController
    {
        public VendorsController(ILogger<VendorsController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return View(new VendorsViewModel(Logger));
        }

        public IActionResult New()
        {
            return View("VendorForm");
        }
    }
}
