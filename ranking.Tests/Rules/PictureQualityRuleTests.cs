using coding_test_ranking.Domain;
using coding_test_ranking.Domain.Rules;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ranking.Tests.Rules
{
    [TestFixture]
    public class PictureQualityRuleTests
    {
        [Test]
        public void Evaluate_pictureQuality_score0()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Pictures = new List<Picture>()
            };
            IRule rule = new PictureQualityRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_pictureQualityHD_score20()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Pictures = new List<Picture>()
                {
                    new Picture
                    {
                        Id = 1,
                        Quality = PictureQualityEnum.HD,
                        Url = "http://www.idealista.com/pictures/1"
                    }
                }
            };
            IRule rule = new PictureQualityRule();

            // Act
            int expectedScore = 20;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_pictureQualitySD_score10()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Pictures = new List<Picture>()
                {
                    new Picture
                    {
                        Id = 1,
                        Quality = PictureQualityEnum.SD,
                        Url = "http://www.idealista.com/pictures/1"
                    }
                }
            };
            IRule rule = new PictureQualityRule();

            // Act
            int expectedScore = 10;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
