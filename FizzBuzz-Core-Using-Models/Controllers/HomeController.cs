using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FizzBuzz_Core_Using_Models.Models;

namespace FizzBuzz_Core_Using_Models.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult FizzBuzz()
        {
            var model = new FizzBuzzModel();
            model.Output = new List<string>();
            return View(model);
        }

        [HttpPost]
        public IActionResult FizzBuzz(int userNumber1, int userNumber2)           
        {
            var output = "";
            
            for (var i = 1; i <= 100; i++)
            {
                var fizzBug = i % userNumber1;
                var buzzBug = i % userNumber2;

                if (fizzBug == 0 && buzzBug == 0)
                {
                    output += "FizzBuzz ";
                }
                else if (fizzBug == 0)
                {
                    output += "Fizz ";
                }
                else if (buzzBug == 0)
                {
                    output += "Buzz ";
                }
                else
                {
                    output += i + " ";
                }
            }

            var fizzBuzzModel = new FizzBuzzModel();
            fizzBuzzModel.Fizzer = userNumber1;
            fizzBuzzModel.Buzzer = userNumber2;
            fizzBuzzModel.Output = output.Split(" ").ToList();


            return View(fizzBuzzModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
