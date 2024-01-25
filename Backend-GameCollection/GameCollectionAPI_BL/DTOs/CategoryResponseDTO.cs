using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.DTOs
{
    public class CategoryResponseDTO
    {
        public string CategoryName { get; set; }
        public ICollection<string> Games { get; set; } = new List<string>();
    }
}
