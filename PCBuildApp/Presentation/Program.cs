using System;
using Presentation.Helpers;
using Domain;
using Domain.GetAndSet;
using System.Collections.Generic;

namespace Presentation
{
    class Program
    {
        static void Main()
        {
            SetFunctions.PullDiscountCodesFromData();
            while (true)
            {
                PrintHelpers.PrintMainMenu();
                var choice = (Enums.MainMenuChoice)InputHelpers.UserNumberInput("vaš izbor", 1, 2);
                Console.Clear();
                switch (choice)
                {
                    case Enums.MainMenuChoice.LogIn:
                        {
                            UserLogin();
                            MainApp();
                            break;
                        }
                    case Enums.MainMenuChoice.Exit:
                        {
                            Console.WriteLine("Hvala na korištenju!");
                            return;
                        }
                }
            }
        }
        static void UserLogin()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Unosite vaše podatke:\n");
                var name = InputHelpers.UserStringInput("ime", ConsoleHelper.symbols + ConsoleHelper.numbers, 3);
                var surname = InputHelpers.UserStringInput("prezime", ConsoleHelper.symbols + ConsoleHelper.numbers, 3);
                var adress = InputHelpers.UserStringInput("adresu", ConsoleHelper.symbols + ConsoleHelper.numbers, 1);
                var adressNumber = InputHelpers.UserNumberInput("adresni broj", 1, 999);

                name = ConsoleHelper.FormatWords(name.ToLower());
                surname = ConsoleHelper.FormatWords(surname.ToLower());
                adress = ConsoleHelper.FormatWords(adress.ToLower());

                Console.Clear();
                Console.WriteLine("Kornisnički podaci: ");
                Console.WriteLine($"Ime: {name}\nPrezime: {surname}\nAdresa: {adress} {adressNumber}");
                Console.WriteLine();

