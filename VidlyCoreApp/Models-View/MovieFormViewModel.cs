using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class MovieFormViewModel : CommonViewModel
    {
        private int _contentProviderId = 0;
        private bool _canUserModifyContentProvider;
        private bool _canUserManageInventory;

        public MovieFormViewModel() : base()
        {
            Mode = FormMode.Update;
            _canUserModifyContentProvider = false;
            _canUserManageInventory = false;
        }

        public MovieFormViewModel(ILogger logger, ClaimsPrincipal principal) : base(logger)
        {
            Mode = FormMode.New;
            DetermineModifyContentProvider(principal);
            DetermineManageInventory(principal);
        }

        public MovieFormViewModel(ILogger logger, ClaimsPrincipal principal, int movieId) : base(logger)
        {
            Mode = FormMode.Update;
            DetermineModifyContentProvider(principal);
            DetermineManageInventory(principal);

            var movie = _dbContext.Movies.Find(movieId);

            if (movie == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            Title = movie.Title;
            Year = movie.Year;
            MpaRatingId = movie.MpaRatingId;
            MovieGenreId = movie.MovieGenreId;
            DateAdded = movie.DateAdded;
            InventoryControlId = movie.InventoryControlId;
            MovieId = movie.MovieId;
        }

        public MovieFormViewModel(MovieFormViewModel model, ClaimsPrincipal principal) : base(model.Logger)
        {
            DetermineModifyContentProvider(principal);
            DetermineManageInventory(principal);

            this.Title = model.Title;
            this.Year = model.Year;
            this.MpaRatingId = model.MpaRatingId;
            this.MovieGenreId = model.MovieGenreId;
            this.DateAdded = model.DateAdded;
            this.InventoryControlId = model.InventoryControlId;
            this.MovieId = model.MovieId;
        }

        private void DetermineModifyContentProvider(ClaimsPrincipal principal)
        {
            try
            {
                if (principal != null)
                {
                    _canUserModifyContentProvider = principal.Claims.Any(c => c.Type == "CanManageContentProviders");
                }
                else
                {
                    string message = "MovieFormViewModel:Principal not defined.";
                    Debug.Assert(false, message);
                    Logger.LogError(message, null);

                    throw new Exception(message);
                }
            }
            catch (Exception exception)
            {
                string message = "Failure evaluating claims on the principal for modifying content provider.";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);

                throw;
            }
        }

        private void DetermineManageInventory(ClaimsPrincipal principal)
        {
            try
            {
                if (principal != null)
                {
                    _canUserManageInventory = principal.Claims.Any(c => c.Type == "CanManageInventory");
                }
                else
                {
                    string message = "MovieFormViewModel:Principal not defined.";
                    Debug.Assert(false, "Principal not defined.");
                    Logger.LogError(message, null);

                    throw new Exception(message);
                }
            }
            catch (Exception exception)
            {
                string message = "Failure evaluating claims on the principal for managing inventory.";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);

                throw;
            }
        }

        public bool CanUserModifyContentProvider()
        {
            return _canUserModifyContentProvider;
        }

        public bool CanUserManageInventory()
        {
            return _canUserManageInventory;
        }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Display(Name = "Movie Genre")]
        [MovieGenreTypeValidation]
        public byte MovieGenreId { get; set; }

        [Display(Name = "Motion Picture Assoc. Rating")]
        [MpaRatingTypeValidation]
        public byte MpaRatingId { get; set; }

        [Required]
        [Display(Name = "Date Added to Inventory")]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Content Provider")]
        [ContentProviderTypeValidation]
        public int ContentProviderId 
        { 
            get
            {
                if (_contentProviderId != 0)
                    return _contentProviderId;

                if (Mode == FormMode.Update)
                {
                    try
                    {
                        var inventoryControl = _dbContext.InventoryControl.Find(InventoryControlId);
                        _contentProviderId = inventoryControl.ContentProviderId;
                        return inventoryControl.ContentProviderId;
                    }
                    catch(Exception exception)
                    {
                        string message = "Error Accessing InventoryControl Table";

                        Debug.Assert(false, message);
                        Debug.Assert(false, exception.Message);

                        Logger.LogError(exception, message, null);
                    }
                }

                return 0;
            }

            set
            {
                _contentProviderId = value;
            }
        }

        [Display(Name = "Release Year")]
        [Required(ErrorMessage = "Enter the Release Year")]
        public int? Year { get; set; }

        public int InventoryControlId { get; set; }

        public int MovieId { get; set; }

        [Display(Name = "Number of Licenses")]
        [Required(ErrorMessage = "Enter the Number of Licenses")]
        public short? NumberOfLicenses { get; set; }

        public int? GetNumberOfLicenses()
        {
            int? count = null;

            if (InventoryControlId != 0)
            {
                try
                {
                    var inventoryControlEntry = _dbContext.InventoryControl.Find(InventoryControlId);

                    if (inventoryControlEntry != null)
                    {
                        count = inventoryControlEntry.PermittedUsageCount;
                    }
                }
                catch (Exception exception)
                {
                    string message = "Exception Accessing InventoryControl Table";

                    Debug.Assert(false, message);
                    Debug.Assert(false, exception.Message);

                    Logger.LogError(exception, message, null);
                }
            }

            return count;
        }

        public IEnumerable<MovieGenre> GetAllGenreTypes()
        {
            IEnumerable<MovieGenre> typeList = null;

            try
            {
                var list = _dbContext.MovieGenres.ToList();
                list.Insert(0, new MovieGenre { MovieGenreId = 0, MovieGenreName = "Select a Genre" });
                typeList = (list as IEnumerable<MovieGenre>);
            }
            catch (Exception exception)
            {
                string message = "Exception Accessing MovieGenres Table";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return typeList;
        }

        public IEnumerable<MpaRating> GetAllMpaRatingTypes()
        {
            IEnumerable<MpaRating> typeList = null;

            try
            {
                var list = _dbContext.MpaRatings.ToList();
                list.Insert(0, new MpaRating { MpaRatingId = 0, MpaRatingName = "Select MPA Rating" });
                typeList = (list as IEnumerable<MpaRating>);

            }
            catch (Exception exception)
            {
                string message = "Exception Accessing MpaRatings Table";
                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return typeList;
        }

        public IEnumerable<ContentProvider> GetAllContentProviders()
        {
            IEnumerable<ContentProvider> providerList = null;

            try
            {
                var list = _dbContext.ContentProviders.ToList();
                providerList = (list as IEnumerable<ContentProvider>);
                list.Insert(0, new ContentProvider { ContentProviderId = 0, ContentProviderName = "Select a Content Provider" });
            }
            catch (Exception exception)
            {
                string message = "Exception Accessing ContentProviders Table";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return providerList;
        }

        public string GetContentProvider()
        {
            string provider = String.Empty;

            try
            {
                var inventoryControl = _dbContext.InventoryControl.Find(InventoryControlId);
                _contentProviderId = inventoryControl.ContentProviderId;

                var contentProvider = _dbContext.ContentProviders.Find(_contentProviderId);
                provider = contentProvider.ContentProviderName;
            }
            catch (Exception exception)
            {
                string message = "Exception Finding ContentProviders";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return provider;
        }

        public void Save()
        {
            if (MovieId != 0)
            {
                SaveExistingMovie();
            }
            else
            {
                SaveNewMovie();
            }
        }

        private void SaveNewMovie()
        {   // Two transactions. 
            // First: Create movie with 0 InventoryControlId.
            // Second: Create Inventory entry with usage count and content provider.
            // Assumption: No new suppliers. Out of bounds transaction.
            // Business Process: Add ContentProvider if needed, 
            //  then add Movie with "Number of Licenses",
            //  then add InventoryControl
            try
            {
                Movie movie = new Movie
                {
                    Title = Title,
                    Year = Year ?? 0,
                    MpaRatingId = MpaRatingId,
                    MovieGenreId = MovieGenreId,
                    DateAdded = DateAdded ?? new DateTime(1, 1, 1),
                    ActiveUseCount = 0,
                    InventoryControlId = 0
                };

                _dbContext.Movies.Add(movie);
                _dbContext.SaveChanges();

                // Update Inventory
                Movie updatedMovie = _dbContext.Movies.Single(m => (
                    m.Title == movie.Title &&
                    m.Year == movie.Year &&
                    m.MpaRatingId == movie.MpaRatingId &&
                    m.MovieGenreId == movie.MovieGenreId));

                InventoryControlEntry inventoryControl = new InventoryControlEntry
                {
                    ContentProviderId = _contentProviderId,
                    PermittedUsageCount = NumberOfLicenses ?? 0,
                    MovieId = updatedMovie.MovieId
                };

                _dbContext.InventoryControl.Add(inventoryControl);

                // Reflect in Movie
                updatedMovie.InventoryControlId = updatedMovie.MovieId; // update

                _dbContext.Movies.Update(updatedMovie);
                _dbContext.SaveChanges();
            }
            catch(Exception exception)
            {
                string message = "Exception Saving New Movie";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);

                throw;
            }
        }

        private void SaveExistingMovie()
        {
            try
            {
                var movieInDb = _dbContext.Movies.Find(MovieId);

                movieInDb.Title = Title;
                movieInDb.Year = Year ?? 0;
                movieInDb.MpaRatingId = MpaRatingId;
                movieInDb.MovieGenreId = MovieGenreId;
                movieInDb.DateAdded = DateAdded ?? new DateTime(1, 1, 1);

                var inventoryControl = _dbContext.InventoryControl.Find(movieInDb.InventoryControlId);

                inventoryControl.PermittedUsageCount = NumberOfLicenses ?? 0;

                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                string message = "Exception Updating Existing Movie";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);

                throw;
            }
        }
    }
}
