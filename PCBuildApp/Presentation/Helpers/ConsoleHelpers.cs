using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Presentation.Helpers
{
    public class ConsoleHelpers
    {
        public const string numbers = "1234567890";
        public const string symbols = ",.-:;<>!#$%&/()=?*¸¨'";
        public const string letters = "qwertzuiopšđžćčlkjhgfdsayxcvbnm";
        public static void ClearNumberOfLinesFromConsole(int numberOfLinesToDelete)
        {
            for (var i = 0; i < numberOfLinesToDelete; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - i);
            }
            Console.Write(new string(' ', Console.WindowWidth));
        }
        public static void WriteInColor(string input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void AddPlaceholder(string placeholderString)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(placeholderString);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(Console.CursorLeft - placeholderString.Length, Console.CursorTop);
        }
        public static string WriteXForDecimals(int maxValue)
        {
            var stringToReturn = "";
            while (maxValue > 0)
            {
                stringToReturn += "X";
                maxValue = (maxValue - (maxValue % 10)) / 10;
            }
            return stringToReturn;
        }
        public static string FormatWords(string stringToChange)
        {
            stringToChange = StringWithoutExtraSpaces(stringToChange);
            List<int> spaceLocations = new() { 0 };
            for (var charIndex = 0; charIndex < stringToChange.Length - 1; charIndex++)
            {
                if (stringToChange[charIndex] == ' ')
                {
                    spaceLocations.Add(charIndex + 1);
                }
            }
            foreach (var index in spaceLocations)
            {
                stringToChange = ChangeCharacterIntoUppercase(stringToChange, index);
            }
            return stringToChange;
        }
        public static bool ForbiddenStringChecker(string stringBeingChecked, string forbiddenCharacters)
        {
            foreach (var character in forbiddenCharacters)
            {
                if (stringBeingChecked.Contains(character))
                {
                    return true;
                }
            }
            return false;
        }
        public static string StringWithoutExtraSpaces(string stringBeingChanged)
        {
            while (stringBeingChanged.Length > 1 && stringBeingChanged[0] == ' ')
            {
                stringBeingChanged = stringBeingChanged.Remove(0, 1);
            }
            while (stringBeingChanged.Length > 1 && stringBeingChanged[^1] == ' ')
            {
                stringBeingChanged = stringBeingChanged.Remove(stringBeingChanged.Length - 1);
            }
            RegexOptions options = RegexOptions.None;
            Regex regex = new("[ \t]{2,}", options);
            stringBeingChanged = regex.Replace(stringBeingChanged, " ");
            return stringBeingChanged;
        }
        public static string ChangeCharacterIntoUppercase(string stringBeingUppercased, int index)
        {
            try
            {
                var firstLetterNeedNotChange = numbers.Contains(stringBeingUppercased[index]) || symbols.Contains(stringBeingUppercased[index]) || letters.ToUpper().Contains(stringBeingUppercased[index]);
                if (firstLetterNeedNotChange)
                {
                    return stringBeingUppercased;
                }
                var letter = "" + stringBeingUppercased[index];
                letter = letter.ToUpper();

                if (stringBeingUppercased.Length > index + 1)
                {
                    stringBeingUppercased = stringBeingUppercased.Remove(index, 1);
                }
                else
                {
                    stringBeingUppercased = stringBeingUppercased.Remove(index);
                }
                stringBeingUppercased = stringBeingUppercased.Insert(index, letter);
            }
            catch
            {
            }
            return stringBeingUppercased;
        }
    }
}
