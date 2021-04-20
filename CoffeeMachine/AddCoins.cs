using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    static class AddCoins
    {
        public static bool addCoins()
        {
            Console.WriteLine("Do you want add coins? \nif yes please push 'y' and 'n' if you don`t want");
            bool wrongAnsver;
            do
            {

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        
                        Console.WriteLine("\nPlease add coins");
                        return true;
                        wrongAnsver = false;
                        break;
                    case ConsoleKey.N:
                        return false;
                        wrongAnsver = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease push 'y' or 'n'");
                        wrongAnsver = true;
                        break;
                }
            } while (wrongAnsver);
            return false;
        }

    }
}
