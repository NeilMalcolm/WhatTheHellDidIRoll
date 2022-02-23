using NUnit.Framework;
using System.Collections.Generic;
using WhatTheHellDidIRoll.Lib;

namespace WhatTheHellDidIRoll.Tests
{
    public class RollTests
    {
        public static IEnumerable<Roll[]> RollData()
        {
            var allData = new Roll[100];
            int index = 0;

            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++) 
                {
                    allData[index] = new Roll(i, j);
                    index++;
                }
            }

            yield return allData;
        }

        [Test]
        [TestCaseSource(nameof(RollData))]
        public void WhenRollIsMadeWithAnyCombinationOfValues_ThenResultIsCorrect(Roll[] rolls)
        {
            // Arrange
            int[] results = new int[100];

            // Act
            foreach (var roll in rolls)
            {
                var latestRoll = roll.GetRoll();
                results[latestRoll - 1] = latestRoll;
            }

            // Assert
            for (int i = 0; i < results.Length; i++)
            {
                Assert.AreEqual(i+1, results[i]);
            }
        }

        [Test]
        [TestCase(10, 1, 1)]
        [TestCase(1, 10, 10)]
        [TestCase(10, 10, 100)]
        [TestCase(1, 1, 11)]
        [TestCase(9, 9, 99)]
        [TestCase(2, 1, 21)]
        [TestCase(2, 9, 29)]
        public void WhenRollIsMade_GetRollReturnsTheExpectedResult(int tensRoll, int unitsRoll, int expectedRoll)
        {
            // Arrange
            var roll = new Roll(tensRoll, unitsRoll);

            // Act
            var actualRoll = roll.GetRoll();

            // Assert
            Assert.AreEqual(expectedRoll, actualRoll);
        }
    }
}