using GameCollectionAPI_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_BL.DTOs
{
    public class GameResponseDTO
    {
        public long GameId { get; set; }
        public string GameName { get; set; }
        public int GameRank { get; set; } = 1;
        public string? GameImage { get; set; } //Front image game path
        public string? GameSynopsis { get; set; }

        public ICollection<string>? GameImages { get; set; } = new List<string>();
        public ICollection<string>? GameCategories { get; set; } = new List<string>();
        //public ICollection<User>? GameUsers { get; set; } = new List<User>();
        public DevelopmentCompanyResponseDTO? GameDevelopmentCompany { get; set; }
    }
}
