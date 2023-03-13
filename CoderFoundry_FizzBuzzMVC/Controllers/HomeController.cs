using CoderFoundry_FizzBuzzMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoderFoundry_FizzBuzzMVC.Controllers
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
            return View();
        }
        [HttpGet]
        public IActionResult FBPage()
        {
            FizzBuzz model = new ();
            model.FizzValue = 3;
            model.BuzzValue = 5;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FBPage(FizzBuzz fizzBuzz)
        {
            for(int i = 0; i <= 100; i++)
            {
                if (i % fizzBuzz.FizzValue == 0 && i % fizzBuzz.BuzzValue == 0)
                {
                    fizzBuzz.Result.Add("FizzBuzz");
                }
                else if (i % fizzBuzz.FizzValue == 0)
                {
                    fizzBuzz.Result.Add("Fizz");
                }
                else if (i % fizzBuzz.BuzzValue == 0)
                {
                    fizzBuzz.Result.Add("Buzz");
                }
                else
                {
                    fizzBuzz.Result.Add(i.ToString());
                }
            }
            return View(fizzBuzz);
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