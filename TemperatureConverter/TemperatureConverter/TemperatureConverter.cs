
using System.Data.Common;

namespace Assignment_2
{
    internal class TemperatureConverter
    {
        List<double> celsiusList = new List<double>();
        List<double> fahrenheitList = new List<double>();

        /// <summary>
        /// Create lists of temperature conversions
        /// Show information.
        /// Initiate displaying the temperature conversion 
        /// then repeat until the user chooses to exit. 
        /// </summary>
        public void StartTemperatureConverter()
        {
            int input = 1; // start input as not 0 so the loop repeats at least once.
            CreateLists(); //Do once
            DisplayInfo(); //Do once

            do
            {
                input = GetUserChoice();
                Console.WriteLine("Your Choice: " + input);

                if (input == 1)
                {
                    DisplayLists(celsiusList, fahrenheitList);
                }
                if (input == 2)
                {
                    DisplayLists(fahrenheitList, celsiusList);
                }

            } while (input != 0);

        }
        /// <summary>
        /// Display menu options
        /// </summary>
        private void DisplayInfo()
        {
            Console.WriteLine();
            Console.WriteLine("------------------ Temperature Converter -------------------");
            Console.WriteLine("0: End program");
            Console.WriteLine("1: Convert temperatures from Celsius to Fahrenheit");
            Console.WriteLine("2: Convert temperatures from Fahrenheit to Celsius");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// prompts user to choose one available option
        /// </summary>
        /// <returns>chosen integer: 0, 1 or 2</returns>
        private int GetUserChoice()
        {
            string message = string.Format("Choose between 0, 1 and 2 to continue.");
            int[] validInputs = [0, 1, 2];
            int chooseOption = ReadIntegerConsole(message, validInputs);
            return chooseOption;
        }

        /// <summary>
        /// Read integer input and validate against set allowed values
        /// continues prompting until it recieves a valid input
        /// </summary>
        /// <param name="message">message displayed when requesting input</param>
        /// <param name="validInputs">array of valid integers</param>
        /// <returns>valid integer</returns>
        private int ReadIntegerConsole(string message, int[] validInputs)
        {
            int num = 0;
            bool done = false;
            do
            {
                Console.WriteLine(message);
                string strValue = Console.ReadLine();
                done = int.TryParse(strValue, out num) && validInputs.Contains(num);
            } while (!done);

            return num;
        }

        /// <summary>
        /// Generate lists of temperatures in C and corresponding temperatures in F
        /// </summary>
        public void CreateLists()
        {
            for (int i = 0; i <= 100; i += 5)
            {
                celsiusList.Add(i);
            }

            foreach (double i in celsiusList)
            {
                fahrenheitList.Add((9.0 / 5.0) * i + 32); //floating point division for accuracy.
            }
        }

        /// <summary>
        /// Display lists in the correct order and formating
        /// </summary>
        /// <param name="firstList">The list that should be displayed first i.e. C or F</param>
        /// <param name="secondList">The list that should be displayed secondly i.e. C or F</param>
        public void DisplayLists(List<double> firstList, List<double> secondList)
        {
            int columns = 3; // Number of columns
            int p = 0; // Counter printed values

            // Loop through the lists and print values
            for (int i = 0; i < celsiusList.Count; i++)
            {
                string textOut = string.Format($"{firstList[i], -5} °C = {secondList[i]} °F \t");

                Console.Write(textOut); // Print the formatted values
                p++; // Increment the counter

                // Check whether to break line
                if ((p % columns == 0) && (p >= columns))
                    Console.WriteLine(); //break line
            }
        }
    }
}