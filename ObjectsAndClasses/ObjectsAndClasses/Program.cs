using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ObjectsAndClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestCustomer1();
            //TestCustomer2();
            //TestNullRefrence();
            //TestFinalize();
            //TestDispose();
            //TestUsing();
            //DisplayToString();
            //CopyRefrenceType();
            //TestInstanceAndStaticMethods();
            TestStaticPropterty();
        }

        private static void TestCustomer1()
        {
            Customer1 CustA = new Customer1();
            Customer1 CustB = new Customer1();

            CustA.CutomerID = "AAAA";
            CustB.CutomerID = "BBBB";

            Console.WriteLine("CustA's customerID = " + CustA.CutomerID);
            Console.WriteLine("CustB's customerID = " + CustB.CutomerID);

            CustA.DisplayID();
            CustB.DisplayID();

            CustA.DisplayID("CustA");
        }

        private static void TestCustomer2()
        {
            Customer2 CustA = new Customer2("ALFKI");
            Customer2 CustB = new Customer2("BOTTM");

            CustA.CutomerName = "Ashraf";
            CustA.UpdateLocation("Oxford", "Denny Garden", "OX1");

            Console.WriteLine(CustA.GetLocation());
            Console.WriteLine(CustA.Country);

            CustB.CutomerName = "Hassan";
            CustB.UpdateLocation("Peshawar", "Hussain town", "25000", "Pakistan");

            Console.WriteLine(CustB.Location);
            Console.WriteLine(CustB.Country);
        }

        private static void TestNullRefrence()
        {
            try
            {
                Customer2 CustA = null;
                Customer2 CustB = new Customer2("BLONP");

                if (CustA == null)
                {
                    Console.WriteLine("CustA is null");
                }

                if (CustB == null)
                {
                    Console.WriteLine("CustB is null");
                }

                //CustA.City = "Los Angeles"; //Exception
                CustB.City = "Florida";

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void TestFinalize()
        {
            StreamDemo x = new StreamDemo();
            x = null;
            GC.Collect(); //Forcing GC to collect Garbage
        }

        private static void TestDispose()
        {
            DisposeDemo demo = null;

            try
            {
                demo = new DisposeDemo();
            }
            finally
            {
                if (demo != null)
                {
                    demo.Dispose();
                }
            }
        }

        private static void TestUsing()
        {
            using (DisposeDemo demo = new DisposeDemo())
            {
                //Do something with demo in here
            }
        }

        private static void DisplayToString()
        {
            Customer2 Cust = new Customer2("ALFKI");
            Cust.CutomerName = "Maria Anders";
            Console.WriteLine(Cust.ToString());
        }

        private static void CopyRefrenceType()
        {
            Customer2 CustA = new Customer2("ALFKI");
            Customer2 CustB = null;

            CustA.CutomerName = "Maria Anders";
            Console.WriteLine("Before: " + CustA.ToString());

            CustB = CustA;

            CustB.CutomerName = "John Smith";
            Console.WriteLine("After: " + CustA.ToString());
        }

        private static void TestInstanceAndStaticMethods()
        {
            string value = "ABCD";

            int pos = value.IndexOf("B");

            Console.WriteLine("Pos = {0}", pos);

            Console.WriteLine(string.Concat("Concatenate", "These", "Togrther"));
        }

        private static void TestStaticPropterty()
        {
            Customer3 CustA = new Customer3("ALFKI");
            Console.WriteLine("CustA.Country " + CustA.Country);

            Customer3.DefaultCountry = "PAK";

            Customer3 CustB = new Customer3("BLONP");
            Console.WriteLine("CustA.Country " + CustA.Country);
            Console.WriteLine("CustB.Country " + CustB.Country);
        }
    }
}