using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Helpers
{
    public class InputHelpers
    {
        public static string UserStringInput(string nameOrSurname, string forbiddenString, int minLength)
        {
            var repeatedInput = false;
            var input = "";
            do
            {
                if (repeatedInput && (input.Length < minLength))
                {
                    Console.WriteLine("Duljina " + nameOrSurname + "na mora biti " + minLength + "!");
                }
                if (repeatedInput && ConsoleHelper.ForbiddenStringChecker(input.ToLower(), forbiddenString))
                {
                    Console.WriteLine(nameOrSurname + " sadrži znak, moraju biti isključivo brojevi!");
                }
                Console.Write("Unesite " + nameOrSurname + ": ");
                input = Console.ReadLine();
                Console.WriteLine();
                repeatedInput = true;
            }
            while ((input.Length < minLength) || ConsoleHelper.ForbiddenStringChecker(input.ToLower(), forbiddenString));
            return input;
        }
        public static int UserNumberInput(string message, int minValue, int maxValue)
        {
            var repeatedInput = false;
            int? number;
            int linesToDelete = 1;
            do
            {
                if (repeatedInput)
                {
                    ConsoleHelper.ClearNumberOfLinesFromConsole(linesToDelete);
                    Console.WriteLine("Morate unjeti broj između " + minValue + " i " + (maxValue) + "!");
                    linesToDelete = 2;
                }
                Console.Write("Unesite " + message + ":   ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                }
                catch
                {
                    number = -1;
                }
                repeatedInput = true;
            }
            while (number > maxValue || number < minValue);
            return (int)number;
        }
        public static bool UserConfirmation(string message)
        {
            Console.WriteLine(message);
            var eraseConfirm = Console.ReadLine();
            if (eraseConfirm is "da")
            {
                return true;
            }
            return false;
        }
    }
}
