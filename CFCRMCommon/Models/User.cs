using CFCRMCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class User
    {
        public string Id { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Role { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public string Salt { get; set; } = String.Empty;

        public bool Active { get; set; }

        public string Color { get; set; } = String.Empty;

        public string ImageSource { get; set; } = String.Empty;

        public UserTypes GetUserType() => Name.Equals("System") ?
                    UserTypes.System : UserTypes.Normal;
    }
}
