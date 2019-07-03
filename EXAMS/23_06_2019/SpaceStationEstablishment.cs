using System;
using System.Collections.Generic;

namespace _02._Space_Station_Establishment
{
    class SpaceStationEstablishment
    {
        private static char[,] galaxy;
        private static int shipRow;
        private static int shipCol;

        private static List<int[]> blackHoles;

        private static int starPower = 0;
        private static bool isDissapeared = false;
        private static bool isInHole = false;


        static void Main(string[] args)
        {
            FillTheGalaxy();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "up")
                {
                    Move(-1, 0);
                }
                else if (command == "down")
                {
                    Move(+1, 0);
                }
                else if (command == "right")
                {
                    Move(0, +1);
                }
                else if (command == "left")
                {
                    Move(0, -1);
                }

                if (isDissapeared || starPower >= 50)
                {
                    break;
                }

            }

            if (isDissapeared)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }

            if (starPower >= 50)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {starPower}");

            PrintGalaxy();

        }

        private static void Move(int rowUpdate, int colUpdate)
        {
            int oldRow = shipRow;
            int oldCol = shipCol;
            shipRow += rowUpdate;
            shipCol += colUpdate;

            galaxy[oldRow, oldCol] = '-';

            if (IsOutOfGalaxy(shipRow, shipCol))
            {
                isDissapeared = true;
                return;

            }
            else if (char.IsDigit(galaxy[shipRow, shipCol]))
            {
                starPower += galaxy[shipRow, shipCol] - 48;
                galaxy[shipRow, shipCol] = 'S';
            }
            else if (galaxy[shipRow, shipCol] == 'O')
            {
                isInHole = true;

                for (int i = 0; i < blackHoles.Count; i++)
                {
                    if (blackHoles[i][0] != shipRow
                        && blackHoles[i][1] != shipCol)
                    {
                        galaxy[shipRow, shipCol] = '-';
                        shipRow = blackHoles[i][0];
                        shipCol = blackHoles[i][1];
                    }
                }
            }

        }

        private static bool IsOutOfGalaxy(int row, int col)
        {
            return row < 0
                   || row >= galaxy.GetLength(0)
                   || col < 0
                   || col >= galaxy.GetLength(1);
        }

        private static void PrintGalaxy()
        {
            for (int row = 0; row < galaxy.GetLength(0); row++)
            {
                for (int col = 0; col < galaxy.GetLength(1); col++)
                {
                    Console.Write(galaxy[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void FillTheGalaxy()
        {
            int n = int.Parse(Console.ReadLine());
            blackHoles = new List<int[]>();
            galaxy = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] inputLine = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    galaxy[row, col] = inputLine[col];

                    if (galaxy[row, col] == 'S')
                    {
                        shipRow = row;
                        shipCol = col;
                    }

                    if (galaxy[row, col] == 'O')
                    {
                        int[] blackHole = { row, col };
                        blackHoles.Add(blackHole);
                    }
                }
            }

        }
    }
}
