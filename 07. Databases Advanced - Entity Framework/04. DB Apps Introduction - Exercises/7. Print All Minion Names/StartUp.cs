using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _7._Print_All_Minion_Names
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string findAllMinionNames = "SELECT Name " +
                                            "FROM Minions";
                using (SqlCommand command = new SqlCommand(findAllMinionNames, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> names = new List<string>();

                        while (reader.Read())
                        {
                            names.Add(reader[0].ToString());
                        }

                        int offset = 0;
                        int firstIndex = 0;
                        int lastIndex = names.Count - 1;

                        while (offset != (names.Count / 2))
                        {
                            Console.WriteLine(names[firstIndex + offset]);
                            Console.WriteLine(names[lastIndex - offset]);
                            offset++;
                        }

                        if (names.Count % 2 == 1)
                        {
                            Console.WriteLine(names[offset]);
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}