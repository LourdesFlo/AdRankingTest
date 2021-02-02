using coding_test_ranking.Domain.Rules;
using System;
using System.Collections.Generic;

namespace coding_test_ranking.Domain
{
    public class AdFactory : IAdFactory
    {
        public Ad CreateAd(AdTypologyEnum typology)
        {
            List<IRule> commonRules = new List<IRule>()
            {
                RulesPool.GetHasPictureRule(),
                RulesPool.GetPictureQualityRule(),
                RulesPool.GetHasDescriptionRule(),
                RulesPool.GetHasKeywordsRule(),
            };

            switch (typology)
            {
                case AdTypologyEnum.FLAT:
                    {
                        List<IRule> flatRules = new List<IRule>() {
                            RulesPool.GetFlatDescriptionLengthRule(),
                            RulesPool.GetIsCompleteFlatAdRule()
                        };
                        flatRules.AddRange(commonRules);

                        return new Flat
                        {
                            Rules = flatRules
                        };
                    }
                case AdTypologyEnum.CHALET:
                    {
                        List<IRule> chaletRules = new List<IRule>() {
                            RulesPool.GetChaletDescriptionLengthRule(),
                                RulesPool.GetIsCompleteChaletAdRule()
                        };
                        chaletRules.AddRange(commonRules);

                        return new Chalet
                        {
                            Rules = chaletRules
                        };
                    }
                case AdTypologyEnum.GARAGE:
                    {
                        List<IRule> garageRules = new List<IRule>() {
                            RulesPool.GetIsCompleteGarageAdRule(),
                        };
                        garageRules.AddRange(commonRules);

                        return new Garage
                        {
                            Rules = garageRules
                        };
                    }
                default:
                    throw new ArgumentException("Invalid value", nameof(typology));
            }
        }
    }
}
