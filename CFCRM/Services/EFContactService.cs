﻿using CFCRM.Data;
using CFCRMCommon.Enums;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Licenses;

namespace CFCRM.Services
{
    public class EFContactService : IContactService
    {
        private readonly IDbContextFactory<CFCRMContext> _dbFactory;

        public EFContactService(IDbContextFactory<CFCRMContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public List<Contact> GetAll()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return context.Contact.OrderBy(c => c.LastName)
                      .ThenBy(c => c.LastName)
                      .ToList();
            }
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return (await context.Contact.ToListAsync()).OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
                      
            }
        }

        public async Task<Contact> AddAsync(Contact contact)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Contact.Add(contact);
                await context.SaveChangesAsync();
                return contact;
            }
        }

        public async Task<Contact> UpdateAsync(Contact contact)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                context.Contact.Update(contact);
                await context.SaveChangesAsync();
                return contact;
            }
        }

        public async Task<Contact?> GetByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var contact = await context.Contact
                            .FirstOrDefaultAsync(i => i.Id == id);
                return contact;
            }
        }

        public async Task<List<Contact>> GetByIdsAsync(List<string> ids)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                return await context.Contact
                            .Where(i => ids.Contains(i.Id)).ToListAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var contact = await context.Contact.FirstOrDefaultAsync(i => i.Id == id);
                if (contact != null)
                {
                    context.Contact.Remove(contact);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Contact>> GetByFilterAsync(ContactFilter filter)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var contacts = await context.Contact
                           .Where(i =>
                            (
                                String.IsNullOrEmpty(filter.TextSearch) ||
                                i.FirstName.Contains(filter.TextSearch) ||
                                i.LastName.Contains(filter.TextSearch) ||
                                i.Email.Contains(filter.TextSearch) ||
                                i.Notes.Contains(filter.TextSearch)
                            )
                        )
                        .OrderBy(c => c.LastName)
                        .ThenBy(c => c.FirstName).ToListAsync();              

                return contacts;
            }
        }

        public List<Contact> GetByFilter(ContactFilter filter)
        {
            using (var context = _dbFactory.CreateDbContext())
            {
                var contacts = context.Contact
                          .Where(i =>
                            (
                                String.IsNullOrEmpty(filter.TextSearch) ||
                                i.FirstName.Contains(filter.TextSearch) ||
                                i.LastName.Contains(filter.TextSearch) ||
                                i.Email.Contains(filter.TextSearch) ||
                                i.Notes.Contains(filter.TextSearch)
                            )
                         )
                         .OrderBy(c => c.LastName)
                         .ThenBy(c => c.FirstName).ToList();                    

                return contacts;
            }
        }
    }
}
