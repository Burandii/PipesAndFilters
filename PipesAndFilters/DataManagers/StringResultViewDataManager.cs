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
        private readonly string _input;

        public StringResultViewDataManager(string input)
        {
            _input = input;
        }

        public StringResultViewModel GetFilteredStringViewModel()
        {
            if (_input.Length < 0)
            {
                return new StringResultViewModel();
            }

            if (_input.Length == 1)
            {
                return new StringResultViewModel
                {
                    UserInput = _input,
                    OrderedWords = _input,
                    ShiftedWords = new List<string> { _input }
                };
            }

            var orderedWords = StringModifier.OrderWords(_input);
            var shiftedWords = new List<string>
            {
                StringModifier.ShiftWordsSingle(orderedWords)
            };
            var orderedWordsCount = orderedWords.Split(null).Length;
            for (int i = 1; i < orderedWordsCount; i++)
            {
                shiftedWords.Add(StringModifier.ShiftWordsSingle(shiftedWords[i - 1]));
            }

            return new StringResultViewModel
            {
                UserInput = _input,
                OrderedWords = orderedWords,
                ShiftedWords = shiftedWords
            };
        }
    }
}
