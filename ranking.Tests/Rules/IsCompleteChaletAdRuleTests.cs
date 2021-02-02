using coding_test_ranking.Domain;
using coding_test_ranking.Domain.Rules;
using NUnit.Framework;
using System.Collections.Generic;

namespace ranking.Tests.Rules
{
    [TestFixture]
    public class IsCompleteChaletAdRuleTests
    {
        [Test]
        public void Evaluate_noCompleteChalet_score0()
        {
            // Arrange
            Ad ad = new Chalet() 
            { 
                Pictures = new List<Picture>()
            };
            IRule rule = new IsCompleteChaletAdRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_noCompleteChaletWithPicture_score0()
        {
            // Arrange
            Ad ad = new Chalet() 
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
            IRule rule = new IsCompleteChaletAdRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_noCompleteChaletWithPictureAndDescription_score0()
        {
            // Arrange
            Ad ad = new Chalet()
            {
                Pictures = new List<Picture>()
                {
                    new Picture
                    {
                        Id = 1,
                        Quality = PictureQualityEnum.HD,
                        Url = "http://www.idealista.com/pictures/1"
                    }
                }, 
                Description = "Hola"
            };
            IRule rule = new IsCompleteChaletAdRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_noCompleteChaletWithPictureDescriptionAndHouseSize_score0()
        {
            // Arrange
            Ad ad = new Chalet()
            {
                Pictures = new List<Picture>()
                {
                    new Picture
                    {
                        Id = 1,
                        Quality = PictureQualityEnum.HD,
                        Url = "http://www.idealista.com/pictures/1"
                    }
                },
                Description = "Hola",
                HouseSize = 300
            };
            IRule rule = new IsCompleteChaletAdRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_isCompleteChalet_score40()
        {
            // Arrange
            Ad ad = new Chalet()
            {
                Pictures = new List<Picture>()
                {
                    new Picture
                    {
                        Id = 1,
                        Quality = PictureQualityEnum.HD,
                        Url = "http://www.idealista.com/pictures/1"
                    }
                },
                Description = "Hola",
                HouseSize = 300,
                GardenSize = 100
            };
            IRule rule = new IsCompleteChaletAdRule();

            // Act
            int expectedScore = 40;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
