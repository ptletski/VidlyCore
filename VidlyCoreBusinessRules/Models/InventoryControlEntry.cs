using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyCoreApp.Models
{
    public class InventoryControlEntry
    {
        public InventoryControlEntry()
        {
        }

        public int MovieId { get; set; }
        public int ContentProviderId { get; set; }
        public short PermittedUsageCount { get; set; }

        [Key]
        public int InventoryControlId { get; set; }
    }
}
