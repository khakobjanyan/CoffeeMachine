using CoffeeMachine.DTO;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace CoffeeMachine
{
    public static class Checking
    {

        public static bool ProductChecking(ResourcesDTO chossenCoffee, int coins, int price)
        {

            var resources = Resources.GetResurces();

            int coffee = chossenCoffee.Coffee;
            int water = chossenCoffee.Water;
            int suger = chossenCoffee.Suger;

            int resCoffee = resources.Coffee;
            int resSugger = resources.Suger;
            int resWater = resources.Water;


            if (price > coins)
            {
                Console.WriteLine("You don`t have enough money");
                return false;
            }
            if (resWater < water || resCoffee < coffee || resSugger < suger)
            {
                Console.WriteLine("Sorry, I`m empty, BYE");
                Process.GetCurrentProcess().Kill();
            }



            return true;

        }
    }
}
