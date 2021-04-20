using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    static class Coins
    {

        public static int insertCoins(int haveCoins = 0)
        {

            int coins = haveCoins;
            bool insertCoins = true, wantAddCoins = true;

            Console.WriteLine("Please insert coins");
            while (!insertCoins || wantAddCoins)
            {
                insertCoins = Int32.TryParse(Console.ReadLine(), out int addcoins);

                if (!insertCoins && !wantAddCoins)
                {
                    Console.WriteLine("Please insert right coins");
                    continue;
                }



                if (addcoins == 50 || addcoins == 100 || addcoins == 200 || addcoins == 500)
                {
                    coins += addcoins;
                    wantAddCoins = AddCoins.addCoins();
                }
                else
                {
                    Console.WriteLine("Please insert right coins");
                    continue;
                }
            }
            return coins;

        }
    }
}
