using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    /// <summary>
    /// Communication
    /// </summary>
    public class Communication
    {
        public string Id { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// Communication Type Id
        /// </summary>
        public string TypeId { get; set; } = String.Empty;

        /// <summary>
        /// Campaign (if any) that communication relates to
        /// </summary>
        public string CampaignId { get; set; } = String.Empty;

        /// <summary>
        /// Account (if any) that communication relates to
        /// </summary>
        public string AccountId { get; set; } = String.Empty;

        /// <summary>
        /// Contact (if any) that communication relates to
        /// </summary>
        public string ContactId { get; set; } = String.Empty;

        public string CreatedUserId { get; set; } = String.Empty;

        public DateTimeOffset CreatedDateTime { get; set; }
    }
}
