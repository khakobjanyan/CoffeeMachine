using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using CoffeeMachine.DTO;
using System.Linq;
using System.Diagnostics;

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

        public static ResourcesDTO ChooseCoffee(List<ProductsDTO> products, out int price)
        {
            bool rightCoffe;
            int requiredId;
            price = 0;
            ResourcesDTO resources = null;
            do
            {
                Console.WriteLine("You can choose coffee selecting coffee number from 1 to 10");
                rightCoffe = Int32.TryParse(Console.ReadLine(), out requiredId);
                if (requiredId < 0 || requiredId > 11)
                {
                    rightCoffe = false;
                }

            } while (!rightCoffe);

            var product = products.FirstOrDefault(x => x.RequiredId == requiredId);

            if (product != null)
            {
                resources = new ResourcesDTO()
                {
                    Coffee = product.Coffee,
                    Water = product.Water,
                    Suger = product.Suger,
                };
                price = product.Price;
            }
            else
            {
                Process.GetCurrentProcess().Kill();
            }

            return resources;

        }

    }
}
