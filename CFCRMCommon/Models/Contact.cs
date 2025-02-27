using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class Contact
    {
        [MaxLength(50)]
        public string Id { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string JobTitle { get; set; } = String.Empty;

        /// <summary>
        /// Job type
        /// </summary>
        [MaxLength(50)]
        public string JobTypeId { get; set; } = String.Empty;

        [MaxLength(50)]
        public string Email { get; set; } = String.Empty;

        [MaxLength(1000)]
        public string Notes { get; set; } = String.Empty;

        /// <summary>
        /// Account (if any) associated with contact. Not set if LeadId is set
        /// </summary>
        [MaxLength(50)]
        public string AccountId { get; set; } = String.Empty;

        /// <summary>
        /// Lead (if any) associated with contact. Not set if AccountId is set.
        /// </summary>
        [MaxLength(50)]
        public string LeadId { get; set; } = String.Empty;

        public bool Active { get; set; }

        //public Address Address { get; set; } = new();

        //public List<PhoneNumber> PhoneNumbers { get; set; } = new();
    }
}
