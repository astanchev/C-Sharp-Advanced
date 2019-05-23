using System.Linq;

namespace _5._Snake_Moves
{
    using System;
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();
            int snakeStartIndex = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0, i = snakeStartIndex; col < matrix.GetLength(1); col++, i++)
                {
                    matrix[row, col] = snake[i];
                    if (i == snake.Length - 1)
                    {
                        i = -1;
                    }

                    if (col == matrix.GetLength(1) - 1)
                    {
                        snakeStartIndex = i + 1;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
