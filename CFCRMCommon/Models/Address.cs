using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class Address
    {
        [MaxLength(50)]
        public string Id { get; set; } = String.Empty;

        [MaxLength(100)]
        public string Line1 { get; set; } = String.Empty;

        [MaxLength(100)]
        public string Line2 { get; set; } = String.Empty;

        [MaxLength(50)]
        public string Town { get; set; } = String.Empty;

        [MaxLength(20)]
        public string Postcode { get; set; } = String.Empty;

        [MaxLength(50)]
        public string CountryId { get; set; } = String.Empty;
    }
}
