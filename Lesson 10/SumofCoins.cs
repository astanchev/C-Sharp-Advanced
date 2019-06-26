using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 9, 10 };
        var targetSum = 27;

        try
        {
            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    public static IDictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var sortedCoins = coins
            .OrderByDescending(c => c)
            .ToList();

        var chosenCoins = new Dictionary<int, int>();
        int currentSum = 0;
        int coinIndex = 0;

        while (currentSum != targetSum && coinIndex < sortedCoins.Count)
        {
            int currentCoinValue = sortedCoins[coinIndex];
            int remainingSum = targetSum - currentSum;
            int numberOfCoinToTake = remainingSum / currentCoinValue;

            if (numberOfCoinToTake > 0)
            {
                chosenCoins[currentCoinValue] = numberOfCoinToTake;

                currentSum += currentCoinValue * numberOfCoinToTake;
            }

            if (currentSum == targetSum)
            {
                break;
            }

            coinIndex++;

        }

        if (currentSum == targetSum)
        {
            return chosenCoins;
        }

        throw new Exception("Error");
    }
}