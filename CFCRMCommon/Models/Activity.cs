namespace CFCRMCommon.Models
{
    /// <summary>
    /// Activity that required someone to take action. E.g. User is tasked with contacting a customer about a
    /// possible sale. E.g. Problem raised by user.
    /// 
    /// It's created by a contact/user and assigned to a contact/user.        
    public class Activity
    {
        public string Id { get; set; } = String.Empty;

        /// <summary>
        /// Activity type (ActivityType.Id)
        /// </summary>
        public string TypeId { get; set; } = String.Empty;

        /// <summary>
        /// Activity status (ActivityStatus.Id)
        /// </summary>
        public string StatusId { get; set; } = String.Empty;

        /// <summary>
        /// Notes
        /// </summary>
        public string Notes { get; set; } = String.Empty;

        /// <summary>
        /// When activity must be completed by
        /// </summary>
        public DateTimeOffset CompletedByDateTime { get; set; }

        /// <summary>
        /// When created
        /// </summary>
        public DateTimeOffset CreatedDateTime { get; set; }

        /// <summary>
        /// Contact (if any) that created
        /// </summary>
        public string CreatedContactId { get; set; } = String.Empty;

        /// <summary>
        /// User (if any) that created
        /// </summary>
        public string CreatedUserId { get; set; } = String.Empty;

        /// <summary>
        /// Contact (if any) that activity is assigned to
        /// </summary>
        public string AssignedContactId { get; set; } = String.Empty;

        /// <summary>
        /// User (if any) that activity is assigned to
        /// </summary>
        public string AssignedUserId { get; set; } = String.Empty;

        /// <summary>
        /// Campaign (if any) that activity is associated with
        /// </summary>
        public string CampaignId { get; set; } = String.Empty;
    }
}
