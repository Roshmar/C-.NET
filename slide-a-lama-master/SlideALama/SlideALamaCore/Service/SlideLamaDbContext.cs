using Microsoft.EntityFrameworkCore;
using SlideLama.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SlideLama
{
    public class SlideLamaDbContext : DbContext
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DbSet<Score> Scores { get; set; }

        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Hodnotenie> Hodnotenies  { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SlideLamaDb;Trusted_Connection=True;");
        }
    }
}
