using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameCollectionAPI_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameImageController : ControllerBase
    {
        private readonly IGameImageService _gameImageService;

        public GameImageController(IGameImageService gameImageService)
        {
            _gameImageService = gameImageService;
        }



        [HttpPost]
        public ActionResult<string> AddGameImage([FromForm] GameImageDTO gameImageDto)
        {
            return Ok(_gameImageService.AddGameImage(gameImageDto));
        }
    }
}
