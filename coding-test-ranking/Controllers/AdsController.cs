using System;
using System.Collections.Generic;
using coding_test_ranking.infrastructure.api;
using coding_test_ranking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace coding_test_ranking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly ICalculateScoreService _calculateScoreService;
        private readonly IGetAdsService _getAdsService;

        private const string SERVER_ERROR = "There was an error while processing your request";

        public AdsController(ICalculateScoreService calculateScoreService, IGetAdsService getAdsService)
        {
            _calculateScoreService = calculateScoreService;
            _getAdsService = getAdsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<QualityAd>> qualityListing()
        {
            try
            {
                return _getAdsService.GetQualityAds();
            }
            catch (Exception ex)
            {
                return Ok(SERVER_ERROR);
            }
        }
        [HttpGet]
        public ActionResult<IEnumerable<PublicAd>> publicListing()
        {
            
            try
            {
                return _getAdsService.GetPublicAds();
            }
            catch (Exception ex)
            {
                return Ok(SERVER_ERROR);
            }
        }

        [HttpGet]
        public ActionResult calculateScore()
        {
            try
            {
                _calculateScoreService.CalculateScore();
                return Accepted();
            }
            catch (Exception ex)
            {
                return Ok(SERVER_ERROR);
            }
        }
    }
}
