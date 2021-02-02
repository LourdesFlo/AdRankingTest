namespace coding_test_ranking.Domain.Rules
{
    public class IsCompleteFlatAdRule : IRule
    {
        private const int IS_COMPLETE_FLAT_SCORE = 40;

        public int Evaluate(Ad ad)
        {
            if (this.HasPictures(ad)
                && this.HasDescription(ad)
                && this.HasHouseSize(ad))
            {
                return IS_COMPLETE_FLAT_SCORE;
            }

            return 0;
        }

        private bool MeetsRule(IRule rule, Ad ad)
        {
            return rule.Evaluate(ad) > 0;
        }

        private bool HasDescription(Ad ad)
        {
            return this.MeetsRule(new HasDescriptionRule(), ad);
        }

        private bool HasPictures(Ad ad)
        {
            return new HasPictureRule().Evaluate(ad) == 0;
        }

        private bool HasHouseSize(Ad ad)
        {
            return ad.HouseSize != null && ad.HouseSize > 0;
        }
    }
}
