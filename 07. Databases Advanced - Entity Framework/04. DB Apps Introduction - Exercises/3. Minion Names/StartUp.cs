using System;
using System.Data.SqlClient;

public class StartUp
{
    public static void Main(string[] args)
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            connection.Open();
            int villianId = int.Parse(Console.ReadLine());
            string villianNameQuery = "SELECT Name " +
                "FROM Villains" +
                " WHERE Id = @param";

            string query = "SELECT m.Name, m.Age " +
                "FROM Minions m " +
                "JOIN MinionsVillains mv ON m.Id = mv.MinionId " +
                "WHERE mv.VillainId = @param";

            using (SqlCommand command = new SqlCommand(villianNameQuery, connection))
            {
                command.Parameters.AddWithValue("@param", villianId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                        return;
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"Villian: {reader[0]}");
                    }
                }

                command.CommandText = query;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int rowNumber = 1;

                    if (!reader.HasRows)
                    {
                        Console.WriteLine($"(no minions)");
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"{rowNumber}. {reader[0]} {reader[1]}");

                        rowNumber++;
                    }
                }
            }

            connection.Close();
        }
    }
}