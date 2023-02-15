using _02_Introduction.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _02_Introduction.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<StudentViewModel> students = new List<StudentViewModel>();

            students.Add(new StudentViewModel { FirstName = "First Name 1", LastName = "Last Name 1", StudentNumber = "1" });
            students.Add(new StudentViewModel { FirstName = "First Name 2", LastName = "Last Name 2", StudentNumber = "2" });
            students.Add(new StudentViewModel { FirstName = "First Name 3", LastName = "Last Name 3", StudentNumber = "3" });
            students.Add(new StudentViewModel { FirstName = "First Name 4", LastName = "Last Name 4", StudentNumber = "4" });
            students.Add(new StudentViewModel { FirstName = "First Name 5", LastName = "Last Name 5", StudentNumber = "5" });

            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Group1 = students;
            viewModel.Group2.Add(new StudentViewModel { FirstName = "First Name 11", LastName = "Last Name 11", StudentNumber = "11" });

            viewModel.PageTitle = "Students";

            return View(viewModel); 
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
