using _04_Configuration.Models;
using _04_Configuration.Models.Shared;
using _04_Configuration.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _04_Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IConfiguration configuration;
        private readonly IStudentService studentService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IStudentService studentService)
        {
            this.logger = logger;
            this.configuration = configuration;
            this.studentService = studentService;
        }

        public IActionResult Index(int category)
        {
            var m1 = configuration.GetValue<string>("message");

            var m2 = configuration["message"];

            Logging m3 = configuration.GetSection("Logging").Get<Logging>();

            if (m3 != null)
            {
                return new JsonResult(m3);
            }
            else
            {
                return View();
            }
        }

        public ContentResult Index1(string category, string product)
        {
            return Content("asd");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}