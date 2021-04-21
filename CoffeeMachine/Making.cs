using CoffeeMachine.DTO;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CoffeeMachine
{
    public static class Making
    {
        public static void CoffeeMaking(List<ResourcesDTO> resurces, int price)
        {
            int suger = 0, coffee = 0, water = 0;
            int resWater = 0, resSugger = 0, resCoffee = 0;
            var resurc = Resources.GetResurces();
            foreach (var item in resurces)
            {
                
                suger = item.Suger;
                coffee = item.Coffee;
                water = item.Water;
            }
            foreach (var item in resurc)
            {
                resCoffee = item.Coffee;
                resWater = item.Water;
                resSugger = item.Suger;
            }
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string sqlExpression = $"UPDATE Resources SET water={resWater - water}, suger={resSugger - suger}, coffee={resCoffee - coffee} WHERE id=1";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
            

        }
    }
}
