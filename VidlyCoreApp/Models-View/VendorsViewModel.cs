using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class VendorsViewModel : CommonViewModel
    {
        public VendorsViewModel(ILogger logger) : base(logger)
        {
        }

        public IEnumerable<ContentProvider> Vendors
        {
            get
            {
                IEnumerable<ContentProvider> providers = null;

                try
                {
                    providers = _dbContext.ContentProviders;
                }
                catch (Exception exception)
                {
                    string message = "Could Not Retrieve Content Providers";

                    Debug.Assert(false, message);
                    Debug.Assert(false, exception.Message);

                    Logger.LogError(exception, message, null);
                }

                return providers;
            }
        }

        public bool IsAny
        {
            get
            {
                bool isAny = false;

                try
                {
                    isAny = Vendors.ToList().Any();
                }
                catch (Exception exception)
                {
                    string message = "Could Not Perform IsAny Check on Content Providers";

                    Debug.Assert(false, message);
                    Debug.Assert(false, exception.Message);

                    Logger.LogError(exception, message, null);
                }

                return isAny;
            }
        }
    }
}
