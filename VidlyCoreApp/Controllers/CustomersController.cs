using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.ViewModels;

namespace VidlyCoreApp.Controllers
{
    [Authorize("CanManageCustomers")]
    public class CustomersController : AppBaseController
    {
        public CustomersController(ILogger<CustomersController> logger) : base(logger)
        {
        }

        public IActionResult Index()                                    /* /Customers */
        {
            return View(new CustomersViewModel(Logger));
        }

        public IActionResult Details(int id)                            /* /Customers/Id */
        {
            try
            {
                CustomerDetailsViewModel model = new CustomerDetailsViewModel(Logger);
                bool isValid = model.Initialize(id);

                if (isValid)
                {
                    return View(model);
                }

                return RedirectToAction("ApplicationError", "Landing");
            }
            catch(Exception exception)
            {   
                Debug.Assert(false, "Customer Details Initialization Exception");
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, "Exception in CustomersController:Details. Directing user with AppError result", null);

                return RedirectToAction("ApplicationError", "Landing");
            }
        }

        public IActionResult Update(int id)                             /* /Customers/Details/id update customer information */
        {
            try
            {
                CustomerFormViewModel model = new CustomerFormViewModel(Logger, id);
                return View("CustomerForm", model);
            }
            catch(Exception exception)
            {
                Debug.Assert(false, "CustomerFormViewModel Couldn't Locate Customer(id)");
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, "Exception in CustomersController:Update. Directing user with AppError result", null);

                return RedirectToAction("ApplicationError", "Landing");
            }
        }

        public IActionResult New()                                      /* /Customers/New */
        {
            return View("CustomerForm", new CustomerFormViewModel(Logger));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(CustomerFormViewModel viewModel)      /* /Customers/New CustomerForm submission, /Customers/Update CustomerForm submission */
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    CustomerFormViewModel model = new CustomerFormViewModel(viewModel);
                    return View("CustomerForm", model);
                }
                else
                {
                    viewModel.Save();
                }
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "Could Not Save Customer Form");
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, "Exception in CustomersController:Save. Directing user with AppError result", null);

                return RedirectToAction("ApplicationError", "Landing");
            }

            return RedirectToAction("Index", "Customers");
        }
    }
}
