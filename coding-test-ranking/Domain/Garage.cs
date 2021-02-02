namespace coding_test_ranking.Domain
{
    public class Garage : Ad
    {
        public override AdTypologyEnum getTypology()
        {
            return AdTypologyEnum.GARAGE;
        }
    }
}
