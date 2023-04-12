using MyNews.BLL.Models.ActicleService;
using MyNews.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNews.BLL.Interfaces
{
    public interface IArticlesService
    {
        Task CreateSomeArticles();

        List<ArticleModel> GetAllArticles();
    }
}