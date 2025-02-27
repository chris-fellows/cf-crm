﻿using System;
using System.Collections.Generic;
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
        public string Id { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;

        public string Notes { get; set; } = String.Empty;        
    }
}
