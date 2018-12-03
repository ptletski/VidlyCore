using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VidlyCoreApp.Models;

namespace VidlyCoreApp.ViewModels
{
    public class CustomersViewModel : CommonViewModel
    {
        public CustomersViewModel() : base()
        {
        }

        public IEnumerable<Customer> Customers 
        {
            get
            {
                var customers = _dbContext.Customers;
                return customers;
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
                catch (Exception e)
                {
                    Debug.Assert(false, "CustomersViewModel Failed IsAny Action");
                    Debug.Assert(false, e.Message);
                }

                return isAny;
            }
        }

        public Customer Find(int id)
        {
            Customer customer = null;

            try
            {
                customer = _dbContext.Customers.SingleOrDefault(c => c.CustomerId == id);
            }
            catch(Exception e)
            {
                Debug.Assert(false, "CustomersViewModel Failed Find Action");
                Debug.Assert(false, e.Message);
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
            catch (Exception e)
            {
                Debug.Assert(false, "CustomersViewModel Failed GetDiscountRate Action");
                Debug.Assert(false, e.Message);
            }

            return rate;
        }
    }
}
