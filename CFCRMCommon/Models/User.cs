using CFCRMCommon.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.Models
{
    public class User
    {
        [MaxLength(150)]
        public string Id { get; set; } = String.Empty;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;

        [MaxLength(100)]
        public string Email { get; set; } = String.Empty;

        [MaxLength(50)]
        public string Role { get; set; } = String.Empty;

        [Required]
        [MaxLength(150)]
        public string Password { get; set; } = String.Empty;

        [Required]
        [MaxLength(150)]
        public string Salt { get; set; } = String.Empty;

        public bool Active { get; set; }

        [Required]
        [MaxLength(50)]
        public string Color { get; set; } = String.Empty;

        [Required]
        [MaxLength(50)]
        public string ImageSource { get; set; } = String.Empty;

        public UserTypes GetUserType() => Name.Equals("System") ?
                    UserTypes.System : UserTypes.Normal;
    }
}
