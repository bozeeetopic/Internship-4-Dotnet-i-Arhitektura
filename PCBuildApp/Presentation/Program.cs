using System;
using Presentation.Helpers;
using Domain.GetAndSet;
using Presentation.Enums;

namespace Presentation
{
    class Program
    {
        static void Main()
        {
            SetFunctions.PullDiscountCodesFromData();
            while (true)
            {
                PrintHelpers.MainMenu();
                var choice = (MainMenuChoice)InputHelpers.UserNumberInput("vaš izbor", 1, 2);
                Console.Clear();
                switch (choice)
                {
                    case MainMenuChoice.LogIn:
                        {
                            UserLogin();
                            MainApp();
                            break;
                        }
                    case MainMenuChoice.Exit:
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
                var name = InputHelpers.UserStringInput("ime", ConsoleHelpers.symbols + ConsoleHelpers.numbers, 1);
                var surname = InputHelpers.UserStringInput("prezime", ConsoleHelpers.symbols + ConsoleHelpers.numbers, 1);
                var adress = InputHelpers.UserStringInput("adresu", ConsoleHelpers.symbols + ConsoleHelpers.numbers, 1);
                var adressNumber = InputHelpers.UserNumberInput("adresni broj", 1, 999);

                name = ConsoleHelpers.FormatWords(name.ToLower());
                surname = ConsoleHelpers.FormatWords(surname.ToLower());
                adress = ConsoleHelpers.FormatWords(adress.ToLower());

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
                PrintHelpers.MainAppMenu();
                var choice = (MainAppChoice)InputHelpers.UserNumberInput("sljedeću akciju", 1, 3);
                Console.Clear();
                switch (choice)
                {
                    case MainAppChoice.AddOrder:
                        {
                            AddOrder();
                            break;
                        }
                    case MainAppChoice.ListOrders:
                        {
                            var billsAndUser = GetFunctions.GetUserBills();
                            if (billsAndUser.Item2 == null)
                            {
                                Console.WriteLine("Niste još uvijek odradili svoj prvi shopping.");
                                Console.ReadKey();
                            }
                            else
                            {
                                PrintHelpers.PrintBill();
                            }
                            break;
                        }
                    case MainAppChoice.LogOut:
                        {
                            SetFunctions.LogOut();
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
                PrintHelpers.OrderMenu(GetFunctions.OrdersExist());
                var choice = (OrderChoice)InputHelpers.UserNumberInput("sljedeću akciju", 1, 4);
                Console.Clear();
                switch (choice)
                {
                    case OrderChoice.Order:
                        {
                            if (ChooseComponent())
                            {
                                ChooseShipmentMethod();
                                break;
                            }
                            break;
                        }
                    case OrderChoice.Discount:
                        {
                            AddDiscount();
                            break;
                        }
                    case OrderChoice.Bill:
                        {
                            if (!GetFunctions.OrdersExist())
                            {
                                Console.WriteLine("Nemoguće upisati račun bez ijednog unesenog PC-a!");
                                Console.ReadKey();
                                break;
                            }
                            SetFunctions.AddBill();
                            break;
                        }
                    case OrderChoice.Exit:
                        {
                            Console.Clear();
                            return;
                        }
                }
                Console.Clear();
            }
        }
        static bool ChooseComponent()
        {
            int numberOfStepsDone = 0;
            while (numberOfStepsDone <= 15)
            {
                Console.Clear();
                PrintHelpers.ComponentsMenu(numberOfStepsDone);
                var choice = (ComponentsChoice)InputHelpers.UserNumberInput("vaš izbor komponente", 1, 6);
                Console.Clear();
                switch (choice)
                {
                    case ComponentsChoice.Processor:
                        {
                            var processors = GetFunctions.GetProcessors();
                            var i = 1;
                            foreach (var processor in processors)
                            {
                                Console.WriteLine($"{i} - {processor}");
                                i++;
                            }
                            var userChoice = InputHelpers.UserNumberInput("vaš izbor procesora", 1, processors.Count);
                            numberOfStepsDone += SetFunctions.AddProcessor(userChoice - 1, processors);
                            break;
                        }
                    case ComponentsChoice.Ram:
                        {
                            var rams = GetFunctions.GetRAMs();
                            var i = 1;
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
                    case ComponentsChoice.HardDisc:
                        {
                            var hardDiscs = GetFunctions.GetHardDiscs();
                            var i = 1;
                            foreach (var hardDisc in hardDiscs)
                            {
                                Console.WriteLine($"{i} - {hardDisc}");
                                i++;
                            }
                            var userChoice = InputHelpers.UserNumberInput("vaš izbor hard diska", 1, hardDiscs.Count);
                            numberOfStepsDone += SetFunctions.AddHardDisk(userChoice - 1, hardDiscs);
                            break;
                        }
                    case ComponentsChoice.Case:
                        {
                            var cases = GetFunctions.GetCases();
                            var i = 1;
                            foreach (var computerCase in cases)
                            {
                                Console.WriteLine($"{i} - {computerCase}");
                                i++;
                            }
                            var userChoice = InputHelpers.UserNumberInput("vaš izbor kučišta", 1, cases.Count);
                            numberOfStepsDone += SetFunctions.AddCase(userChoice - 1, cases);
                            break;
                        }
                    case ComponentsChoice.Done:
                        {
                            if (numberOfStepsDone != 15)
                            {
                                Console.WriteLine("Nemoguće završiti kupnju, nisu sve komponente odabrane!");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine($"Vaš PC:\n{GetFunctions.GetPC()}\n");
                            if (InputHelpers.UserConfirmation("Ako ste zadovoljni i želite nastaviti prema odabiru načina preuzimanja potvrdite: "))
                            {
                                Console.Clear();
                                return true;
                            }
                            break;
                        }
                    case ComponentsChoice.Exit:
                        {
                            SetFunctions.SetPC();
                            return false;
                        }
                }
                Console.Clear();
            }
            return false;
        }
        static bool ChooseShipmentMethod()
        {
            Console.Clear();
            var travelPrice = 0;
            PrintHelpers.ShipmentMenu();
            var choice = (ShipmentChoice)InputHelpers.UserNumberInput("način preuzeća", 1, 2);
            switch (choice)
            {
                case ShipmentChoice.Self:
                    {
                        break;
                    }
                case ShipmentChoice.Delivery:
                    {
                        travelPrice = GetFunctions.GetDeliveryPrice();
                        break;
                    }
                case ShipmentChoice.Exit:
                    {
                        SetFunctions.SetPC();
                        return false;
                    }
            }
            SetFunctions.PutOrderIntoList(travelPrice);
            Console.Clear();
            return true;
        }
        static void AddDiscount()
        {
            while (true)
            {
                Console.Clear();
                var discounts = GetFunctions.GetDiscounts();
                PrintHelpers.DiscountMenu();
                var choice = (DiscountChoice)InputHelpers.UserNumberInput("odabir popusta", 1, 4);
                switch (choice)
                {
                    case DiscountChoice.VIP:
                        {
                            if (discounts.Item1)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                Console.ReadKey();
                                break;
                            }
                            if (!GetFunctions.AmountSpentIsEnough())
                            {
                                Console.WriteLine("Niste još ostvarili pravo na ovaj popust!");
                                Console.ReadKey();
                                break;
                            }
                            SetFunctions.SetDiscounts((true, discounts.Item2, discounts.Item3));
                            break;
                        }
                    case DiscountChoice.Amount:
                        {
                            if (discounts.Item2)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                Console.ReadKey();
                                break;
                            }
                            if (!GetFunctions.ThereAreThreeSameComponentsInBill())
                            {
                                Console.WriteLine("Niste još ostvarili pravo na ovaj popust!");
                                Console.ReadKey();
                                break;
                            }
                            SetFunctions.SetDiscounts((discounts.Item1, true, discounts.Item3));
                            break;
                        }
                    case DiscountChoice.Code:
                        {
                            if (discounts.Item3)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                Console.ReadKey();
                                break;
                            }
                            if (InputHelpers.UserSuccesfullCodeInput())
                            {
                                SetFunctions.SetDiscounts((discounts.Item1, discounts.Item2, true));
                            }
                            break;
                        }
                    case DiscountChoice.Back:
                        {
                            Console.Clear();
                            return;
                        }
                }
            }
        }
    }
}
