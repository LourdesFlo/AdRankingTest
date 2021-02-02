namespace coding_test_ranking.Domain
{
    public class Flat : Ad
    {
        public override AdTypologyEnum getTypology()
        {
            return AdTypologyEnum.FLAT;
        }
    }
}
