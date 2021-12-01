using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Helpers
{
    public class PrintHelpers
    {
       public static void PrintComponentsMenu(int binaryMemory)
        {
            bool hasAllInputs = false;
            if (binaryMemory == 15) 
            {
                hasAllInputs = true;
            }

            if (binaryMemory >= 8)
            {
                ConsoleHelper.Green("1 - Mjenjanje Procesora\n");
                binaryMemory -= 8;
            }
            else
            {
                Console.Write("1 - Odabir Procesora\n");
            }

            if(binaryMemory >= 4)
            {
                ConsoleHelper.Green("2 - Mjenjanje RAM memorije\n");
                binaryMemory -= 4;
            }
            else
            {
                Console.Write("2 - Odabir RAM memorije\n");
            }

            if (binaryMemory >= 2)
            {
                ConsoleHelper.Green("3 - Mjenjanje hard diska\n");
                binaryMemory -= 2;
            }
            else
            {
                Console.Write("3 - Odabir hard diska\n");
            }

            if (binaryMemory >= 1)
            {
                ConsoleHelper.Green("4 - Mjenjanje kučišta\n");
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
