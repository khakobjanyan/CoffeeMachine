using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, I`m a coffee machine");
            bool checkingResult = false;
            int requiredId, coins = 0;
            while (!checkingResult)
            {
                coins = Coins.insertCoins(coins);
                requiredId = Products.ChooseCoffee(coins);
                checkingResult = Checking.checking(requiredId, coins);
            }

        }
    }


}
