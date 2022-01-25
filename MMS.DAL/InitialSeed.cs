using Microsoft.AspNetCore.Identity;
using MMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DAL
{
    public class InitialSeed
    {
        private readonly RoleManager<Role> roleManager;
        public InitialSeed(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;    
        }

        public async void CreateRoles()
        {
            string[] rolesNames = {
                "Admin",
                "Moderator",
                "User",
                "ArmyManager",
                "StateManager",
                "ConflictManager"
            };

            foreach (var roleName in rolesNames)
            {
                var role = new Role
                {
                    Name = roleName
                };
                this.roleManager.CreateAsync(role).Wait();
            }
        }

    }
}
