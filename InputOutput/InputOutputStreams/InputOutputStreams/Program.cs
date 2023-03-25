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
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter)
                {
                    break;
                }

                sb.Append(k.KeyChar);
            }

            return sb.ToString();
        }
    }
}
