using System;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine, string weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; }
        public string Color { get; set; }

        public void PrintCar()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{Model}:");
            output.AppendLine($"  {Engine.Model}:");
            output.AppendLine($"    Power: {Engine.Power}");
            output.AppendLine($"    Displacement: {Engine.Displacement}");
            output.AppendLine($"    Efficiency: {Engine.Efficiency}");
            output.AppendLine($"  Weight: {Weight}");
            output.AppendLine($"  Color: {Color}");

            Console.WriteLine(output);
        }
    }
}