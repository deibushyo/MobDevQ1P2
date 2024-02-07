using System;

namespace ConsoleBasedCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double operand1, operand2;
            double result = 0;
            bool isValidInput = false;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Enter first operand:");
                isValidInput = double.TryParse(Console.ReadLine(), out operand1);
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine("Enter second operand:");
                isValidInput = double.TryParse(Console.ReadLine(), out operand2);
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine("Choose an operation:");
                Console.WriteLine("[1] Add");
                Console.WriteLine("[2] Subtract");
                Console.WriteLine("[3] Multiply");
                Console.WriteLine("[4] Divide");

                int choice;
                isValidInput = int.TryParse(Console.ReadLine(), out choice);

                if (!isValidInput || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        result = operand1 + operand2;
                        break;
                    case 2:
                        result = operand1 - operand2;
                        break;
                    case 3:
                        result = operand1 * operand2;
                        break;
                    case 4:
                        if (operand2 == 0)
                        {
                            Console.WriteLine("Cannot divide by zero. Please enter a non-zero second operand.");
                            continue;
                        }
                        result = operand1 / operand2;
                        break;
                }

                // Display the result
                if (result % 1 == 0)
                {
                    Console.WriteLine("Result: " + result.ToString("0"));
                }
                else
                {
                    Console.WriteLine("Result: " + result.ToString("0.00"));
                }

                Console.WriteLine("Do you want to continue? (Y/N)");
                string continueChoice = Console.ReadLine();
                if (continueChoice.ToUpper() != "Y")
                {
                    break;
                }
            }
        }
    }
}