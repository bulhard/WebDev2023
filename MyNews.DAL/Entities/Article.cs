namespace MyNews.DAL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime PublishDate { get; set; }
        public string? Author { get; set; }
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}