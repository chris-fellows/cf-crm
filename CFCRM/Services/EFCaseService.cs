//using CFCRM.Data;
//using CFCRMCommon.Interfaces;
//using CFCRMCommon.Models;
//using Microsoft.EntityFrameworkCore;

//namespace CFCRM.Services
//{
//    public class EFCaseService : ICaseService
//    {
//        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

//        public EFCaseService(IDbContextFactory<CFCRMContext> dbFactory)
//        {
//            _dbFactory = dbFactory;
//        }

//        public List<Case> GetAll()
//        {
//            using (var context = _dbFactory.CreateDbContext())
//            {
//                return context.Case.OrderBy(u => u.Name).ToList();
//            }
//        }

//        public async Task<List<Case>> GetAllAsync()
//        {
//            using (var context = _dbFactory.CreateDbContext())
//            {
//                return (await context.Case.ToListAsync()).OrderBy(u => u.Name).ToList();
//            }
//        }

//        public async Task<Case> AddAsync(Case caseObject)
//        {
//            using (var context = _dbFactory.CreateDbContext())
//            {
//                context.Case.Add(caseObject);
//                await context.SaveChangesAsync();
//                return caseObject;
//            }
//        }

//        public async Task<Case> UpdateAsync(Case caseObject)
//        {
//            using (var context = _dbFactory.CreateDbContext())
//            {
//                context.Case.Update(caseObject);
//                await context.SaveChangesAsync();
//                return caseObject;
//            }
//        }

//        public async Task<Case?> GetByIdAsync(string id)
//        {
//            using (var context = _dbFactory.CreateDbContext())
//            {
//                var caseObject = await context.Case.FirstOrDefaultAsync(i => i.Id == id);
//                return caseObject;
//            }
//        }

//        public async Task<List<Case>> GetByIdsAsync(List<string> ids)
//        {
//            using (var context = _dbFactory.CreateDbContext())
//            {
//                return await context.Case.Where(i => ids.Contains(i.Id)).ToListAsync();
//            }
//        }

//        public async Task DeleteByIdAsync(string id)
//        {
//            using (var context = _dbFactory.CreateDbContext())
//            {
//                var caseObject = await context.Case.FirstOrDefaultAsync(i => i.Id == id);
//                if (caseObject != null)
//                {
//                    context.Case.Remove(caseObject);
//                    await context.SaveChangesAsync();
//                }
//            }
//        }

//        public Case? GetById(string id)
//        {
//            using (var context = _dbFactory.CreateDbContext())
//            {
//                var caseObject = context.Case.FirstOrDefault(i => i.Id == id);
//                return caseObject;
//            }
//        }

//        public async Task<Case?> GetByNameAsync(string name)
//        {
//            using (var context = _dbFactory.CreateDbContext())
//            {
//                var caseObject = await context.Case.FirstOrDefaultAsync(i => i.Name == name);
//                return caseObject;
//            }
//        }
//    }
//}
