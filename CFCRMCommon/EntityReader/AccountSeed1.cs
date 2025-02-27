using CFCRMCommon.Constants;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.EntityReader
{
    public class AccountSeed1 : IEntityReader<Account>
    {
        private readonly IUserService _userService;

        public AccountSeed1(IUserService userService)
        {
            _userService = userService;
        }

        public IEnumerable<Account> Read()
        {
            var users = _userService.GetAll();

            var list = new List<Account>()
            {
                new Account()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Account 1",
                    Notes = "Notes for account",
                    OwningUserId = users[0].Id
                },
                new Account()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Account 2",
                    Notes = "Notes for account",
                    OwningUserId = users[0].Id
                },
                new Account()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Account 3",                    
                    Notes = "Notes for account",                    
                    OwningUserId = users[0].Id
                },
                new Account()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Account 4",
                    Notes = "Notes for account",
                    OwningUserId = users[0].Id
                },
                new Account()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Account 5",
                    Notes = "Notes for account",
                    OwningUserId = users[0].Id
                }
            };

            return list;
        }
    }
}
