using AutoMapper;
using coding_test_ranking.Domain;
using coding_test_ranking.infrastructure.api;
using coding_test_ranking.infrastructure.persistence;
using coding_test_ranking.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coding_test_ranking.Repositories
{
    public class AdRepository : IAdRepository
    {
        private readonly InMemoryPersistence _persistence;
        private readonly IMapper _mapper;
        private List<AdVO> ads;
        public AdRepository(InMemoryPersistence persistence, IMapper mapper)
        {
            _persistence = persistence;
            _mapper = mapper;
            ads = persistence.GetAds();
        }

        public List<Ad> GetAllAds()
        {
            List<Ad> adsDomain = new List<Ad>();

            foreach(AdVO ad in ads)
            {
                var adType = (AdTypologyEnum)Enum.Parse(typeof(AdTypologyEnum), ad.Typology);
                if (adType == AdTypologyEnum.CHALET)
                {
                    adsDomain.Add(_mapper.Map<AdVO, Chalet>(ad));
                } else
                {
                    adsDomain.Add(_mapper.Map<AdVO, Ad>(ad));
                }
            }

            return adsDomain;
        }

        public List<PublicAd> GetPublicAds()
        {
            List<AdVO> adsFilter = ads.Where(ad => ad.Score >= 40).OrderBy(t => t.Score).ToList();
            List<PublicAd> publicAds = _mapper.Map<List<AdVO>, List<PublicAd>>(ads);
            return publicAds;
        }

        public List<QualityAd> GetQualityAds()
        {
            return _mapper.Map <List<AdVO>, List<QualityAd>>(ads);
        }

        public async Task UpdateAd(Ad ad)
        {
            try
            {
                AdVO adVo = _mapper.Map<Ad, AdVO>(ad);
                await _persistence.UpdateAd(adVo);
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
