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
            var users = await _databaseContext.Users.Include(user => user.UserRole).ToListAsync();
            await _databaseContext.DisposeAsync();

            List<UserResponseDTO> result = new List<UserResponseDTO>();
            for(int i = 0; i < users.Count; i++)
            {
                result.Add(new UserResponseDTO
                {
                    UserNickName = users[i].UserNickName,
                    UserEmail = users[i].UserEmail,
                    RoleName = users[i].UserRole.RoleName,
                    Games = users[i].UserGames.ToList()
                });
            }
            
            return result;
        }
    }
}
