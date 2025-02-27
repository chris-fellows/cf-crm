using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRM.Services
{
    public class EFProductService : IProductService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFProductService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<Product> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.Product.OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Product.OrderBy(p => p.Name).ToListAsync();
            }
        }

        public async Task<Product> AddAsync(Product product)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Product.Add(product);
                await context.SaveChangesAsync();
                return product;
            }
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Product.Update(product);
                await context.SaveChangesAsync();
                return product;
            }
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var product = await context.Product.FirstOrDefaultAsync(i => i.Id == id);
                return product;
            }
        }

        public async Task<List<Product>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Product.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var product = await context.Product.FirstOrDefaultAsync(i => i.Id == id);
                if (product != null)
                {
                    context.Product.Remove(product);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<Product?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var product = await context.Product.FirstOrDefaultAsync(i => i.Name == name);
                return product;
            }
        }
    }
}
