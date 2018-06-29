using System;
using System.Data;
using System.Data.SqlClient;

namespace _9._Increase_Age_Stored_Procedure
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int minionId = int.Parse(Console.ReadLine());
                using (SqlCommand command = new SqlCommand("usp_GetOlder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@minionId", minionId));
                    command.ExecuteNonQuery();

                    command.CommandType = CommandType.Text;
                    string findNameAndAgeOfMinion = "SELECT Name, Age" +
                                                    " FROM Minions" +
                                                    " WHERE Id = @minionId";
                    command.CommandText = findNameAndAgeOfMinion;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Console.WriteLine($"{reader[0]} – {reader[1]} years old");
                    }
                }

                connection.Close();
            }
        }
    }
}