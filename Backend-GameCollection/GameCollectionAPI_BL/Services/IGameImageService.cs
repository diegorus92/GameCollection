using GameCollectionAPI_BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.Services
{
    public interface IGameImageService
    {
        public string AddGameImage(GameImageDTO gameImageDto);
    }
}
