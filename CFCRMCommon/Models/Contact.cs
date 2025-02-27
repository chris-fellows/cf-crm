using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class Contact
    {
        public string Id { get; set; } = String.Empty;

        public string FirstName { get; set; } = String.Empty;

        public string LastName { get; set; } = String.Empty;

        public string JobTitle { get; set; } = String.Empty;

        /// <summary>
        /// Job type
        /// </summary>
        public string JobTypeId { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Notes { get; set; } = String.Empty;

        public string AccountId { get; set; } = String.Empty;

        public bool Active { get; set; }

        //public Address Address { get; set; } = new();

        //public List<PhoneNumber> PhoneNumbers { get; set; } = new();
    }
}
