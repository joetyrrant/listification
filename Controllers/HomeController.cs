using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Listification.Models;



namespace Listification.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("listify")]
        public IActionResult Index()
        {
            var model = new ViewModel() { DomainName = Request.Host.Host };
            return View(model);

        }

        [HttpGet("listify/example")]
        public IActionResult example()
        {
            // Given a list of numbers ranging from 100 to 200
            var list = new Listify(100, 200);
            var ab = list[50];
            var isEqual = ab.Should().Equal(150);
            var ch = list.Max();//just to show you have access to all IEnumerable methods
            return Json(new { IsEqual = isEqual, Value = ab });
        }

        [HttpGet("listify/start/{start}/end/{end}/index/{index}")]
        public IActionResult Listifier(int start, int end, int index)
        {
            if (index >= end)
            {
                return BadRequest("Index is equal or greater than end.");
            }

            if (start >= end)
            {
                return BadRequest("start is equal or greater than end.");
            }

            var list = new Listify(start, end);
            var result = list[index];

            return Json(new { Value = result });
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

