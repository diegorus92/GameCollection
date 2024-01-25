using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_DAL.Models
{
    public class DevelopmentCompany
    {
        public long DevelopmentCompanyId { get; set; }
        public string DevelopmentCompanyName { get; set; }
        public string DevelopmentCompanyLogo { get; set; } //Logo image path


        public DevelopmentCompany(string developmentCompanyName, string developmentCompanyLogo)
        {
            DevelopmentCompanyName = developmentCompanyName;
            DevelopmentCompanyLogo = developmentCompanyLogo;
        }

        public ICollection<Game>? Games { get; set; } = new List<Game>();
    }
}
