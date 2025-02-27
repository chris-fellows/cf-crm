using CFCRMCommon.Constants;
using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.EntityReader
{
    /// <summary>
    /// Audit event type seed #1
    /// </summary>
    public class AuditEventTypeSeed1 : IEntityReader<AuditEventType>
    {
        public IEnumerable<AuditEventType> Read()
        {
            var list = new List<AuditEventType>()
            {
                new AuditEventType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = AuditEventTypeNames.Error,
                    Color = Color.Red.ToArgb().ToString(),
                    ImageSource = "audit_event_type.png"
                },               
                new AuditEventType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = AuditEventTypeNames.PasswordResetCreated,
                    Color = Color.Red.ToArgb().ToString(),
                    ImageSource = "audit_event_type.png"
                },
                new AuditEventType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = AuditEventTypeNames.PasswordUpdated,
                    Color = Color.Red.ToArgb().ToString(),
                    ImageSource = "audit_event_type.png"
                },           
                new AuditEventType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = AuditEventTypeNames.UserCreated,
                    Color = Color.Red.ToArgb().ToString(),
                    ImageSource = "audit_event_type.png"
                },
                new AuditEventType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = AuditEventTypeNames.UserLogInSuccess,
                    Color = Color.Red.ToArgb().ToString(),
                    ImageSource = "audit_event_type.png"
                },
                new AuditEventType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = AuditEventTypeNames.UserLogOut,
                    Color = Color.Red.ToArgb().ToString(),
                    ImageSource = "audit_event_type.png"
                },
                new AuditEventType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = AuditEventTypeNames.UserLogInError,
                    Color = Color.Red.ToArgb().ToString(),
                    ImageSource = "audit_event_type.png"
                },
                new AuditEventType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = AuditEventTypeNames.UserUpdated,
                    Color = Color.Red.ToArgb().ToString(),
                    ImageSource = "audit_event_type.png"
                }
            };

            return list;
        }
    }
}
