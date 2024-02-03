using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.DTOs
{
    public class DevelopmentCompanyDTO
    {
        public string DevelopmentCompanyName { get; set; }
        public IFormFile File { get; set; }//After we'll use info into this property to take the final image path and save it in DB
    }
}
