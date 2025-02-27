using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class Address
    {
        public string Id { get; set; } = String.Empty;

        public string Line1 { get; set; } = String.Empty;

        public string Line2 { get; set; } = String.Empty;

        public string Town { get; set; } = String.Empty;

        public string Postcode { get; set; } = String.Empty;

        public string CountryId { get; set; } = String.Empty;
    }
}
