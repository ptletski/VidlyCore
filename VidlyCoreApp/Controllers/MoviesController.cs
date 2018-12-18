using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.ViewModels;

namespace VidlyCoreApp.Controllers
{
    [Authorize("CanManageVideos")]
    public class MoviesController : AppBaseController
    {
        public MoviesController(ILogger<MoviesController> logger) : base(logger)
        {
        }

        public IActionResult Index()                                    /* /Movies */
        {
            return View(new MoviesViewModel(Logger));
        }

        public IActionResult Details(int id)                            /* /Movies/Id */
        {
            try
            {
                MovieDetailsViewModel model = new MovieDetailsViewModel(Logger);
                bool isValid = model.Initialize(id);

                if (isValid)
                {
                    return View(model);
                }

                return RedirectToAction("ApplicationError", "Landing");
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "MovieDetailsViewModel construction and initialization failed.");
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, "Exception in MoviesController:Details. Directing user with AppError result", null);

                return RedirectToAction("ApplicationError", "Landing");
            }
        }

        public IActionResult Update(int id)                             /* /Movies/Details/id update Movie information */
        {
            try
            {
                MovieFormViewModel model = new MovieFormViewModel(Logger, User, id);

                return View("MovieForm", model);
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "MovieFormViewModel construction failed.");
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, "Exception in MoviesController:Update. Directing user with AppError result", null);

                return RedirectToAction("ApplicationError", "Landing");
            }
        }

        public IActionResult New()                                      /* /Movies/New */
        {
            try
            {
                MovieFormViewModel viewModel = new MovieFormViewModel(Logger, User);

                return View("MovieForm", viewModel);
            }
            catch (Exception exception)
            {
                Debug.Assert(false, "MovieFormViewModel construction failed.");
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, "Exception in MoviesController:New. Directing user with AppError result", null);

                return RedirectToAction("ApplicationError", "Landing");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(MovieFormViewModel viewModel)         /* /Movies/New MovieForm submission, /Movies/Update MovieForm submission */
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    MovieFormViewModel model = new MovieFormViewModel(viewModel, User)
                    {
                        Logger = this.Logger
                    };

                    return View("MovieForm", model);
                }
                else
                {
                    viewModel.Save();
                }

                return RedirectToAction("Index", "Movies");
            }
            catch(Exception exception)
            {
                Debug.Assert(false, "Couldn't Not Save Movie Form");
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, "Exception in MoviesController:Save. Directing user with AppError result", null);

                return RedirectToAction("ApplicationError", "Landing");
            }
        }
    }
}
