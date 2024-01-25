using GameCollectionAPI_DAL.Data;
using GameCollectionAPI_DAL.Models;
using GameCollectionAPI_BL.DTOs;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;//use this namespace instead of "System.Data.Entity" to make the asynchronous function work correctly
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GameCollectionAPI_BL.Services
{
    public class RoleService : IRoleService
    {
        private readonly DatabaseContext _databaseContext;

        public RoleService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public string AddRole(Role role)
        {
            Role? myrole = _databaseContext.Roles.FirstOrDefault<Role>(r => role.RoleName.ToLower() == r.RoleName.ToLower());

            if (myrole != null) return $"Role -{role.RoleName}- already exist.";

            _databaseContext.Roles.Add(role);
            _databaseContext.SaveChanges();
            _databaseContext.Dispose();
            return $"Role -{role.RoleName}- added successfuly";
        }

        public async Task<IEnumerable<RoleDTO>> GetRoles() 
        {
            var roles = await _databaseContext.Roles.ToListAsync();
            List<RoleDTO> rolesDto = new List<RoleDTO>();

            _databaseContext.Dispose();

            foreach(Role role in roles)
            {
                rolesDto.Add(new RoleDTO { RoleName = role.RoleName });
            }

            return rolesDto;
        }

        public ICollection<RoleResponseDTO> GetRolesWithUsers()
        {
            List<RoleResponseDTO> response = new List<RoleResponseDTO>();

            ICollection<Role> roles = _databaseContext.Roles.Include(role => role.Users).ToList();
            foreach(Role role in roles)
            {
                response.Add(new RoleResponseDTO {
                    RoleName = role.RoleName, Users = role.Users.Select(user => user.UserNickName).ToList() 
                });
            }

            _databaseContext.Dispose();
            return response;
        }
    }
}
