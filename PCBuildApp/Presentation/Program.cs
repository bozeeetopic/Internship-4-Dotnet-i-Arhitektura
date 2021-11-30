using System;
using Presentation.Helpers;
using Domain;
using Presentation.Enums;

namespace Presentation
{
    class Program
    {
        static void Main()
        {
            do
            {
                GetComponent();
                //GetTakingOfPackage();
            }
            while (InputHelpers.UserConfirmation("Želite li unjeti još jedan PC? (da)"));
        }

        static void GetComponent()
        {
            int numberOfStepsDone = 0;
            while (numberOfStepsDone <= 15)
            {
                PrintHelpers.PrintComponentsMenu(numberOfStepsDone);
                var input = InputHelpers.UserNumberInput("vaš izbor", 1, 5);
                numberOfStepsDone += AddComponent(numberOfStepsDone, input);
                Console.Clear();
                numberOfStepsDone++;
                Console.WriteLine(numberOfStepsDone);
            }
        }

        public static int AddComponent(int numberOfStepsDone, int userChoice)
        {
            var choice = (ComponentsChoice)userChoice;
            switch (choice)
            {
                case ComponentsChoice.Processor:
                    {
                        if (numberOfStepsDone >= 8) { }
                        break;
                    }
                case ComponentsChoice.RAM:
                    {
                        break;
                    }
                case ComponentsChoice.HardDisc:
                    {
                        break;
                    }
                case ComponentsChoice.Case:
                    {
                        break;
                    }
                case ComponentsChoice.Done:
                    {
                        break;
                    }
            }
            return 0;
        }
    }
}
