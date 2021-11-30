using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Helpers
{
    public class PrintHelpers
    {
       public static void PrintStepsDone(int number)
        {
            if(number >= 8)
            {
                ConsoleHelper.Green("Odabir komponenti:");
                number -= 8;
            }
            else
            {
                Console.WriteLine("Odabir komponenti:");
            }

            if(number >= 4)
            {
                ConsoleHelper.Green("drugo:");
                number -= 4;
            }
            else
            {
                Console.WriteLine("drugo:");
            }

            if (number >= 2)
            {
                ConsoleHelper.Green("trece:");
                number -= 2;
            }
            else
            {
                Console.WriteLine("trece:");
            }
            if (number >= 1)
            {
                ConsoleHelper.Green("cetri:");
            }
            else
            {
                Console.WriteLine("cetri:");
            }
        }
    }
}
