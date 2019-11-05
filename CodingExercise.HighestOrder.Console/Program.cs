using System;
using System.Collections.Generic;

namespace CodingExercise.HighestOrder.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please enter List of Interger for Highest Common Factor - Type S to cancel");
            var listofintergers = new List<int>();

            while (true)
            {
                System.Console.WriteLine("Please enter an interger value - Type S to cancel");
                var input = System.Console.ReadLine();
                int currentinterger;

                if (input.Equals("S", StringComparison.OrdinalIgnoreCase))
                    break;

                if (int.TryParse(input, out currentinterger) == false)
                    System.Console.WriteLine("Value not interger");
                else
                    listofintergers.Add(currentinterger);
            }
            System.Console.WriteLine($"Highest Order Factor {HighestCommonDivisorFactor.GetHighestCommonDivisor(listofintergers)}");
        }
    }
}
