using System;
using System.Collections.Generic;

namespace coding_test_ranking.Domain.Rules
{
    public class PictureQualityRule : IRule
    {
        private const int HD_SCORE = 20;
        private const int SD_SCORE = 10;

        private readonly static Dictionary<PictureQualityEnum, int> QualityScoreMapping = new Dictionary<PictureQualityEnum, int>()
        {
            { PictureQualityEnum.HD, HD_SCORE  },
            { PictureQualityEnum.SD, SD_SCORE  }
        };


        public int Evaluate(Ad ad)
        {
            int score = 0;

            ad.Pictures.ForEach(picture =>
            {
                int adQualityScore;
                if(!QualityScoreMapping.TryGetValue(picture.Quality, out adQualityScore))
                {
                    throw new ArgumentException("Invalid picture quality", nameof(ad));
                }
                score += adQualityScore;
            });

            return score;
        }
    }
}

