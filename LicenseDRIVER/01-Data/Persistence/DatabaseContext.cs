
using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data.Persistence
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
         
        }

       public virtual DbSet<User> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

        }
    }
}
