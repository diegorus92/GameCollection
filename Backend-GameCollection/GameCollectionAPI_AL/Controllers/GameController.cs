using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_BL.Services;
using GameCollectionAPI_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameCollectionAPI_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }




        [HttpPost]
        public ActionResult<string>AddGame([FromForm]GameDTO game)
        {
            return Ok(_gameService.AddGame(game));
        }

        [HttpGet]
        public async Task<IEnumerable<GameResponseDTO>> GetGames()
        {
            return await _gameService.GetGames();
        }
    }
}
