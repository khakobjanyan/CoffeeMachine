using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using CoffeeMachine.DTO;

namespace CoffeeMachine
{
    class Products
    {
        public static List<ProductsDTO> GetProductsList()
        {
            var products = new List<ProductsDTO>();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string commandText = "SELECT * FROM Products";
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand(commandText, connection);



                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        
                        Console.WriteLine("Please choose the coffee");
                        Console.WriteLine("\nNamber\tName\tPrice\n");
                        while (reader.Read())
                        {
                            var product = new ProductsDTO()
                            {
                                RequiredId = reader.GetInt32(3),
                                Name = reader.GetString(1),
                                Price = reader.GetInt32(2),
                                Water = reader.GetInt32(4),
                                Coffee = reader.GetInt32(5),
                                Suger = reader.GetInt32(6)
                            };
                            products.Add(product);
                        }
                    }
                }
            }
            return products;

        }

        public static List<ResourcesDTO> ChooseCoffee(List<ProductsDTO> products, out int price)
        {
            bool rightCoffe;
            int requiredId;
            price = 0;
            var choosenCoffee = new List<ResourcesDTO>();
            do
            {
                Console.WriteLine("Please enter number from 1 to 10");
                rightCoffe = Int32.TryParse(Console.ReadLine(), out requiredId);
                if (requiredId < 0 || requiredId > 11)
                {
                    rightCoffe = false;
                }

            } while (!rightCoffe);
            foreach (var product in products)
            {
                if(product.RequiredId == requiredId)
                {
                    price = product.Price;
                    var resurces = new ResourcesDTO()
                    {
                        Coffee = product.Coffee,
                        Water = product.Water,
                        Suger = product.Suger,
                        
                    };
                    choosenCoffee.Add(resurces);
                }
            }

            
            return choosenCoffee;

        }

    }
}
