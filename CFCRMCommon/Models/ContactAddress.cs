using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class ContactAddress
    {
        [Key]
        [ForeignKey("Contact")]
        public string Id { get; set; } = String.Empty;       

        public Address Address { get; set; } = new();

        public virtual Contact Contact { get; set; }
    }
}
