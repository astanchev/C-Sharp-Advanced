using System.Linq;

namespace _1._Diagonal_Difference
{
    using System;
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            
            int[,] matrix = new int[dimensions, dimensions];
            int sum = 0;
            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            for (int i = 0; i < dimensions; i++)
            {
                primaryDiagonal += matrix[i,i];
                secondaryDiagonal += matrix[(dimensions-1)-i,i];
            }

            int difference = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(difference);
        }
    }
}
