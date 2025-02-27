﻿using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Interfaces
{
    public interface IAccountService : IEntityWithIdNameService<Account, string>
    {
        Task<List<Account>> GetByFilterAsync(AccountFilter filter);

        List<Account> GetByFilter(AccountFilter filter);
    }
}
