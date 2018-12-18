using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using VidlyCoreApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace VidlyCoreApp.ViewModels
{
    public class CustomerFormViewModel : CommonViewModel
    {
        public CustomerFormViewModel() : base()
        {
            Mode = FormMode.Update;
        }
                  
        public CustomerFormViewModel(ILogger logger) : base(logger)
        {
            Mode = FormMode.New;
        }

        public CustomerFormViewModel(ILogger logger, int customerId) : base(logger)
        {
            Mode = FormMode.Update;

            var customer = _dbContext.Customers.Find(customerId);

            if (customer == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            Name = customer.Name;
            Address = customer.Address;
            City = customer.City;
            State = customer.State;
            BirthDate = customer.BirthDate;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            MembershipTypeId = customer.MembershipTypeId;
            CustomerId = customer.CustomerId;
        }

        public CustomerFormViewModel(CustomerFormViewModel model) : base(model.Logger)
        {
            this.Name = model.Name;
            this.MembershipTypeId = model.MembershipTypeId;
            this.BirthDate = model.BirthDate;
            this.Address = model.Address;
            this.City = model.City;
            this.State = model.State;
            this.IsSubscribedToNewsletter = model.IsSubscribedToNewsletter;
            this.CustomerId = model.CustomerId;
        }

        [Required]  
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        [MembershipTypeValidation]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [MembershipAgeValidation]
        public DateTime? BirthDate { get; set; }

        [Required] 
        public string Address { get; set; }

        [Required] 
        public string City { get; set; }

        [Required] 
        public string State { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public int CustomerId { get; set; }

        public IEnumerable<MembershipType> GetAllMembershipTypes()
        {
            IEnumerable<MembershipType> typeList = null;

            try
            {
                var list = _dbContext.MembershipTypes.ToList();
                list.Insert(0, new MembershipType { MembershipTypeId = 0, MembershipName = "Select a Membership" });
                typeList = (list as IEnumerable<MembershipType>);
            }
            catch(Exception exception)
            {
                string message = "Exception Accesing MembershipTypes Table";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);
            }

            return typeList;
        }

        public void Save()
        {
            if (CustomerId != 0)
            {
                SaveExistingCustomer();
            }
            else
            {
                SaveNewCustomer();
            }
        }

        private void SaveNewCustomer()
        {
            try
            {
                VidlyCoreApp.Models.Customer customer = new VidlyCoreApp.Models.Customer
                {
                    Name = this.Name,
                    Address = this.Address,
                    City = this.City,
                    State = this.State,
                    BirthDate = this.BirthDate,
                    MembershipTypeId = this.MembershipTypeId,
                    IsSubscribedToNewsletter = this.IsSubscribedToNewsletter
                };

                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                string message = "Exception Updating Existing Customer";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);

                throw;
            }
        }

        private void SaveExistingCustomer()
        {
            try
            {
                var customerInDb = _dbContext.Customers.Find(CustomerId);

                customerInDb.Name = this.Name;
                customerInDb.Address = this.Address;
                customerInDb.City = this.City;
                customerInDb.State = this.State;
                customerInDb.BirthDate = this.BirthDate;
                customerInDb.MembershipTypeId = this.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = this.IsSubscribedToNewsletter;
                customerInDb.CustomerId = this.CustomerId;

                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                string message = "Exception Updating Existing Customer";

                Debug.Assert(false, message);
                Debug.Assert(false, exception.Message);

                Logger.LogError(exception, message, null);

                throw;
            }
        }
    }
}
