using System;
using NUnit.Framework;

public class RepairPointsCalculatorTests
{
    private RepairPointsCalculator repairPointsCalculator;

    [SetUp]
    public void Setup()
    {
        repairPointsCalculator = new RepairPointsCalculator();
    }

    [Test]
    [TestCase(0)]
    [TestCase(10)]
    [TestCase(50)]
    public void CalculateRepairPoints_SetAmountOfClicks_AssertCalculatedPoints(int amountOfClicks)
    {
        int calculatedPoints = repairPointsCalculator.CalculateRepairPoints(amountOfClicks);

        Assert.AreEqual(amountOfClicks, calculatedPoints);
    }

    [Test]
    [TestCase(-1)]
    [TestCase(-999)]
    public void CalculateRepairPoints_SetAmountOfClicksNegative_ThrowsArgumentOutOfRangeException(int amountOfClicks)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => repairPointsCalculator.CalculateRepairPoints(amountOfClicks));
    }
}
