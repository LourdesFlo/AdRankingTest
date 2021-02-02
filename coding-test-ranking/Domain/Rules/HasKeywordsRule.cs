using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace coding_test_ranking.Domain.Rules
{
    public class HasKeywordsRule : IRule
    {
        private const int HAS_WORD_SCORE = 5;
        private const string CLEAN_WORD_REGEX = @"[^\w\.@-]";
        private static readonly List<string> keywords = new List<string> { "Luminoso", "Nuevo", "Céntrico", "Reformado", "Ático" };

        public int Evaluate(Ad ad)
        {
            HashSet<string> keywordsFound = new HashSet<string>();

            string[] descriptionWords = ad.Description.Split(" ");
            foreach(string word in descriptionWords)
            {
                var w = Regex.Replace(word, CLEAN_WORD_REGEX, "");
                if (keywords.Contains(w, StringComparer.InvariantCultureIgnoreCase)) {
                    keywordsFound.Add(w);
                }
            }

            return keywordsFound.Count * HAS_WORD_SCORE;
        }
    }
}
