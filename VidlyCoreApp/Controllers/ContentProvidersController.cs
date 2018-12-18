using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.ViewModels;

namespace VidlyCoreApp.Controllers
{
    [Authorize("CanManageContentProviders")]
    public class ContentProvidersController : AppBaseController
    {
        public ContentProvidersController(ILogger<ContentProvidersController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return View(new ContentProvidersViewModel(Logger));
        }

        public IActionResult New()
        {
            return View("ContentProviderForm");
        }
    }
}
