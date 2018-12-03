using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using VidlyCoreApp.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace VidlyCoreApp.ViewModels
{
    public class CustomerFormViewModel : CommonViewModel
    {
        public CustomerFormViewModel() : base()
        {
            Mode = FormMode.New;
        }

        public CustomerFormViewModel(int customerId) : base()
        {
            Mode = FormMode.Update;

            var customer = _dbContext.Customers.SingleOrDefault(c => c.CustomerId == customerId);

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

        public CustomerFormViewModel(CustomerFormViewModel model)
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
            catch(Exception e)
            {
                Debug.Assert(false, "Exception Accesing MembershipTypes Table");
                Debug.Assert(false, e.Message);
            }

            return typeList;
        }

        public void SaveNewCustomer()
        {
            VidlyCoreApp.Models.Customer customer = new VidlyCoreApp.Models.Customer();

            customer.Name = this.Name;
            customer.Address = this.Address;
            customer.City = this.City;
            customer.State = this.State;
            customer.BirthDate = this.BirthDate;
            customer.MembershipTypeId = this.MembershipTypeId;
            customer.IsSubscribedToNewsletter = this.IsSubscribedToNewsletter;

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void SaveExistingCustomer(int id)
        {
            var customerInDb = _dbContext.Customers.Single(c => c.CustomerId == id);

            customerInDb.Name = this.Name;
            customerInDb.Address = this.Address;
            customerInDb.City = this.City;
            customerInDb.State = this.State;
            customerInDb.BirthDate = this.BirthDate;
            customerInDb.MembershipTypeId = this.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = this.IsSubscribedToNewsletter;
            customerInDb.CustomerId = id;

            _dbContext.SaveChanges();
        }
    }
}
