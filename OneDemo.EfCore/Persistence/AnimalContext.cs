using Microsoft.EntityFrameworkCore;
using OneDemo.EfCore.Models;

namespace OneDemo.EfCore.Persistence
{
    public class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        public AnimalContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var dog = new Animal() { Id = 1, Name = "dog" };
            var cat = new Animal() { Id = 2, Name = "cat" };

            modelBuilder.Entity<Animal>().HasData(dog);
            modelBuilder.Entity<Animal>().HasData(cat);
        }
    }
}