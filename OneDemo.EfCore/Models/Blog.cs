using System.Collections.Generic;

namespace OneDemo.EfCore.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // use this for lazy loading
        // virtual public IList<Post> Posts { get; set; }

        // use this for eager loading
        public IList<Post> Posts { get; set; }
    }
}