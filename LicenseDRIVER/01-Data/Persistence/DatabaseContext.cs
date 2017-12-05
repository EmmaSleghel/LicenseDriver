﻿
using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace Data.Persistence
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
         
        }

       public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

        }
    }
}
