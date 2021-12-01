using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Presentation.Helpers
{
    public class ConsoleHelper
    {
        public const string numbers = "1234567890";
        public const string symbols = ",.-:;<>!#$%&/()=?*¸¨'";
        public const string letters = "qwertzuiopšđžćčlkjhgfdsayxcvbnm";
        public static void ClearNumberOfLinesFromConsole(int numberOfLinesToDelete)
        {
            for(var i = 0; i< numberOfLinesToDelete; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop-i);
            }
            Console.Write(new string(' ', Console.WindowWidth));
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

        public static string FormatWords(string stringToChange)
        {
            stringToChange = StringWithoutExtraSpaces(stringToChange);
            List<int> spaceLocations = new() { 0};
            for(var charIndex = 0; charIndex < stringToChange.Length-1; charIndex++)
            {
                if(stringToChange[charIndex] == ' ')
                {
                    spaceLocations.Add(charIndex+1);
                }
            }
            foreach(var index in spaceLocations)
            {
                stringToChange =  ChangeCharacterIntoUppercase(stringToChange, index);
            }
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
        public static string StringWithoutExtraSpaces(string stringWithSpaces)
        {
            while (stringWithSpaces.Length > 1 && stringWithSpaces[0] == ' ')
            {
                stringWithSpaces = stringWithSpaces.Remove(0, 1);
            }
            while (stringWithSpaces.Length > 1 && stringWithSpaces[^1] == ' ')
            {
                stringWithSpaces = stringWithSpaces.Remove(stringWithSpaces.Length - 1);
            }
            RegexOptions options = RegexOptions.None;
            Regex regex = new("[ \t]{2,}", options);
            stringWithSpaces = regex.Replace(stringWithSpaces, " ");
            return stringWithSpaces;
        }
        public static string ChangeCharacterIntoUppercase(string stringWithNoUppercase, int index)
        {
            try
            {
                var firstLetterNeedNotChange = numbers.Contains(stringWithNoUppercase[index]) || symbols.Contains(stringWithNoUppercase[index]) || letters.ToUpper().Contains(stringWithNoUppercase[index]);
                if (firstLetterNeedNotChange)
                {
                    return stringWithNoUppercase;
                }
                var letter = "" + stringWithNoUppercase[index];
                letter = letter.ToUpper();
            
                if (stringWithNoUppercase.Length > index + 1)
                {
                    stringWithNoUppercase = stringWithNoUppercase.Remove(index, 1);
                }
                else
                {
                    stringWithNoUppercase = stringWithNoUppercase.Remove(index);
                }
                stringWithNoUppercase = stringWithNoUppercase.Insert(index, letter);
            }
            catch
            {
            }
            return stringWithNoUppercase;
        }
    }
}
