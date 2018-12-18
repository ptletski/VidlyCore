using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.ViewModels;

namespace VidlyCoreApp.Controllers
{
    [Authorize("CanManageInventory")]
    public class InventoryController : AppBaseController
    {
        public InventoryController(ILogger<InventoryController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            return View(new InventoryViewModel(Logger));
        }

        public IActionResult New()
        {
            return View("InventoryForm");
        }
    }
}
