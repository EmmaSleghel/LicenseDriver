using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Data.Persistence
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
         
        }

       // public virtual DbSet<> 
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        
        }
    }
}
