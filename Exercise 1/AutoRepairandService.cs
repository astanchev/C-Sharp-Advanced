using System;
using System.Collections;
using System.Collections.Generic;

namespace _06._Auto_Repair_and_Service
{
    class AutoRepairAndService
    {
        static void Main(string[] args)
        {
            Stack<string> servedCars = new Stack<string>();
            string[] inputCars = Console.ReadLine().Split();
            Queue<string> waitingList = new Queue<string>(inputCars);
            string command = string.Empty;
            string modelName = string.Empty;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                if (input.Contains("CarInfo"))
                {
                    command = "CarInfo";
                    modelName = input.Split('-')[1];
                }
                else
                {
                    command = input;
                }


                switch (command)
                {
                    case "Service":
                        if (waitingList.Count > 0)
                        {
                            Console.WriteLine($"Vehicle {waitingList.Peek()} got served.");
                            servedCars.Push(waitingList.Dequeue());
                        }
                        break;
                    case "CarInfo":
                        if (waitingList.Contains(modelName))
                        {
                            Console.WriteLine("Still waiting for service.");
                        }
                        else
                        {
                            Console.WriteLine("Served.");
                        }
                        break;
                    case "History":
                        Console.WriteLine(string.Join(", ", servedCars));
                        break;
                    default: break;

                }
            }

            if (waitingList.Count > 0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", waitingList)}");
            }

            if (servedCars.Count > 0)
            {
                Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
            }
        }
    }
}
