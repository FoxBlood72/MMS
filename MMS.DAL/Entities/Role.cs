using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MMS.DAL.Entities
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
