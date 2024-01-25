using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.DTOs
{
    public class RoleResponseDTO
    {
        public string RoleName { get; set; }
        public List<string> Users { get; set; } = new List<string>();
    }
}
