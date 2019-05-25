namespace _07._SoftUni_Party
{
    using System;
    using System.Collections.Generic;

    class SoftUniParty
    {
        static void Main(string[] args)
        {
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PARTY")
                {
                    break;
                }

                if (char.IsDigit(input[0]))
                {
                    vip.Add(input);
                }
                else
                {
                    guests.Add(input);
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (char.IsDigit(input[0]))
                {
                    vip.Remove(input);
                }
                else
                {
                    guests.Remove(input);
                }
            }

            Console.WriteLine(vip.Count + guests.Count);
            foreach (var guest in vip)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
