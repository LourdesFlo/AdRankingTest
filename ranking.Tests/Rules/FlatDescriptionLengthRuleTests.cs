using coding_test_ranking.Domain;
using coding_test_ranking.Domain.Rules;
using NUnit.Framework;

namespace ranking.Tests.Rules
{
    [TestFixture]
    public class FlatDescriptionLengthRuleTests
    {
        [Test]
        public void Evaluate_descritionLessThan10_score0()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Description = "hello!"
            };
            IRule rule = new FlatDescriptionLengthRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_descritionBetween20And49_score10()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Description = "Piso nuevo, barato, moderno, con mucha amplitud, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra YA!"
            };
            IRule rule = new FlatDescriptionLengthRule();

            // Act
            int expectedScore = 10;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_descritionMoreThan50_score30()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Description = "Piso nuevo, barato, moderno, con mucha amplitud, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra YA! Piso nuevo, barato, moderno, con mucha amplitud, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra YA, URGENTE URGENTE, COMPRA  YA, COMPRA YA, COMPRA YA, COMPRA YA!"
            };
            IRule rule = new FlatDescriptionLengthRule();

            // Act
            int expectedScore = 30;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
