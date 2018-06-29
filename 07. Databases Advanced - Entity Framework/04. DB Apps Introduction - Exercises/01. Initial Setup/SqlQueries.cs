using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

public class SqlQueries : IEnumerable<string>
{
    private List<string> queries;

    public SqlQueries()
    {
        this.queries = new List<string>();
    }

    public string DatabaseName { get; set; }

    public void AddQuery(string query)
    {
        this.queries.Add(query);
    }

    public void ExecuteNonQuery(SqlConnection connection)
    {
        ChangeDatabase(connection);

        while (this.queries.Count != 0)
        {
            string query = this.queries[0];

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
                if (query.StartsWith("CREATE DATABASE"))
                {
                    string databaseName = string.Empty;

                    int length = query.Length;
                    int indexOfLastSpace = query.LastIndexOf(" ") + 1;
                    databaseName = query.Substring(indexOfLastSpace, length - indexOfLastSpace);

                    connection.ChangeDatabase(databaseName);

                    this.DatabaseName = databaseName;
                }
            }
            this.queries.RemoveAt(0);
        }

        if (this.queries.Count != 0)
        {
            throw new InvalidOperationException("Not all queries is executed!");
        }
    }

    public void ExecuteNonQuery(SqlConnection connection, string query)
    {
        ChangeDatabase(connection);

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.ExecuteNonQuery();
            if (query.StartsWith("CREATE DATABASE"))
            {
                string databaseName = string.Empty;

                int length = query.Length;
                int indexOfLastSpace = query.LastIndexOf(" ") + 1;
                databaseName = query.Substring(indexOfLastSpace, length - indexOfLastSpace);

                connection.ChangeDatabase(databaseName);

                this.DatabaseName = databaseName;
            }
        }
    }

    private void ChangeDatabase(SqlConnection connection)
    {
        if (connection.Database != this.DatabaseName && !string.IsNullOrEmpty(this.DatabaseName))
        {
            connection.ChangeDatabase(this.DatabaseName);
        }
    }

    public IEnumerator<string> GetEnumerator()
    {
        return this.queries.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.queries.GetEnumerator();
    }
}