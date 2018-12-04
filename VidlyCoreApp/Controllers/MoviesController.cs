using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VidlyCoreApp.ViewModels;

namespace VidlyCoreApp.Controllers
{
    public class MoviesController : VidlyControllerBase
    {
        public MoviesController() : base()
        {
        }

        public IActionResult Index()                                    /* /Movies */
        {
            return View(new MoviesViewModel());
        }

        public IActionResult Details(int id)                            /* /Movies/Id */
        {
            RemoveCookie("Movie");
            SetCookie("Movie", id.ToString());

            IActionResult r = NotFound();

            try
            {
                var model = new MovieDetailsViewModel();
                var isValid = model.Initialize(id);

                if (isValid)
                {
                    r = View(model);
                }
            }
            catch (Exception e)
            {
                Debug.Assert(false, "MovieDetailsViewModel Constuction and Initialization Failed");
                Debug.Assert(false, e.Message);
            }

            return r;
        }

        public IActionResult Update(int id)                             /* /Movies/Details/id update Movie information */
        {
            try
            {
                var model = new MovieFormViewModel(id);
                return View("MovieForm", model);
            }
            catch (Exception e)
            {
                Debug.Assert(false, "MovieFormViewModel Construction failed.");
                Debug.Assert(false, e.Message);

                return View();
            }
        }

        public IActionResult New()                                      /* /Movies/New */
        {
            RemoveCookie("Movie");
            return View("MovieForm", new MovieFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(MovieFormViewModel viewModel)         /* /Movies/New MovieForm submission, /Movies/Update MovieForm submission */
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    MovieFormViewModel model = new MovieFormViewModel(viewModel);
                    return View("MovieForm", model);
                }
                else
                {
                    string cookieValue = GetCookie("Movie");

                    if (cookieValue != null)
                    {
                        int movieId = int.Parse(cookieValue);
                        viewModel.SaveExistingMovie(movieId);
                    }
                    else
                    {
                        viewModel.SaveNewMovie();
                    }
                }
            }
            catch(Exception e)
            {
                Debug.Assert(false, "Couldn't Not Save Movie Form");
                Debug.Assert(false, e.Message);
            }

            return RedirectToAction("Index", "Movies");
        }
    }
}
