using CFCRMCommon.Constants;
using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.EntityReader
{
    public class JobTypeSeed1 : IEntityReader<JobType>
    {

        public IEnumerable<JobType> Read()
        {
            var list = new List<JobType>()
            {
                new JobType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Unknown",
                },
                new JobType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "IT",
                },
                new JobType()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Procurement",
                },
            };

            return list;
        }
    }
}
