using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.Logging;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class CustomersViewModel : CommonViewModel
    {
        public CustomersViewModel(ILogger logger) : base(logger)
        {
        }

        public IEnumerable<Customer> Customers 
        {
            get
            {
                try
                {
                    return _dbContext.Customers;
                }
                catch(Exception exception)
                {
                    string message = "Failure listing Customers.";

                    Debug.Assert(false, message);
                    Debug.Assert(false, exception.Message);

                    Logger.LogError(exception, message, null);

                    throw;
                }
            }
        }

        public bool IsAny
        {
            get
            {
                bool isAny = false;

                try
                {
                    List<Customer> list = Customers.ToList();
                    isAny = list.Any();
                }
                catch (Exception exception)
                {
                    string message = "CustomersViewModel Failed IsAny Action";

                    Debug.Assert(false, message);
                    Debug.Assert(false, exception.Message);

                    Logger.LogError(exception, message, null);
                }

                return isAny;
            }
        }

        public Customer Find(int id)
        {
            Customer customer = null;

            try
            {
                customer = _dbContext.Customers.Find(id);
            }
            catch(Exception exception)
            {
                string message = "CustomersViewModel Failed Find Action";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return customer;
        }

        public byte GetDiscountRate(Customer customer)
        {
            byte rate = 0;

            try
            {
                byte membershipType = customer.MembershipTypeId;
                rate = _dbContext.MembershipTypes.Find(membershipType).DiscountRate;
            }
            catch (Exception exception)
            {
                string message = "CustomersViewModel Failed GetDiscountRate Action";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return rate;
        }
    }
}
