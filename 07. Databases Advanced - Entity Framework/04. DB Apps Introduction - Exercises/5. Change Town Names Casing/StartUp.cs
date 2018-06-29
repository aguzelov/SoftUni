using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _5._Change_Town_Names_Casing
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                string countryName = Console.ReadLine();

                string findCountryId = "SELECT Id " +
                    "FROM Countries " +
                    "WHERE Name = @countryName";
                int countryId = 0;
                using (SqlCommand command = new SqlCommand(findCountryId, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No town names were affected.");
                            return;
                        }
                        reader.Read();
                        countryId = int.Parse(reader[0].ToString());
                    }

                    command.CommandText = "UPDATE Towns " +
                        "SET Name = upper(Name) " +
                        "WHERE CountryCode = @countryId";

                    command.Parameters.AddWithValue("@countryId", countryId);
                    int rowAffected = command.ExecuteNonQuery();
                    if (rowAffected == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                        return;
                    }

                    command.CommandText = "SELECT Name " +
                        "FROM Towns " +
                        "WHERE CountryCode = @countryId";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> towns = new List<string>();
                        while (reader.Read())
                        {
                            towns.Add(reader[0].ToString());
                        }
                        Console.WriteLine($"{towns.Count} town names were affected.");
                        Console.WriteLine("[" + string.Join(", ", towns) + "]");
                    }
                }

                connection.Close();
            }
        }
    }
}