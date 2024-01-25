using GameCollectionAPI_BL.Services;
using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameCollectionAPI_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }



        [HttpPost]
        public ActionResult<string> AddRole(RoleDTO role)
        {
            Role newRole = new Role(role.RoleName);

            return Ok(_roleService.AddRole(newRole));
        }

        [HttpGet]
        public async Task<IEnumerable<RoleDTO>> GetRoles()
        {
            return await _roleService.GetRoles();
        }

        [HttpGet("roles_users")]
        public ActionResult<ICollection<RoleResponseDTO>> GetRolesWithUsers()
        {
            return Ok(_roleService.GetRolesWithUsers());
        }
    }
}
