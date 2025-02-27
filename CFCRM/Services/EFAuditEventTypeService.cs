using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;
using CFCRM.Data;

namespace CFCRMCommon.Services
{
    public class EFAuditEventTypeService : IAuditEventTypeService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFAuditEventTypeService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<AuditEventType> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.AuditEventType.OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<List<AuditEventType>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.AuditEventType.OrderBy(e => e.Name).ToListAsync();
            }
        }

        public async Task<AuditEventType> AddAsync(AuditEventType auditEventType)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.AuditEventType.Add(auditEventType);
                await context.SaveChangesAsync();
                return auditEventType;
            }
        }

        public async Task<AuditEventType> UpdateAsync(AuditEventType auditEventType)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.AuditEventType.Update(auditEventType);
                await context.SaveChangesAsync();
                return auditEventType;
            }
        }

        public async Task<AuditEventType?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var auditEventType = await context.AuditEventType.FirstOrDefaultAsync(i => i.Id == id);
                return auditEventType;
            }
        }

        public async Task<List<AuditEventType>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.AuditEventType.Where(i => ids.Contains(i.Id)).ToListAsync();                
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var auditEventType = await context.AuditEventType.FirstOrDefaultAsync(i => i.Id == id);
                if (auditEventType != null)
                {
                    context.AuditEventType.Remove(auditEventType);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<AuditEventType?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var auditEventType = await context.AuditEventType.FirstOrDefaultAsync(i => i.Name == name);
                return auditEventType;
            }
        }
    }
}
