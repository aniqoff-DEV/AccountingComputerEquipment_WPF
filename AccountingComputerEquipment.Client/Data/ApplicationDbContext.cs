using AccountingComputerEquipment.Client.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountingComputerEquipment.Client.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OfficeEquipment> OfficeEquipment { get; set; }
        public DbSet<AccessLevel> AccessLevels { get; set; }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AccoutingComputerEquipmentApp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLevel>().HasData(
               new AccessLevel { Id = 1, Name = LevelEnum.Admin.ToString()},
               new AccessLevel { Id = 2, Name = LevelEnum.Level1.ToString() },
               new AccessLevel { Id = 3, Name = LevelEnum.Level2.ToString() },
               new AccessLevel { Id = 4, Name = LevelEnum.Level3.ToString() },
               new AccessLevel { Id = 5, Name = LevelEnum.Level4.ToString() }
               );
        }
    }
}
