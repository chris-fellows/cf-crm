﻿using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Interfaces
{
    public interface IAuditEventService : IEntityWithIdService<AuditEvent, string>
    {
        Task<List<AuditEvent>> GetByFilterAsync(AuditEventFilter auditEventFilter);

        List<AuditEvent> GetByFilter(AuditEventFilter auditEventFilter);
    }
}
