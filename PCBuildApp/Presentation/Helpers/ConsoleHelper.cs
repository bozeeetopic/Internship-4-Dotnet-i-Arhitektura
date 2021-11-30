using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Helpers
{
    public class ConsoleHelper
    {
        const string numbers = "1234567890";
        const string symbols = " ,.-:;<>!#$%&/()=?*¸¨'";
        const string letters = "qwertzuiopšđžćčlkjhgfdsayxcvbnm";
        public static void ClearNumberOfLinesFromConsole(int numberOfLinesToDelete)
        {
            Console.SetCursorPosition(0, Console.CursorTop - numberOfLinesToDelete);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void Red(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Green(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static string TurnFirstCharacterUppercase(string stringToChange)
        {
            var firstLetterNeedNotChange = numbers.Contains(stringToChange[0]) || symbols.Contains(stringToChange[0]) || letters.ToUpper().Contains(stringToChange[0]);
            if (firstLetterNeedNotChange)
            {
                return stringToChange;
            }
            string letter = ""+stringToChange[0];
            letter = letter.ToUpper();
            stringToChange= stringToChange.Remove(0, 1);
            stringToChange=stringToChange.Insert(0, letter);
            return stringToChange;
        }
        public static bool ForbiddenStringChecker(string stringBeingChecked, string forbiddenString)
        {
            foreach (var character in forbiddenString)
            {
                if (stringBeingChecked.Contains(character))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
