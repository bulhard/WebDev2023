﻿namespace MyNews.BLL.Models.ActicleService
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string? Author { get; set; }

        public string? CategoryName { get; set; }
    }
}