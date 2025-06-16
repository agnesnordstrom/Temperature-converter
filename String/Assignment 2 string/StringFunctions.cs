using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2C1
{
    internal class StringFunctions
    {
        public void StartStringFunctions()
        {

            do
            {
                StringLength();
                PredictMyDay();
            }
            while (RunAgain());
        }

        public void StringLength()
        {
            Console.WriteLine("---------- String length! ----------");
            Console.WriteLine();
            Console.WriteLine("Enter any text: ");
            string text = Console.ReadLine();
            int length = text.Length;
            Console.WriteLine($"Character count: {length}");
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
        }

        public void PredictMyDay()
        {
            Console.WriteLine("---------- Day predictor! ----------");
            Console.WriteLine();
            Console.Write("Enter a number between 1 and 7: ");
            if (int.TryParse(Console.ReadLine(), out int day))
            {
                switch (day)
                {
                    case 1:
                        Console.WriteLine("Keep calm on Mondays! You can fall apart!");
                        break;
                    case 2:
                    case 3:
                        Console.WriteLine("Tuesdays and Wednesdays break your heart!");
                        break;
                    case 4:
                        Console.WriteLine("Thursday is your lucky day, don't wait for Friday!");
                        break;
                    case 5:
                        Console.WriteLine("Friday, you are in love!");
                        break;
                    case 6:
                        Console.WriteLine("Saturday, do nothing and do plenty of it!");
                        break;
                    case 7:
                        Console.WriteLine("And Sunday always comes too soon!");
                        break;
                    default:
                        Console.WriteLine("No day? A good day but it doesn't exist!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number input");
            }
            Console.WriteLine();
        }

        public bool RunAgain()
        {
            Console.Write("Do you want to try again? (y/n): ");
            string response = Console.ReadLine();
            return string.Equals(response, "y", StringComparison.OrdinalIgnoreCase);

        }
    }
}