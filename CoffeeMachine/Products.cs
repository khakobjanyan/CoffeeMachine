using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    class Products
    {
        public static int ChooseCoffee(int coins)
        {
            string commandText = "SELECT * FROM Products";
            using (var connection = new SqliteConnection("Data Source=CoffeeMachine.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(commandText, connection);



                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        
                        Console.WriteLine($"You have {coins} coins");
                        Console.WriteLine("Please choose the coffee");
                        Console.WriteLine("\nNamber\tName\tPrice\n");
                        while (reader.Read())
                        {
                            var name = reader["name"];
                            var price = reader["price"];
                            var required = reader["required"];
                            Console.WriteLine($"{required}\t{name}\t{price}");
                        }
                    }
                }
            }

            
            bool rightCoffe;
            int requiredId;
            do
            {
                Console.WriteLine("You can choose coffee select coffee number from 1 to 10");
                rightCoffe = Int32.TryParse(Console.ReadLine(), out requiredId);
                if (requiredId < 0 || requiredId > 11)
                {
                    rightCoffe = false;
                }
                
            } while (!rightCoffe);

            return requiredId;
        }
    }
}
