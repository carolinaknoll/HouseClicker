using System;

public class RepairPointsCalculator
{
    public int CalculateRepairPoints(int amountOfClicks)
    {
        if (amountOfClicks < 0) {
            throw new ArgumentOutOfRangeException("Number of clicks cannot be negative.");
        }

        return amountOfClicks;
    }
}
