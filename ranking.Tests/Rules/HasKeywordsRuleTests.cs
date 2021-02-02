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
    public class HasKeywordsRuleTests
    {
        [Test]
        public void Evaluate_hasNoKeywords_score0()
        {
            // Arrange
            Ad ad = new Flat() 
            {
                Description = "Piso"
            };
            IRule rule = new HasKeywordsRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_hasOneKeyword_score5()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Description = "Piso luminoso"
            };
            IRule rule = new HasKeywordsRule();

            // Act
            int expectedScore = 5;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_hasTwoKeyword_score10()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Description = "Piso nuevo y luminoso"
            };
            IRule rule = new HasKeywordsRule();

            // Act
            int expectedScore = 10;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_hasThreeKeyword_score15()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Description = "Piso nuevo, luminoso y céntrico"
            };
            IRule rule = new HasKeywordsRule();

            // Act
            int expectedScore = 15;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_hasFourKeyword_score20()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Description = "Piso nuevo, luminoso, céntrico y reformado"
            };
            IRule rule = new HasKeywordsRule();

            // Act
            int expectedScore = 20;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_hasAllKeyword_score25()
        {
            // Arrange
            Ad ad = new Flat()
            {
                Description = "Piso nuevo, luminoso, céntrico, reformado y ático"
            };
            IRule rule = new HasKeywordsRule();

            // Act
            int expectedScore = 25;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
