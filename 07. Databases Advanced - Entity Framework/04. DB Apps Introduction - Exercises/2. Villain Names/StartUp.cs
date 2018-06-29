using System;
using System.Data.SqlClient;

public class StartUp
{
    public static void Main(string[] args)
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            connection.Open();

            string query = "SELECT v.Name, count(mv.MinionId) AS[Number] " +
                "FROM MinionsVillains mv " +
                "JOIN Villains v ON mv.VillainId = v.Id " +
                "GROUP BY mv.VillainId, v.Name " +
                "HAVING count(mv.MinionId) > 3 " +
                "ORDER BY Number DESC";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} - {reader[1]}");
                    }
                }
            }

            connection.Close();
        }
    }
}