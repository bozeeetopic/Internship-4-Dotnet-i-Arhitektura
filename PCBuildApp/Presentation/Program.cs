using System;
using Presentation.Helpers;

namespace Presentation
{
    class Program
    {
        static void Main()
        {

            GetComponent();
            
        }

        static void GetComponent()
        {
            int numberOfStepsDone = 0;
            while (numberOfStepsDone <= 15)
            {
                Console.WriteLine(numberOfStepsDone);
                PrintHelpers.PrintComponentsMenu(numberOfStepsDone);
                Console.WriteLine(numberOfStepsDone);
                var choice = (Enums.ComponentsChoice)InputHelpers.UserNumberInput("vaš izbor", 1, 5);
                switch (choice)
                {
                    case Enums.ComponentsChoice.Processor:
                        {
                            // numberOfStepsDone = AddComponent();
                            break;
                        }
                }
                Console.Clear();
            }
        }
    }
}
