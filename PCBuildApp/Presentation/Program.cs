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
        PrintHelpers.PrintLogo(ConsoleColor.White,ConsoleColor.Yellow,ConsoleColor.Blue);
        SetFunctions.PullDiscountCodesFromData();
        while (true)
        {
            Console.Clear();
            PrintHelpers.MainMenu();
            var choice = (MainMenuChoice)InputHelpers.UserNumberInput("vaš izbor", 1, 2);
            Console.Clear();
            switch (choice)
            {
                case MainMenuChoice.LogIn:
                    {
                        if (UserLogin())
                        {
                            MainApp();
                        }
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
        static bool UserLogin()
        {
            var name = "";
            var surname = "";
            var adress = "";
            var adressNumber = 0;
            var counterOfInputs = 0;
            while (true)
            {
                PrintHelpers.UserMenu(counterOfInputs);
                var choice = (UserChoice)InputHelpers.UserNumberInput("vaše podatke", 1, 5);
                Console.Clear();
                switch (choice)
                {
                    case UserChoice.Name:
                        {
                            if(name != "")
                            {
                                name = InputHelpers.UserStringInput("ime", ConsoleHelpers.symbols + ConsoleHelpers.numbers, 1);

                                break;
                            }
                            else
                            {
                                name = InputHelpers.UserStringInput("ime", ConsoleHelpers.symbols + ConsoleHelpers.numbers, 1);
                                counterOfInputs += 4;
                                break;
                            }
                        }
                    case UserChoice.Surname:
                        {
                            if (surname != "")
                            {
                                surname = InputHelpers.UserStringInput("prezime", ConsoleHelpers.symbols + ConsoleHelpers.numbers, 1);
                                break;
                            }
                            else
                            {
                                surname = InputHelpers.UserStringInput("prezime", ConsoleHelpers.symbols + ConsoleHelpers.numbers, 1);
                                counterOfInputs += 2;
                                break;
                            }
                        }
                    case UserChoice.Adress:
                        {
                            if (adressNumber != 0)
                            {
                                adress = InputHelpers.UserStringInput("adresu", ConsoleHelpers.symbols + ConsoleHelpers.numbers, 1);
                                adressNumber = InputHelpers.UserNumberInput("adresni broj", 1, 999);
                                break;
                            }
                            else
                            {
                                adress = InputHelpers.UserStringInput("adresu", ConsoleHelpers.symbols + ConsoleHelpers.numbers, 1);
                                adressNumber = InputHelpers.UserNumberInput("adresni broj", 1, 999);
                                counterOfInputs += 1;
                                break;
                            }
                        }
                    case UserChoice.Continue:
                        {
                            if (counterOfInputs < 7)
                            {
                                Console.WriteLine("Niste još unjeli sve podatke korisnika!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            name = ConsoleHelpers.FormatWords(name.ToLower());
                            surname = ConsoleHelpers.FormatWords(surname.ToLower());
                            adress = ConsoleHelpers.FormatWords(adress.ToLower());

                            Console.Clear();
                            Console.WriteLine("Kornisnički podaci: ");
                            Console.WriteLine($"Ime: {name}\nPrezime: {surname}\nAdresa: {adress} {adressNumber}");
                            Console.WriteLine();
                            if (InputHelpers.UserConfirmation("Potvrdite unos korisnika: "))
                            {
                                Console.Clear();
                                SetFunctions.AddUser(name, surname, adress + " " + adressNumber, new Random(adressNumber + adress.Length).Next(50, 999));
                                return true;
                            }
                            break;
                        }
                    case UserChoice.Abort:
                        {
                            if (counterOfInputs > 0)
                            {
                                if(!InputHelpers.UserConfirmation("Jeste li sigurni da želite izaći? Svi uneseni podaci će biti izgubljeni! Potvrdite: "))
                                {
                                    break;
                                }
                            }
                            Console.Clear();
                            return false;
                        }
                }
                Console.Clear();
            }
        }
        static void MainApp()
        {
            while (true)
            {
                PrintHelpers.MainAppMenu(GetFunctions.OrdersExist());
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
                                System.Threading.Thread.Sleep(1000);
                            }
                            else
                            {
                                PrintHelpers.PrintBill();
                            }
                            break;
                        }
                    case MainAppChoice.LogOut:
                        {
                            if (GetFunctions.OrdersExist())
                            {
                                if (InputHelpers.UserConfirmation("Ako se izlogirate izgubit ćete svoje trenutno nenaplaćene narudžbe. Nastaviti? "))
                                {
                                    Console.Clear();
                                    SetFunctions.LogOut();
                                    return;
                                }
                                break;
                            }
                            SetFunctions.LogOut();
                            Console.Clear();
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
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            Console.WriteLine(GetFunctions.GetBill().ToString(GetFunctions.GetBill().ExtraPartsDiscount));
                            if (InputHelpers.UserConfirmation("Jeste li sigururni da želite naplatiti ovaj račun? "))
                            {
                                SetFunctions.AddBill();
                            }
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
                                System.Threading.Thread.Sleep(1000);
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
                PrintHelpers.DiscountMenu(discounts);
                var choice = (DiscountChoice)InputHelpers.UserNumberInput("odabir popusta", 1, 4);
                Console.Clear();
                switch (choice)
                {
                    case DiscountChoice.VIP:
                        {
                            if (discounts.Item1)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            if (GetFunctions.AmountSpentIsEnough())
                            {
                                Console.WriteLine("Ostvarili ste VIP popust u iznosu  100kn");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            Console.WriteLine("Niste još ostavarili pravo na ovaj popust!");
                            System.Threading.Thread.Sleep(1000);
                            break;
                        }
                    case DiscountChoice.Amount:
                        {
                            if (discounts.Item2)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            if (!GetFunctions.ThereAreThreeSameComponentsInBill())
                            {
                                Console.WriteLine("Niste još ostvarili pravo na ovaj popust!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            var bill = GetFunctions.GetBill();
                            Console.WriteLine("Ostvarili ste pravo na ovaj popust!");
                            foreach(var component in bill.ExtraComponents())
                            {
                                Console.WriteLine($"\t{component}");
                            }
                            Console.WriteLine(value: $"\tUkupna cijena besplatnih komponenata: \t\t\t\t{Data.Entities.Bill.TotalPriceOfExtraComponents(bill.ExtraComponents())}kn");
                            System.Threading.Thread.Sleep(1000);
                            SetFunctions.SetDiscounts(true);
                            break;
                        }
                    case DiscountChoice.Code:
                        {
                            if (discounts.Item3)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                System.Threading.Thread.Sleep(1000);
                                break;
                            }
                            InputHelpers.UserSuccesfullCodeInput();
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
