using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    /// <summary>
    /// Custom property
    /// </summary>
    public class CustomProperty
    {
        public string Id { get; set; } = String.Empty;

        public string SystemValueTypeId { get; set; } = String.Empty;

        public string Value { get; set; } = String.Empty;
    }
}
