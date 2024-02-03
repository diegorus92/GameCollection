using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.DTOs
{
    public class GameDTO
    {  
        public string GameName { get; set; }
        public int GameRank { get; set; } = 1;
        public string GameSynopsis { get; set; }

        public IFormFile? ImageFile { get; set; }
        public List<string> Categories { get; set; }
        public string DevelopmentCompanyName { get; set; }
    }
}
