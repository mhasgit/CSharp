using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq
{
    #region Linq Types
    // Delegates
    delegate void ProcessInt(int value); // Action<int>

    delegate void ProcessNumbers(int a, int b); // Action<int, int>

    delegate int ProcessInts(int a, int b); // Func<int, int, int>

    // Extension Methods
    public static class IntExtensions
    {
        public static DateTime March(this int day, int year)
        {
            return new DateTime(year, 3, day);
        }
    }

    public static class EnumerableExtensions
    {
        public static int MyMax(this IEnumerable<int> list)
        {
            int max = -1;
            foreach (int item in list)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        public static int Count(this IEnumerable<int> list)
        {
            int count = 0;
            foreach (int item in list)
            {
                count++;
            }

            return count;
        }

        public static int Average(this IEnumerable<int> list)
        {
            int count = 0;
            int sum = 0;
            foreach (int item in list)
            {
                count++;
                sum += item;
            }

            return sum / count;
        }

        public static bool MyAll<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach (T item in list)
            {
                if (predicate(item) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
    #endregion

    // Linq to Objects
    // Linq to SQL
    // Linq to XML
    // Linq to anything
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Dictionary<int, string> d = new Dictionary<int, string>();
            int[] ints = { 1, 2, 3 };
            LinqRemaining(ints);
        }

        private static void LinqRemaining(IEnumerable<int> enumeralbe)
        {
            enumeralbe.Any(x => x % 2 == 0);
            var nums = enumeralbe.Select(i => new { Number = i, Squared = i * i });
        }

        #region Linq Basics

        static void DisplayInt(int value)
        {
            Console.WriteLine(value);
        }

        static void SquareInt(int value)
        {
            Console.WriteLine(value * value);
        }

        static void AddInts(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        private static void LinqBasics()
        {
            // Extension Methods

            // Anonymous Types
            var person = new
            {
                FirstName = "Muhammad",
                LastName = "Hassan",
                Age = 24
            };

            // Delegates & Lambda Expressions
            ProcessInt funcDelegate = DisplayInt;
            funcDelegate.Invoke(3);

            funcDelegate = SquareInt;
            funcDelegate(5);

            // Inline anonymous delegate
            ProcessInts alwaysOneFunc = delegate { return 1; };
            ProcessInts alwaysOneFuncLambda = (a, b) => 1;

            ProcessInts add = delegate (int a, int b) { return a + b; };
            ProcessInts addLambda = (a, b) => a + b;
            int sum = add(3, 7);

            ProcessInt squareLambda = x => Console.WriteLine(x * x);

            ProcessNumbers processNumFunc = (a, b) => Console.WriteLine(a + b);

            Action writeAction = () => Console.WriteLine();
            Action<int> intAction = (x) => Console.WriteLine(x);

            Func<int> intFunc = () => 1;
            Func<int, int, int> addFunc = (x, y) => x + y;


            List<int> list = new List<int>();
            // list.ConvertAll(delegate (int x) { return x.ToString(); });
            var converted = list.ConvertAll(x => new Person { Age = x });
            var listSquared = list.ConvertAll(x => x * x);
            IEnumerable<int> enumerable = list;

            if (list.All(i => i > 0))
            {

            }

            DateTime dob = new DateTime(1999, 3, 1);
            DateTime db = 1.March(1999);
            // IntExtensions.March(1, 1999);
        }

        List<Person> ConvertAll(List<int> list, Converter<int, Person> ageConverter)
        {
            var people = new List<Person>();
            foreach (var item in list)
            {
                people.Add(ageConverter(item));
            }

            return people;
        }

        #endregion

        #region Collection Basics
        private static void CollectionsBasic()
        {
            // List<T>
            List<string> days = new List<string>();
            days.Add("Sunday");
            days.Add("Friday");
            days.Insert(1, "Monday");
            days[0] = "Day";
            Console.WriteLine(days[1]);
            IReadOnlyList<string> readOnlyDays = days.AsReadOnly();

            List<List<Person>> list = new List<List<Person>>();
            List<Person> firstGroup = new List<Person>()
            {
                new Person()
            };
            list.Add(firstGroup);

            // Stack
            Stack<string> tokens = new Stack<string>();
            Stack<Person> persons = new Stack<Person>();
            Stack<List<Person>> people = new Stack<List<Person>>();
            people.Push(firstGroup);

            // Queue
            Queue<string> queue = new Queue<string>();

            // Linked List
            LinkedList<string> linkedList = new LinkedList<string>();

            LinkList myList = new LinkList();
            myList.Add("Sunday");

            // Dictionary
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "Hassan");
            dict.Add(2, "Shafiq");
            dict[3] = "Hussain Ahmad";
            Console.WriteLine(dict[3]);

            if (dict.TryGetValue(3, out string name))
            {
                Console.WriteLine(name);
            }

            var studentSubjects = new Dictionary<string, List<string>>();
            List<string> studentSubjectsList = new List<string>()
            {
                "AOA", "ADS", "DCS"
            };
            studentSubjects.Add("Hassan", studentSubjectsList);
            List<string> hassanSubjects = studentSubjects["Hassan"];

            // Sets
            HashSet<string> set = new HashSet<string>();

            // Typesless collections
            System.Collections.ArrayList students = new System.Collections.ArrayList();
            students.Add("asdasd");
            students.Add(2);
            students.Add(new Person());
            string obj = (string)students[0];



            // IEnumberable<T>, IEnumerator<T>
            List<string>.Enumerator enumerator = days.GetEnumerator();
            while (enumerator.MoveNext())
            {
                string day = enumerator.Current;
                Console.WriteLine(day);
            }

            foreach (string day in days)
            {
                Console.WriteLine(day);
            }

            // Custom Enumerator
            MyCollection<int> ints = new MyCollection<int>();
            //IEnumerator<int> intsEnumerator = ints.GetEnumerator();
            //intsEnumerator.MoveNext();

            // Debug MyCollection class to see how foreach loop works
            // 1. foreach loop gets the Enumerator though IEnumerable GetEnumerator method
            // 2. Calls the MoveNext method of the enumerator
            // 3. Calls the Current property of enumerator if MoveNext returns true else loop is ended
            // 4. Repeat 2 & 3
            ints.Initilize(new int[] { 1, 2, 3, 4, 5, 6, 1, 2, 3 });
            foreach (int i in ints)
            {
                Console.WriteLine(i);
            }


            ints.Min();
            ints.Max();
            ints.Sum();
            ints.Average();
            ints.Where(IsEvenNumber);
            ints.Distinct();
            ints.All(IsEvenNumber);
            ints.Any(IsEvenNumber);
            ints.OrderBy(i => i);
            ints.OrderByDescending(i => i);
            if (ints.All(IsEvenNumber))
            {

            }

            Debugger.Break();
        }

        static bool IsEvenNumber(int number)
        {
            return number % 2 == 0;
        }
        #endregion
    }
}
