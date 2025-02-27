using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CFCRMCommon.Models;

namespace CFCRM.Data
{
    public class CFCRMContext : DbContext
    {
        public CFCRMContext (DbContextOptions<CFCRMContext> options)
            : base(options)
        {
        }
        public DbSet<CFCRMCommon.Models.AuditEvent> AuditEvent { get; set; } = default!;
        public DbSet<CFCRMCommon.Models.AuditEventType> AuditEventType { get; set; } = default!;

        public DbSet<CFCRMCommon.Models.JobType> JobType { get; set; } = default!;
        public DbSet<CFCRMCommon.Models.PasswordReset> PasswordReset { get; set; } = default!;
        public DbSet<CFCRMCommon.Models.User> User { get; set; } = default!;
        public DbSet<CFCRMCommon.Models.Account> Account { get; set; } = default!;
        public DbSet<CFCRMCommon.Models.Contact> Contact { get; set; } = default!;

        public DbSet<CFCRMCommon.Models.SystemValueType> SystemValueType { get; set; } = default!;
    }
}
