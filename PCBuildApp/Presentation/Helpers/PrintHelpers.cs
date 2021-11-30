using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Helpers
{
    public class PrintHelpers
    {
       public static void PrintComponentsMenu(int number)
        {
            bool hasAllInputs = false;
            if (number == 15) 
            {
                hasAllInputs = true;
            }

            if (number >= 8)
            {
                ConsoleHelper.Green("1 - Odabir Procesora\n");
                number -= 8;
            }
            else
            {
                Console.Write("1 - Odabir Procesora\n");
            }

            if(number >= 4)
            {
                ConsoleHelper.Green("2 - Odabir RAM memorije\n");
                number -= 4;
            }
            else
            {
                Console.Write("2 - Odabir RAM memorije\n");
            }

            if (number >= 2)
            {
                ConsoleHelper.Green("3 - Odabir hard diska\n");
                number -= 2;
            }
            else
            {
                Console.Write("3 - Odabir hard diska\n");
            }

            if (number >= 1)
            {
                ConsoleHelper.Green("4 - Odabir kučišta\n");
            }
            else
            {
                Console.Write("4 - Odabir kučišta\n");
            }

            if (hasAllInputs)
            {
                Console.Write("5 - Nastavak prema plačanju\n");
            }
            else
            {
                ConsoleHelper.Red("5 - Nastavak prema plačanju\n");
            }
            Console.WriteLine();
        }
    }
}
