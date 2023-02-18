using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedTechniques
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void BaseClassMember()
        {
            Customer customer1 = new Customer();
            customer1.CustomerName = "Bigge Industries";
            customer1.RecordSales("Bigge", 100000, 500);

            Customer customer2 = new Customer();
            customer2.CustomerName = "John Smith";
            customer2.RecordSales("Smith", 10, 5);
        }

        static void InheritedMember()
        {
            CorporateCustomer customer1 = new CorporateCustomer();
            customer1.CustomerName = "Bigge Industries";
            customer1.RecordSales("Bigge", 100000, 500);

            IndividualCustomer customer2 = new IndividualCustomer();
            customer2.CustomerName = "John Smith";
            customer2.RecordSales("Smith", 10, 5);
        }

        static void AddMembers()
        {
            CorporateCustomer customer1 = new CorporateCustomer();
            customer1.CustomerName = "Bigge Industries";
            customer1.SalesRep = "Ed";
            customer1.CreditLimit = 100000;

            int amount = 100000;
            int units = 500;
            customer1.RecordSales("Bigge", amount, units);
            customer1.ChangeCreditLimit(Convert.ToInt32(amount / 10));

            Console.WriteLine("{0} says the customer's credit limits is now {1:C}", customer1.SalesRep, customer1.CreditLimit);
            Console.WriteLine();

            IndividualCustomer customer2 = new IndividualCustomer();
            customer2.FirstName = "John";
            customer2.LastName = "Smith";
            customer2.CustomerName = "John Smith";
            customer2.BirthdayMonth = 5;
            customer2.BirthdayDay = 30;

            amount = 100;
            if (DateTime.Today.Month == customer2.BirthdayMonth && DateTime.Today.Day == customer2.BirthdayDay)
            {
                amount = Convert.ToInt32(amount * 0.8);
                Console.WriteLine("{0}, you get a 20% discount today", customer2.FirstName);
            }
            else
            {
                Console.WriteLine("Sorry {0}, no discount today", customer2.CustomerName);
            }
            customer2.RecordSales("Smith", amount, 5);
        }

        static void OverriddenMembers()
        {
            CorporateCustomer customer1 = new CorporateCustomer();
            customer1.CustomerName = "Bigge Industries";
            Console.WriteLine("The corporate customer is {0}", customer1.CustomerName);

            IndividualCustomer customer2 = new IndividualCustomer();
            customer2.FirstName = "John";
            customer2.LastName = "Smith";
            customer2.CustomerName = "John Smith";
            Console.WriteLine("The individual customer is {0}", customer2.CustomerName);

            IndividualCustomer customer3 = new IndividualCustomer();
            customer3.CustomerName = "Mary Jones";
            Console.WriteLine("The individual customer is {0} {1}", customer3.FirstName, customer3.LastName);
        }

        static void OverloadedMembers()
        {
            CorporateCustomer customer1 = new CorporateCustomer();
            //customer1.CustomerID = "Bigge";
            customer1.SalesRep = "Ed";
            customer1.RecordSales(customer1.CustomerID, customer1.SalesRep, 100000, 500);

            CorporateCustomer customer2 = new CorporateCustomer();
            //customer2.CustomerID = "Small";
            customer1.RecordSales(customer1.CustomerID, 50000, 250);
        }

        static void CallingBaseClassMembers()
        {
            IndividualCustomer customer1 = new IndividualCustomer();

            //customer1.CustomerID = "Smith";
            customer1.BirthdayMonth = 5;
            customer1.BirthdayDay = 30;

            IndividualCustomer customer2 = new IndividualCustomer();

            //customer2.CustomerID = "Jones";
            customer1.BirthdayMonth = 6;
            customer1.BirthdayDay = 29;

            customer1.RecordSales(customer1.CustomerID, customer1.BirthdayMonth, customer1.BirthdayDay, 1000, 50);

            customer2.RecordSales(customer2.CustomerID, customer2.BirthdayMonth, customer2.BirthdayDay, 1000, 50);

        }

        static void AbstractClasses()
        {
            //AbstractCustomer abstCust = new AbstractCustomer();   //not allowed
        }

        static void SealesClasses()
        {
            //Can not inherit from Sealed Classes
        }

        static void TestImplicitExplicitInterface()
        {
            TestInterface myTest = new TestInterface();
            myTest.Location = "PAK"; //can access all the methods and properties with implicit implementation

            TestInterface2 myTest2 = new TestInterface2();
            //can not access the properties with explicit implementation
        }

        static void TestBothInterfaces()
        {
            TestBothInterfaces myTest = new TestBothInterfaces();
            // now we can access both interfaces properties and methods
        }

        class Sale : IComparable
        {
            protected int _Amount;
            public int Amount
            {
                get
                { return _Amount; }
                set
                {
                    _Amount = value;
                }
            }

            public int CompareTo(object obj)
            {
                if (obj is Sale)
                {
                    Sale temp = (Sale)obj;
                    return _Amount.CompareTo(temp._Amount);
                }
                throw new ArgumentException("You must pass a Sale");
            }
        }

        static void CompareSales()
        {
            Sale sale1 = new Sale();
            Sale sale2 = new Sale();

            sale1.Amount = 5000;
            sale2.Amount = 750;

            if (sale1.Amount > sale2.Amount)
            {
                Console.WriteLine("Sale 1 is higher than sale 2");
            }
            else
            {
                Console.WriteLine("Sale 2 is higher than sale 1");
            }
            if (sale1.Amount.CompareTo(sale2.Amount) > 0)
            {
                Console.WriteLine("Sale 1 is higher than sale 2");
            }
            else
            {
                Console.WriteLine("Sale 2 is higher than sale 1");
            }

            //Only possible with implementing ICompareableInterface
            if (sale1.CompareTo(sale2) > 0)
            {
                Console.WriteLine("Sale 1 is higher than sale 2");
            }
            else
            {
                Console.WriteLine("Sale 2 is higher than sale 1");
            }
        }

        static void NestedClass()
        {
            Customer3.Information customerInfo = new Customer3.Information();
            customerInfo.CustomerName = "Bigge Industries";
            Customer3.Financial customerFinancial = new Customer3.Financial();
            int units = 500;
            customerFinancial.RecordSales("Bigge", 100000, units);
            Console.WriteLine("The amount of this sale is {0}", customerInfo.CustomerName);
        }
    }
}
