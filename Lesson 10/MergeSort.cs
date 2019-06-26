using System;
using System.Linq;

namespace _05._Merge_Sort
{
    class MergeSort
    {
        public class Mergesort<T>
        where T : IComparable
        {
            private static T[] aux;

            private static void Merge(T[] arr, int lo, int mid, int hi)
            {
                if (IsLess(arr[mid], arr[mid + 1]))
                {
                    return;
                }
                else
                {
                    for (int index = lo; index < hi + 1; index++)
                    {
                        aux[index] = arr[index];
                    }
                }

                int i = lo;
                int j = mid + 1;

                for (int k = lo; k <= hi; k++)
                {
                    if (i > mid)
                    {
                        arr[k] = aux[j++];
                    }
                    else if (j > hi)
                    {
                        arr[k] = aux[i++];
                    }
                    else if (IsLess(aux[i], aux[j]))
                    {
                        arr[k] = aux[i++];
                    }
                    else
                    {
                        arr[k] = aux[j++];
                    }
                }

            }

            private static void Sort(T[] arr, int lo, int hi)
            {
                if (lo >= hi)
                {
                    return;
                }

                int mid = (hi + lo) / 2;

                Sort(arr, lo, mid);
                Sort(arr, mid + 1, hi);
                Merge(arr, lo, mid, hi);

            }

            private static bool IsLess(T comparable, T comparable1)
            {
                if (comparable.CompareTo(comparable1) < 0)
                {
                    return true;
                }

                return false;
            }

            public static void Sort(T[] arr)
            {
                aux = new T[arr.Length];
                Sort(arr, 0, arr.Length - 1);
            }
        }
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

           Mergesort<int>.Sort(array);

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
