using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PipesAndFilters.Models
{
    public class StringResultViewModel
    {
        public string UserInput { get; set; }
        public string OrderedWords { get; set; }
        public string ShiftedWords { get; set; }
    }
}
