namespace _03._Custom_Min_Function
{
    using System;
    using System.Linq;

    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> MinNumber = GetMin;

            Console.WriteLine(MinNumber(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()));

        }

        private static int GetMin(int[] arr)
        {
            int minNumber = int.MaxValue;
            foreach (var el in arr)
            {
                if (el<minNumber)
                {
                    minNumber = el;
                }
            }

            return minNumber;
        }
    }
}
