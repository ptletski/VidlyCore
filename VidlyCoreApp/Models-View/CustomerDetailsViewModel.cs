using System;
using System.Diagnostics;
using System.Linq;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class CustomerDetailsViewModel : CommonViewModel
    {
        private Customer _customer;

        public CustomerDetailsViewModel() : base()
        {
        }

        public bool Initialize(int customerId)
        {
            _customer = _dbContext.Customers.SingleOrDefault(c => c.CustomerId == customerId);

            return (_customer == null) ? false : true;
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
            catch(Exception e)
            {
                Debug.Assert(false, "CustomerDetaulsViewModel Failed During Finding Membership Name");
                Debug.Assert(false, e.Message);
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
