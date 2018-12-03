using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyCoreApp.Models
{
    public class Customer
    {
        public Customer()
        {
        }

        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Key]
        public int CustomerId { get; set; }

        // Implied Foreign Key - Not Supported By SQLite!
        //public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
