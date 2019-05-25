using System;
using System.Collections.Generic;

namespace _6._Hot_Potato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            Queue<string> queue = new Queue<string>(kids);
            int toss = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    string kid = queue.Dequeue();
                    queue.Enqueue(kid);
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
