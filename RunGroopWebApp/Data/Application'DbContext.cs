using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Data
{
    public class Application_DbContext: DbContext
    {
        public Application_DbContext(DbContextOptions<Application_DbContext>options) : base(options) { 
        
        }
        public DbSet<Race> Races { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Address> adresses { get; set; } 
    }
}
