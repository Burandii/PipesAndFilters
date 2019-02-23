using System.Collections.Generic;
using System.Linq;

namespace PipesAndFilters.Filters
{
    public class StringModifier
    {

        public static string OrderWords(string input)
        {
            var words = input.Split(null);
            var sorted = words.OrderBy(n => n);

            return string.Join(' ', sorted.ToArray());
        }

        public static string ShiftWordsSingle(string input)
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

        public static List<string> ShiftWordsIntoList(string input)
        {
            var words = input.Split(null);

            var wordSets = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                var s = "";
                for (int k = i; k < words.Length + i; k++)
                {
                    s += words[k % words.Length] + " ";
                }
                wordSets.Add(s.Trim());
            }

            return wordSets;
        }
    }
}
