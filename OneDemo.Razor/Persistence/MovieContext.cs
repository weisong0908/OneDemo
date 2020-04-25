using Microsoft.EntityFrameworkCore;
using OneDemo.Razor.Models;

namespace OneDemo.Razor.Persistence
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
    }
}