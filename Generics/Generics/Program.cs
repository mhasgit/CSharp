using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericPredicate();
        }

        private static void SwapValues()
        {
            int value1 = 12345;
            int value2 = 54321;

            Console.WriteLine("Value1 is {0} Value2 is {1}", value1, value2);
            Helper.Swap(ref value1, ref value2);
            Console.WriteLine("Value1 is now {0} Value2 is now {1}", value1, value2);

            string value3 = "Abra";
            string value4 = "Cadabra";

            Console.WriteLine("Value3 is {0} Value4 is {1}", value3, value4);
            Helper.Swap(ref value3, ref value4);
            Console.WriteLine("Value3 is now {0} Value3 is now {1}", value3, value4);

            object object1 = "Abra";
            object object2 = "Cadabra";
            Console.WriteLine("object1 is {0} object2 is {1}", object1, object2);
            Helper.Swap(ref object1, ref object2);
            Console.WriteLine("object1 is now {0} object2 is now {1}", object1, object2);
        }

        private static void GenericMethod()
        {
            int value1 = 12345;
            int value2 = 54321;

            Console.WriteLine("Value1 is {0} Value2 is {1}", value1, value2);
            Helper2.Swap(ref value1, ref value2);
            Console.WriteLine("Value1 is now {0} Value2 is now {1}", value1, value2);

            string value3 = "Abra";
            string value4 = "Cadabra";

            Console.WriteLine("Value3 is {0} Value4 is {1}", value3, value4);
            Helper2.Swap(ref value3, ref value4);
            Console.WriteLine("Value3 is now {0} Value3 is now {1}", value3, value4);

            DateTime value5 = DateTime.Today;
            DateTime value6 = DateTime.Today.AddDays(1);
            Console.WriteLine("value5 is {0:d} value6 is {1:d}", value5, value6);
            Helper2.Swap(ref value5, ref value6);
            Console.WriteLine("value5 is {0:d} value6 is {1:d}", value5, value6);

            //This code will not compile
            //int value7 = 99;
            //string value8 = "Hello";
            //Helper2.Swap(value7, value8);
        }

        private static void GenericClass()
        {
            int value1 = 12345;
            int value2 = 54321;

            Console.WriteLine("Value1 is {0} Value2 is {1}", value1, value2);
            Helper2.Swap(ref value1, ref value2);
            Console.WriteLine("Value1 is now {0} Value2 is now {1}", value1, value2);
            Console.WriteLine();

            string valueString = Helper2.MakeString(value1, value2);
            Console.WriteLine("Make a string and you get {0}", valueString);

            valueString = Helper2.MakeString("12345", "54321");
            Console.WriteLine("Make a string and you get {0}", valueString);
            Console.WriteLine();

            Helper3<int> integerHelper = new Helper3<int>();
            value1 = 12345;
            value2 = 54321;

            Console.WriteLine("Value1 is {0} Value2 is {1}", value1, value2);
            Helper3<int>.Swap(ref value1, ref value2);
            Console.WriteLine("Value1 is now {0} Value2 is now {1}", value1, value2);
            Console.WriteLine();

            //valueString = integerHelper.MakeString(value1, value2);  //Not Working
            valueString = Helper3<int>.MakeString(value1, value2);
            Console.WriteLine("Make a string and you get {0}", valueString);

            //This code will not compile
            //valueString = integerHelper.MakeString("12345", "54321");
            
            Helper3<string> stringHelper = new Helper3<string>();

            //valueString = stringHelper.MakeString("12345", "54321"); //Not Working

            valueString = Helper3<string>.MakeString("12345", "54321");
            Console.WriteLine("Make a string and you get {0}", valueString);

        }

        private static void SortSimpeTypes()
        {
            decimal[] numbers = { 50.5M, 10M, 600M };
            Array.Sort(numbers);
            foreach (decimal value in numbers)
            {
                Console.WriteLine(string.Format("{0:C}", value));
            }
            Console.WriteLine();

            string[] strings = { "Canna", "Franastan", "Anna" };
            Array.Sort(strings);
            foreach (string value in strings)
            {
                Console.WriteLine(string.Format("{0:d}", value));
            }
            Console.WriteLine();

            DateTime[] dates = { DateTime.Today, DateTime.Today.AddDays(3), DateTime.Today.AddDays(-4) };
            Array.Sort(dates);
            foreach (DateTime value in dates)
            {
                Console.WriteLine(string.Format("{0:d}", value));
            }
        }

        private static void SortFiles()
        {
            DirectoryInfo di = new DirectoryInfo(@"c:\");
            FileInfo[] files = di.GetFiles();
            //This code will compile but cause a runtime error
            Array.Sort(files);
            foreach (FileInfo file in files)
            {
                Console.WriteLine("{0} ({1} bytes)", file.Name, file.Length);
            }
        }

        private static void SortWithIComparer()
        {
            DirectoryInfo di = new DirectoryInfo(@"c:\");
            FileInfo[] files = di.GetFiles("*.*");
            Array.Sort(files, new ComparerFileNames());
            foreach (FileInfo file in files)
            {
                Console.WriteLine("{0} ({1} bytes)", file.Name, file.Length);
            }
            Console.WriteLine();

            Array.Sort(files, new CompareFileLengths());
            foreach (FileInfo file in files)
            {
                Console.WriteLine("{0} ({1} bytes)", file.Name, file.Length);
            }
        }

        private static void GenericComparison()
        {
            DirectoryInfo di = new DirectoryInfo(@"c:\");
            FileInfo[] files = di.GetFiles("*.*");

            Console.WriteLine("Files sorted by name:");
            Array.Sort(files, Comparers.CompareFileNames);
            foreach (FileInfo file in files)
            {
                Console.WriteLine("{0} ({1} bytes)", file.Name, file.Length);
            }
            Console.WriteLine();

            Console.WriteLine("Files sorted by size:");
            Array.Sort(files, Comparers.CompareFileLengths);
            foreach (FileInfo file in files)
            {
                Console.WriteLine("{0} ({1} bytes)", file.Name, file.Length);
            }

            Customer customer1 = new Customer();
            customer1.CustomerName = "Bigge Industries";
            Customer customer2 = new Customer();
            customer2.CustomerName = "Smalle Industries";
            Customer customer3 = new Customer();
            customer3.CustomerName = "Tinye Industries";

            Customer[] customers = { customer1, customer2, customer3 };
            Console.WriteLine();
            Console.WriteLine("Customer sorted by names");
            Array.Sort(customers, Comparers.CompareCustomerNames);
            for (int i = 0; i < customers.Length; i++)
            {
                Console.WriteLine(customers[i]);
            }
        }

        private static void FindInArray()
        {
            string[] strings = { "Canna", "Franastan", "Anna" };
            if (Array.IndexOf(strings, "Jimmy") > 0)
            {
                Console.WriteLine("Jimmy is in the array of strings");
            }
            else
            {
                Console.WriteLine("Jimmy is not in the array of strings");
            }
        }

        private static void GenericPredicate()
        {

            Customer customer1 = new Customer();
            customer1.CustomerName = "Bigge Industries";
            customer1.Country = "Canada";
            Customer customer2 = new Customer();
            customer2.CustomerName = "Smalle Industries";
            customer2.Country = "USA";
            Customer customer3 = new Customer();
            customer3.CustomerName = "Tinye Industries";
            customer3.Country = "USA";

            Customer[] customers = { customer1, customer2, customer3 };

            Console.WriteLine("Customers in the USA");
            int index = 0;
            while (true)
            {
                index = Array.FindIndex(customers, index, Customer.IsInUSA);
                if (index == -1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(customers[index]);
                }
                index += 1;
            }

            Console.WriteLine();
            Console.WriteLine("Customer not in USA");
            index = 0;
            while (true)
            {
                index = Array.FindIndex(customers, index, Customer.IsInUSA);
                if (index == -1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(customers[index]);
                }
                index += 1;
            }
        }
    }
}
