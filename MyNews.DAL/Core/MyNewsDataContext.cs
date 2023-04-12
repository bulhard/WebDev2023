using Microsoft.EntityFrameworkCore;
using MyNews.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNews.DAL.Core
{
    public class MyNewsDataContext : DbContext
    {
        public MyNewsDataContext(DbContextOptions<MyNewsDataContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; } = default!;

        public DbSet<ArticleToTag> ArticleToTags { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<ContactRequest> ContactRequests { get; set; } = default!;

        public DbSet<Tag> Tags { get; set; } = default!;

        public DbSet<User> Users { get; set; } = default!;
    }
}