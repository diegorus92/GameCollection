using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_DAL.Data;
using GameCollectionAPI_DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.Services
{
    public class GameService : IGameService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly string _imagePath;

        public GameService(DatabaseContext databaseContext, IConfiguration config)
        {
            _databaseContext = databaseContext;
            _imagePath = config.GetSection("Configuration").GetSection("ImagePath").Value;
        }



        public string AddGame(GameDTO game)
        {
            //Looking for User
            User? user = _databaseContext.Users.FirstOrDefault(u => u.UserId == game.UserId);
            if (user == null) return $"User -<{game.UserId}>- doesn't exist";

            //Check if The game already exist into a User
            Game gameToSave = user.UserGames.FirstOrDefault(g => g.GameName == game.GameName);
            if (gameToSave != null) return $"this game -<{game.GameName}>- already exist for this user: {user.UserId}";

            gameToSave = new Game();

            gameToSave.GameName = game.GameName;
            gameToSave.GameRank = (game.GameRank >= 1 && game.GameRank <= 5) ? game.GameRank : 1;
            gameToSave.GameSynopsis = game.GameSynopsis;

            //Image processing///////////////////////////////
            if(game.ImageFile == null) //no image added
            {
                gameToSave.GameImage = "";
            }
            else                      //Image added
            {
                string imagePath = "";
                string extension = game.ImageFile.FileName.Split(".")[1];
                if(extension != "jpg" && extension != "png")
                {
                    gameToSave.GameImage = "";
                    Console.WriteLine("File extension invalid. Image must be JPG or PNG");
                    Console.WriteLine("Image not saved");
                }
                else
                {
                    try
                    {
                        imagePath = Path.Combine(_imagePath, game.ImageFile.FileName);
                        using(FileStream fstream = new FileStream(imagePath, FileMode.Create))
                        {
                            game.ImageFile.CopyTo(fstream);
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                //////////////////////////////////////////////////
              
            }

            //Categories
            List<Category> allCategories = _databaseContext.Categories.ToList();
            foreach (string category in game.Categories)
            {
                Category? tempCategory = allCategories.FirstOrDefault(cat => cat.CategoryName == category);
                if (tempCategory != null)
                {
                    gameToSave.GameCategory.Add(tempCategory);
                }
            }

            //Development Company
            DevelopmentCompany? developmenCompany = _databaseContext.DevelopmentCompanies.
                FirstOrDefault(devComp => devComp.DevelopmentCompanyName == game.DevelopmentCompanyName);
            if (developmenCompany != null)
            {
                gameToSave.GameDevelopmentCompany = developmenCompany;
            }
            else 
                return $"This Dev Company -<{game.DevelopmentCompanyName}>- doesn't exist. Game not saved";


            //Everything OK?... so let's save Game into DB
            user.UserGames.Add(gameToSave);
            _databaseContext.Games.Add(gameToSave);
            _databaseContext.SaveChanges();
            _databaseContext.Dispose();
            return $"Game: -<{gameToSave.GameName}>- saved successfuly for user -<{user.UserId}>-";
        }



        public async Task<IEnumerable<GameResponseDTO>> GetGames()
        {
            List<Game> games = await _databaseContext.Games.
                Include(game => game.GameImages).
                Include(game => game.GameCategory).
                Include(game => game.GameDevelopmentCompany).ToListAsync();

            List<GameResponseDTO> gamesResponse = new List<GameResponseDTO>();
            foreach (Game game in games)
            {
                gamesResponse.Add(new GameResponseDTO
                {
                    GameId = game.GameId,
                    GameName = game.GameName,
                    GameRank = game.GameRank,
                    GameImage = game.GameImage,
                    GameSynopsis = game.GameSynopsis,
                    GameImages = game.GameImages.Select(images => images.GameImagePath).ToList(),
                    GameCategories = game.GameCategory.Select(categories => categories.CategoryName).ToList(),

                    GameDevelopmentCompany = game.GameDevelopmentCompany != null ? 
                    new DevelopmentCompanyResponseDTO
                    {
                        DevelopmentCompanyName = game.GameDevelopmentCompany.DevelopmentCompanyName,
                        LogoName = game.GameDevelopmentCompany.DevelopmentCompanyLogo
                    } : null
                });
            }

            return gamesResponse;
        }
    }
}
