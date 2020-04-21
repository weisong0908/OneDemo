using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetBlogsNormally()
        {
            var blogs = _bloggingContext.Blogs.ToList();

            return Ok(blogs);
        }

        [HttpGet("posts")]
        public IActionResult GetPostsLazyLoaded()
        {
            var blogs = _bloggingContext.Blogs.ToList();

            var posts = new List<Post>();

            foreach (var blog in blogs)
            {
                foreach (var post in blog.Posts)
                {
                    posts.Add(post);
                }
            }

            var titles = posts.Select(p => p.Title);

            return Ok(titles);
        }
    }
}