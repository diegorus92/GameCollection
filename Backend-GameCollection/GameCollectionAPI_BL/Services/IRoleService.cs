using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_DAL.Models;

namespace GameCollectionAPI_BL.Services
{
    public interface IRoleService
    {
        public string AddRole(Role role);
        public Task<IEnumerable<RoleDTO>> GetRoles();
        public ICollection<RoleResponseDTO> GetRolesWithUsers();
    }
}
