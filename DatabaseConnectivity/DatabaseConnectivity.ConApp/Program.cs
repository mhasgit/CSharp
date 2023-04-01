using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using System.Security;
using System.Configuration;
using DatabaseConnectivity.Library;

namespace DatabaseConnectivity.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] functions = new string[]
            {
                nameof(BasicConnectivity),
                nameof(DDLAndDMLBasics),
                nameof(EmployeeMapperExample),
                nameof(DisconnectedADO)
            };

            int selectedIndex = 0;
            while (true)
            {
                Console.Clear();

                for (int i = 0; i <= functions.Length - 1; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.WriteLine(functions[i]);
                }

                ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                switch (keyPressed.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex < 0)
                        {
                            selectedIndex = functions.Length - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex >= functions.Length)
                        {
                            selectedIndex = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        string selectedFunction = functions[selectedIndex];
                        ExecuteFunction(selectedFunction);
                        Console.ReadKey(true);
                        break;
                }
            }
        }

        private static void ExecuteFunction(string function)
        {
            switch (function)
            {
                case nameof(BasicConnectivity):
                    BasicConnectivity();
                    break;
                case nameof(DDLAndDMLBasics):
                    DDLAndDMLBasics();
                    break;
                case nameof(EmployeeMapperExample):
                    EmployeeMapperExample();
                    break;
                case nameof(DisconnectedADO):
                    DisconnectedADO();
                    break;
            }
        }


        private static void DisconnectedADO()
        {
            DataTable dt = new DataTable();
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = ConnectionHelper.GetSqlConnection(ConfigurationManager.ConnectionStrings["SQL2022"].ConnectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    // SELECT * FROM Locations;
                    command.CommandText = "SELECT * FROM Employees;";
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);

                    sqlAdapter.Fill(dt);
                }
                // SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM Employees", connection);
            }
        }

        private static void EmployeeMapperExample()
        {
            List<Employee> employees = new List<Employee>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQL2022"].ConnectionString;
            using (SqlConnection connection = ConnectionHelper.GetSqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    // Never trust the user input


                    // string userId = Console.ReadLine(); // -- DROP DATABASE TEST2;
                    // To prevent SQL Injection Attack, always use Parameters for command
                    command.CommandText = "SELECT EmployeeId, FirstName, LastName, Phone, Email FROM Employees"; //  WHERE EmployeeId = @ID
                    // command.Parameters.AddWithValue("@ID", 14);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //int employeeId = reader.GetInt32(0);
                            //string firstName = reader.GetString(1);
                            //string lastName = reader.GetString(2);
                            //string phone = reader.GetString(3);
                            //string email = reader.GetString(4);

                            //Console.WriteLine("{0} {1}", firstName, lastName);

                            Employee employee = EmployeeMapper.MapEmployee(reader);
                            employees.Add(employee);
                        }
                    }
                }

            }
        }

        private static void DDLAndDMLBasics()
        {
            SqlConnection connection = ConnectionHelper.GetSqlConnection("Data Source=localhost;Initial Catalog=master;");
            connection.Open();
            string sql = "INSERT INTO TABLE VALUES(); SELECT SCOPE_IDENTITY();";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TEST2') CREATE DATABASE TEST2";
            int rowsAffected = command.ExecuteNonQuery();

            connection.ChangeDatabase("TEST2");
            command.CommandText = @"
                  IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Employees')
                    CREATE TABLE [dbo].[Employees](
	                    [EmployeeID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	                    [FirstName] [varchar](50) NOT NULL,
	                    [LastName] [varchar](50) NOT NULL,
	                    [Email] [varchar](50) NOT NULL,
	                    [Phone] [varchar](20) NOT NULL
                    )";

            rowsAffected = command.ExecuteNonQuery();

            command.CommandText = @"
                        INSERT INTO Employees (FirstName, LastName, Email, Phone)
                        VALUES
                            ('Jane', 'Doe', 'janedoe@example.com', '123-456-7890'),
                            ('Bob', 'Smith', 'bobsmith@example.com', '123-456-7890'),
                            ('Alice', 'Johnson', 'alicejohnson@example.com', '123-456-7890'),
                            ('Tom', 'Wilson', 'tomwilson@example.com', '123-456-7890'),
                            ('Sara', 'Lee', 'saralee@example.com', '123-456-7890'),
                            ('Alex', 'Brown', 'alexbrown@example.com', '123-456-7890'),
                            ('Emily', 'Davis', 'emilydavis@example.com', '123-456-7890'),
                            ('Mark', 'Jackson', 'markjackson@example.com', '123-456-7890'),
                            ('Jessica', 'Clark', 'jessicaclark@example.com', '123-456-7890'),
                            ('Mike', 'Anderson', 'mikeanderson@example.com', '123-456-7890'),
                            ('Emily', 'Garcia', 'emilygarcia@example.com', '123-456-7890'),
                            ('Jack', 'White', 'jackwhite@example.com', '123-456-7890'),
                            ('Lauren', 'Smith', 'laurensmith@example.com', '123-456-7890'),
                            ('Sean', 'Lee', 'seanlee@example.com', '123-456-7890'),
                            ('Emily', 'Johnson', 'emilyjohnson@example.com', '123-456-7890'),
                            ('Mike', 'Davis', 'mikedavis@example.com', '123-456-7890'),
                            ('Linda', 'Anderson', 'lindaanderson@example.com', '123-456-7890'),
                            ('John', 'Garcia', 'johngarcia@example.com', '123-456-7890')
                        ";

            rowsAffected = command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        private static void BasicConnectivity()
        {
            // string connectionString = "Data Source=.;Initial Catalog=master;User=Hassan;Password=P@ssWord;Intergrated Security=True;MultipleActiveResultSets=True;SSPI=True";
            SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "master",
                IntegratedSecurity = true,
                ApplicationName = "DatabaseConnectivity"
            };

            Console.WriteLine(cb.ConnectionString);

            Debugger.Break();

            using (SqlConnection connection = ConnectionHelper.GetSqlConnection(cb.ConnectionString))
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
