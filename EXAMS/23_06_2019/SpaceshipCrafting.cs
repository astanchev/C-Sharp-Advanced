using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Spaceship_Crafting
{
    class SpaceshipCrafting
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materialQuantity = new Dictionary<string, int>();
            if (!materialQuantity.ContainsKey("Carbon fiber"))
            {
                materialQuantity["Carbon fiber"] = 0;
            }
            if (!materialQuantity.ContainsKey("Lithium"))
            {
                materialQuantity["Lithium"] = 0;
            }
            if (!materialQuantity.ContainsKey("Aluminium"))
            {
                materialQuantity["Aluminium"] = 0;
            }
            if (!materialQuantity.ContainsKey("Glass"))
            {
                materialQuantity["Glass"] = 0;
            }

            int[] inputLiquids = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> liquids = new Queue<int>(inputLiquids);

            int[] inputItems = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> items = new Stack<int>(inputItems);

            while (items.Count > 0 && liquids.Count > 0)
            {
                int currentLiquid = liquids.Dequeue();
                int currentItem = items.Pop();

                int currentMaterialValue = currentLiquid + currentItem;

                if (currentMaterialValue == 100)
                {
                    materialQuantity["Carbon fiber"]++;
                }
                else if (currentMaterialValue == 75)
                {
                    materialQuantity["Lithium"]++;
                }
                else if (currentMaterialValue == 50)
                {
                    materialQuantity["Aluminium"]++;
                }
                else if (currentMaterialValue == 25)
                {
                    materialQuantity["Glass"]++;
                }
                else
                {
                    currentItem += 3;
                    items.Push(currentItem);
                }
            }

            if (materialQuantity["Carbon fiber"] > 0
                && materialQuantity["Lithium"] > 0
                && materialQuantity["Aluminium"] > 0
                && materialQuantity["Glass"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }


            if (items.Count > 0)
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var material in materialQuantity.OrderBy(m => m.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
