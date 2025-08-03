using Microsoft.AspNetCore.Mvc;
using NQueenAnswer;

namespace NQueenAnswer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(int n)
        {
            if (n < 1 || n > 10)
            {
                n = 5; // デフォルト値
            }

            var allSolutions = NQueenGenerator.Generate(n);
            var uniqueSolutions = NQueenGenerator.DeleteDuplicate(allSolutions);

            ViewBag.N = n;
            ViewBag.AllSolutions = allSolutions;
            ViewBag.UniqueSolutions = uniqueSolutions;
            ViewBag.AllCount = allSolutions.Count();
            ViewBag.UniqueCount = uniqueSolutions.Count();

            return View("Index");
        }

        public IActionResult Tutorial()
        {
            return View();
        }

        public IActionResult ClassStructure()
        {
            return View();
        }

        public IActionResult BruteForceDemo()
        {
            return View();
        }

        public IActionResult SequenceDiagram()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
