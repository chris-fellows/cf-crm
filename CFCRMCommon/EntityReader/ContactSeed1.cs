using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.EntityReader
{
    public class ContactSeed1 : IEntityReader<Contact>
    {
        public IEnumerable<Contact> Read()
        {
            var list = new List<Contact>()
            {
                new Contact()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = "",                    
                    Active = true,
                    Email = "john.smith@xxxx.com",
                    FirstName = "John",
                    JobTitle = "Procurement Manager",
                    JobTypeId = "",
                    LastName = "Smith",                                                                            
                    Notes = "Notes for contact"
                },
                new Contact()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = "",
                    Active = true,
                    Email = "jane.smith@xxxx.com",
                    FirstName = "Jane",
                    JobTitle = "Procurement Manager",
                    JobTypeId = "",
                    LastName = "Smith",
                    Notes = "Notes for contact"
                },
                new Contact()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = "",
                    Active = true,
                    Email = "karen.jones@xxxx.com",
                    FirstName = "Karen",
                    JobTitle = "IT Manager",
                    JobTypeId = "",
                    LastName = "Jones",
                    Notes = "Notes for contact"
                },
                new Contact()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = "",
                    Active = true,
                    Email = "alex.green@xxxx.com",
                    FirstName = "Alex",
                    JobTitle = "Procurement Manager",
                    JobTypeId = "",
                    LastName = "Green",
                    Notes = "Notes for contact"
                },
                new Contact()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = "",
                    Active = true,
                    Email = "kevin.alexander@xxxx.com",
                    FirstName = "Kevin",
                    JobTitle = "IT Administrator",
                    JobTypeId = "",
                    LastName = "Alexander",
                    Notes = "Notes for contact"
                },
            };

            return list;
        }
    }
}
