using coding_test_ranking.Domain;
using coding_test_ranking.Repositories.Interfaces;
using coding_test_ranking.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace coding_test_ranking.Services
{
    public class CalculateScoreService : ICalculateScoreService
    {
        private readonly IAdRepository _adRepository;
        public CalculateScoreService(IAdRepository adRepository)
        {
            _adRepository = adRepository;
        }

        public async Task CalculateScore()
        {
            List<Ad> ads = _adRepository.GetAllAds();

            List<Task> adUpdates = new List<Task>();
            foreach(Ad ad in ads)
            {
                ad.Score = ad.getScore();
                adUpdates.Add(_adRepository.UpdateAd(ad));
            }

            await Task.WhenAll(adUpdates.ToArray());
        }
    }
}
