using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Interfaces
{
    public interface IContactService : IEntityWithIdService<Contact, string>
    {
        Task<List<Contact>> GetByFilterAsync(ContactFilter filter);

        List<Contact> GetByFilter(ContactFilter filter);
    }
}
