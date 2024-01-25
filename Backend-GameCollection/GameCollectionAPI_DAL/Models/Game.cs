using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_DAL.Models
{
    public class Game
    {
        public long GameId { get; set; }
        public string GameName { get; set; }
        public int GameRank { get; set; } = 1;
        public string? GameImage { get; set; } //Front image game path
        public string? GameSynopsis { get; set; }
        
        public ICollection<GameImage>? GameImages { get; set; } = new List<GameImage>();
        public ICollection<Category>? GameCategory { get; set; } = new List<Category>();
        public ICollection<User>? GameUsers { get; set; } = new List<User>();
        public DevelopmentCompany? GameDevelopmentCompany { get; set; }
        

    }
}
