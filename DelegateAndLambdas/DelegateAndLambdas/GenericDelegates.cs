using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DelegateAndLambdas
{
    internal class GenericDelegates
    {
        public void WorkingWithAction()
        {
            Action<string> action = message => Console.WriteLine(message);
            Action<string, int, string> displayDetails = (Name, Age, Email) =>
            {
                Console.WriteLine($"Name: {Name}, Age: {Age}, Email: {Email}");
            };

            displayDetails("Alice", 25, "alice@123");

        }

        public void WorkingWithFunc()
        {
            Func<int, int, int, int> addition = (a, b, c) => a + b + c;
            int result = addition(2, 4, 5);
            Console.WriteLine("Result is: {0}", result);
        }

        public void WorkingWithPredicate()
        {
            Predicate<int> isEven = number => number % 2 == 0;
            bool check = isEven(100);
            Console.WriteLine(check);
        }

        public void UsingLambdaWithLinq()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = numbers.Where(n => n % 2 == 0 ).ToList();

            foreach (var number in numbers)
            {
                Console.Write($" {number} ");
            }
        }
    }

    
    
}
