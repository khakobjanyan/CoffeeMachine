using CoffeeMachine.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, I`m a coffee machine");




            bool checkingResult = false;
            int  coins = 0, price;
            ResourcesDTO neededResurces;

            while (!checkingResult)
            {
                Console.WriteLine("Please insert coins. Allowed coins are 50,100,200,500.");
                coins = Coins.insertCoins(coins);

                Console.WriteLine($"\nYou have {coins} coins");
                Console.WriteLine("Please choose the coffee.");
                Console.WriteLine("\nNamber\tName\tPrice");
                List<ProductsDTO> products = Products.GetProductsList();
                foreach (var item in products.OrderBy(x => x.RequiredId).ToList())
                {
                    Console.WriteLine($"{item.RequiredId}\t{item.Name}\t{item.Price}");
                }
               
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
