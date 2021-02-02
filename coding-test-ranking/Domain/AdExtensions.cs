namespace coding_test_ranking.Domain
{
    public static class AdExtensions
    {
        public static bool IsFlat(this Ad ad)
        {
            return ad.getTypology() == AdTypologyEnum.FLAT;
        }

        public static bool IsChalet(this Ad ad)
        {
            return ad.getTypology() == AdTypologyEnum.CHALET;
        }

        public static bool IsGarage(this Ad ad)
        {
            return ad.getTypology() == AdTypologyEnum.GARAGE;
        }
    }
}
