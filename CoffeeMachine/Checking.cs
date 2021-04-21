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

        public static bool ProductChecking(List<ResourcesDTO> chossenCoffee, int coins, int price)
        {
            
            int resCoffee = 0, resWater = 0, resSugger = 0,  water = 0, coffee = 0, suger = 0;

            
            var resurces = Resources.GetResurces();

            foreach (var ingredient in chossenCoffee)
            {
                coffee = ingredient.Coffee;
                water = ingredient.Water;
                suger = ingredient.Suger;
                
            }

            
            foreach (var resurc in resurces)
            {
                resCoffee = resurc.Coffee;
                resSugger = resurc.Suger;
                resWater = resurc.Water;
                
            }

            if(price > coins)
            {
                Console.WriteLine("You don`t have enough money");
                return false;
            }
            if(resWater < water || resCoffee < coffee || resSugger < suger)
            {
                Console.WriteLine("Sorry, I`m empty, BYE");
                Process.GetCurrentProcess().Kill();
            }

            

            return true;

        }
    }
}
