using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;

namespace CFCRMCommon.Services
{
    public class EFAccountService : IAccountService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFAccountService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<Account> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.Account.OrderBy(e => e.Name).ToList();
            }
        }

        public async Task<List<Account>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Account
                        .OrderBy(e => e.Name)
                        .ToListAsync();
            }
        }

        public async Task<Account> AddAsync(Account account)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Account.Add(account);
                await context.SaveChangesAsync();
                return account;
            }
        }

        public async Task<Account> UpdateAsync(Account account)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Account.Update(account);
                await context.SaveChangesAsync();
                return account;
            }
        }

        public async Task<Account?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var account = await context.Account.FirstOrDefaultAsync(i => i.Id == id);
                return account;
            }
        }

        public async Task<List<Account>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Account.Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var account = await context.Account.FirstOrDefaultAsync(i => i.Id == id);
                if (account != null)
                {
                    context.Account.Remove(account);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<Account?> GetByNameAsync(string name)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var account = await context.Account.FirstOrDefaultAsync(i => i.Name == name);
                return account;
            }
        }

        public async Task<List<Account>> GetByFilterAsync(AccountFilter filter)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var accounts = await context.Account                           
                           .Where(i =>
                            (
                                String.IsNullOrEmpty(filter.TextSearch) ||
                                i.Name.Contains(filter.TextSearch) ||
                                i.Notes.Contains(filter.TextSearch)
                            ) &&
                            (
                                filter.OwningUserIds == null ||
                                !filter.OwningUserIds.Any() ||
                                filter.OwningUserIds.Contains(i.OwningUserId)
                            )
                        )
                        .OrderBy(e => e.Name).ToListAsync();                        

                return accounts;
            }
        }

        public List<Account> GetByFilter(AccountFilter filter)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var accounts = context.Account
                          .Where(i =>
                            (
                               String.IsNullOrEmpty(filter.TextSearch) ||
                                i.Name.Contains(filter.TextSearch) ||
                                i.Notes.Contains(filter.TextSearch)
                            ) &&
                            (
                                filter.OwningUserIds == null ||
                                !filter.OwningUserIds.Any() ||
                                filter.OwningUserIds.Contains(i.OwningUserId)
                            )
                         )
                         .OrderBy(i => i.Name).ToList();                    

                return accounts;
            }
        }
    }
}
