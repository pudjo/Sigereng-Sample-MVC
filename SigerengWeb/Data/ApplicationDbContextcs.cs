using Microsoft.EntityFrameworkCore;
using SigerengWeb.Models;

namespace SigerengWeb.Data
{
    public class ApplicationDbContextcs : DbContext
    {
        public ApplicationDbContextcs(DbContextOptions<ApplicationDbContextcs> option) : base(option)
        {

        }
        public DbSet<Catagory> Catagories { get; set; }
        // update-database

        // add-migration AddCatagoryTable
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Catagory>().HasData(
                new Catagory { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Catagory { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Catagory { Id = 3, Name = "History", DisplayOrder = 3 }
                );

        }
    }
}
