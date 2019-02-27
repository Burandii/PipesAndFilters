﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PipesAndFilters.Filters
{
    public class StringModifier
    {
        public static List<string> Alphabetize(List<string> input)
        {
            return input.OrderBy(n => n).ToList();
        }

        public static List<string> CircularlyShift(List<string> input)
        {
            var allShifted = new List<string>();
            foreach (var wordSet in input) // "all the cool cats", "what must be done"
            {
                var wordCount = wordSet.Split(null).Length;
                var currentShift = wordSet;
                allShifted.Add(currentShift);
                for (int i = 1; i < wordCount; i++)
                {
                    currentShift = AlphabetizeSingleString(currentShift);
                    allShifted.Add(currentShift.Trim());
                }
            }

            return allShifted;
        }

        public static string AlphabetizeSingleString(string input)
        {
            var words = input.Split(null);
            var result = new List<string>();
            for (int i = 1; i < words.Length; i++)
            {
                result.Add(words[i]);
            }
            result.Add(words[0]);

            return string.Join(' ', result.ToArray());
        }
    }
}
