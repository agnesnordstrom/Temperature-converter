namespace Assignment_2
{
    internal class CostCalculator
    {
        private double discountRate;
        private int quantity;
        private double unitPrice;

        public void ReadCostData() //Read input and call validation
        {
            unitPrice = ReadDoubleInput("Enter the original price per unit: ");
            quantity = ReadIntInput("Enter the quanitity of the product: ");
        }

        private double ReadDoubleInput(string prompt) //Validate double
        {
            double value;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
                Console.Write(prompt);  // Prompt again
            }
            return value;
        }

        private int ReadIntInput(string prompt) //validate int
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a whole and positive number.");
                Console.Write(prompt);  // Prompt again
            }
            return value;
        }

        public void SetDiscountRate() //calculate discount based on quantity
        {
            if (quantity >= 10 && quantity <= 19)
            {
                discountRate = 0.8; // 20% discount
            }
            else if (quantity >= 20 && quantity <= 49)
            {
                discountRate = 0.7; // 30% discount
            }
            else if (quantity >= 50 && quantity <= 99)
            {
                discountRate = 0.6; // 40% discount
            }
            else if (quantity >= 100)
            {
                discountRate = 0.5; // 50% discount
            }
            else
            {
                discountRate = 1; // No discount
            }
        }

        public void DisplayCalculation()
        {
            double originalCost = CalculateOriginalCost();
            double discountPercentage = CalculateDiscountPercentage();
            double finalCost = CalculateFinalCost();

            Console.WriteLine("Original Total Cost: " + originalCost);
            Console.WriteLine("Discount Applied: " + discountPercentage + "%");
            Console.WriteLine("Final Total Cost: " + finalCost);
        }

        private double CalculateOriginalCost() //calculate and return original cost.
        {
            return unitPrice * quantity;
        }
        private double CalculateFinalCost() //calculate and return final cost.
        {
            return unitPrice * quantity * discountRate;
        }
        private double CalculateDiscountPercentage() // transform discountRate into percentages
        {
            double percentage = (1 - discountRate) * 100;
            return Math.Round(percentage, 2); // round to 2 digits to avoid floating point errors
        }

        private bool checkIfContinue()
        {
            Console.WriteLine("Do you want to calculate again? y/n");
            string userInput = Console.ReadLine();
            if (userInput == "y")
            {
                return true;
            }
            else if (userInput == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Enter 'y' or 'n'");
                return checkIfContinue();

            }
        }
        public void StartCostCalculator()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                ReadCostData(); //read input
                SetDiscountRate(); //apply discount based on quantity
                DisplayCalculation(); //display result

                //ask whether to quit or rerun the calculations
                continueRunning = checkIfContinue();
            }
        }
    }
}
