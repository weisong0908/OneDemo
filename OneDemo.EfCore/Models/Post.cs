namespace OneDemo.EfCore.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }
        // use this for lazy loading
        // virtual public Blog Blog { get; set; }

        //use this for eager loading
        public Blog Blog { get; set; }
    }
}