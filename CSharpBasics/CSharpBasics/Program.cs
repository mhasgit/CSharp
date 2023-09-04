using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    public static class StringUtil
    {
        public static string Base64Encode(this string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }
    }

    public static class EnumerableExtensionss
    {
        public static string MySelect<T>(this IEnumerable<T> value)
        {
            return string.Empty;
        }
    }


    public class Program
    {
        private static Random random = new Random();
        public delegate void ShowMessage(string msg);
        public delegate void MessageReceived(string msg);

        public static void Main(string[] args)
        {
            List<string> names = new List<string>()
            {
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
                RandomString(),
            };

            var visaApplication = new
            {
                ApplicationId = 123123,
                ApplicantName = "Muhammad Hassan",
                VisaType = "Umra",
                Duration = TimeSpan.FromDays(90),
                ValidUntil = DateTime.Now.AddDays(90)
            };

            Console.WriteLine(visaApplication.GetType().Name);

            var a1 = new { X = 1, Y = 4 };
            var a2 = new { X = 1, Y = 4 };
            Console.WriteLine(a1.GetType() == a2.GetType());
            
            Console.WriteLine(visaApplication.GetType().Name);


            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine();



            string personalDetails = "Muhammad Hassan";
            personalDetails.Base64Encode();

            Console.WriteLine(StringUtil.Base64Encode(personalDetails));



            // Func<int, int> addOne = delegate (int xxx) { return xxx + 1; };
            Func<int, int> addOne = xxx  => xxx + 1;




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


        public static string RandomString(int length = 10)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            StringBuilder sb = new StringBuilder();

            string randomString = string.Empty;

            for(int i = 0; i < length; i++)
            {
                char randomChar = chars[random.Next(i, chars.Length - 1)];
                if (i == 0)
                {
                    sb.Append(char.ToUpper(randomChar));
                    randomString += char.ToUpper(randomChar);
                }
                else
                {
                    sb.Append(random);
                    randomString += randomChar;
                }
            }

            return sb.ToString();
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
            if (x == y) { } // compares the values inside the bytes

            Person p1 = new Person() { Id = 1 };
            Person p2 = new Person() { Id = 2 };

            // Person p2 = p1;
            if (p1 == p2) { } // True or False

            String s1 = "xx";
            String s2 = "xx";

            if (s1 == s2) { } // T or F


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
        static void AddRef(ref int a, ref int b)
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
