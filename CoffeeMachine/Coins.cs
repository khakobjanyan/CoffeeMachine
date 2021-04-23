using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CoffeeMachine
{
    static class Coins
    {

        /// <summary>
        /// Used to add money
        /// </summary>
        /// <param name="haveCoins">inserted money</param>
        /// <returns>Sum of inserted money</returns>
        public static int insertCoins(int haveCoins = 0)
        {

            int coins = haveCoins;
            bool insertCoins = true, wantAddCoins = true;
            var acceptedCoinsString = ConfigurationManager.AppSettings.Get("acceptedCoins");
            var acceptedCoins = acceptedCoinsString.Split(',').ToList();
            
           
            while (!insertCoins || wantAddCoins)
            {
                insertCoins = Int32.TryParse(Console.ReadLine(), out int addcoins);

                if (!insertCoins && !wantAddCoins)
                {
                    Console.WriteLine("Please insert right coins , allowed coins are 50,100,200,500");
                    continue;
                }



                if (acceptedCoins.Contains(addcoins.ToString()))
                {
                    coins += addcoins;
                    wantAddCoins = AddCoins.addCoins();
                }
                else
                {
                    Console.WriteLine("Please insert right coins , allowed coins are 50,100,200,500");
                    continue;
                }
            }
            return coins;

        }
    }
}
