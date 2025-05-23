﻿using System.ComponentModel.DataAnnotations;

namespace CFCRMCommon.Models
{
    /// <summary>
    /// System value type
    /// </summary>
    public class SystemValueType
    {
        [MaxLength(50)]
        public string Id { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;
    }
}
