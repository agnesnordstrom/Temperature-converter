using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GuessANumberGame
{
    /// <summary>
    /// This class represents a simple game.  An object of this
    /// class generates a random number between 0 and 99 and 
    /// lets the user guess the number.
    /// </summary>
    internal class GuessTheNumber
    {
        int level = 1; //difficulty level starts at 1
        int maxAttempts = int.MaxValue; //infinite attempts

        private Random random = new Random();

        /// <summary>
        /// Start the game and then runs a loop until the user 
        /// chooses to exit.
        /// Show some information.
        /// Start Playing.
        /// After each round, ask the use to continue or exit.
        /// 
        /// </summary>
        public void Start()
        {
            bool play = true; //flag to decide to continue or not

            //Display some info about the game
            DisplayGameInfo();

            //Set Level
            SetLevel(); 
            //Run a loop.  play is true at the beginning
            //The loop runs at least once.
            while (play)
            {
                PlayGame();
                play = PlayAgain();
            }

            Console.WriteLine("Please kam-bak!");
        }

        /// <summary>
        /// Play one round.
        /// Randomize an integer number between 0 and 99.
        /// The Random class in C# has several methods: The Next method gives an int
        /// between a start and an end limit (not including the upper limit).
        /// </summary>
        private void PlayGame()
        {
            bool done = false;
            int randNum = random.Next(0, 100);
            int attempt = 0;  //unlimited number of attempts

            do
            {
                attempt++;
                done = CheckAttempts(attempt);

                string message = string.Format("Attempt no. {0, 2}, Your guess (0 - 99): ", attempt);

                //Get the user's number
                int userNum = ReadIntegerConsole(message);

                if (userNum == randNum)
                {
                    done = true;
                    Console.WriteLine();
                    Console.WriteLine(" ++++++++  Congratulations! +++++++++");
                }
                else if (userNum > randNum)
                    Console.WriteLine("Too high!");
                else
                    Console.WriteLine("Too low!");

            } while (!done);
        }

        ///set number of attempts
        private int SetNumberOfAttempts(int level)
        {
            switch (level)
            {
                case 2:
                    return 10; //10 attempts
                case 3:
                    return 8; //8 attempts
                case 4:
                    return 5; //5 attempts
                default:
                    return int.MaxValue; //infinite attempts
            }

        }

        private bool CheckAttempts(int attempt)
        {
            return attempt >= maxAttempts;
        }

        private void SetLevel()
        {
            string message = string.Format("Choose a level (1 - 4): ", level);
            level = ReadIntegerConsole(message);
            maxAttempts = SetNumberOfAttempts(level);
            Console.WriteLine($"You've leveled up to level {level}! You now have {maxAttempts} attempts.");
        }

        /// <summary>
        /// PlayAgain 
        /// Ask the user to continue or exit.
        /// </summary>
        /// <returns>return true if user answers 'y' or false otherwise.</returns>
        private bool PlayAgain()
        {
            Console.WriteLine();
            Console.Write("Play again (y/n)? ");
            char response = char.Parse(Console.ReadLine());

            if ((response == 'y') || (response == 'Y'))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Display game info.
        /// </summary>
        private void DisplayGameInfo()
        {
            Console.WriteLine();
            Console.WriteLine("------------------ GUESS THE NUMBER -------------------");
            Console.WriteLine("   The computer selects a random value between 0 and 99");
            Console.WriteLine("   You have guesss the number. The game will help you");
            Console.WriteLine("   by letting you know if the guess number is too high");
            Console.WriteLine("   or too low! It also displays the number of attempts.");
            Console.WriteLine("   the game stops and you replay.");
            Console.WriteLine("------------------ GUESS THE NUMBER -------------------");
            Console.WriteLine();
        }
        /// <summary>
        /// Read a numerical integer value from the console window. Convert the 
        /// user input from string to an integer.  If the user provides an 
        /// invalid value, the methods repeats asking for valid number.
        /// </summary>
        /// <param name="message">Message to display for the user!</param>
        /// <returns></returns>
        private int ReadIntegerConsole(string message)
        {
            
            int num = 0;

            bool done = false;
            do
            {
                Console.WriteLine(message);
                string strValue = Console.ReadLine();
                done = int.TryParse(strValue,out num);

            }while (!done);

            return num;
        }
    }
}
