using System;
using UnityEngine;
using NUnit.Framework;

public class RepairPointsCalculatorTests
{
    [Test]
    [TestCase(0)]
    [TestCase(10)]
    [TestCase(50)]
    public void CalculateRepairPoints_SetAmountOfClicks_AssertCalculatedPoints(int amountOfClicks)
    {
        var repairPointsCalculator = new RepairPointsCalculator();

        int calculatedPoints = repairPointsCalculator.CalculateRepairPoints(amountOfClicks);

        Assert.AreEqual(amountOfClicks, calculatedPoints);
    }

    [Test]
    [TestCase(-1)]
    [TestCase(-999)]
    public void CalculateRepairPoints_SetAmountOfClicksNegative_ThrowsExceptions(int amountOfClicks)
    {
        var repairPointsCalculator = new RepairPointsCalculator();
        Assert.Throws<ArgumentOutOfRangeException>(() => repairPointsCalculator.CalculateRepairPoints(amountOfClicks));
    }
}
