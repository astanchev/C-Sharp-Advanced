using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        private const double distance = 20.0;
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> enginesList = new List<Engine>();
            List<Car> specialCarsList = new List<Car>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "No more tires")
                {
                    break;
                }

                string[] inputLine = input.Split();

                Tire[] currentTires = new Tire[4]
                {
                    new Tire(int.Parse(inputLine[0]), double.Parse(inputLine[1])),
                    new Tire(int.Parse(inputLine[2]), double.Parse(inputLine[3])),
                    new Tire(int.Parse(inputLine[4]), double.Parse(inputLine[5])),
                    new Tire(int.Parse(inputLine[6]), double.Parse(inputLine[7]))
                };

                tiresList.Add(currentTires);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Engines done")
                {
                    break;
                }

                string[] inputLine = input.Split();

                int horsePower = int.Parse(inputLine[0]);
                double cubicCapacity = double.Parse(inputLine[1]);

                Engine currentEngine = new Engine(horsePower, cubicCapacity);

                enginesList.Add(currentEngine);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Show special")
                {
                    break;
                }

                string[] inputLine = input.Split();

                string make = inputLine[0];
                string model = inputLine[1];
                int year = int.Parse(inputLine[2]);
                double fuelQuantity = double.Parse(inputLine[3]);
                double fuelConsumption = double.Parse(inputLine[4]);
                int engineIndex = int.Parse(inputLine[5]);
                int tireIndex = int.Parse(inputLine[6]);

                Car car = new Car(
                                 make, 
                                 model, 
                                 year, 
                                 fuelQuantity, 
                                 fuelConsumption, 
                                 enginesList[engineIndex], 
                                 tiresList[tireIndex]);

                if (IsSpecial(car))
                {
                    car.Drive(distance);
                    specialCarsList.Add(car);
                }
            }

            foreach (var car in specialCarsList)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }

        private static bool IsSpecial(Car car)
        {
            return car.Year >= 2017 
                   && car.Engine.HorsePower >= 330 
                   && car.Tires.Select(x => x.Pressure).Sum() >= 9 
                   && car.Tires.Select(x => x.Pressure).Sum() <= 10;
        }
    }

    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(
            string make,
            string model,
            int year,
            double fuelQuantity,
            double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public Car(
                    string make,
                    string model,
                    int year,
                    double fuelQuantity,
                    double fuelConsumption,
                    Engine engine,
                    Tire[] tires)
                    : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public void Drive(double distance)
        {
            bool canContinue = this.FuelQuantity - (distance * this.FuelConsumption / 100) >= 0;
            if (canContinue)
            {
                this.FuelQuantity -= distance * this.FuelConsumption / 100;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            sb.Append($"FuelQuantity: {this.FuelQuantity}");
            return sb.ToString();
        }
    }

    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }

    public class Tire
    {
        private int year;
        private double pressure;

        public int Year { get; set; }
        public double Pressure { get; set; }

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }
}

