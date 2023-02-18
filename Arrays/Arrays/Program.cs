using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestBinarySearch();
        }
        private static void FirstArray()
        {
            Random rnd = new Random();
            int[] weeks = new int[53];
            for (int i = 0; i < 53; i++)
            {
                weeks[i] = rnd.Next(0, 100);
            }

            foreach (int i in weeks)
            {
                Console.WriteLine(i);
            }
        }

        private static void CreateAndFillArray()
        {
            string[] Instructor = new string[4];
            Instructor[0] = "Tom";
            Instructor[1] = "Mary";
            Instructor[2] = "Andy";
            Instructor[3] = "Peter";

            //Need to add more instructors?
            //C# does'nt provide a way to resize an array
            //You must create a new array and copy in the old element

            string[] InstructorTemp = (string[])Instructor.Clone();
            Instructor = new string[6];
            Array.Copy(InstructorTemp, Instructor, InstructorTemp.Length);
            InstructorTemp = null;

            //Now you can add new elements
            Instructor[4] = "Ken";
            Instructor[5] = "Erik";

            //You can assign refrence to arrays.
            //After this, People refers to same array as Instructor

            string[] People = Instructor;

            //Change the first element
            People[0] = "Tommy";
            Console.WriteLine(Instructor[0]);

            //Guess what's in Instructor[0] now? ("Tommy")

            string[] Friends = (string[])Instructor.Clone();
            Friends[0] = "Brian";
            //No changes bcz it is two different arrays now

            Writer[] Writers = new Writer[4];
            Writers[0] = new Writer("Andy", "FL");
            Writers[1] = new Writer("Mary", "FL");
            Writers[2] = new Writer("Ken", "CA");
            Writers[3] = new Writer("Robert", "WA");

            //array different type of declaration
            string[] Trainers = { "Brian", "Julie", "Ted", "Bob", "Don" };
            string[] Trainers1 = new string[] { "Brian", "Julie", "Ted", "Bob", "Don" };

            Writer[] Authors = { new Writer("Andy", "FL"), new Writer("Mary", "FL"), new Writer("Ken", "CA"), new Writer("Robert", "WA") };

            //You can create multi-dimentional arrays, as well:

            string[,] States = new string[50, 2];
            States[0, 0] = "Alabama";
            States[0, 1] = "Alabama";
            States[1, 0] = "Alabama";
            States[1, 1] = "Alabama";
            //and so on...

            //You can initialize multi-dimensional arrays
            //at declaration time, as well:
            string[,] States1 = {
                      {"AK", "Alaska"},
                      {"Al", "Alabama"},
                      {"AR", "Arkansas"},
                      {"AZ", "Arizona"},
                      {"CA", "California"},
                      {"CO", "Colorado"},
                      {"CT", "Connecticut"},
                      {"DC", "Washington, D.C."},
                      {"DE", "Delaware"},
                      {"FL", "Florida"},
                      {"GA", "Georgia"},
                      {"GU", "Guam"},
                      {"HI", "Hawaii"},
                      {"IA", "Iowa"},
                      {"ID", "Idoha"},
                      {"IL", "Illinois"},
                      {"IN", "Indiana"},
                      {"KS", "Kansas"},
                      {"AK", "Alaska"},
                      {"AK", "Alaska"},};

            Console.WriteLine("=Retrieve by Index=========");
            Console.WriteLine("Instructor[0] = " + Instructor[0]);
            Console.WriteLine("States[2, 1]" + States1[2, 1]);

            Console.WriteLine("=Loop by index==========");
            for (int i = 0; i < Instructor.Length; i++)
            {
                Console.WriteLine(Instructor[i]);
            }

            for (int i = 0; i < Writers.Length; i++)
            {
                Console.WriteLine("Writers[{0}]: {1}", i, Writers.ToString());
            }

            //Use foreach loop (treat array as collection of items)
            Console.WriteLine("=For Each (Text)===========");
            foreach (string trainsers in Trainers)
            {
                Console.WriteLine(trainsers);
            }

            Console.WriteLine("=For Each (Objects)===========");
            foreach (Writer wrt in Writers)
            {
                Console.WriteLine(wrt);
            }

            Console.WriteLine("=Array to Methods===========");
            PrintElements("Friends", Friends);
        }

        private static void MethodParameters()
        {
            string result = string.Empty;

            //Pass string.format three parameters
            result = string.Format("{0} {1}", "Item1", "Item2");
            Console.WriteLine(result);

            result = string.Format("{0}, {1}, {2}, {3}, {4}, {5} ",
                "Item1", "Item2", "Item3", "Item4", "Item5", "Item6");
            Console.WriteLine(result);

            Console.WriteLine("=Use params to allow indefinite number of parameters===========");
            PrintAll("Here's a string", 12, DateTime.Now, new Writer("Brian", "Ca"));
        }

        private static void PrintElements(string ArrayName, object[] ArraytoPrint)
        {
            //Given a one dimensional Array print
            //its contents into the console window
            if (ArraytoPrint.Rank == 1)
            {
                for (int i = 0; i < ArraytoPrint.Length; i++)
                {
                    Console.WriteLine("{0}[{1}] = {2}", ArrayName, i, ArraytoPrint);
                }
            }
        }

        private static void PrintAll(params Object[] items)
        {
            foreach (object obj in items)
            {
                Console.WriteLine(obj);
            }
        }

        private static void ArraysInTheFramwork()
        {
            string TextToSplit = "This is a test of how this works";
            string[] words = TextToSplit.Split();
            Console.WriteLine("= string.split Method=========");
            PrintAll(words);

            Process[] processes = Process.GetProcesses();
            //Can't call the PrintAll bcz the ToString
            //method of the process class does't look nice:

            Console.WriteLine("= Process.GetProcesses Method=========");
            foreach (Process item in processes)
            {
                Console.WriteLine("{0} ({1} bytes)", item.ProcessName, item.WorkingSet64);
            }

        }

        private static void DisplayFileInfo(FileInfo[] files, string FileNames)
        {
            //Console.WriteLine(files, " ");
        }

        private static void SimpleSort()
        {
            string[] items = { "Mary", "Andy", "Ken", "Robert", "Brian", "Erik" };
            Console.WriteLine("=Unsorted list============");
            PrintAll(items);

            Console.WriteLine("=Sorted list============");
            Array.Sort(items);
            PrintAll(items);

            Console.WriteLine("=Reverse list==========");
            Array.Reverse(items);
            PrintAll(items);
        }

        private static void InvalidSort()
        {
            Writer[] writers = new Writer[4];
            writers[0] = new Writer("Robert", "WA");
            writers[1] = new Writer("Mary", "FL");
            writers[2] = new Writer("Andy", "FL");
            writers[3] = new Writer("Ken", "CA");

            try
            {
                Array.Sort(writers);
                PrintAll(writers);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sort failed: " + ex.Message);
            }
        }

        private static void SortFiles()
        {
            FileInfo[] files = new DirectoryInfo("C:\\").GetFiles();
            try
            {
                Array.Sort(files);
                DisplayFileInfo(files, "== Files ======");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorted failed: " + ex.Message);
            }
        }

        private static void SortFiles1()
        {
            FileInfo[] files = new DirectoryInfo("C:\\").GetFiles();
            try
            {
                Array.Sort(files, new CompareFileNames());
                DisplayFileInfo(files, "== Sort on File Names ======");

                Array.Sort(files, new CompareFileLengths());
                DisplayFileInfo(files, "== Sort on File Sizes ======");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorted failed: " + ex.Message);
            }
        }

        private static void SortFiles2()
        {
            FileInfo[] files = new DirectoryInfo("C:\\").GetFiles();
            try
            {
                Array.Sort(files, new CompareFiles(CompareFiles.CompareFields.Length));
                DisplayFileInfo(files, "== Sort on File Names ======");

                Array.Sort(files, new CompareFiles(CompareFiles.CompareFields.Length));
                DisplayFileInfo(files, "== Sort on File Sizes ======");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorted failed: " + ex.Message);
            }
        }

        private static int CompareWriterName(Writer writer1, Writer writer2)
        {
            return writer1.Name.CompareTo(writer2.Name);
        }

        private static int CompareWriterHome(Writer writer1, Writer writer2)
        {
            return writer1.HomeState.CompareTo(writer2.HomeState);
        }

        private static void SortWriters()
        {

            Writer[] writers = new Writer[4];
            writers[0] = new Writer("Robert", "WA");
            writers[1] = new Writer("Mary", "FL");
            writers[2] = new Writer("Andy", "FL");
            writers[3] = new Writer("Ken", "CA");

            try
            {
                Array.Sort(writers, CompareWriterName);
                Console.WriteLine("= Sort by name ======");
                PrintAll(writers);

                Array.Sort(writers, CompareWriterHome);
                Console.WriteLine("= Sort by home state ======");
                PrintAll(writers);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sort failed: " + ex.Message);
            }
        }

        private static void TestIndexOf()
        {
            string[] States = {"Alaska", "Alabama", "Arkansas", "Arizona", "California",
                                "Colorado", "Connecticus", "Washington, D.C", "Delaware",
                               "Florida", "Georgia", "Guam", "Hawaii", "Iowa", "Idaho",
                                "Illinois", "Indiana", "Kansas", "Montana", "North Carolina",
                                "Nebraska", "Nevada", "Ohio", "New York", "Oregon", "Oklahoma",
                                  "South Dakota", "South Caroline", "Rhode Island", };

            string stateToFind = "Nevada";

            do
            {
                int index = Array.IndexOf(States, stateToFind);
                if (index == -1)
                {
                    Console.WriteLine("'{0}' was'nt find", stateToFind);
                }
                else
                {
                    Console.WriteLine("{0} was found at position {1}", stateToFind, index);
                }
                Console.WriteLine();
                Console.Write("Enter state to search: ");
                stateToFind = Console.ReadLine();
                index = Array.IndexOf(States, stateToFind);
            } while (true);
        }

        private static void TestBinarySearch()
        {
            string[] States = {"Alaska", "Alabama", "Arkansas", "Arizona", "California",
                                "Colorado", "Connecticus", "Washington, D.C", "Delaware",
                               "Florida", "Georgia", "Guam", "Hawaii", "Iowa", "Idaho",
                                "Illinois", "Indiana", "Kansas", "Montana", "North Carolina",
                                "Nebraska", "Nevada", "Ohio", "New York", "Oregon", "Oklahoma",
                                  "South Dakota", "South Caroline", "Rhode Island", };

            string stateToFind = "South Dakota";

            Array.Sort(States);

            do
            {
                int index = Array.BinarySearch(States, stateToFind);
                if (index < 0)
                {
                    Console.WriteLine("'{0}' was'nt find, but it would have"
                        + " appeared before item {1}", stateToFind, -index - 1);
                }
                else
                {
                    Console.WriteLine("{0} was found at position {1}", stateToFind, index);
                }
                Console.WriteLine();
                Console.Write("Enter state to search: ");
                stateToFind = Console.ReadLine();
                index = Array.IndexOf(States, stateToFind);
            } while (true);
        }

        private static void TestFindAll()
        {
            FileInfo[] files = new DirectoryInfo("C:\\").GetFiles();
            DisplayFileInfo(files, "= Input Files =======");

            FileInfo[] outputFiles = Array.FindAll(files, CheckForSmallFile);
            DisplayFileInfo(outputFiles, "= output Files =======");
        }

        private static bool CheckForSmallFile(FileInfo file)
        {
            return file.Length < 1000;
        }

        private static void testWriter1()
        {
            Writer1 writers = new Writer1();
            writers.Add(new Writer("Robert", "WA"));
            writers.Add(new Writer("Mary", "FL"));
            writers.Add(new Writer("Andy", "FL"));
            writers.Add(new Writer("Ken", "CA"));

            //This cause the array to resize itself
            writers.Add(new Writer("Doug", "CA"));

            //How can you retrieve an item by number?
            //This code won't compile

            //Console.WriteLine(writers[0]);

            //What if you want to retrieve a writer
            //by name? This code won't compile either:

            //Console.WriteLine(writers["Doug"].HomeState);
        }

        private static void TestWriter2()
        {
            Writer2 writers = new Writer2();
            writers.Add(new Writer("Robert", "WA"));
            writers.Add(new Writer("Mary", "FL"));
            writers.Add(new Writer("Andy", "FL"));
            writers.Add(new Writer("Ken", "CA"));
            writers.Add(new Writer("Doug", "CA"));

            try
            {
                Console.WriteLine(writers[0]);
                Console.WriteLine(writers["Doug"].HomeState);
                writers["Andy"] = new Writer("Andy", "NY");
                Console.WriteLine("== All the writers =======");

                for (int i = 0; i < writers.Length; i++)
                {
                    Console.WriteLine(writers[i]);
                }

                //Try something that triggers an exception
                Console.WriteLine(writers[17]);

                //This still does'nt work
                //foreach (Writer item in writers)
                //{
                //    Console.WriteLine(item);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void TestWriter3()
        {
            Writer3 writers = new Writer3();
            writers.Add(new Writer("Robert", "WA"));
            writers.Add(new Writer("Mary", "FL"));
            writers.Add(new Writer("Andy", "FL"));
            writers.Add(new Writer("Ken", "CA"));
            writers.Add(new Writer("Doug", "CA"));

            try
            {
                //This still does'nt work
                foreach (Writer item in writers)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
