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
        public IEnumerable<Account> Read()
        {
            var list = new List<Account>()
            {
                new Account()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Account 1",
                    Notes = "Notes for account"                   
                },
                new Account()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Account 2",
                    Notes = "Notes for account"
                },
                new Account()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Account 3",
                    Notes = "Notes for account"
                },
                new Account()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Account 4",
                    Notes = "Notes for account"
                },
                new Account()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Account 5",
                    Notes = "Notes for account"
                }               
            };        

            return list;
        }
    }
}
