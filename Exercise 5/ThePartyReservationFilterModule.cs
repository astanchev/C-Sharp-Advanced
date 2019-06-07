namespace _11._The_Party_Reservation_Filter_Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();
            List<string> filters = new List<string>();
            Predicate<string> predicate;
            Action<List<string>> Print = g => Console.WriteLine(string.Join(" ", g));

            while (true)
            {
                string[] input = Console.ReadLine().Split(";");
                if (input[0] == "Print")
                {
                    break;
                }

                string command = input[0];
                string filter = input[1] + "=>" + input[2];

                if (command == "Add filter")
                {
                    filters.Add(filter);
                }
                else
                {
                    filters.Remove(filter);
                }
            }

            foreach (var filter in filters)
            {
                string[] splitedFilter = filter.Split("=>");
                string filterType = splitedFilter[0];
                string filterParameter = splitedFilter[1];

                predicate = GetPredicate(filterType, filterParameter);

                guests.RemoveAll(predicate);
            }

            Print(guests);
        }

        private static Predicate<string> GetPredicate(string filterType, string filterParameter)
        {
            if (filterType == "Starts with")
            {
                return p => p.StartsWith(filterParameter);
            }
            else if (filterType == "Ends with")
            {
                return p => p.EndsWith(filterParameter);
            }
            else if (filterType == "Length")
            {
                return p => p.Length == int.Parse(filterParameter);
            }
            else if (filterType == "Contains")
            {
                return p => p.Contains(filterParameter);
            }

            return null;
        }
    }
}
