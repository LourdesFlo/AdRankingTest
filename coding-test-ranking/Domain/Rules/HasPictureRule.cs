namespace coding_test_ranking.Domain.Rules
{
    public class HasPictureRule : IRule
    {
        private const int NO_PHOTOS_SCORE = -10;
        private const int WITH_PHOTOS_SCORE = 0;

        public int Evaluate(Ad ad)
        {
            if (ad.Pictures.Count > 0)
            {
                return WITH_PHOTOS_SCORE;
            }

            return NO_PHOTOS_SCORE;
        }
    }
}

