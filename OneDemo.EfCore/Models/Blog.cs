using System.Collections.Generic;

namespace OneDemo.EfCore.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // use virtual to enable lazyloading
        virtual public IList<Post> Posts { get; set; }
        // public IList<Post> Posts { get; set; }
    }
}