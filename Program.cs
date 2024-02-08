//* group members:
//* Baulita, Andrea
//* Escabarte, Queeny
//* Pacampara, Rolan Dave

using System;
using System.ComponentModel;

namespace ConsoleBasedCalculator
{
    class Program
    {
        static void Main()
        {
            double operand1, operand2, result = 0;
            bool isValidInput = false;

            Console.Clear();
            do{
                Console.WriteLine("----- Calculator -----");
                Console.WriteLine("Enter first operand:");
                isValidInput = double.TryParse(Console.ReadLine(), out operand1);
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }else{
                    break;
                }
            }while(true);

            while (true)
            {
                Console.WriteLine("Enter second operand:");
                isValidInput = double.TryParse(Console.ReadLine(), out operand2);
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }
                
                DisplayMenu();

                int choice;
                isValidInput = int.TryParse(Console.ReadLine(), out choice);

                if (!isValidInput || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    Console.WriteLine("Restarting process...");
                    Thread.Sleep(3000); // added a 3 second delay before restarting the process if an invalid choice is entered
                    Main();
                }

                switch (choice)
                {
                    case 1:
                        result = Add(operand1, operand2);
                        break;
                    case 2:
                        result = Subtract(operand1, operand2);
                        break;
                    case 3:
                        result = Multiply(operand1, operand2);
                        break;
                    case 4:
                        if (operand2 == 0)
                        {
                            Console.WriteLine("Cannot divide by zero. Please enter a non-zero second operand.");
                            continue;
                        }
                        result = Divide(operand1, operand2);
                        break;
                }

                // displaying the result
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
                }else{
                    // memory handling to use previous result as the 1st operand for next operation to be done
                    operand1 = result;
                    Console.Clear();
                    Console.WriteLine("First operand is now " + result.ToString());
                    continue;
                }
            }
        }

        // function to display the menu
        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("----- Calculator Menu -----");
            Console.WriteLine("[1] Add");
            Console.WriteLine("[2] Subtract");
            Console.WriteLine("[3] Multiply");
            Console.WriteLine("[4] Divide");
            Console.WriteLine("Select an operation:");
        }

        // operation functions
        public static double Add(double operand1, double operand2)
        {
            return operand1 + operand2;
        }

        public static double Subtract(double operand1, double operand2)
        {
            return operand1 - operand2;
        }

        public static double Multiply(double operand1, double operand2)
        {
            return operand1 * operand2;
        }

        public static double Divide(double operand1, double operand2)
        {
            return operand1 / operand2;
        }
    }
}