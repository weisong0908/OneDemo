using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneDemo.EfCore.Models;
using OneDemo.EfCore.Persistence;

namespace OneDemo.EfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BloggingController : ControllerBase
    {
        private readonly BloggingContext _bloggingContext;

        public BloggingController(BloggingContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        [HttpGet("blogs")]
        public IActionResult GetBlogs()
        {
            var blogs = _bloggingContext.Blogs.ToList();

            return Ok(blogs);
        }

        [HttpGet("posts")]
        public IActionResult GetPosts()
        {
            // use this for lazy loading
            // var blogs = _bloggingContext.Blogs.ToList();

            // use this for eager loading
            // var blogs = _bloggingContext.Blogs.Include(b => b.Posts).ToList();

            // use this for explicit loading
            var blogs = _bloggingContext.Blogs.ToList();
            _bloggingContext.Posts.Where(p => !string.IsNullOrWhiteSpace(p.Blog.Title)).Load();

            var posts = new List<Post>();

            foreach (var blog in blogs)
                posts.AddRange(blog.Posts);

            // transform using Select to avoid System.Text.Json exception
            var titles = posts.Select(p => p.Title);

            return Ok(titles);
        }
    }
}