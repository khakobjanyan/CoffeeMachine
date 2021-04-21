using CoffeeMachine.DTO;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CoffeeMachine
{
    public class Resources
    {
        public static List<ResourcesDTO> GetResurces()
        {
            var resurces = new List<ResourcesDTO>();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string commandText = "SELECT * FROM Resources";
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
                            var resurc = new ResourcesDTO()
                            {
                                Water = reader.GetInt32(1),
                                Coffee = reader.GetInt32(2),
                                Suger = reader.GetInt32(3)
                            };
                            resurces.Add(resurc);
                        }
                    }
                }
            }

            return resurces;
        }
        



    }
}
