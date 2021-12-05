using System;
using Domain;
using Domain.GetAndSet;

namespace Presentation.Helpers
{
    public class PrintHelpers
    {
        public static void ComponentsMenu(int binaryMemory)
        {
            Console.WriteLine("Unesite broj komponente:\n");
            bool hasAllInputs = false;
            if (binaryMemory == 15)
            {
                hasAllInputs = true;
            }

            if (binaryMemory >= 8)
            {
                ConsoleHelpers.WriteInColor("1 - Mjenjanje Procesora\n", ConsoleColor.Green);
                binaryMemory -= 8;
            }
            else
            {
                Console.Write("1 - Odabir Procesora\n");
            }

            if (binaryMemory >= 4)
            {
                ConsoleHelpers.WriteInColor("2 - Mjenjanje RAM memorije\n", ConsoleColor.Green);
                binaryMemory -= 4;
            }
            else
            {
                Console.Write("2 - Odabir RAM memorije\n");
            }

            if (binaryMemory >= 2)
            {
                ConsoleHelpers.WriteInColor("3 - Mjenjanje hard diska\n", ConsoleColor.Green);
                binaryMemory -= 2;
            }
            else
            {
                Console.Write("3 - Odabir hard diska\n");
            }

            if (binaryMemory >= 1)
            {
                ConsoleHelpers.WriteInColor("4 - Mjenjanje kučišta\n", ConsoleColor.Green);
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
                ConsoleHelpers.WriteInColor("5 - Nastavak prema odabiru načina preuzeća\n", ConsoleColor.Red);
            }

            Console.Write("6 - Odustani\n");
            Console.WriteLine();
        }
        public static void MainAppMenu()
        {
            Console.WriteLine("Unesite broj pored akcije koju želite ispisati:\n");
            Console.Write("1 - Dodavanje narudžbe\n");
            Console.Write("2 - Pregled narudžbi\n");
            Console.Write("3 - Log out\n");
            Console.WriteLine();
        }
        public static void OrderMenu(bool hasOrder)
        {
            Console.WriteLine("Unesite broj željene akcije:\n");
            if (hasOrder)
            {
                ConsoleHelpers.WriteInColor("1 - Dodavanje narudžbe\n", ConsoleColor.Green);
            }
            else
            {
                Console.Write("1 - Dodavanje narudžbe\n");
            }

            ConsoleHelpers.WriteInColor("2 - Dodavanje popusta\n", ConsoleColor.Green);

            if (hasOrder)
            {
                Console.Write("3 - Naplati račun\n");
            }
            else
            {
                ConsoleHelpers.WriteInColor("3 - Naplati račun\n", ConsoleColor.Red);
            }
            Console.Write("4 - Natrag\n");
            Console.WriteLine();
        }
        public static void MainMenu()
        {
            Console.WriteLine("Dobrodošli u PCBuildApp!");
            Console.WriteLine();
            Console.WriteLine("Moguće akcije su:");
            Console.WriteLine("1 - Korisnikov log-in");
            Console.WriteLine("2 - Exit App");
            Console.WriteLine();
        }
        public static void ShipmentMenu()
        {
            Console.WriteLine("Unesite broj pored načina preuzimanja računala:\n");
            Console.Write("1 - Osobno preuzimanje (besplatno)\n");
            Console.Write("2 - Dostava (dodatna naplata ovisno o težini narudžbe)\n");
            Console.Write("3 - Odustani od narudžbe\n");
            Console.WriteLine();
        }
        public static void DiscountMenu((bool vip, bool amount, bool code) discount)
        {
            Console.WriteLine("Unesite vrstu popusta koje želite ostvariti:\n");
            if (discount.vip)
            {
                ConsoleHelpers.WriteInColor("1 - Popust na vjerno članstvo\n", ConsoleColor.Red);
            }
            else
            {
                Console.Write("1 - Popust na vjerno članstvo\n");
            }

            if (discount.amount)
            {
                ConsoleHelpers.WriteInColor("2 - Popust na količinu\n", ConsoleColor.Red);
            }
            else
            {
                Console.Write("2 - Popust na količinu\n");
            }

            if (discount.code)
            {
                ConsoleHelpers.WriteInColor("3 - Popust zbog promo kodova\n", ConsoleColor.Red);
            }
            else
            {
                Console.Write("3 - Popust zbog promo kodova\n");
            }
            Console.Write("4 - Povratak u prethodni meni\n");
            Console.WriteLine();
        }
        public static void PrintBill()
        {
            var billsAndUser = GetFunctions.GetUserBills();
            Console.Write(new string('=', Console.WindowWidth));
            Console.WriteLine();
            Console.WriteLine(billsAndUser.Item1.ToString());
            foreach (var bill in billsAndUser.Item2)
            {
                Console.Write(bill.ToString(bill.ExtraPartsDiscount));
                Console.Write(new string('-', Console.WindowWidth));
            }
            Console.WriteLine();
            Console.Write(new string('=', Console.WindowWidth));
            Console.ReadLine();
        }
    }
}
