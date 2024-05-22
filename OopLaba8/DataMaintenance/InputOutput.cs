using System;

namespace OopLaba8.DataMaintenance
{
    public class InputOutput
    {

        public static int enterInt(int max, int min) {
            bool checkNumber = false;
            int number = 0;
            while (!checkNumber) {
                try
                {
                    number = Int32.Parse(Console.ReadLine());
                } catch (Exception e) {
                    Console.WriteLine("Invalid input. Please, enter a number");
                    continue;
                }
                checkNumber = Validation.validateNumber(number, max, min);
                if (!checkNumber) {
                    Console.WriteLine("Invalid input, please enter " +
                                      "number between " + max + " and " + min);
                }
            }
            return number;
        }

        public static string enterString() {
            string input = Console.ReadLine();
            return input;
        }
        public static bool enterBooleanData()
        {
         return Boolean.Parse(Console.ReadLine());
            
        }

    }
}