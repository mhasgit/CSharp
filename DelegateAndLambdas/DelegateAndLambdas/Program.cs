using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
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
             TestGenericDel();
            // WorkingWithEvent();
            // TestBackAccount();

        }
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


    }
}
