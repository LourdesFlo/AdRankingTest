using AutoMapper;
using coding_test_ranking.Domain;
using coding_test_ranking.infrastructure.persistence;
using System.Collections.Generic;

namespace coding_test_ranking.Mapper
{
    public class PictureVOResolver : IValueResolver<AdVO, Ad, List<Picture>>
    {
        private readonly InMemoryPersistence persistence;
        private readonly IMapper _mapper;

        public PictureVOResolver(InMemoryPersistence persistence, IMapper mapper)
        {
            this.persistence = persistence;
            _mapper = mapper;
        }

        public List<Picture> Resolve(AdVO source, Ad destination, List<Picture> destMember, ResolutionContext context)
        {
            destMember = new List<Picture>();
            foreach(int pictureId in source.Pictures)
            {
                destMember.Add(_mapper.Map<PictureVO, Picture>(persistence.GetPictureById(pictureId)));
            }

            return destMember;
        }
    }
}