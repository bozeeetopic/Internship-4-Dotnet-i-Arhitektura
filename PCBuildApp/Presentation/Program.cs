using System;
using Presentation.Helpers;

namespace Presentation
{
    class Program
    {
        static void Main()
        { 

            int numberOfStepsDone = 0;
            while (numberOfStepsDone < 15)
            {
                PrintHelpers.PrintStepsDone(numberOfStepsDone);
                Console.WriteLine("sto zelite:");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    //number += getComponent();
                }
            }
            // ispis komponenti(broj)
            //broj = funckija
            //e
            
        }
    }
}
