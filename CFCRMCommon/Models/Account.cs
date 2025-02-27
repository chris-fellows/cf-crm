﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class Account
    {
        [MaxLength(50)]
        public string Id { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;

        [Required]
        [MaxLength(1000)]
        public string Notes { get; set; } = String.Empty;

        [Required]
        [MaxLength(50)]
        public string OwningUserId { get; set; } = String.Empty;
    }
}
