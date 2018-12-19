using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyCoreApp.Models
{
    public class MembershipType
    {
        public static readonly byte Prompt = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quarterly = 3;
        public static readonly byte Yearly = 4;

        public MembershipType()
        {
        }

        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string MembershipName { get; set; }

        [Key]
        public byte MembershipTypeId { get; set; }
    }
}
