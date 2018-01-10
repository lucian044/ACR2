using ACR2.Core.Models;
using ACR2.Models;
using Microsoft.EntityFrameworkCore;

namespace ACR2.Persistence
{
    public class ACRDbContext : DbContext
    {
        public ACRDbContext(DbContextOptions<ACRDbContext> options) : base (options)
        {  
        }

        public DbSet<Week> Week { get; set; }
        public DbSet<WeekEntry> WeekEntry { get; set; }
        public DbSet<Category> Category { get; set; } 
        public DbSet<WeekNumber> WeekNumber { get; set; }
        public DbSet<Photo> Photo { get; set; }
    }
}