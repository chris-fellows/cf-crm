using CFCRM.Data;
using CFCRMCommon.Enums;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Services
{
    public class EFSystemValueTypeService : ISystemValueTypeService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFSystemValueTypeService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<SystemValueType> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.SystemValueType.OrderBy(u => u.Name).ToList();
            }
        }

        public async Task<List<SystemValueType>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return (await context.SystemValueType.ToListAsync()).OrderBy(u => u.Name).ToList();
            }
        }

        public async Task<SystemValueType> AddAsync(SystemValueType systemValueType)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.SystemValueType.Add(systemValueType);
                await context.SaveChangesAsync();
                return systemValueType;
            }
        }

        public async Task<SystemValueType> UpdateAsync(SystemValueType systemValueType)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.SystemValueType.Update(systemValueType);
                await context.SaveChangesAsync();
                return systemValueType;
            }
        }

        public async Task<SystemValueType?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var systemValueType = await context.SystemValueType.FirstOrDefaultAsync(i => i.Id == id);
                return systemValueType;
            }
        }

        public async Task<List<SystemValueType>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.SystemValueType.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var systemValueType = await context.SystemValueType.FirstOrDefaultAsync(i => i.Id == id);
                if (systemValueType != null)
                {
                    context.SystemValueType.Remove(systemValueType);
                    await context.SaveChangesAsync();
                }
            }
        }

        public SystemValueType? GetById(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var systemValueType = context.SystemValueType.FirstOrDefault(i => i.Id == id);
                return systemValueType;
            }
        }

        public async Task<SystemValueType?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var systemValueType = await context.SystemValueType.FirstOrDefaultAsync(i => i.Name == name);
                return systemValueType;
            }
        }
    }
}
