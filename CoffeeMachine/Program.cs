using CoffeeMachine.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, I`m a coffee machine");




            bool checkingResult = false;
            int  coins = 0, price;
            List<ResourcesDTO> neededResurces;

            while (!checkingResult)
            {
                Console.WriteLine("Please insert coins. Allowed coins are 50,100,200,500.");
                coins = Coins.insertCoins(coins);

                Console.WriteLine($"\nYou have {coins} coins");
                List<ProductsDTO> products = Products.GetProductsList();
                foreach (var item in products)
                {
                    Console.WriteLine($"\t{item.RequiredId}\t{item.Name}\t{item.Price}");
                }
                Console.WriteLine("You can choose coffee selecting coffee number from 1 to 10");
                neededResurces = Products.ChooseCoffee(products, out price);

                checkingResult = Checking.ProductChecking(neededResurces, coins, price);
                if (checkingResult)
                {
                    Making.CoffeeMaking(neededResurces, price);
                    Console.WriteLine("Your Coffee is done, ENJOY");
                    Console.WriteLine($"Please take your change. Your change is:{coins - price}");
                }

            }



        }
    }


}
