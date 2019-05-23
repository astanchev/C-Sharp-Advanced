using System.Linq;

namespace _4._Matrix_Shuffling
{
    using System;
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (IsInputValid(input, matrix))
                {
                    string[] inputLine = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    int row1 = int.Parse(inputLine[1]);
                    int col1 = int.Parse(inputLine[2]);
                    int row2 = int.Parse(inputLine[3]);
                    int col2 = int.Parse(inputLine[4]);

                    Swap(row1, col1, row2, col2, matrix);

                    Print(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        private static void Swap(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            string temp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = temp;
        }

        private static void Print(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col > 0)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsInputValid(string input, string[,] matrix)
        {
            string[] inputLine = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (inputLine.Length != 5)
            {
                return false;
            }
            if (inputLine[0] != "swap")
            {
                return false;
            }
            bool isRow1Correct = int.TryParse(inputLine[1], out int row1);
            bool isCol1Correct = int.TryParse(inputLine[2], out int col1);
            bool isRow2Correct = int.TryParse(inputLine[3], out int row2);
            bool isCol2Correct = int.TryParse(inputLine[4], out int col2);

            if (isRow1Correct && isCol1Correct && isRow2Correct && isCol2Correct)
            {
                if (row1 < 0 || row1 > matrix.GetLength(0) - 1)
                {
                    return false;
                }

                if (col1 < 0 || col1 > matrix.GetLength(1) - 1)
                {
                    return false;
                }

                if (row2 < 0 || row2 > matrix.GetLength(0) - 1)
                {
                    return false;
                }

                if (col2 < 0 || col2 > matrix.GetLength(1) - 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
