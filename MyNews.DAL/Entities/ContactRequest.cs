﻿namespace MyNews.DAL.Entities
{
    public class ContactRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
    }
}