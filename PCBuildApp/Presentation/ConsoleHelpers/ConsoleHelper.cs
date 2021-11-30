using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ConsoleHelpers
{
    class ConsoleHelper
    {
        public static void ClearNumberOfLinesFromConsole(int numberOfLinesToDelete)
        {
            Console.SetCursorPosition(0, Console.CursorTop - numberOfLinesToDelete);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
