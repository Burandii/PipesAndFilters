using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PipesAndFilters.Models;

namespace PipesAndFilters.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetStrings(string input)
        {
            var orderedWords = OrderWords(input);
            var results = new StringResultViewModel
            {
                UserInput = input,
                OrderedWords = orderedWords,
                ShiftedWords = ShiftWords(orderedWords)
            };

            return View("Index", results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string OrderWords(string input)
        {
            var words = input.Split(null);
            var sorted = words.OrderBy(n => n);

            return string.Join(' ', sorted.ToArray());
        }

        public string ShiftWords(string input)
        {
            var words = input.Split(null);
            var startingIndex = 0;

            var wordSets = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                var s = "";
                for (int k = i; k < words.Length+i; k++)
                {
                    s += words[k % words.Length] + " ";
                }
                Console.WriteLine(s);
                wordSets.Add(s.Trim());
            }

            return string.Join(',', wordSets.ToArray());
        }

    }
}
