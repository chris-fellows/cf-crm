using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.EntityReader
{
    public class LeadSeed1 : IEntityReader<Lead>
    {
        public IEnumerable<Lead> Read()
        {
            var list = new List<Lead>()
            {
                new Lead()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lead 1",
                    Notes = "Lead notes"                    
                },
                new Lead()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lead 2",
                    Notes = "Lead notes"
                },
                new Lead()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lead 3",
                    Notes = "Lead notes"
                },
                new Lead()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lead 4",
                    Notes = "Lead notes"
                },
                new Lead()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lead 1",
                    Notes = "Lead notes"
                }
            };

            return list;
        }
    }
}
