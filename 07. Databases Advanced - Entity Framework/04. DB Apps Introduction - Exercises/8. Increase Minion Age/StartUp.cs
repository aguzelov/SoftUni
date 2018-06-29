using System;
using System.Data.SqlClient;
using System.Linq;

namespace _8._Increase_Minion_Age
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int[] minionsId = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                foreach (int id in minionsId)
                {
                    UpdateMinionNameAndAge(connection, id);
                }

                string findAllMinions = "SELECT Name, Age " +
                                        "FROM Minions";

                using (SqlCommand command = new SqlCommand(findAllMinions, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} {reader[1]}");
                        }
                    }
                }

                connection.Close();
            }
        }

        private static void UpdateMinionNameAndAge(SqlConnection connection, int param)
        {
            string updateMinionAgeAndName = "UPDATE Minions " +
                                "SET Age += 1 " +
                                ", Name = UPPER(LEFT(Name, 1)) + LOWER(RIGHT(Name, LEN(Name) - 1)) " +
                                "WHERE Id = @param";

            using (SqlCommand command = new SqlCommand(updateMinionAgeAndName, connection))
            {
                command.Parameters.AddWithValue("@param", param);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
        }
    }
}