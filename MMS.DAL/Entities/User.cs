using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MMS.DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public string RefreshToken { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
