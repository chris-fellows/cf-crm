﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class Country
    {
        [MaxLength(50)]
        public string Id { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;

        [Required]
        [MaxLength(50)]
        public string Color { get; set; } = String.Empty;

        [Required]
        [MaxLength(50)]
        public string ImageSource { get; set; } = String.Empty;
    }
}
