using coding_test_ranking.Domain;
using coding_test_ranking.Domain.Rules;
using NUnit.Framework;

namespace ranking.Tests.Rules
{
    [TestFixture]
    public class ChaletDescriptionLengthRuleTests
    {
        [Test]
        public void Evaluate_descritionLessThan10_score0()
        {
            // Arrange
            Ad ad = new Chalet()
            {
                Description = "hello!"
            };
            IRule rule = new ChaletDescriptionLengthRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_descritionMoreThan50_score20()
        {
            // Arrange
            Ad ad = new Chalet()
            {
                Description = "Piso nuevo, barato, moderno, con mucha amplitud, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra YA! Piso nuevo, barato, moderno, con mucha amplitud, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra, compra YA, URGENTE URGENTE, COMPRA  YA, COMPRA YA, COMPRA YA, COMPRA YA!"
            };
            IRule rule = new ChaletDescriptionLengthRule();

            // Act
            int expectedScore = 20;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
