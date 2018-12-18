using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class ContentProviderViewItem
    {
        public string ContentProviderName { get; set; }
        public string ContractReference { get; set; }
    }

    public class ContentProvidersViewModel : CommonViewModel
    {
        public ContentProvidersViewModel(ILogger logger) : base(logger)
        {
        }

        public bool IsAny
        {
            get
            {
                bool isAny = false;

                try
                {
                    var contentProviders = _dbContext.ContentProviders;
                    List<ContentProvider> list = contentProviders.ToList();
                    isAny = list.Any();
                }
                catch (Exception exception)
                {
                    string message = "ContentProvidersViewModel Failed IsAny Action";

                    Debug.Assert(false, message);
                    Debug.Assert(false, exception.Message);

                    Logger.LogError(exception, message, null);
                }

                return isAny;
            }
        }

        public IEnumerable<ContentProviderViewItem> ContentProviders
        {
            get
            {
                List<ContentProviderViewItem> viewItems = new List<ContentProviderViewItem>();

                try
                {
                    var contentProviders = _dbContext.ContentProviders;

                    foreach(var contentProvider in contentProviders)
                    {
                        ContentProviderViewItem viewItem = new ContentProviderViewItem()
                        {
                            ContentProviderName = contentProvider.ContentProviderName,
                            ContractReference = contentProvider.ContractReference
                        };

                        viewItems.Add(viewItem);
                    }
                }
                catch(Exception exception)
                {
                    string message = "Failure Collecting Content Providers";

                    Debug.Assert(false, message);
                    Debug.Assert(false, exception.Message);

                    Logger.LogError(exception, message, null);
                }

                return viewItems;
            }
        }
    }
}
