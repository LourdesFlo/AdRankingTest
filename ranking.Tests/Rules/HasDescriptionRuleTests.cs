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
    public class HasDescriptionRuleTests
    {
        [Test]
        public void Evaluate_hasNoDescription_score0()
        {
            // Arrange
            Ad ad = new Chalet();
            IRule rule = new HasDescriptionRule();

            // Act
            int expectedScore = 0;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }

        [Test]
        public void Evaluate_hasDescription_score5()
        {
            // Arrange
            Ad ad = new Chalet()
            {
                Description = "hello!"
            };
            IRule rule = new HasDescriptionRule();

            // Act
            int expectedScore = 5;
            int actualScore = rule.Evaluate(ad);

            // Assert
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
