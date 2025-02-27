using CFCRMCommon.Constants;
using CFCRMCommon.Models;

namespace CFCRMCommon.EntityReader
{
    public class SystemValueTypeSeed1 : IEntityReader<SystemValueType>
    {
        public IEnumerable<SystemValueType> Read()
        {
            var list = new List<SystemValueType>()
            {
                new SystemValueType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = SystemValueTypeNames.AuditEventId
                },
                new SystemValueType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = SystemValueTypeNames.AuditEventTypeId
                },               
                new SystemValueType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = SystemValueTypeNames.PasswordResetId
                },              
                new SystemValueType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = SystemValueTypeNames.UserId
                }
            };

            return list;
        }
    }
}
