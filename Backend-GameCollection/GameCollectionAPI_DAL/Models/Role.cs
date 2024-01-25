using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_DAL.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }



        public Role(string roleName)
        {
            RoleId = 0;
            RoleName = roleName;
        }

        public ICollection<User>? Users { get; set; } = new List<User>();
    }
}
