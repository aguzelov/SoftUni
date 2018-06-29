using System;
using System.Data.SqlClient;

public class StartUp
{
    public static void Main(string[] args)
    {
        using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
        {
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            Minion minion = new Minion();

            try
            {
                string townQuery = "SELECT * " +
                    "FROM Towns " +
                    "WHERE Name = @param";

                if (!ExecuteReader(connection, transaction, townQuery, minion.Town))
                {
                    string insertTown = "INSERT INTO Towns (Name) VALUES (@param)";

                    ExecuteNonQuery(connection, transaction, insertTown, minion.Town);

                    Console.WriteLine($"Town {minion.Town} was added to the database.");
                }

                string villianQuery = "SELECT * " +
                    "FROM Villains " +
                    "WHERE Name = @param";
                if (!ExecuteReader(connection, transaction, villianQuery, minion.Villian))
                {
                    string insertVillian = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@param,4)";

                    ExecuteNonQuery(connection, transaction, insertVillian, minion.Villian);

                    Console.WriteLine($"Villain {minion.Villian} was added to the database.");
                }

                string findVillianIdQuery = "SELECT DISTINCT Id " +
                    "FROM Villains " +
                    "WHERE Name = @param";
                int villianId = 0;
                int townId = 0;
                using (SqlCommand command = new SqlCommand(findVillianIdQuery, connection, transaction))
                {
                    command.Parameters.AddWithValue("@param", minion.Villian);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        villianId = int.Parse(reader[0].ToString());
                    }
                    command.Parameters.Clear();

                    command.CommandText = "SELECT Id " +
                    "FROM Towns " +
                    "WHERE Name = @param";
                    command.Parameters.AddWithValue("@param", minion.Town);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        townId = int.Parse(reader[0].ToString());
                    }
                    command.Parameters.Clear();

                    command.CommandText = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name,@age ,@townId)";
                    command.Parameters.AddWithValue("@name", minion.Name);
                    command.Parameters.AddWithValue("@age", minion.Age);
                    command.Parameters.AddWithValue("@townId", townId);

                    command.ExecuteNonQuery();

                    command.Parameters.Clear();

                    int minionId = 0;
                    command.CommandText = "SELECT Id " +
                    "FROM Minions " +
                    "WHERE Name = @param";
                    command.Parameters.AddWithValue("@param", minion.Name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        minionId = int.Parse(reader[0].ToString());
                    }
                    command.Parameters.Clear();

                    command.CommandText = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId ,@villianId )";
                    command.Parameters.AddWithValue("@minionId", minionId);
                    command.Parameters.AddWithValue("@villianId", villianId);

                    command.ExecuteNonQuery();

                    Console.WriteLine($"Successfully added {minion.Name} to be minion of {minion.Villian}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                Console.WriteLine("  Message: {0}", ex.Message);

                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    // This catch block will handle any errors that may have occurred
                    // on the server that would cause the rollback to fail, such as
                    // a closed connection.
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }

            connection.Close();
        }
    }

    private static void ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, string query, string param)
    {
        using (SqlCommand command = new SqlCommand(query, connection, transaction))
        {
            command.Parameters.AddWithValue("@param", param);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }
    }

    private static bool ExecuteReader(SqlConnection connection, SqlTransaction transaction, string query, string param)
    {
        using (SqlCommand command = new SqlCommand(query, connection, transaction))
        {
            command.Parameters.AddWithValue("@param", param);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    command.Parameters.Clear();
                    return false;
                }
            }
            command.Parameters.Clear();
        }

        return true;
    }
}