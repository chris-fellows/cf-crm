using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRM.Services
{
    public class EFCountryService : ICountryService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFCountryService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<Country> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.Country.OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<List<Country>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Country.OrderBy(e => e.Name).ToListAsync();
            }
        }

        public async Task<Country> AddAsync(Country country)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Country.Add(country);
                await context.SaveChangesAsync();
                return country;
            }
        }

        public async Task<Country> UpdateAsync(Country country)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Country.Update(country);
                await context.SaveChangesAsync();
                return country;
            }
        }

        public async Task<Country?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var country = await context.Country.FirstOrDefaultAsync(i => i.Id == id);
                return country;
            }
        }

        public async Task<List<Country>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Country.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var country = await context.Country.FirstOrDefaultAsync(i => i.Id == id);
                if (country != null)
                {
                    context.Country.Remove(country);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<Country?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var country = await context.Country.FirstOrDefaultAsync(i => i.Name == name);
                return country;
            }
        }
    }
}
