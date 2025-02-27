using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class AccountFilter
    {
        public string? TextSearch { get; set; }

        public List<string>? OwningUserIds { get; set; }
    }
}
