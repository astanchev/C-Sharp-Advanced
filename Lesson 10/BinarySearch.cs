using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _07._Binary_Search
{
    class BinarySearch07
    {
        public class BinarySearch
        {
            public static int IndexOf(int[] arr, int key)
            {
                int lo = 0;
                int hi = arr.Length - 1;
                while (lo <= hi)
                {
                    int mid = lo + (hi - lo) / 2;

                    if (key < arr[mid])
                    {
                        hi = mid - 1;
                    }
                    else if (key > arr[mid])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }

                return -1;
            }
        }

        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int searchNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch.IndexOf(array, searchNumber));
        }

    }
}
