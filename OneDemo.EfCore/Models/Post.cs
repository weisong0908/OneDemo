namespace OneDemo.EfCore.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BlogId { get; set; }
        virtual public Blog Blog { get; set; }
    }
}