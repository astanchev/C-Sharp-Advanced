using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class CupsandBottles
    {
        static void Main(string[] args)
        {
            int[] cupsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>(cupsInput);
            int[] bottlesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(bottlesInput);

            int wastedLiters = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Dequeue();
                int currentBottle = bottles.Pop();

                if (currentCup <= currentBottle)
                {
                    wastedLiters += currentBottle - currentCup;
                }
                else
                {
                    while (currentCup > 0)
                    {
                        currentCup -= currentBottle;
                        if (currentCup <= 0)
                        {
                            wastedLiters += Math.Abs(currentCup);
                            break;
                        }

                        if (bottles.Count > 0)
                        {
                            currentBottle = bottles.Pop();
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles.Reverse())}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLiters}");
        }
    }
}
