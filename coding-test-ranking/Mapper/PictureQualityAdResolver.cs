using AutoMapper;
using coding_test_ranking.infrastructure.api;
using coding_test_ranking.infrastructure.persistence;
using System.Collections.Generic;

namespace coding_test_ranking.Mapper
{
    public class PictureQualityAdResolver : IValueResolver<AdVO, QualityAd, List<string>>
    {
        private readonly InMemoryPersistence persistence;

        public PictureQualityAdResolver(InMemoryPersistence persistence)
        {
            this.persistence = persistence;
        }

        public List<string> Resolve(AdVO source, QualityAd destination, List<string> destMember, ResolutionContext context)
        {
            destMember = new List<string>();

            foreach(int picture in source.Pictures)
            {
                destMember.Add(persistence.GetPictureById(picture).Url);
            }

            return destMember;
        }
    }
}
