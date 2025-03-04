﻿using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRMCommon.Services
{
    public class EFPasswordResetService : IPasswordResetService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFPasswordResetService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<PasswordReset> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.PasswordReset.OrderBy(i => i.CreatedDateTime).ToList();
            }
        }

        public async Task<List<PasswordReset>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.PasswordReset.OrderBy(i => i.CreatedDateTime).ToListAsync();
            }
        }

        public async Task<PasswordReset> AddAsync(PasswordReset passwordReset)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.PasswordReset.Add(passwordReset);
                await context.SaveChangesAsync();
                return passwordReset;
            }
        }

        public async Task<PasswordReset> UpdateAsync(PasswordReset passwordReset)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.PasswordReset.Update(passwordReset);
                await context.SaveChangesAsync();
                return passwordReset;
            }
        }

        public async Task<PasswordReset?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var passwordReset = await context.PasswordReset.FirstOrDefaultAsync(i => i.Id == id);
                return passwordReset;
            }
        }

        public async Task<List<PasswordReset>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.PasswordReset.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var passwordReset = await context.PasswordReset.FirstOrDefaultAsync(i => i.Id == id);
                if (passwordReset != null)
                {
                    context.PasswordReset.Remove(passwordReset);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<PasswordReset?> GetByUserIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var passwordReset = await context.PasswordReset.FirstOrDefaultAsync(i => i.UserId == id);
                return passwordReset;
            }
        }
    }
}
