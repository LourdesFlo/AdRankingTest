namespace coding_test_ranking.Domain
{
    public class Chalet : Ad
    {
        public int? GardenSize { get; set; }
        public override AdTypologyEnum getTypology()
        {
            return AdTypologyEnum.CHALET;
        }
    }
}
