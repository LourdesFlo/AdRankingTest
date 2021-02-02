namespace coding_test_ranking.Domain.Rules
{
    public class FlatDescriptionLengthRule : IRule
    {
        private const int MEDIUM_SIZE_DESCRIPTION_SCORE = 10;
        private const int LARGE_SIZE_DESCRIPTION_SCORE = 30;

        public int Evaluate(Ad ad)
        {
            int wordsCount = ad.Description.Split(" ").Length;

            if(this.isMediumSizeDescription(wordsCount))
            {
                return MEDIUM_SIZE_DESCRIPTION_SCORE;
            }

            if (this.isLargeSizeDescription(wordsCount))
            {
                return LARGE_SIZE_DESCRIPTION_SCORE;
            }

            return 0;
        }

        private bool isMediumSizeDescription(int wordsCount)
        {
            return wordsCount > 20 && wordsCount < 49;
        }
        private bool isLargeSizeDescription(int wordsCount)
        {
            return wordsCount >= 50;
        }
    }
}
