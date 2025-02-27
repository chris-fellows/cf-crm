using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRM.Services
{
    public class EFCaseTypeService : ICaseTypeService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFCaseTypeService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<CaseType> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.CaseType.OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<List<CaseType>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return (await context.CaseType.ToListAsync()).OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<CaseType> AddAsync(CaseType caseType)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.CaseType.Add(caseType);
                await context.SaveChangesAsync();
                return caseType;
            }
        }

        public async Task<CaseType> UpdateAsync(CaseType caseType)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.CaseType.Update(caseType);
                await context.SaveChangesAsync();
                return caseType;
            }
        }

        public async Task<CaseType?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var caseType = await context.CaseType.FirstOrDefaultAsync(i => i.Id == id);
                return caseType;
            }
        }

        public async Task<List<CaseType>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.CaseType.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var caseType = await context.CaseType.FirstOrDefaultAsync(i => i.Id == id);
                if (caseType != null)
                {
                    context.CaseType.Remove(caseType);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<CaseType?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var caseType = await context.CaseType.FirstOrDefaultAsync(i => i.Name == name);
                return caseType;
            }
        }
    }
}
