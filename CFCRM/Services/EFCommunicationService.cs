using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRM.Services
{
    public class EFCommunicationService : ICommunicationService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFCommunicationService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<Communication> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.Communication.OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<List<Communication>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return (await context.Communication.ToListAsync()).OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<Communication> AddAsync(Communication communication)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Communication.Add(communication);
                await context.SaveChangesAsync();
                return communication;
            }
        }

        public async Task<Communication> UpdateAsync(Communication communication)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Communication.Update(communication);
                await context.SaveChangesAsync();
                return communication;
            }
        }

        public async Task<Communication?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var communication = await context.Communication.FirstOrDefaultAsync(i => i.Id == id);
                return communication;
            }
        }

        public async Task<List<Communication>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Communication.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var communication = await context.Communication.FirstOrDefaultAsync(i => i.Id == id);
                if (communication != null)
                {
                    context.Communication.Remove(communication);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<Communication?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var communication = await context.Communication.FirstOrDefaultAsync(i => i.Name == name);
                return communication;
            }
        }
    }
}
