using System;
using System.Data.SqlClient;

namespace _6._Remove_Villain
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            int villianId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string findVillianName = "SELECT Name FROM Villains WHERE Id = @villianId";
                using (SqlCommand command = new SqlCommand(findVillianName, connection))
                {
                    command.Parameters.AddWithValue("@villianId", villianId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No such villain was found.");
                            return;
                        }
                        reader.Read();
                        Console.WriteLine($"{reader[0]} was deleted.");
                    }

                    command.CommandText = "DELETE FROM MinionsVillains WHERE VillainId = @villianId";
                    int minionsCount = command.ExecuteNonQuery();
                    Console.WriteLine($"{minionsCount} minions were released.");

                    command.CommandText = "DELETE FROM Villains WHERE Id = @villianId";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}