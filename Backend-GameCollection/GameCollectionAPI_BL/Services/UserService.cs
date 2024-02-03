using GameCollectionAPI_BL.DTOs;
using GameCollectionAPI_DAL.Data;
using GameCollectionAPI_DAL.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore; //use this namespace instead of "System.Data.Entity" to make the asynchronous function work correctly
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.Services
{
    public class UserService:IUserService
    {
        private readonly DatabaseContext _databaseContext;

        public UserService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }






        //Register
        public string AddUser(UserDTO user)
        {
            
            User? myUser = _databaseContext.Users.FirstOrDefault(
                    u => u.UserEmail.ToLower() == user.UserEmail.ToLower()
                    );
            

            if (myUser != null) return "This user already exist";
            if (user.UserPassword != user.UserPasswordRepeated) return "The Password and Repeated Password doesn't match";

            myUser = new User();
            myUser.UserNickName = user.UserNickName;
            myUser.UserEmail = user.UserEmail;

            //Add Role 
            Role? role = _databaseContext.Roles.FirstOrDefault(r => r.RoleName.ToLower() == "normal");
            if (role == null) return "Roles not found";
            myUser.UserRole = role; //Add role to new user
            
 
            //Create Pw Hash & Salt
            HMACSHA512 hmac = new HMACSHA512();
            myUser.UserPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.UserPassword));
            myUser.UserPasswordSalt = hmac.Key;

            _databaseContext.Users.Add(myUser);
            _databaseContext.SaveChanges();
            _databaseContext.Dispose();
            return "New user registered successfully";
        }


        public async Task<IEnumerable<UserResponseDTO>> GetUsers()
        {
            var users = await _databaseContext.Users.Include(user => user.UserRole).Include(user => user.UserGames).ToListAsync();
            await _databaseContext.DisposeAsync();

            List<UserResponseDTO> result = new List<UserResponseDTO>();
            List<GameResponseDTO> gamesUser = new List<GameResponseDTO>();

            for (int i = 0; i < users.Count; i++)
            {
                foreach (Game game in users[i].UserGames.ToList())
                {
                    gamesUser.Add(new GameResponseDTO
                    {
                        GameId = game.GameId,
                        GameName = game.GameName,
                        GameRank = game.GameRank,
                        GameImage = game.GameImage,

                    });
                }

                result.Add(new UserResponseDTO
                {
                    UserNickName = users[i].UserNickName,
                    UserEmail = users[i].UserEmail,
                    RoleName = users[i].UserRole.RoleName,
                    Games = gamesUser.ToList()
                });

                gamesUser.Clear();
            }
            
            return result;
        }


        public async Task<UserResponseDTO>? GetUserByEmail(string email)
        {
            User? user = await _databaseContext.Users.
                Include(user => user.UserRole).Include(user => user.UserGames).
                FirstOrDefaultAsync(user => user.UserEmail.ToLower() == email.ToLower());

            if (user == null) return null;
            
            //Get games list of selected user
            ICollection<GameResponseDTO> gamesUserDto = new List<GameResponseDTO>();
            foreach(Game gamesUser in user.UserGames.ToList())
            {
                gamesUserDto.Add(new GameResponseDTO
                {
                    GameId = gamesUser.GameId,
                    GameName = gamesUser.GameName,
                    GameRank = gamesUser.GameRank,
                    GameImage = gamesUser.GameImage,
                    GameSynopsis = gamesUser.GameSynopsis,

                });
            }

            //Create response user data
            UserResponseDTO result = new UserResponseDTO
            {
                UserNickName = user.UserNickName,
                UserEmail = user.UserEmail,
                RoleName = user.UserRole.RoleName,
                Games = gamesUserDto.ToList() //games list of user
            };

            return result;
        }
    }
}
