using System;

namespace CoffeeMachine
{
    static class AddCoins
    {
        public static bool addCoins()
        {
            Console.WriteLine("Do you want to add coins? \nif yes press 'y', if no press 'n'");
            bool wrongAnsver;
            do
            {

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        
                        Console.WriteLine("\nPlease add coins. Allowed coins are 50,100,200,500.");
                        return true;
                    case ConsoleKey.N:
                        return false;
                    default:
                        Console.WriteLine("\nPlease press 'y' or 'n'");
                        wrongAnsver = true;
                        break;
                }
            } while (wrongAnsver);
            return false;
        }

    }
}
