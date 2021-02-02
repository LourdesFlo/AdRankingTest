namespace coding_test_ranking.Domain.Rules
{
    public class ChaletDescriptionLengthRule : IRule
    {
        private const int LARGE_SIZE_DESCRIPTION_SCORE = 20;

        public int Evaluate(Ad ad)
        {
            int wordsCount = ad.Description.Split(" ").Length;

            if (this.isLargeSizeDescription(wordsCount))
            {
                return LARGE_SIZE_DESCRIPTION_SCORE;
            }

            return 0;
        }

        private bool isLargeSizeDescription(int wordsCount)
        {
            return wordsCount > 50;
        }
    }
}
