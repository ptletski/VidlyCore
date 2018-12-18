using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class CustomerDetailsViewModel : CommonViewModel
    {
        private Customer _customer;

        public CustomerDetailsViewModel(ILogger logger) : base(logger)
        {
        }

        public bool Initialize(int customerId)
        {
            try
            {
                _customer = _dbContext.Customers.Single(c => c.CustomerId == customerId);
            }
            catch(Exception exception)
            {
                string message = "Failure Initializing Customer Via EF";

                Debug.Assert(false, "Failure Initializing Customer Via EF");
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);

                throw;
            }

            return (_customer != null);
        }

        public string GetCustomerName()
        {
            return _customer.Name;
        }

        public string GetMembershipName()
        {
            string name = "";

            try
            {
                byte membershipType = _customer.MembershipTypeId;
                name = _dbContext.MembershipTypes.Find(membershipType).MembershipName;
            }
            catch(Exception exception)
            {
                string message = "CustomerDetaulsViewModel Failed During Finding Membership Name";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return name;
        }

        public string GetBirthDate()
        {
            DateTime dateTime = _customer.BirthDate ?? new DateTime(1,1,1);

            if (dateTime.Year == 1)
            {
                return null;
            }

            return dateTime.ToShortDateString();
        }

        public int GetCustomerId()
        {
            return _customer.CustomerId;
        }

        public bool IsSubscribedToNewsletter()
        {
            return _customer.IsSubscribedToNewsletter;
        }
    }
}
