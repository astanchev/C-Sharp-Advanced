namespace _01._Action_Print
{
    using System;
    using System.Linq;
    class ActionPrint
    {
        static void Main(string[] args)
        {
            Action<string> Print = msg => Console.WriteLine(msg);
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(Print);
        }
    }
}
