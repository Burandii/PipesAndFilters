using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipesAndFilters.Models
{
    public class StringResultViewModel
    {
        public List<string> UserInput { get; set; }
        public List<List<string>> EachWordSet { get; set; }
        public List<string> CombinedWords { get; set; }
    }
}
