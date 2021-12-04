﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Helpers
{
    public class InputHelpers
    {
        public static string UserStringInput(string stringName, string forbiddenString, int minLength)
        {
            var repeatedInput = false;
            var input = "";
            int linesToDelete = 0;
            do
            {
                if (linesToDelete == 3)
                {
                    Console.SetCursorPosition(0, Console.GetCursorPosition().Top + 1);
                }
                if (linesToDelete != 0)
                {
                    ConsoleHelper.ClearNumberOfLinesFromConsole(linesToDelete);
                    Console.SetCursorPosition(0, Console.GetCursorPosition().Top - 1);
                }
                linesToDelete = 1;
                if (repeatedInput && (input.Trim().Length < minLength))
                {
                    Console.WriteLine("Duljina unosa mora biti " + minLength + "!");
                    linesToDelete++;
                }
                if (repeatedInput && ConsoleHelper.ForbiddenStringChecker(input.ToLower(), forbiddenString))
                {
                    Console.WriteLine("Unos sadrži znak, moraju biti isključivo brojevi!");
                    linesToDelete++;
                }

                Console.Write("Unesite " + stringName + ": ");
                ConsoleHelper.AddPlaceholder(stringName);
                input = Console.ReadLine();
                repeatedInput = true;
            }
            while ((input.Trim().Length < minLength) || ConsoleHelper.ForbiddenStringChecker(input.ToLower(), forbiddenString));
            return input;
        }
        public static int UserNumberInput(string message, int minValue, int maxValue)
        {
            var repeatedInput = false;
            int? number = 0;
            int linesToDelete = 2;
            do
            {
                if (repeatedInput)
                {
                    ConsoleHelper.ClearNumberOfLinesFromConsole(linesToDelete);
                    Console.SetCursorPosition(0, Console.GetCursorPosition().Top + 1);
                    if ((int)number == -1)
                    {
                        Console.Write("Morate unjeti ");
                        ConsoleHelper.Red("BROJ");
                        Console.Write(" između " + minValue + " i " + (maxValue) + "!\n");
                    }
                    else
                    {
                        Console.Write("Morate unjeti broj između ");
                        ConsoleHelper.Red("" + minValue);
                        Console.Write(" i ");
                        ConsoleHelper.Red("" + maxValue);
                        Console.Write("!\n");
                    }
                    linesToDelete = 3;
                }
                Console.Write("Unesite " + message + ":   ");
                ConsoleHelper.AddPlaceholder(ConsoleHelper.XForDecimals(maxValue));
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
            Console.Write(message);
            ConsoleHelper.AddPlaceholder("da");
            var eraseConfirm = Console.ReadLine();
            if (eraseConfirm.ToLower() is "da")
            {
                return true;
            }
            return false;
        }
    }
}
