namespace coding_test_ranking.Domain
{
    public interface IAdFactory
    {
        Ad CreateAd(AdTypologyEnum typology);
    }
}
