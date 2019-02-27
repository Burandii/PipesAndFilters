using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using PipesAndFilters.Filters;
using PipesAndFilters.Models;

namespace PipesAndFilters.DataManagers
{
    public class StringResultViewDataManager
    {
        private readonly List<string> _input;
        private readonly string _userInput;

        public StringResultViewDataManager(string input)
        {
            _userInput = input;
            _input = new List<string>(input.Split(
                new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None)); 
        }


        public StringResultViewModel GetFilteredStringViewModel()
        {
            if (_userInput.Length <= 0)
            {
                return new StringResultViewModel();
            }

            if (_userInput.Length == 1)
            {
                return new StringResultViewModel
                {
                    UserInput = _input,
                    EachWordSet = new List<List<string>>
                    {
                        _input
                    },
                    CombinedWords = _input
                };
            }

            return new StringResultViewModel
            {
                EachWordSet = FilterEveryWordSet(),
                UserInput = _input,
                CombinedWords = FilterCombinedWordSet()
            };
        }

        private List<List<string>> FilterEveryWordSet()
        {
            var eachWordSetOutput = new List<List<string>>();

            foreach (var s in _input)
            {
                var circularlyShiftedSingle = StringModifier.CircularlyShift(new List<string> { s });
                eachWordSetOutput.Add(StringModifier.Alphabetize(circularlyShiftedSingle));
            }

            return eachWordSetOutput;
        }

        private List<string> FilterCombinedWordSet()
        {
            var circularlyShifted = StringModifier.CircularlyShift(_input);
            return StringModifier.Alphabetize(circularlyShifted);
        }

    }
}
