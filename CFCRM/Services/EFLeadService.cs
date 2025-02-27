using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRM.Services
{
    public class EFLeadService : ILeadService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFLeadService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<Lead> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.Lead.OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<List<Lead>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Lead.OrderBy(e => e.Name).ToListAsync();
            }
        }

        public async Task<Lead> AddAsync(Lead lead)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Lead.Add(lead);
                await context.SaveChangesAsync();
                return lead;
            }
        }

        public async Task<Lead> UpdateAsync(Lead lead)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Lead.Update(lead);
                await context.SaveChangesAsync();
                return lead;
            }
        }

        public async Task<Lead?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var lead = await context.Lead.FirstOrDefaultAsync(i => i.Id == id);
                return lead;
            }
        }

        public async Task<List<Lead>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Lead.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var lead = await context.Lead.FirstOrDefaultAsync(i => i.Id == id);
                if (lead != null)
                {
                    context.Lead.Remove(lead);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<Lead?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var account = await context.Lead.FirstOrDefaultAsync(i => i.Name == name);
                return account;
            }
        }
    }
}
