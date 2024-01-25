using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_DAL.Models
{
    public class GameImage
    {
        public long GameImageId { get; set; }
        public string GameImagePath { get; set; }


        public Game ImageGame { get; set; }
    }
}
