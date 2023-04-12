using MyNews.BLL.Interfaces;
using MyNews.BLL.Models.ActicleService;
using MyNews.DAL.Core;
using MyNews.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNews.BLL.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly MyNewsDataContext appDbContext;

        public ArticlesService(MyNewsDataContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task CreateSomeArticles()
        {
            if (!appDbContext.Categories.Any())
            {
                try
                {
                    appDbContext.Categories.Add(new Category { Title = "Sports", DateCreated = DateTime.Now });
                    appDbContext.Categories.Add(new Category { Title = "National", DateCreated = DateTime.Now });
                    appDbContext.Categories.Add(new Category { Title = "International", DateCreated = DateTime.Now });
                    appDbContext.Categories.Add(new Category { Title = "Economics", DateCreated = DateTime.Now });
                    appDbContext.Categories.Add(new Category { Title = "Politics", DateCreated = DateTime.Now });
                    appDbContext.Categories.Add(new Category { Title = "Lifestyle", DateCreated = DateTime.Now });
                    appDbContext.Categories.Add(new Category { Title = "Technology", DateCreated = DateTime.Now });

                    await appDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var s = ex.Message;
                }

                try
                {
                    for (int i = 1; i <= 7; i++)
                        for (int j = 1; j <= 7; j++)
                        {
                            appDbContext.Articles.Add(new Article
                            {
                                Author = $"Author {i} {j}",
                                CategoryId = i,
                                Content = $"Content {i} {j}",
                                DateCreated = DateTime.Now,
                                Image = $"image{i}{j}.jpg"
                            });
                        }

                    await appDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var s = ex.Message;
                }
            }
        }

        public List<ArticleModel> GetAllArticles()
        {
            return appDbContext.Articles
                .Select(a => new ArticleModel
                {
                    Id = a.Id,
                    Author = a.Author,
                    Content = a.Content,
                    Image = a.Image,
                    PublishDate = a.PublishDate,
                    Title = a.Title,
                    CategoryName = a.Category.Title
                })
                .ToList();
        }
    }
}