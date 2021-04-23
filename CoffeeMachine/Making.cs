using CoffeeMachine.DTO;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CoffeeMachine
{
    public static class Making
    {
        /// <summary>
        /// Updates resources table in data base according to the picked coffee
        /// </summary>
        /// <param name="neededResources"></param>
        
        public static void CoffeeMaking(ResourcesDTO neededResources)
        {


            var resourc = Resources.GetResurces();
            int suger = neededResources.Suger;
            int coffee = neededResources.Coffee;
            int water = neededResources.Water;

            int resCoffee = resourc.Coffee;
            int resWater = resourc.Water;
            int resSugger = resourc.Suger;
            

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
