﻿using CFCRM.Data;
using CFCRMCommon.Enums;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRMCommon.Services
{
    public class EFUserService : IUserService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;
        private readonly IPasswordService _passwordService;

        public EFUserService(IDbContextFactory<CFCRMContext> dbFactory,
                            IPasswordService passwordService)
        {
            _dbFactory = dbFactory;
            _passwordService = passwordService;
        }

        public List<User> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.User.OrderBy(u => u.Name).ToList();
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.User.OrderBy(u => u.Name).ToListAsync();
            }
        }

        public async Task<User> AddAsync(User user)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.User.Add(user);
                await context.SaveChangesAsync();
                return user;
            }
        }

        public async Task<User> UpdateAsync(User user)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.User.Update(user);
                await context.SaveChangesAsync();
                return user;
            }
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var user = await context.User.FirstOrDefaultAsync(i => i.Id == id);
                return user;
            }
        }

        public async Task<List<User>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.User.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var user = await context.User.FirstOrDefaultAsync(i => i.Id == id);
                if (user != null)
                {
                    context.User.Remove(user);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<User?> ValidateCredentialsAsync(string username, string password)                                                        
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var user = await context.User.FirstOrDefaultAsync(i => i.Email == username);
                if (user != null &&
                    user.Active &&
                    user.GetUserType() == UserTypes.Normal &&
                    _passwordService.IsValid(user.Password, password, user.Salt))                    
                {
                    return user;
                }
                return null;
            }
        }

        public User? GetById(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var user = context.User.FirstOrDefault(i => i.Id == id);
                return user;
            }
        }
    }
}
