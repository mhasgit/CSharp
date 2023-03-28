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

namespace DatabaseConnectivity.ConApp
{

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class EmployeeMapper
    {
        public static Employee MapEmployee(SqlDataReader reader)
        {
            var employee = new Employee();

            employee.EmployeeId = (int)reader["EmployeeId"];
            employee.FirstName = (string)reader["FirstName"];
            employee.LastName = (string)reader["LastName"];
            employee.Email = (string)reader["Email"];
            employee.Phone = (string)reader["Phone"];

            return employee;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQL2022"].ConnectionString;
            using (SqlConnection connection = GetSqlConnection(connectionString))
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
            SqlConnection connection = GetSqlConnection("Data Source=localhost;Initial Catalog=master;");
            connection.Open();

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

        private static SqlConnection GetSqlConnection(string connectionString, bool useCredentials = true)
        {
            if (useCredentials)
            {
                SecureString secureString = GetSecureString("P@ssw0rd");
                SqlCredential credential = new SqlCredential("sa", secureString);
                return new SqlConnection(connectionString, credential);
            }

            return new SqlConnection(connectionString);
        }

        private static SecureString GetSecureString(string password)
        {
            SecureString secureString = new SecureString();
            for (int i = 0; i < password.Length; i++)
            {
                secureString.AppendChar(password[i]);
            }
            secureString.MakeReadOnly();
            return secureString;
        }

        private static void BasicConnectivity()
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
