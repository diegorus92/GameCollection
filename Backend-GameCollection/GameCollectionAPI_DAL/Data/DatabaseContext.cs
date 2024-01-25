using GameCollectionAPI_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCollectionAPI_DAL.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>options):base(options)
        {
            
        }

        public virtual DbSet<Role>Roles {  get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameImage> GameImages { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DevelopmentCompany> DevelopmentCompanies { get; set; }


        
    }
}
