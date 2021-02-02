namespace coding_test_ranking.Domain.Rules
{
    public class HasDescriptionRule : IRule
    {
        private const int HAS_DESCRIPTION_SCORE = 5;

        public int Evaluate(Ad ad)
        {
            if(!string.IsNullOrEmpty(ad.Description))
            {
                return HAS_DESCRIPTION_SCORE;
            }

            return 0;
        }
    }
}
