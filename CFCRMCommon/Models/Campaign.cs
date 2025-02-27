﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class Campaign
    {
        public string Id { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;

        public string Notes { get; set; } = String.Empty;

        /// <summary>
        /// User that owns campaign
        /// </summary>
        public string OwningUserId { get; set; } = String.Empty;

        public DateTimeOffset StartDateTime { get; set; }

        public DateTimeOffset EndDateTime { get; set; } 

        ///// <summary>
        ///// Campaign contacts
        ///// </summary>
        //public ICollection<ContactReference> Contacts { get; set; }
    }
}
