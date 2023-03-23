using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TappitTest.Models;

namespace TappitTest
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        { 
            
        }

        //This links the table relationships together to make manipulating the data easier
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sports>()
                .HasMany(x => x.FavouriteSports)
                .WithOne(x => x.Sports)
                .HasForeignKey(x => x.SportId);
            modelBuilder.Entity<People>()
                .HasMany(x => x.FavouriteSports)
                .WithOne(x => x.People)
                .HasForeignKey(x => x.PersonId);
        }

        public DbSet<FavouriteSports> FavouriteSports { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Sports> Sports { get; set; }
    }
}
