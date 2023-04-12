using Microsoft.AspNetCore.Mvc;
using MyNews.BLL.Interfaces;
using MyNews.DAL.Core;
using MyNews.Web.Models;
using MyNews.Web.Models.Home;
using System.Diagnostics;

namespace MyNews.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;
        private readonly IArticlesService articlesService;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IArticlesService articlesService)
        {
            _logger = logger;
            this.userService = userService;
            this.articlesService = articlesService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            await articlesService.CreateSomeArticles();

            homeViewModel.Articles = articlesService.GetAllArticles();

            return View(homeViewModel);
        }

        public IActionResult Login()
        {
            userService.InitAdmin();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}