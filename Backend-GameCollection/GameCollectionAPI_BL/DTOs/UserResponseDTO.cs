using GameCollectionAPI_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.DTOs
{
    public class UserResponseDTO
    {
        public string UserNickName { get; set; }
        public string UserEmail { get; set; }
        public string RoleName { get; set; }
        public List<GameResponseDTO> Games { get; set; } = new List<GameResponseDTO>();
    }
}
