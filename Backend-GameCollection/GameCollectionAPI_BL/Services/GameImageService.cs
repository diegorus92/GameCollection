using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_DAL.Data;
using GameCollectionAPI_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.Services
{
    public class GameImageService : IGameImageService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly string _imagePath;

        public GameImageService(DatabaseContext databaseContext, IConfiguration config)
        {
            _databaseContext = databaseContext;
            _imagePath = config.GetSection("Configuration").GetSection("ImagePath").Value;
        }


        public string AddGameImage(GameImageDTO gameImageDto)
        {
            Game? game = _databaseContext.Games.FirstOrDefault(game => game.GameName.ToLower() == gameImageDto.GameName.ToLower());
            if (game == null) return $"Game: -{gameImageDto.GameName}- doesn't exist!";

            GameImage gameImage = new GameImage();
            string path;

            //Images processing///////////////////
            if (gameImageDto.GameImage == null) return "No Image file added";
            string extensionImage = gameImageDto.GameImage.FileName.Split('.')[1]; //Verify valid extension image
            if (extensionImage != "jpg" && extensionImage != "png") return $"Invalid image extension: -{gameImageDto.GameImage.FileName}-";
                
                try
                {
                    path = Path.Combine(_imagePath, gameImageDto.GameImage.FileName);
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        gameImageDto.GameImage.CopyTo(fs);
                    }
                }
                catch (Exception ex)
                {
                    return $"Error during Image Processing: --> {ex.Message}. Image name: -{gameImageDto.GameImage.FileName}-";
                }
            ////////////////////////////////////////

            gameImage.GameImagePath = path;
            gameImage.ImageGame = game;
            _databaseContext.GameImages.Add(gameImage);

            game.GameImages.Add(gameImage);

            _databaseContext.SaveChanges();
            _databaseContext.Dispose();

            return $"New images for game: -{game.GameName}- saved successfully";
        }
    }
}
