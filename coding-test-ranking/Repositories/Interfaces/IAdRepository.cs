using coding_test_ranking.Domain;
using coding_test_ranking.infrastructure.api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace coding_test_ranking.Repositories.Interfaces
{
    public interface IAdRepository
    {
        List<Ad> GetAllAds();

        Task UpdateAd(Ad ad);

        List<PublicAd> GetPublicAds();

        List<QualityAd> GetQualityAds();
    }
}
