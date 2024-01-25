using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_DAL.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string UserNickName { get; set; }
        public string UserEmail { get; set; }
        public Byte[] UserPasswordHash { get; set; }
        public byte[] UserPasswordSalt { get; set; }

        public Role UserRole { get; set; } 
        public ICollection<Game>? UserGames { get; set; } = new List<Game>();

    }
}
