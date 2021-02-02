using coding_test_ranking.Domain;
using coding_test_ranking.infrastructure.api;
using System.Collections.Generic;

namespace coding_test_ranking.Services.Interfaces
{
    public interface IGetAdsService
    {
        List<QualityAd> GetQualityAds();

        List<PublicAd> GetPublicAds();
    }
}
