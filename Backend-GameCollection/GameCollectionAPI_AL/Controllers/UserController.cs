using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_BL.Services;
using GameCollectionAPI_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GameCollectionAPI_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost("register")]
        public ActionResult<string> Register(UserDTO userDto)
        {
            return Ok(_userService.AddUser(userDto));
        }

        [HttpGet]
        public async Task<IEnumerable<UserResponseDTO>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UserResponseDTO>> GetUserByEmail(string email)
        {
            UserResponseDTO userResponseDto = await _userService.GetUserByEmail(email);
            if (userResponseDto != null) return Ok(userResponseDto);
            return NotFound(null);
        }
    }
}
