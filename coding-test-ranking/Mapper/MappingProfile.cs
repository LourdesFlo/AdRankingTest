using AutoMapper;
using coding_test_ranking.Domain;
using coding_test_ranking.infrastructure.api;
using coding_test_ranking.infrastructure.persistence;
using System;

namespace coding_test_ranking.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdVO, Ad>()
                .ConstructUsing((AdVO adrepo) =>
                   new AdFactory()
                        .CreateAd((AdTypologyEnum)Enum.Parse(typeof(AdTypologyEnum)
                                    , adrepo.Typology))
                ).ForMember(ad => ad.Pictures, opt => opt.MapFrom<PictureVOResolver>())
            .ForMember(ad => ad.Rules, opt => opt.Ignore());

            CreateMap<AdVO, Chalet>()
                .ConstructUsing((AdVO adrepo) =>
                   (Chalet)new AdFactory()
                        .CreateAd((AdTypologyEnum)Enum.Parse(typeof(AdTypologyEnum)
                                    , adrepo.Typology))
                )
                .ForMember(ad => ad.GardenSize, opt => opt.MapFrom(src => src.GardenSize))
                .ForMember(ad => ad.Pictures, opt => opt.MapFrom<PictureVOResolver>())
                .ForMember(ad => ad.Rules, opt => opt.Ignore());

            CreateMap<Ad, AdVO>()
                .ForMember(adDto => adDto.Typology, opt => opt.MapFrom(adRepo => adRepo.getTypology().ToString()))
                .ForMember(adDto=> adDto.Pictures, opt => opt.MapFrom<PictureResolver>());

            CreateMap<PictureVO, Picture>()
                .ForMember(pictureDomain => pictureDomain.Quality, opt => opt.MapFrom(pictureDto => Enum.Parse(typeof(PictureQualityEnum), pictureDto.Quality)));

            CreateMap<AdVO, QualityAd>().ForMember(dest => dest.PictureUrls, opt => opt.MapFrom<PictureQualityAdResolver>());
            CreateMap<AdVO, PublicAd>().ForMember(dest => dest.PictureUrls, opt => opt.MapFrom<PicturePublicAdResolver>());
        }
    }
}
