using coding_test_ranking.Domain;
using coding_test_ranking.Domain.Rules;
using NUnit.Framework;
using System.Collections.Generic;

namespace ranking.Tests.Rules
{
    [TestFixture]
    public class IsCompleteGarageAdRuleTests
    {
        [Test]
        public void Evaluate_noCompleteGarage_score0()
        {
            // Arrange
            Ad ad = new Garage()
            {
                Pictures = new List<Picture>()
            };
            IRule rule = new IsCompleteGarageAdRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_isCompleteGarage_score40()
        {
            // Arrange
            Ad ad = new Garage()
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
            IRule rule = new IsCompleteGarageAdRule();

            // Act
            int expectedScore = 40;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
