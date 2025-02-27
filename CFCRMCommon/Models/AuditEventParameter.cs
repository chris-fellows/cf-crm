using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFCRMCommon.Models
{
    /// <summary>
    /// Audit event parameter
    /// </summary>
    public class AuditEventParameter
    {
        /// <summary>
        /// [MaxLength(50)]
        /// </summary>
        public string Id { get; set; } = String.Empty;

        /// <summary>
        /// System Value Type Id
        /// </summary>
        //[Required]
        //[MaxLength(50)]
        //[ForeignKey("SystemValueType")]        
        public string SystemValueTypeId { get; set; } = String.Empty;

        //[DeleteBehavior(DeleteBehavior.NoAction)]
        //public virtual SystemValueType? SystemValueType { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        //[Required]
        //[MaxLength(500)]
        public string Value { get; set; } = String.Empty;
    }
}
