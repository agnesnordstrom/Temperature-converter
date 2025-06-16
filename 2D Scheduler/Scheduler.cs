using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Scheduler
{
    internal class Scheduler
    {
        List<int> workingNightList = new List<int>();
        List<int> workingWeekendList = new List<int>();
        public void StartScheduler()
        {
            int input = 1; // start input as not 0 so the loop repeats at least once.
            CreateLists(); // do once
            ShowInformation(); //do once

            do
            {
                input = GetUserChoice();
                Console.WriteLine("Your Choice: " + input);

                if (input == 1)
                {
                    DisplayLists(workingNightList, "nights");
                    Console.WriteLine();
                    Console.WriteLine("\n ------------------------------------------------------------");
                }
                if (input == 2)
                {
                    DisplayLists(workingWeekendList, "weekends");
                    Console.WriteLine("\n ------------------------------------------------------------");
                }

            } while (input != 0);

        }


        public void ShowInformation()
        {
            Console.WriteLine();
            Console.WriteLine("------------------ Your work schedule -------------------");
            Console.WriteLine("0: End program");
            Console.WriteLine("1: Show a list of weekends to work");
            Console.WriteLine("2: Show a list of nights to work");
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
        /// Generate lists of weeks to work weekend and nights
        /// </summary>
        public void CreateLists()
        {
            //Adds every fourth week starting from week 1 to a list
            for (int i = 1; i <= 52; i += 1)
            {
                if (i % 4 == 1)
                {
                    workingNightList.Add(i);
                }
            }

            // Adds every even week starting from week 2 to a list
            for (int i = 2; i <= 52; i += 1) 
            {
                if (i % 2 == 0)
                {
                    workingWeekendList.Add(i);
                }
            }
        }

        /// <summary>
        /// Display the correct list and format it
        /// </summary>
        /// <param name="workingList">The list to show, nights or weekends</param>
        /// <param name="time">Weekends or nights</param>
        public void DisplayLists(List<int> workingList, string time)
        {
            int columns = 3; // Number of columns
            int p = 0; // Counter printed values

            Console.WriteLine($"You work {time} on the following weeks: ");


            // Loop through the lists and print values
            for (int i = 0; i < workingNightList.Count; i++)
            {
                string textOut = string.Format($"week {workingList[i], -5} \t");

                Console.Write(textOut); // Print the formatted values
                p++; // Increment the counter

                // Check whether to break line
                if ((p % columns == 0) && (p >= columns))
                    Console.WriteLine(); //break line
            }
        }

    }
}
