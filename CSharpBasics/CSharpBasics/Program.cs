using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public class Program
    {
        public delegate void ShowMessage(string msg);
        public delegate void MessageReceived(string msg);

        public static void Main(string[] args)
        {

            int? x = null;
            DateTime? now = null; // DateTime.Now;

            int xx = x ?? 0;
            int yy = x == null ? 0 : x.Value;

            DateTime dt = now?.Date ?? DateTime.Now;
            DateTime dtt = now != null ? now.Value.Date : DateTime.Now;

            MessageReceived messageReceived;

            // Nullable
            // Delegates
            ShowMessage del = ShowFirstName;
            del += ShowLastName;

            Action<string> method = (msg) => Console.WriteLine(msg);
            Func<bool> func = () => true;

            // del("message");
            del.Invoke("message");
        }

        public static void ShowFirstName(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void ShowLastName(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class OutRefProgram
    {
        public static void Playground()
        {
            int value;

            AddTwo(out value);

            AddOne(ref value);

            if (int.TryParse("123123", out value)) 
            {
                Console.WriteLine(value);
            }
        }

        static void AddOne(ref int a)
        {
            a++;
        }

        static void AddTwo(out int a)
        {
            a = 2;
            Console.WriteLine(a);
        }
    }

    class Person 
    {
        public int Id { get; set; }
    }

    internal class PassByValueAndRefProgram
    {
        static void Playground()
        {
            int x = 10;
            int y = 20;
            // int y = x;
            if(x == y) { } // compares the values inside the bytes

            Person p1 = new Person() {  Id = 1 };
            Person p2 = new Person() { Id = 2 };

            // Person p2 = p1;
            if (p1 == p2) { } // True or False

            String s1 = "xx";
            String s2 = "xx";

            if(s1 == s2) { } // T or F


            Console.WriteLine($"{x}, {y}"); // 10, 20
            Add(x, y);
            Console.WriteLine($"{x}, {y}"); // 10, 20

            Console.WriteLine();
            Console.WriteLine("Pass by ref for value types");
            Console.WriteLine();

            Console.WriteLine($"{x}, {y}"); // 10, 20
            AddRef(ref x, ref y);
            Console.WriteLine($"{x}, {y}"); // 10, 20


            Console.WriteLine(p1.Id); // 1
            Console.WriteLine(p2.Id); // 2
            ChangeId(p1, p2);
            Console.WriteLine(p1.Id); // 10
            Console.WriteLine(p2.Id); // 20

            Console.WriteLine();
            Console.WriteLine("Pass by ref for reference types");
            Console.WriteLine();

            Console.WriteLine(p1.Id); // 1
            Console.WriteLine(p2.Id); // 2
            ChangeIdRef(ref p1, ref p2);
            Console.WriteLine(p1.Id); // 10
            Console.WriteLine(p2.Id); // 20
        }


        // What do we mean by pass by value?
        // A copy of the type is created

        // Parameters of value types are passed by value
        static void Add(int a, int b)
        {
            a = 20;
            b = 30;
        }

        // // Pass by reference - no copy is created
        static void AddRef(ref int a,ref int b)
        {
            a = 20;
            b = 30;
        }

        // Parameters of reference types are passed by value
        static void ChangeId(Person a1, Person a2) // References are passed by value
        {
            a1.Id = 10;
            a2.Id = 20;
            // a1 = new Person() { Id = 10 };
            // a2 = new Person() { Id = 20 };
        }


        // Pass by reference - no copy is created
        static void ChangeIdRef(ref Person a1, ref Person a2) // References are passed by value
        {
            a1.Id = 10;
            a2.Id = 20;
            // a1 = new Person() { Id = 10 };
            // a2 = new Person() { Id = 20 };
        }
    }
}
