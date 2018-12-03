using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class MovieFormViewModel : CommonViewModel
    {
        private int _contentProviderId = 0;

        public MovieFormViewModel() : base()
        {
            Mode = FormMode.New;
        }

        public MovieFormViewModel(int movieId)
        {
            Mode = FormMode.Update;

            var movie = _dbContext.Movies.Single(m => m.MovieId == movieId);

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
        }

        public MovieFormViewModel(MovieFormViewModel model)
        {
            this.Title = model.Title;
            this.Year = model.Year;
            this.MpaRatingId = model.MpaRatingId;
            this.MovieGenreId = model.MovieGenreId;
            this.DateAdded = model.DateAdded;
            this.InventoryControlId = model.InventoryControlId;
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
                        Debug.Assert(false, "Error Accessing InventoryControl Table");
                        Debug.Assert(false, exception.Message);
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
                    var inventoryControlEntry = _dbContext.InventoryControl.Single(i => i.InventoryControlId == InventoryControlId);

                    if (inventoryControlEntry != null)
                    {
                        count = inventoryControlEntry.PermittedUsageCount;
                    }
                }
                catch (Exception exception)
                {
                    Debug.Assert(false, "Exception Acessing InventoryControl Table");
                    Debug.Assert(false, exception.Message);
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
                Debug.Assert(false, "Exception Accessing MovieGenres Table");
                Debug.Assert(false, exception.Message);
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
                Debug.Assert(false, "Exception Accessing MpaRatings Table");
                Debug.Assert(false, exception.Message);
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
                Debug.Assert(false, "Exception Accessing ContentProviders Table");
                Debug.Assert(false, exception.Message);
            }

            return providerList;
        }

        public string GetContentProvider()
        {
            var inventoryControl = _dbContext.InventoryControl.Find(InventoryControlId);
            _contentProviderId = inventoryControl.ContentProviderId;
            var contentProvider = _dbContext.ContentProviders.Find(_contentProviderId);
            return contentProvider.ContentProviderName;
        }

        public void SaveNewMovie()
        {   // Two transactions. 
            // First: Create movie with 0 InventoryControlId.
            // Second: Create Inventory entry with usage count and content provider.
            // Assumption: No new suppliers. Out of bounds transaction.
            // Business Process: Add ContentProvider if needed, 
            //  then add Movie with "Number of Licenses",
            //  then add InventoryControl
            Movie movie = new Movie();

            movie.Title = Title;
            movie.Year = Year ?? 0;
            movie.MpaRatingId = MpaRatingId;
            movie.MovieGenreId = MovieGenreId;
            movie.DateAdded = DateAdded ?? new DateTime(1,1,1);
            movie.ActiveUseCount = 0;
            movie.InventoryControlId = 0;

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            // Update Inventory
            Movie updatedMovie = _dbContext.Movies.Single(m => (
                m.Title == movie.Title && 
                m.Year == movie.Year && 
                m.MpaRatingId == movie.MpaRatingId && 
                m.MovieGenreId == movie.MovieGenreId));
            InventoryControlEntry inventoryControl = new InventoryControlEntry();

            inventoryControl.ContentProviderId = _contentProviderId;
            inventoryControl.PermittedUsageCount = NumberOfLicenses ?? 0;
            inventoryControl.MovieId = updatedMovie.MovieId;

            _dbContext.InventoryControl.Add(inventoryControl);

            // Reflect in Movie
            updatedMovie.InventoryControlId = updatedMovie.MovieId; // update

            _dbContext.Movies.Update(updatedMovie);
            _dbContext.SaveChanges();
        }

        public void SaveExistingMovie(int id)
        {
            var movieInDb = _dbContext.Movies.Single(m => m.MovieId == id);

            movieInDb.Title = Title;
            movieInDb.Year = Year ?? 0;
            movieInDb.MpaRatingId = MpaRatingId;
            movieInDb.MovieGenreId = MovieGenreId;
            movieInDb.DateAdded = DateAdded ?? new DateTime(1,1,1);

            var inventoryControl = _dbContext.InventoryControl.Single(i => i.InventoryControlId == movieInDb.InventoryControlId);

            inventoryControl.PermittedUsageCount = NumberOfLicenses ?? 0;

            _dbContext.SaveChanges();
        }
    }
}
