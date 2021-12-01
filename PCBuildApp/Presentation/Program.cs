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

            GetComponent();
            GetShipmentMethod();
        }

        static void GetComponent()
        {
            int numberOfStepsDone = 0;
            do
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
                            Console.WriteLine("Vaš PC:\n"+GetFunctions.GetPC().ToString());
                            return;
                        }
                }
                Console.WriteLine("ENTER za nastavak");
                Console.ReadLine();
                Console.Clear();
            } while (numberOfStepsDone <= 15);
        }
        static void GetShipmentMethod()
        {

        }
    }
}
