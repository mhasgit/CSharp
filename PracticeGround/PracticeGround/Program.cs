using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security;
using System.Data;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using InputOutputTools;
using InputOutputStream;
using InputOutputTools.BinarySerializer;

namespace PracticeGround
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestBinaryFileViewer();
        }

        #region File IO
        public static void TestBinaryFileViewer()
        {
            while (true)
            {
                string filePath = Console.ReadLine();

                Console.Clear();
                BinaryFileViewer.ViewFile(filePath);
            }
        }

        private static void TestSerializer()
        {

            Student student = new Student()
            {
                Id = 12,
                Name = "Ali",
                Address = "Kohat"
            };

            // Write
            FileSerializer<Student> fileSerializer = new FileSerializer<Student>("student.bin");
            fileSerializer.WriteObject(student);

            // Read
            Student studentFromFile = fileSerializer.ReadObject();
            Console.WriteLine(studentFromFile.Name);


        }

        private static void UseFileTransferTool()
        {
            Console.WriteLine("Src File Path");
            string srcFilePath = Console.ReadLine();
            Console.WriteLine("Dest File Path");
            string destFilePath = Console.ReadLine();

            FileTransferTool fileTransferTool = new FileTransferTool(srcFilePath, destFilePath);

            Console.WriteLine("Press enter to start file transfer");
            Console.ReadKey();

            fileTransferTool.Start();

            //fileTransferTool.Pause();
            //fileTransferTool.Resume();
            //fileTransferTool.Cancel();

            Console.WriteLine("File Transfer Completed");
            Console.ReadKey();

        }

        private static string ReadPassword()
        {
            Console.WriteLine("Enter your password");

            StringBuilder sb = new StringBuilder();

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    Console.WriteLine("\b \b");
                }
                else if (keyInfo.KeyChar != '\u0000' && keyInfo.Key != ConsoleKey.Backspace)
                {
                    sb.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }

                Console.WriteLine();
                Console.WriteLine("Your password is: " + sb);

            }
            return sb.ToString();
        }

        #endregion


        #region ADO.Net
        private static void BasicConnectivity()
        {
            SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "master",
                IntegratedSecurity = true,
                ApplicationName = "DatabaseConnectivity"
            };

            Console.WriteLine(cb.ConnectionString);

            using (SqlConnection connection = ConnectionHelper.GetSqlConnection(cb.ConnectionString))
            {
                connection.Open();

                Console.WriteLine(connection.State);

                string commandText = "SELECT * FROM sys.databases";
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0));
                        Console.WriteLine(reader.GetInt32(1));
                    }

                }
            }
        }

        private static void DDLAndDMLBasics()
        {
            SqlConnection connection = ConnectionHelper.GetSqlConnection("Data Source=localhost;Initial Catalog=master");
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

        private static void EmployeeMapperExample()
        {
            var employees = new List<Employee>();

            string connectionString = ConfigurationManager.ConnectionStrings["SQL2022"].ConnectionString;

            using (SqlConnection connecion = ConnectionHelper.GetSqlConnection(connectionString))
            {
                connecion.Open();

                using (SqlCommand command = connecion.CreateCommand())
                {

                    command.CommandText = "SELECT EmployeeId, FirstName, LastName, Phone, Email FROM Employees";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //int employeeId = reader.GetInt32(0);
                            //string firstName = reader.GetString(1);
                            //string lastName = reader.GetString(2);
                            //string email = reader.GetString(3);
                            //string phone = reader.GetString(4);

                            //Console.WriteLine("{0} {1}", employeeId, firstName);

                            Employee employee = EmployeeMapper.MapEmployee(reader);
                            employees.Add(employee);
                        }
                    }
                }

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
                    command.CommandText = "SELECT * FROM Employees";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);

                    sqlDataAdapter.Fill(dt);
                }

                //SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Employees", connection);
            }
        }

        #endregion
    }
}
