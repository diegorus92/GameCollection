using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.DTOs
{
    public class GameImageDTO
    {
        public IFormFile GameImage { get; set; }
        public string GameName {  get; set; }
    }
}
