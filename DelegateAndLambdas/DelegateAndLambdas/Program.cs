using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndLambdas
{
    internal class Program
    {
        public delegate void MyDel(string message);
        public delegate void MyDelegate(string message, int age);

        static void Main(string[] args)
        {
            // TestShowMsg();
            // MulticastDelegate();
            // TestDelToFuncMethod();
            // AnonymousDelegate();
            // TestGenericDel();
            // WorkingWithEvent();
            // TestBackAccount();
            // TestPolymorphism();
            // LinqMultipleCondition();
        }

        #region Polymorphism


        public static void TestPolymorphism()
        {
            //Animal animal = new Animal();
            //animal.Speak();

            Cat cat = new Cat();
               cat.Speak();
        }

        public class Animal
        {
            public virtual void Speak()
            {
                Console.WriteLine("The animal makes a sound");
            }
        }

        public class Dog : Animal
        {
            public override void Speak()
            {
                Console.WriteLine("The dog barks");
            }
        }

        public class Cat : Animal
        {
            public override void Speak()
            {
                Console.WriteLine("The cat meows");
            }
        }
        #endregion

        #region Delegate Basics

        private static void TestGenericDel()
        {
            GenericDelegates genericDelegates = new GenericDelegates();

            Console.WriteLine("Action Del");
            genericDelegates.WorkingWithAction();

            Console.WriteLine("Func Del");
            genericDelegates.WorkingWithFunc();

            Console.WriteLine("Predicate Del");
            genericDelegates.WorkingWithPredicate();

            Console.WriteLine("Lambda expression Example");
            genericDelegates.UsingLambdaWithLinq();
        }

        private static void AnonymousDelegate()
        {
            MyDelegate anonDel = delegate(string msg, int age)
            {
                Console.WriteLine("Anonymous method says: {0}! Your age is:  {1}", msg, age);
            };
            anonDel("Hello, there", 24);
        }

        private static void TestDelToFuncMethod()
        {
            PassingDelegateToFunction(Greet, "Bob");
        }

        private static void PassingDelegateToFunction(MyDel myDel, string param)
        {
            myDel(param);
        }

        private static void MulticastDelegate()
        {
            MyDel myDel = Greet;
            myDel += SayBye;
            myDel("Alice");
        }

        private static void Greet(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }

        private static void SayBye(string name)
        {
            Console.WriteLine("Good Bye, {0}!", name);
        }

        private static void TestShowMsg()
        {
            MyDel myDel = ShowMsg;
            myDel("Hello, world");
        }

        private static void ShowMsg(string message)
        {
            Console.WriteLine(message);
        }

        #endregion

        #region Event Basics

        public static void WorkingWithEvent()
        {
            Timer timer = new Timer(1000);

            timer.TimerTicked += (sender, e) =>
            {
                Console.WriteLine("Timer ticked");
            };
        }

        private static void TestBackAccount()
        {
            var account = new BankAccount(500);

            account.Deposited += (sender, amount) => Console.WriteLine($"Deposited: {amount}");
            account.Withdrew += (sender, amount) => Console.WriteLine($"Withdrew: {amount}");
            account.BalanceBelowThreshold += (sender, currentBalance) => Console.WriteLine($"Warning! Low balance: {currentBalance}");

            account.Deposit(200);
            account.Withdraw(50);
            account.Withdraw(100);
            account.Withdraw(500);
            account.Withdraw(50);
        }


        #endregion

        #region Linq Basics

        private static void LinqToObjectsQuery()
        {
            // Linq to objects query
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = from number in numbers
                              where number % 2 == 0
                              select number;
            foreach (var num in numbers)
            {
                Console.WriteLine(num);
            }

            // With Lambda syntax

            // var evenNum = numbers.Where(n => n % 2 == 0);
        }

        private static void LinqMultipleCondition()
        {
            var fruits = new List<string> { "date", "mango", "banana", "cherry", "apple" };

            var results = from fruit in fruits
                          where fruit.Length > 3
                          orderby fruit
                          select fruit;

            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
        }

        #endregion

        #region Built-in data structures

        private static void WorkingWithDataStructures()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine(numbers[2]);

            
            List<string> fruits = new List<string> { "apple", "banana", "cherry" };
            fruits.Add("date");
            Console.WriteLine(fruits[2]);

            Dictionary<string, int> ages = new Dictionary<string, int>
            {
                {"Alice", 25},
                {"Bob", 30}
            };

            ages["Charlie"] = 28;
            Console.WriteLine(ages["Bob"]);

            Queue<string> names = new Queue<string>();
            names.Enqueue("Alice");
            names.Enqueue("Bob");
            Console.WriteLine(names.Dequeue());

            Stack<int> nums = new Stack<int>();
            nums.Push(1);
            nums.Push(2);
            Console.WriteLine(nums.Pop());

            HashSet<int> uniqueNumbers = new HashSet<int> { 1, 2, 3, 2, 1 };
            Console.WriteLine(uniqueNumbers.Count);

            LinkedList<string> days = new LinkedList<string>();
            days.AddLast("Monday");
            days.AddLast("Tuesday");
            days.AddFirst("Sunday");
            Console.WriteLine(days.First.Value);

            (var name, var age, var country) = ("Alice", 25, "USA");
            Console.WriteLine($"Name: {name}, Age: {age}, Country: {country}");
        }



        #endregion
    }
}
