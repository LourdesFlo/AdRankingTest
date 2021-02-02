using AutoMapper;
using coding_test_ranking.Domain;
using coding_test_ranking.infrastructure.persistence;
using System.Collections.Generic;

namespace coding_test_ranking.Mapper
{
    public class PictureResolver : IValueResolver<Ad, AdVO, List<int>>
    {
        public List<int> Resolve(Ad source, AdVO destination, List<int> destMember, ResolutionContext context)
        {
            destMember = new List<int>();

            foreach(Picture picture in source.Pictures)
            {
                destMember.Add(picture.Id);
            }

            return destMember;
        }
    }
}
