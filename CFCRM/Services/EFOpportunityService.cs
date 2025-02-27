using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRM.Services
{
    public class EFOpportunityService : IOpportunityService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFOpportunityService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<Opportunity> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.Opportunity.OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<List<Opportunity>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return (await context.Opportunity.ToListAsync()).OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<Opportunity> AddAsync(Opportunity opportunity)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Opportunity.Add(opportunity);
                await context.SaveChangesAsync();
                return opportunity;
            }
        }

        public async Task<Opportunity> UpdateAsync(Opportunity opportunity)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Opportunity.Update(opportunity);
                await context.SaveChangesAsync();
                return opportunity;
            }
        }

        public async Task<Opportunity?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var opportunity = await context.Opportunity.FirstOrDefaultAsync(i => i.Id == id);
                return opportunity;
            }
        }

        public async Task<List<Opportunity>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Opportunity.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var opportunity = await context.Opportunity.FirstOrDefaultAsync(i => i.Id == id);
                if (opportunity != null)
                {
                    context.Opportunity.Remove(opportunity);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<Opportunity?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var opportunity = await context.Opportunity.FirstOrDefaultAsync(i => i.Name == name);
                return opportunity;
            }
        }
    }
}
