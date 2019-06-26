using System;
using System.Linq;

namespace _02._Recursive_Factorial
{
    class RecursiveFactorial
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(number));
        }

        private static long Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factorial(--number);
        }
    }
}
