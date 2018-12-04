using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VidlyCoreApp.ViewModels;

namespace VidlyCoreApp.Controllers
{
    public class CustomersController : VidlyControllerBase
    {
        public CustomersController() : base()
        {
        }

        public IActionResult Index()                                    /* /Customers */
        {
            return View(new CustomersViewModel());
        }

        public IActionResult Details(int id)                            /* /Customers/Id */
        {
            RemoveCookie("Customer");
            SetCookie("Customer", id.ToString());

            IActionResult r = NotFound();

            try
            {
                var model = new CustomerDetailsViewModel();
                var isValid = model.Initialize(id);

                if (isValid)
                {
                    r = View(model);
                }
            }
            catch(Exception e)
            {   // EventSource to replace in v2.2 Asp.Net Core
                Debug.Assert(false, "Customer Details Initialation Exception");
                Debug.Assert(false, e.Message);
            }

            return r;
        }

        public IActionResult Update(int id)                             /* /Customers/Details/id update customer information */
        {
            try
            {
                var model = new CustomerFormViewModel(id);
                return View("CustomerForm", model);
            }
            catch(Exception e)
            {
                Debug.Assert(false, "CustomerFormViewModel Couldn't Locate Customer(id)");
                Debug.Assert(false, e.Message);

                return View();
            }
        }

        public IActionResult New()                                      /* /Customers/New */
        {
            RemoveCookie("Customer");
            return View("CustomerForm", new CustomerFormViewModel());
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
                    string cookieValue = GetCookie("Customer");

                    if (cookieValue != null)
                    {
                        int customerId = int.Parse(cookieValue);
                        viewModel.SaveExistingCustomer(customerId);
                    }
                    else
                    {
                        viewModel.SaveNewCustomer();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Assert(false, "Could Not Save Customer Form");
                Debug.Assert(false, e.Message);
            }

            return RedirectToAction("Index", "Customers");
        }
    }
}
