namespace MyNews.DAL.Entities
{
    public class ArticleToTag
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int ActicleId { get; set; }

        public Article? Article { get; set; }
        public Tag? Tag { get; set; }
    }
}