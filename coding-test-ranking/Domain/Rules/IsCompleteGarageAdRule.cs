namespace coding_test_ranking.Domain.Rules
{
    public class IsCompleteGarageAdRule : IRule
    {
        private const int IS_COMPLETE_GARAGE_SCORE = 40;

        public int Evaluate(Ad ad)
        {
            if (this.HasPictures(ad))
            {
                return IS_COMPLETE_GARAGE_SCORE;
            }

            return 0;
        }

        private bool HasPictures(Ad ad)
        {
            return new HasPictureRule().Evaluate(ad) == 0;
        }
    }
}
