using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class InventoryViewItem
    {
        public string MovieName { get; set; }
        public string ContentProviderName { get; set; }
        public int PermittedUsageCount { get; set; }
    }

    public class InventoryViewModel : CommonViewModel
    {
        public InventoryViewModel(ILogger logger) : base(logger)
        {
        }

        public IEnumerable<InventoryViewItem> Inventory
        {
            get
            {
                List<InventoryViewItem> displayItems = new List<InventoryViewItem>();

                try
                {
                    var inventory = _dbContext.InventoryControl;

                    foreach (var item in inventory)
                    {
                        var displayItem = new InventoryViewItem()
                        {
                            MovieName = FindMovie(item.MovieId).Title,
                            ContentProviderName = FindContentProvider(item.ContentProviderId).ContentProviderName,
                            PermittedUsageCount = item.PermittedUsageCount
                        };

                        displayItems.Add(displayItem);
                    }
                }
                catch (Exception exception)
                {
                    string message = "Failure Collecting Inventory Items";

                    Debug.Assert(false, message);
                    Debug.Assert(false, exception.Message);

                    Logger.LogError(exception, message, null);
                }

                return displayItems;
            }
        }

        public bool IsAny
        {
            get
            {
                bool isAny = false;

                try
                {
                    var inventory = _dbContext.InventoryControl;
                    List<InventoryControlEntry> list = inventory.ToList();
                    isAny = list.Any();
                }
                catch (Exception exception)
                {
                    Debug.Assert(false, "InventoryViewModel Failed IsAny Action");
                    Debug.Assert(false, exception.Message);
                }

                return isAny;
            }
        }

        public Movie FindMovie(int id)
        {
            Movie movie = null;

            try
            {
                movie = _dbContext.Movies.Find(id);
            }
            catch (Exception exception)
            {
                string message = $"Failure Finding Movie by Id={id}";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return movie;
        }

        public ContentProvider FindContentProvider(int id)
        {
            ContentProvider provider = null;

            try
            {
                provider = _dbContext.ContentProviders.Find(id);
            }
            catch (Exception exception)
            {
                string message = $"Failure Finding Content Provider by Id={id}";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return provider;
        }
    }
}
