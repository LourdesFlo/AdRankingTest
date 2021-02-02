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
    public class HasPictureRuleTests
    {
        [Test]
        public void Evaluate_hasNoPicture_scoreMinus10()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Pictures = new List<Picture>()
            };
            IRule rule = new HasPictureRule();

            // Act
            int expectedScore = -10;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_hasPicture_score0()
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
            IRule rule = new HasPictureRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
