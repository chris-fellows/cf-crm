using CFCRMCommon.Interfaces;
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
        private readonly IAccountService _accountService;
        private readonly IJobTypeService _jobTypeService;

        public ContactSeed1(IAccountService accountService,
                IJobTypeService jobTypeService)
        {
            _accountService = accountService;
            _jobTypeService = jobTypeService;
        }

        public IEnumerable<Contact> Read()
        {
            var accounts = _accountService.GetAll();
            var jobTypes = _jobTypeService.GetAll();

            var list = new List<Contact>()
            {
                new Contact()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = accounts[0].Id,
                    Active = true,
                    Email = "john.smith@xxxx.com",
                    FirstName = "John",
                    JobTitle = "Procurement Manager",
                    JobTypeId = jobTypes[0].Id,
                    LastName = "Smith",
                    Notes = "Notes for contact",
                    Address = new ContactAddress()
                    {
                       Address = new Address()
                       {
                           Id = Guid.NewGuid().ToString(),
                           Line1 = "Line 1",
                           Line2 = "Line 2",
                           Postcode = "ABC 123",
                           Town = "MyTown"
                       }
                    }
                },
                new Contact()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = accounts[0].Id,
                    Active = true,
                    Email = "jane.smith@xxxx.com",
                    FirstName = "Jane",
                    JobTitle = "Procurement Manager",
                    JobTypeId = jobTypes[0].Id,
                    LastName = "Smith",
                    Notes = "Notes for contact",
                    Address = new ContactAddress()
                    {
                       Address = new Address()
                       {
                           Id = Guid.NewGuid().ToString(),
                           Line1 = "Line 1",
                           Line2 = "Line 2",
                           Postcode = "ABC 123",
                           Town = "MyTown"
                       }
                    }
                },
                new Contact()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = accounts[0].Id,
                    Active = true,
                    Email = "karen.jones@xxxx.com",
                    FirstName = "Karen",
                    JobTitle = "IT Manager",
                    JobTypeId = jobTypes[0].Id,
                    LastName = "Jones",
                    Notes = "Notes for contact",
                    Address = new ContactAddress()
                    {
                       Address = new Address()
                       {
                           Id = Guid.NewGuid().ToString(),
                           Line1 = "Line 1",
                           Line2 = "Line 2",
                           Postcode = "ABC 123",
                           Town = "MyTown"
                       }
                    }
                },
                new Contact()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = accounts[1].Id,
                    Active = true,
                    Email = "alex.green@xxxx.com",
                    FirstName = "Alex",
                    JobTitle = "Procurement Manager",
                    JobTypeId = jobTypes[1].Id,
                    LastName = "Green",
                    Notes = "Notes for contact",
                    Address = new ContactAddress()
                    {
                       Address = new Address()
                       {
                           Id = Guid.NewGuid().ToString(),
                           Line1 = "Line 1",
                           Line2 = "Line 2",
                           Postcode = "ABC 123",
                           Town = "MyTown"
                       }
                    }
                },
                new Contact()
                {
                    Id = Guid.NewGuid().ToString(),
                    AccountId = accounts[1].Id,
                    Active = true,
                    Email = "kevin.alexander@xxxx.com",
                    FirstName = "Kevin",
                    JobTitle = "IT Administrator",
                    JobTypeId = jobTypes[2].Id,
                    LastName = "Alexander",
                    Notes = "Notes for contact",
                    Address = new ContactAddress()
                    {
                       Address = new Address()
                       {
                           Id = Guid.NewGuid().ToString(),
                           Line1 = "Line 1",
                           Line2 = "Line 2",
                           Postcode = "ABC 123",
                           Town = "MyTown"
                       }
                    }
                },
            };
            
            return list;
        }
    }
}
