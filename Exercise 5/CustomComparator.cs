namespace _08._Custom_Comparator
{
    using System;
    using System.Linq;
    class CustomComparator
    {
        static void Main(string[] args)
        {
            Action<int[]> Print = arr => Console.WriteLine(string.Join(" ", arr));

            Func<int, int, int> SortArr = (a, b) =>
                    (a % 2 == 0 && b % 2 != 0) ? -1 :
                    (a % 2 != 0 && b % 2 == 0) ? 1 :
                    a.CompareTo(b);

            int[] inputNumbers = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

            Array.Sort(inputNumbers, (x ,y) => sortArr(x, y));

            Print(inputNumbers);
        }
    }
}
