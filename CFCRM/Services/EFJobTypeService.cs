using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRM.Services
{
    public class EFJobTypeService : IJobTypeService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFJobTypeService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<JobType> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.JobType.OrderBy(u => u.Name).ToList();
            }
        }

        public async Task<List<JobType>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.JobType.OrderBy(u => u.Name).ToListAsync();
            }
        }

        public async Task<JobType> AddAsync(JobType jobType)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.JobType.Add(jobType);
                await context.SaveChangesAsync();
                return jobType;
            }
        }

        public async Task<JobType> UpdateAsync(JobType jobType)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.JobType.Update(jobType);
                await context.SaveChangesAsync();
                return jobType;
            }
        }

        public async Task<JobType?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var jobType = await context.JobType.FirstOrDefaultAsync(i => i.Id == id);
                return jobType;
            }
        }

        public async Task<List<JobType>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.JobType.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var jobType = await context.JobType.FirstOrDefaultAsync(i => i.Id == id);
                if (jobType != null)
                {
                    context.JobType.Remove(jobType);
                    await context.SaveChangesAsync();
                }
            }
        }

        public JobType? GetById(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var jobType = context.JobType.FirstOrDefault(i => i.Id == id);
                return jobType;
            }
        }

        public async Task<JobType?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var jobType = await context.JobType.FirstOrDefaultAsync(i => i.Name == name);
                return jobType;
            }
        }
    }
}
