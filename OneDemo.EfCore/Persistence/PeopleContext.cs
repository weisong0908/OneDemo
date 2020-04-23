using Microsoft.EntityFrameworkCore;
using OneDemo.EfCore.Models;

namespace OneDemo.EfCore.Persistence
{
    public class PeopleContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var person1 = new Person() { Id = 1, Name = "Person 1" };
            var person2 = new Person() { Id = 2, Name = "Person 2" };

            modelBuilder.Entity<Person>().HasData(person1);
            modelBuilder.Entity<Person>().HasData(person2);
        }
    }
}