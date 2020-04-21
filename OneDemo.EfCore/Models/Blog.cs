using System.Collections.Generic;

namespace OneDemo.EfCore.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<Post> Posts { get; set; }
    }
}