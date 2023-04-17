namespace InputOutputStreams
{
    using InputOutputTools;
    using System;
    using System.CodeDom;
    using System.Data.SqlClient;
    using System.IO;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading;

    public class Program
    {
        static void Main(string[] args)
        {
            TestBinaryFileViewer();
            
        }

        public static void TestBinaryFileViewer()
        {
            while (true)
            {
                string filePath = Console.ReadLine();

                Console.Clear();
                BinaryFileViewer.ViewFile(filePath);
            }
        }

        private static void TestFileSerializer()
        {
            // Write Object
            Student student = new Student
            {
                Id = 1,
                Name = "Test",
                Address = "Random Address"
            };

            FileSerializer<Student> fileSerializer = new FileSerializer<Student>("student.bin");
            fileSerializer.WriteObject(student);

            // Read Object
            Student studentFromFile = fileSerializer.ReadObject();
            Console.WriteLine(studentFromFile.Name);
        }

        private static void UseFileTransferTool()
        {
            Console.Write("Src File Path: ");
            string srcFilePath = Console.ReadLine();
            Console.Write("Dest File Path: ");
            string destFilePath = Console.ReadLine();

            FileTransferTool fileTransferTool = new FileTransferTool(srcFilePath, destFilePath);

            Console.WriteLine("Press enter to start file transfer");
            Console.ReadKey();

            // File.Copy(srcFilePath, destFilePath, true);

            fileTransferTool.Start();

            fileTransferTool.Pause();
            fileTransferTool.Resume();
            fileTransferTool.Cancel();

            Console.WriteLine("File transfer complete");
            Console.ReadKey();
        }

        private static string ReadPassword()
        {
            Console.Write("Enter your password: ");

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
                    Console.Write("\b \b");
               }
                else if (keyInfo.KeyChar != '\u0000' && keyInfo.Key != ConsoleKey.Backspace)
                {
                    sb.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Your password is: " + sb);

            return sb.ToString();
        }
    }
}
