using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRM.Services
{
    public class EFCommunicationTypeService : ICommunicationTypeService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFCommunicationTypeService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<CommunicationType> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.CommunicationType.OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<List<CommunicationType>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return (await context.CommunicationType.ToListAsync()).OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<CommunicationType> AddAsync(CommunicationType communicationType)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.CommunicationType.Add(communicationType);
                await context.SaveChangesAsync();
                return communicationType;
            }
        }

        public async Task<CommunicationType> UpdateAsync(CommunicationType communicationType)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.CommunicationType.Update(communicationType);
                await context.SaveChangesAsync();
                return communicationType;
            }
        }

        public async Task<CommunicationType?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var communicationType = await context.CommunicationType.FirstOrDefaultAsync(i => i.Id == id);
                return communicationType;
            }
        }

        public async Task<List<CommunicationType>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.CommunicationType.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var communicationType = await context.CommunicationType.FirstOrDefaultAsync(i => i.Id == id);
                if (communicationType != null)
                {
                    context.CommunicationType.Remove(communicationType);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<CommunicationType?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var communicationType = await context.CommunicationType.FirstOrDefaultAsync(i => i.Name == name);
                return communicationType;
            }
        }
    }
}
