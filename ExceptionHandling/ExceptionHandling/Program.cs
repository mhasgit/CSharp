using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("A. No Error Handling");
                Console.WriteLine("B. Simple Catch");
                Console.WriteLine("C. Error Bubbling");
                Console.WriteLine("D. Which Exception");
                Console.WriteLine("E. Multiple Exception");
                Console.WriteLine("F. Throw Exception");
                Console.WriteLine("G. Test Finally");
                Console.WriteLine("G. Test Using");
                Console.WriteLine("I. User-defined Exception");
                Console.WriteLine();

                char input;
                Console.Write("Enter your choice: ");
                input = Convert.ToChar(Console.Read());
                switch (Char.ToUpper(input))
                {
                    case 'A':
                        NoErrorHandling();
                        break;
                    case 'B':
                        SimpleCatch();
                        break;
                    case 'C':
                        ErrorBubbling();
                        break;
                    case 'D':
                        WhichException();
                        break;
                    case 'E':
                        MultipleException();
                        break;
                    case 'F':
                        ThrowException();
                        break;
                    case 'G':
                        TestFinally();
                        break;
                    case 'H':
                        TestUsing();
                        break;
                    case 'I':
                        UserDefinedException();
                        break;

                    default:
                        Console.WriteLine("Wrong Input! try again.......");
                        break;
                }
            } while (true);
           
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

        private static void ThrowException()
        {
            try
            {
                TestThrow();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error occurred:" + ex.Message);
                try
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
                catch (Exception)
                {
                    // Do nothing.
                }
            }
        }

        private static void TestThrow()
        {
            string fileName = GetFileName();

            // No matter what happens, throw back
            // a FileNotFoundException.
            try
            {
                FileStream fs = File.Open(fileName, FileMode.Open);
                long fileSize = fs.Length;
                Console.WriteLine("'{0}' is {1} bytes", fileName, fileSize);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw (new FileNotFoundException("Unable to open the specific file.", ex));
            }
        }

        private static void TestFinally()
        {
            // Run Finally block to run code no
            // matter what else happens.

           FileStream fs = null;
            DriveInfo di = new DriveInfo("C:\\");

            try
            {
                string fileName = GetFileName();
                fs = File.Open(fileName, FileMode.Open);
                long fileSize = fs.Length;
                long copies = di.TotalSize / fileSize;
                Console.WriteLine("'{0}' is {1} bytes. " + "You can have {2} of these on the drive.", fileName, fileSize, copies);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                // Run this code no matter what happens.
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
            private static void TestUsing()
            {
                try
                {
                    string fileName = GetFileName();
                    using (FileStream fs = File.Open(fileName, FileMode.Open))
                    {
                        long fileSize = fs.Length;
                        Console.WriteLine("'{0}' is {1} bytes. ", fileName, fileSize);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        private static void UserDefinedException()
        {
            // Test a user-defined exception

            try
            {
                string fileName = GetFileName();
                long fileSize = GetSize(fileName);
            }
            catch (FileTooLargeException ex)
            {
                Console.WriteLine("Please select a smaller file! " + "The file you selected was {0}", ex.FileSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static long GetSize(string FileName)
        {
            using (FileStream fs = File.Open(FileName, FileMode.Open))
            {
                long filesize = fs.Length;
                if (filesize > 100)
                {
                    throw (new FileTooLargeException("The file you selected is too large.", null, filesize));
                }
                return filesize;
            }
        }
    }
}
