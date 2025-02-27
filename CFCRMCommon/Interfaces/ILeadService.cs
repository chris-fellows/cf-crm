using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Interfaces
{
    public interface ILeadService : IEntityWithIdNameService<Lead, string>
    {
    }
}
