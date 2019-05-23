using System.Linq;

namespace _6._Bomb_the_Basement
{
    using System;
    class BombtheBasement
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];

            int[] data = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
            int bombX = data[0];
            int bombY = data[1];
            int bombRadius = data[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (IsPointInside(bombX, bombY, row, col, bombRadius))
                    {
                        matrix[row, col] = 1;
                    }
                    else
                    {
                        matrix[row, col] = 0;
                    }
                }
            }
            
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                bool isColChanged = false;
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    if (matrix[row, col] == 0 && matrix[row+1, col] == 1)
                    {
                        matrix[row, col] = 1;
                        matrix[row + 1, col] = 0;
                        isColChanged = true;
                    }
                }

                if (isColChanged)
                {
                    col--;
                }
            }

            Print(matrix);
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsPointInside(int bombX, int bombY, int row, int col, int bombRadius)
        {
            double distance = Math.Sqrt(Math.Pow(row - bombX, 2) + Math.Pow(col - bombY, 2));
            if (distance > bombRadius)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
