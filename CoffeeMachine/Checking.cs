using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    public static class Checking
    {

        public static bool checking(int requiredId, int coins)
        {
            int price = 0, coffee = 0, water = 0, sugger = 0;
            int resCoffee = 0, resWater = 0, resSugger = 0;
            string sqlExpression = $"SELECT price,water,coffee,suger FROM Products WHERE required={requiredId}";
            using (var connection = new SqliteConnection("Data Source=CoffeeMachine.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            price = reader.GetInt32(0);
                            if (price > coins)
                            {
                                Console.WriteLine("You don`t have enouth money");
                                return false;
                            }
                            coffee = reader.GetInt32(2);
                            water = reader.GetInt32(1);
                            sugger = reader.GetInt32(3);
                        }
                    }
                }

                command.CommandText = "SELECT * FROM Resurces";
                using (SqliteDataReader reader1 = command.ExecuteReader())
                {
                    if (reader1.Read())
                    {
                        resCoffee = reader1.GetInt32(2);
                        resSugger = reader1.GetInt32(3);
                        resWater = reader1.GetInt32(1);
                    }

                }

                if (resCoffee <= coffee || resSugger <= sugger || resWater <= water)
                {
                    Console.WriteLine("Sorry, I`m empty, BYE");
                    
                }
                else
                {
                    command.CommandText = $"UPDATE Resurces SET water={resWater - water}, suger={resSugger - sugger}, coffee={resCoffee - coffee} WHERE id=1";
                    command.ExecuteNonQuery();

                    Console.WriteLine("Your Coffee is done, ENJOY");
                    if ((coins - price) > 0)
                        Console.WriteLine($"Please give your coins: {coins - price}");

                }

            }

            return true;
        }
    }
}
