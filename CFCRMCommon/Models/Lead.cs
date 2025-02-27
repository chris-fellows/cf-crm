using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    /// <summary>
    /// Lead information. Someone who has expressed interest in the company.
    /// </summary>
    public class Lead
    {
        [MaxLength(50)]
        public string Id { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(1000)]
        public string Notes { get; set; } = String.Empty;        
    }
}
