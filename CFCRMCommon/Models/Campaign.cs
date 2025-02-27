using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class Campaign
    {
        [MaxLength(50)]
        public string Id { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(1000)]
        public string Notes { get; set; } = String.Empty;

        /// <summary>
        /// User that owns campaign
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string OwningUserId { get; set; } = String.Empty;

        public DateTimeOffset StartDateTime { get; set; }

        public DateTimeOffset EndDateTime { get; set; } 

        ///// <summary>
        ///// Campaign contacts
        ///// </summary>
        //public ICollection<ContactReference> Contacts { get; set; }
    }
}
