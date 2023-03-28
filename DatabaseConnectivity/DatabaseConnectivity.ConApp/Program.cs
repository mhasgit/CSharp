using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace DatabaseConnectivity.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();

            cb.DataSource = ".";
            cb.InitialCatalog = "master";
            cb.IntegratedSecurity = true;
            // string connectionString = "Data Source=.;Initial Catalog=master;User=Hassan;Password=P@ssWord;Intergrated Security=True;MultipleActiveResultSets=True;SSPI=True";
            cb.ApplicationName = "DatabaseConnectivity";

            Console.WriteLine(cb.ConnectionString);

            Debugger.Break();

            using (SqlConnection connection = new SqlConnection(cb.ConnectionString))
            {
                connection.Open();

                Console.WriteLine(connection.State);

                Debugger.Break();

                string commandText = "SELECT * FROM sys.databases;";
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    Debugger.Break();

                    while (reader.Read())
                    {
                        Debugger.Break();

                        Console.WriteLine(reader.GetString(0));
                        Console.WriteLine(reader.GetInt32(1));
                    }
                }
            }

        }
    }
}
