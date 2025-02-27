using CFCRMCommon.Models;

namespace CFCRM.Utilities
{
    public static class UIUtilities
    {
        public static string AnyId = Guid.Empty.ToString();

        private const string _anyText = "Any";

        public static void AddAny(List<AuditEventType> auditEventTypes)
        {
            auditEventTypes.Insert(0, new AuditEventType()
            {
                Id = AnyId,
                Name = _anyText
            });
        }

        public static void AddAny(List<JobType> jobTypes)
        {
            jobTypes.Insert(0, new JobType()
            {
                Id = AnyId,
                Name = _anyText
            });
        }
    }
}
