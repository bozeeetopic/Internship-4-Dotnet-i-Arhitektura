using System;
using Presentation.Helpers;
using Domain;
using Domain.GetAndSet;

namespace Presentation
{
    class Program
    {
        static void Main()
        {
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
                            Console.WriteLine("Hvala na korištenju!s");
                            return;
                        }
                }
            }
        }

        static void UserLogin()
        {
            var name = InputHelpers.UserStringInput("ime", ConsoleHelper.symbols + ConsoleHelper.numbers, 3);
            var surname = InputHelpers.UserStringInput("prezime", ConsoleHelper.symbols + ConsoleHelper.numbers, 3);
            var adress = InputHelpers.UserStringInput("adresu", ConsoleHelper.symbols + ConsoleHelper.numbers, 10);
            var adressNumber = InputHelpers.UserNumberInput("adresni broj", 1,99);
            var distance = new Random().Next(50,999);

            name = ConsoleHelper.FormatWords(name.ToLower());
            surname = ConsoleHelper.FormatWords(surname.ToLower());
            adress = ConsoleHelper.FormatWords(adress.ToLower());

            SetFunctions.AddUser(name,surname,adress+adressNumber,distance);
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
                            var orders = GetFunctions.GetUserOrders();
                            if (orders == null)
                            {
                                Console.WriteLine("Niste još uvijek odradili svoj prvi shopping.");
                            }
                            else
                            {
                                foreach (var order in orders)
                                {
                                    Console.WriteLine(order);
                                }
                            }
                            break;
                        }
                    case Enums.MainAppChoice.LogOut:
                        {
                            return;
                        }
                }
                Console.WriteLine("Enter za nasatavak..");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void AddOrder()
        {
            bool hasOrder = false;
            while (true)
            {
                PrintHelpers.PrintOrderMenu(hasOrder);
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
                                hasOrder = true;
                            }
                            while (InputHelpers.UserConfirmation("Želite li unjeti još računala (da)?"));
                            break;
                        }
                    case Enums.OrderChoice.Discount:
                        {
                            AddDiscount();
                            break;
                        }
                    case Enums.OrderChoice.Bill:
                        {
                            if (!hasOrder)
                            {
                                Console.WriteLine("Nemoguće upisati račun bez ijednog unesenog PC-a!");
                                break;
                            }
                            SetFunctions.AddBill();
                            hasOrder = false;
                            break;
                        }
                    case Enums.OrderChoice.Exit:
                        {
                            return;
                        }
                }
            }
        }

        static void ChooseComponent()
        {
            int numberOfStepsDone = 0;
            while (numberOfStepsDone <= 15)
            {
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
                                break;
                            }
                            Console.WriteLine("Vaš PC:\n" + GetFunctions.GetPC().ToString());
                            if (InputHelpers.UserConfirmation("Ako ste zadovoljni i želite nastaviti prema odabiru načina preuzimanja unesite DA: "))
                                return;
                            { }
                            break;
                        }
                }
                Console.WriteLine("ENTER za nastavak");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static void ChooseShipmentMethod()
        {
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
        }
        static void AddDiscount()
        {
            while (true)
            {
                PrintHelpers.PrintDiscountMenu();
                var choice = (Enums.DiscountChoice)InputHelpers.UserNumberInput("odabir popusta", 1, 4);
                switch (choice)
                {
                    case Enums.DiscountChoice.VIP:
                        {
                            if (true)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                break;
                            }
                        }
                    case Enums.DiscountChoice.Amount:
                        {
                            if (true)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                break;
                            }
                        }
                    case Enums.DiscountChoice.Code:
                        {
                            if (true)
                            {
                                Console.WriteLine("Već ste ostvarili ovaj popust!");
                                break;
                            }
                        }
                    case Enums.DiscountChoice.Back:
                        {
                            return;
                        }
                }
                return;
            }
        }
    }
}
