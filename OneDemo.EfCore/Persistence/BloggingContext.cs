using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OneDemo.EfCore.Models;

namespace OneDemo.EfCore.Persistence
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BloggingContext(DbContextOptions options) : base(options)
        {

        }

        // enable lazyloading
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var personalBlog = new Blog()
            {
                Id = 1,
                Title = "personal blog"
            };

            var personalPosts = new List<Post>()
            {
                new Post(){ Id = 1, Title = "personal post 1", BlogId = 1 },
                new Post(){ Id = 2, Title = "personal post 2", BlogId = 1 },
                new Post(){ Id = 3, Title = "personal post 3", BlogId = 1 }
            };

            var workBlog = new Blog()
            {
                Id = 2,
                Title = "work blog"
            };

            var workPosts = new List<Post>()
            {
                new Post(){ Id = 4, Title = "work post 1", BlogId = 2 },
                new Post(){ Id = 5, Title = "work post 2", BlogId = 2 },
                new Post(){ Id = 6, Title = "work post 3", BlogId = 2 }
            };

            modelBuilder.Entity<Blog>().HasData(personalBlog);
            modelBuilder.Entity<Blog>().HasData(workBlog);
            modelBuilder.Entity<Post>().HasData(personalPosts);
            modelBuilder.Entity<Post>().HasData(workPosts);
        }
    }
}