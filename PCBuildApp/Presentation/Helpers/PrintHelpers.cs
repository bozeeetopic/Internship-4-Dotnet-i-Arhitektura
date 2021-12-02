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
            Console.WriteLine("Unesite broj komponente:\n");
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
        public static void PrintMainAppMenu()
        {
            Console.WriteLine("Unesite broj pored akcije koju želite ispisati:\n");
            Console.Write("1 - Dodavanje narudžbe\n");
            Console.Write("2 - Pregled narudžbi\n");
            Console.Write("3 - Log out\n");
            Console.WriteLine();
        }
        public static void PrintOrderMenu(bool hasOrder)
        {
            Console.WriteLine("Unesite broj željene akcije:\n");
            if (hasOrder)
            {
                ConsoleHelper.Green("1 - Dodavanje narudžbe\n");
            }
            else
            {
                Console.Write("1 - Dodavanje narudžbe\n");
            }

            ConsoleHelper.Green("2 - Dodavanje popusta\n");

            if (hasOrder)
            {
                Console.Write("3 - Naplati račun\n");
            }
            else
            {
                ConsoleHelper.Red("3 - Naplati račun\n");
            }
            Console.Write("4 - Natrag\n");
            Console.WriteLine();
        }
        public static void PrintMainMenu()
        {
            Console.WriteLine("Dobrodošli u PCBuildApp!");
            Console.WriteLine();
            Console.WriteLine("Moguće akcije su:");
            Console.WriteLine("1 - Korisnikov log-in");
            Console.WriteLine("2 - Exit App");
            Console.WriteLine();
        }
        public static void PrintShimentMenu()
        {
            Console.WriteLine("Unesite broj pored načina preuzimanja računala:\n");
            Console.Write("1 - Osobno preuzimanje (besplatno)\n");
            Console.Write("2 - Dostava (dodatna naplata ovisno o težini narudžbe)\n");
            Console.WriteLine();
        }
        public static void PrintDiscountMenu()
        {
            Console.WriteLine("Unesite vrstu popusta koje želite ostvariti:\n");
            Console.Write("1 - Popust na vjerno članstvo\n");
            Console.Write("2 - Popust na količinu\n");
            Console.Write("3 - Popust zbog promo kodova\n");
            Console.Write("4 - Povratak u prethodni meni\n");
            Console.WriteLine();
        }
    }
}
