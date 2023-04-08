using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndLinq
{
    internal class Program
    {
        static void Main(string[] args)
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

            if(dict.TryGetValue(3, out string name))
            {
                Console.WriteLine(name);
            }

            Dictionary<string, List<string>> studentSubjects = new Dictionary<string, List<string>>();
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

            foreach(string day in days)
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
    }


    class MyCollection<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>
    {
        int currentIndex = 0;
        T[] array = new T[10];

        public void Initilize(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this.array[i] = array[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            //foreach (T item in array)
            //{
            //    yield return item;
            //}

            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        // IEnumerator<T>
        public T Current {
            get
            {
                return this.array[currentIndex++];
            }
        }

        public bool MoveNext()
        {
            if(currentIndex < array.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            currentIndex = 0;
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current => throw new NotImplementedException();
    }

    class Person { }


    class Node
    {
        public Node Next { get; set; }
        public string Item { get; set; }
    }

    class LinkList 
    {
        private Node head;
        private Node tail;

        public void AddFirst(Node node)
        {
            node.Next = head;
            head = node;
        }

        public void AddLast(Node node)
        {
            tail.Next = node;
            tail = tail.Next;
        }

        public void Add(string item)
        {
            Node node = new Node();
            node.Item = item;

            this.AddNode(node);
        }

        private void AddNode(Node node)
        {
            if(head == null)
            {
                head = node;
            }
            //else
            //{
            //    Node prev = head;
            //    Node next = head;
            //    while(next != null)
            //    {
            //        prev = next;
            //        next = next.Next;
            //    }

            //    prev.Next = node;
            //    tail = node;
            //}

            tail.Next = node;
            tail = tail.Next;
        }


    }
}
