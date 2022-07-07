using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal static class Input
    {
        public static string StringNotEmpyty(string inputName = "String")
        {
            string? input;
            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    Console.WriteLine($"{inputName} cannot be null or empty");
            } while (string.IsNullOrEmpty(input));
            return input;
        }

        public static DateOnly FutureDate()
        {
            DateOnly date;
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            do
            {
                string? input = Console.ReadLine();
                if (DateOnly.TryParse(input, out DateOnly parsedDate)
                    && parsedDate > today)
                    date = parsedDate;
                else
                    Console.WriteLine("Invalid date");
            } while (date <= today);
            return date;
        }
        
        public static int PositiveInt()
        {
            int positiveInt = 0;
            do
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int parsedInt)
                    && parsedInt > 0)
                    positiveInt = parsedInt;
                else
                    Console.WriteLine("Invalid int");
            } while (positiveInt == 0);
            return positiveInt;
        }

        public static bool YesOrNo()
        {
            string input = Console.ReadLine()!.ToLower();
            switch (input)
            {
                case "y":
                case "yes":
                    return true;
                case "n":
                case "no":
                    return false;
                default:
                    Console.WriteLine("Invalid input, please insert \"yes\" or \"no\" ('y'/'n')");
                    return YesOrNo();
            }
        }
    }
}