                SetFunctions.AddUser(name, surname, adress + " " + adressNumber, new Random(adressNumber + adress.Length).Next(50, 999));
            }
            while (!InputHelpers.UserConfirmation("Potvrdite unos korisnika: "));
            Console.Clear();
        }
        static void MainApp()
        {
            while (true)
            {
                PrintHelpers.PrintMainAppMenu();
                var choice = (Enums.MainAppChoice)InputHelpers.UserNumberInput("sljedeću akciju", 1, 3);
                Console.Clear();
                switch (choice)
                {
                    case Enums.MainAppChoice.AddOrder:
                        {
                            AddOrder();
                            break;
                        }
                    case Enums.MainAppChoice.ListOrders:
                        {
                            var billsAndUser = GetFunctions.GetUserBills();
                            if (billsAndUser.Item2 == null)
                            {
                                Console.WriteLine("Niste još uvijek odradili svoj prvi shopping.");
                                Console.ReadLine();
                            }
                            else
                            {
                                PrintBill();
                            }
                            break;
                        }
                    case Enums.MainAppChoice.LogOut:
                        {
                            return;
                        }
                }
                Console.Clear();
            }
        }

        static void AddOrder()
        {
            while (true)
            {
                PrintHelpers.PrintOrderMenu(GetFunctions.OrdersExist());
                var choice = (Enums.OrderChoice)InputHelpers.UserNumberInput("sljedeću akciju", 1, 4);
                Console.Clear();
                switch (choice)
                {
                    case Enums.OrderChoice.Order:
                        {
                            do
                            {
                                ChooseComponent();
                                ChooseShipmentMethod();
                            }
                            while (InputHelpers.UserConfirmation("Želite li unjeti još računala? Potvrdite:"));
                            break;
                        }
                    case Enums.OrderChoice.Discount:
                        {
                            AddDiscount();
                            break;
                        }
                    case Enums.OrderChoice.Bill:
                        {
                            if (!GetFunctions.OrdersExist())
                            {
                                Console.WriteLine("Nemoguće upisati račun bez ijednog unesenog PC-a!");
                                Console.ReadLine();
                                break;
                            }
                            SetFunctions.AddBill();
                            break;
                        }
                    case Enums.OrderChoice.Exit:
                        {
                            Console.Clear();
                            return;
                        }
                }
                Console.Clear();
            }
        }
        static void ChooseComponent()
        {
            int numberOfStepsDone = 0;
            while (numberOfStepsDone <= 15)
            {
                Console.Clear();
                PrintHelpers.PrintComponentsMenu(numberOfStepsDone);
                var choice = (Enums.ComponentsChoice)InputHelpers.UserNumberInput("vaš izbor komponente", 1, 5);
                Console.Clear();
                switch (choice)
                {
                    case Enums.ComponentsChoice.Processor:
                        {
                            var processors = GetFunctions.GetProcessors();
                            int i = 1;
                            foreach (var processor in processors)
                            {
                                Console.WriteLine($"{i} - {processor}");
                                i++;
                            }
                            var userChoice = InputHelpers.UserNumberInput("vaš izbor procesora", 1, processors.Count);
                            numberOfStepsDone += SetFunctions.AddProcessor(userChoice - 1, processors);
                            break;
                        }
                    case Enums.ComponentsChoice.RAM:
                        {
                            var rams = GetFunctions.GetRAMs();
                            int i = 1;
                            foreach (var ram in rams)
                            {
                                Console.WriteLine($"{i} - {ram}");
                                i++;
                            }
                            var userChoice = InputHelpers.UserNumberInput("vaš izbor RAM memorije", 1, rams.Count);
                            var ramAmount = InputHelpers.UserNumberInput("broj RAM memorija", 1, 4);
                            numberOfStepsDone += SetFunctions.AddRAM(userChoice - 1, rams, ramAmount);
                            break;
                        }
                    case Enums.ComponentsChoice.HardDisc:
                        {
                            var hardDiscs = GetFunctions.GetHardDiscs();
                            int i = 1;
                            foreach (var hardDisc in hardDiscs)
                            {
                                Console.WriteLine($"{i} - {hardDisc}");
                                i++;
                            }
                            var userChoice = InputHelpers.UserNumberInput("vaš izbor hard diska", 1, hardDiscs.Count);
                            numberOfStepsDone += SetFunctions.AddHardDisk(userChoice - 1, hardDiscs);
                            break;
                        }
                    case Enums.ComponentsChoice.Case:
                        {
                            var cases = GetFunctions.GetCases();
                            int i = 1;
                            foreach (var computerCase in cases)
                            {
                                Console.WriteLine($"{i} - {computerCase}");
                                i++;
                            }
                            var userChoice = InputHelpers.UserNumberInput("vaš izbor kučišta", 1, cases.Count);
                            numberOfStepsDone += SetFunctions.AddCase(userChoice - 1, cases);
                            break;
                        }
                    case Enums.ComponentsChoice.Done:
                        {
                            if (numberOfStepsDone != 15)
                            {
                                Console.WriteLine("Nemoguće završiti kupnju, nisu sve komponente odabrane!");
                                Console.ReadLine();
                                break;
                            }
                            Console.WriteLine("Vaš PC:\n" + GetFunctions.GetPC().ToString() + "\n");
                            if (InputHelpers.UserConfirmation("Ako ste zadovoljni i želite nastaviti prema odabiru načina preuzimanja potvrdite: "))
                            {
                                return;
                            }
                            break;
                        }
                }
                Console.Clear();
            }
        }
        static void ChooseShipmentMethod()
        {
            Console.Clear();
            int travelPrice = 0;
            PrintHelpers.PrintShimentMenu();
            var choice = (Enums.ShipmentChoice)InputHelpers.UserNumberInput("način preuzeća", 1, 2);
            switch (choice)
            {
                case Enums.ShipmentChoice.Self:
                    {
                        break;
                    }
                case Enums.ShipmentChoice.Delivery:
                    {
                        travelPrice = GetFunctions.GetDeliveryPrice();
                        break;
                    }
            }
            SetFunctions.PutOrderIntoList(travelPrice);
            Console.Clear();
        }
        static void AddDiscount()
        {
            while (true)
            {
                Console.Clear();
                var discounts = GetFunctions.GetDiscounts();
                PrintHelpers.PrintDiscountMenu();
                var choice = (Enums.DiscountChoice)InputHelpers.UserNumberInput("odabir popusta", 1, 4);
                switch (choice)
                {
                    case Enums.DiscountChoice.VIP:
                        {
                            if (discounts.Item1)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                Console.ReadLine();
                                break;
                            }
                            if (!GetFunctions.AmountSpentIsEnough())
                            {
                                Console.WriteLine("Niste još ostvarili pravo na ovaj popust!");
                                Console.ReadLine();
                                break;
                            }
                            SetFunctions.SetDiscounts((true, discounts.Item2, discounts.Item3));
                            break;
                        }
                    case Enums.DiscountChoice.Amount:
                        {
                            if (discounts.Item2)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                Console.ReadLine();
                                break;
                            }
                            if (!GetFunctions.ThereAreThreeSameComponentsInBill())
                            {
                                Console.WriteLine("Niste još ostvarili pravo na ovaj popust!");
                                Console.ReadLine();
                                break;
                            }
                            SetFunctions.SetDiscounts((true, discounts.Item2, discounts.Item3));
                            break;
                        }
                    case Enums.DiscountChoice.Code:
                        {
                            if (discounts.Item3)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                Console.ReadLine();
                                break;
                            }
                            if (UserSuccesfullCodeInput())
                            {
                                SetFunctions.SetDiscounts((true, discounts.Item2, discounts.Item3));
                            }
                            break;
                        }
                    case Enums.DiscountChoice.Back:
                        {
                            Console.Clear();
                            return;
                        }
                }
            }
        }
        static bool UserSuccesfullCodeInput()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Unos poklon bona za kupnju:\n");
                var userInput = InputHelpers.UserStringInput("kod", "", 10);
                if (GetFunctions.ContainsCode(userInput))
                {
                    return true;
                }
                Console.WriteLine("\nUneseni kod ne postoji!");
            }
            while (InputHelpers.UserConfirmation("Potvrdite ponovni unos: "));
            return false;
        }
        static void PrintBill()
        {
            var billsAndUser = GetFunctions.GetUserBills();
            Console.Write(new string('=', Console.WindowWidth));
            Console.WriteLine();
            Console.WriteLine(billsAndUser.Item1.ToString());
            foreach (var bill in billsAndUser.Item2)
            {
                foreach (var order in bill.Orders)
                {
                    Console.WriteLine(order.ToString()+"\n\n");
                }
                Console.Write(bill.ToString(bill.Discounts.Item2));

                Console.Write(new string('-', Console.WindowWidth));
            }
            Console.WriteLine();
            Console.Write(new string('=', Console.WindowWidth));
            Console.ReadLine();
        }
    }
}
