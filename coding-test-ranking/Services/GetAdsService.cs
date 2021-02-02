using AutoMapper;
using coding_test_ranking.infrastructure.api;
using coding_test_ranking.Repositories.Interfaces;
using coding_test_ranking.Services.Interfaces;
using System.Collections.Generic;

namespace coding_test_ranking.Services
{
    public class GetAdsService : IGetAdsService
    {
        private readonly IAdRepository _adRepository;
        private readonly IMapper _mapper;
        public GetAdsService(IAdRepository adRepository, IMapper mapper)
        {
            _adRepository = adRepository;
            _mapper = mapper;
        }

        public List<PublicAd> GetPublicAds()
        {
            return _adRepository.GetPublicAds();
        }

        public List<QualityAd> GetQualityAds()
        {
            return _adRepository.GetQualityAds();
        }
    }
}
