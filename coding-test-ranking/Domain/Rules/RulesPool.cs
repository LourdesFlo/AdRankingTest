using System;
using System.Collections.Generic;

namespace coding_test_ranking.Domain.Rules
{
    public static class RulesPool
    {
        private static readonly Dictionary<string, IRule> Rules = new Dictionary<string, IRule>
        {
            {nameof(HasPictureRule), new HasPictureRule()},
            {nameof(PictureQualityRule), new PictureQualityRule()},
            {nameof(HasDescriptionRule), new HasDescriptionRule()},
            {nameof(FlatDescriptionLengthRule), new FlatDescriptionLengthRule()},
            {nameof(ChaletDescriptionLengthRule), new ChaletDescriptionLengthRule()},
            {nameof(HasKeywordsRule), new HasKeywordsRule()},
            {nameof(IsCompleteFlatAdRule), new IsCompleteFlatAdRule()},
            {nameof(IsCompleteChaletAdRule), new IsCompleteChaletAdRule()},
            {nameof(IsCompleteGarageAdRule), new IsCompleteGarageAdRule()},
        };

        public static IRule GetHasPictureRule()
        {
            return GetRule(nameof(HasPictureRule));
        }

        public static IRule GetPictureQualityRule()
        {
            return GetRule(nameof(PictureQualityRule));
        }

        public static IRule GetHasDescriptionRule()
        {
            return GetRule(nameof(HasDescriptionRule));
        }

        public static IRule GetFlatDescriptionLengthRule()
        {
            return GetRule(nameof(FlatDescriptionLengthRule));
        }

        public static IRule GetChaletDescriptionLengthRule()
        {
            return GetRule(nameof(ChaletDescriptionLengthRule));
        }
        public static IRule GetHasKeywordsRule()
        {
            return GetRule(nameof(HasKeywordsRule));
        }
        
        public static IRule GetIsCompleteFlatAdRule()
        {
            return GetRule(nameof(IsCompleteFlatAdRule));
        }

        public static IRule GetIsCompleteChaletAdRule()
        {
            return GetRule(nameof(IsCompleteChaletAdRule));
        }
        public static IRule GetIsCompleteGarageAdRule()
        {
            return GetRule(nameof(IsCompleteGarageAdRule));
        }

        private static IRule GetRule(string key)
        {
            IRule rule;
            if(!Rules.TryGetValue(key, out rule))
            {
                throw new ArgumentException("Rule not found in pool", key);
            }

            return rule;
        }
    }
}
