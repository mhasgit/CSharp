using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SimpleCatch();
        }

        private static void NoErrorHandling()
        {
            string fileName = GetFileName();

            FileStream fs = File.Open(fileName, FileMode.Open);
            long fileSize = fs.Length;

            Console.WriteLine("'{0}' is {1} bytes", fileName, fileSize);
            fs.Close();
        }

        private const string FILENAME = @"A:Test.txt";

        private static string GetFileName()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("Press ENTER to use the default file {0}", FILENAME);
            Console.SetCursorPosition(0, 0);
            Console.Write("Enter a file name: ");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                newName = FILENAME;
            }
            Console.SetCursorPosition(0, 3);
            return newName;
        }

        private static void SimpleCatch()
        {
            string fileName = GetFileName();

            try
            {
                FileStream fs = File.Open(fileName, FileMode.Open);
                long fileSize = fs.Length;
                Console.WriteLine("'{0}' is {1} bytes", fileName, fileSize);
                fs.Close();
            }
            catch
            {
                Console.WriteLine("Error occured!");
            }
        }

        private static void ErrorBubbling()
        {
            try
            {
                A();
            }
            catch
            {
                Console.WriteLine("Error occurred!");
            }
        }

        private static void A()
        {
            B();
            Console.WriteLine("In B(). You'll never see this.");
        }

        private static void B()
        {
            C();
            Console.WriteLine("In C(). You'll never see this, either.");
        }

        private static void C()
        {
            string fileName = GetFileName();

            FileStream fs = File.Open(fileName, FileMode.Open);
            long fileSize = fs.Length;
            Console.WriteLine("'{0}' is {1} bytes", fileName, fileSize);
            fs.Close();
        }

        private static void WhichException()
        {
            string fileName = GetFileName();

            //Now you can at least tell what went wrong! 
            try
            {
                FileStream fs = File.Open(fileName, FileMode.Open);
                long fileSize = fs.Length;
                Console.WriteLine("'{0}' is {1} bytes", fileName, fileSize);
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
            }
            
        }

        private static void MultipleException()
        {
            string fileName = GetFileName();

            try
            {
                FileStream fs = File.Open(fileName, FileMode.Open);
                long fileSize = fs.Length;
                Console.WriteLine("'{0}' is {1} bytes", fileName, fileSize);
                fs.Close();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("You passed in a null argument.");
            }

            catch (ArgumentException)
            {
                Console.WriteLine("You specified an invalid filename. " + "Make sure you enter something besides spaces, " +
                    "and that none of the characters is invalid.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The path was'nt specified in the correct format.");
            }

            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You specified a folder name, not a file name; " + "perhaps you don't have sufficient rights.");
            }

            catch (PathTooLongException)
            {
                Console.WriteLine("The path is too long");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("You specified a folder that does'nt exist " + "or can't be found");
            }

            catch (IOException)
            {
                Console.WriteLine("An I/O error occurred. " + "Perhaps there's no disk in the drive?");
            }

            catch (Exception)
            {
                // You can't handle the exception.
                // Throw it back out to the caller, and hope
                // they can handle it! You'll only get here
                // if the exception isn't related to I/O
                // And that shouldn't happen
                throw;
            }
        }
    }
}
