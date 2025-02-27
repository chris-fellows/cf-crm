using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRM.Services
{
    public class EFActivityService : IActivityService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFActivityService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<Activity> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.Activity.OrderBy(i => i.CreatedDateTime).ToList();
            }
        }

        public async Task<List<Activity>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return (await context.Activity.ToListAsync()).OrderBy(i => i.CreatedDateTime).ToList();
            }
        }

        public async Task<Activity> AddAsync(Activity activity)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Activity.Add(activity);
                await context.SaveChangesAsync();
                return activity;
            }
        }

        public async Task<Activity> UpdateAsync(Activity activity)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Activity.Update(activity);
                await context.SaveChangesAsync();
                return activity;
            }
        }

        public async Task<Activity?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var activity = await context.Activity.FirstOrDefaultAsync(i => i.Id == id);
                return activity;
            }
        }

        public async Task<List<Activity>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Activity.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var activity = await context.Activity.FirstOrDefaultAsync(i => i.Id == id);
                if (activity != null)
                {
                    context.Activity.Remove(activity);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<PasswordReset?> GetByUserIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var activity = await context.PasswordReset.FirstOrDefaultAsync(i => i.UserId == id);
                return activity;
            }
        }
    }
}
