namespace ValuesAndRefrenceTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // ValuesAndRefrenceTypes();

            // ConsEnumStructExamples();

            // TypeOperators();
        }

        static void ValuesAndRefrenceTypes()
        {
            //string and object are refrence type in c#

            object objectOne;
            int numberOne;

            numberOne = 77;
            objectOne = numberOne;

            Console.WriteLine("objectOne is {0}", objectOne);

            Console.WriteLine("objectOne is {0}", (int)objectOne);

            string stringOne;
            stringOne = numberOne.ToString();

            Console.WriteLine("stringOne is " + stringOne);
        }

        static void ConsEnumStructExamples()
        {
            UsingConstants();
            UsingEnumerations();
            UsingStructs();
        }
        static void UsingConstants()
        {
            const int monthsInYear = 12;
            const int daysInYear = 365;

            Console.WriteLine("There are {0} months and {1} days in a year", monthsInYear, daysInYear);
            Console.WriteLine();
        }

        enum CalenderWeek
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6,
            Saturday = 7
        }

        enum WorkWeek
        {
            Monday= 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }

        static void UsingEnumerations()
        {
            Console.WriteLine("Sunday is day " + (int)CalenderWeek.Sunday + " in the calender week");
            Console.WriteLine();
            Console.WriteLine("Sunday is day " + (int)WorkWeek.Sunday + " in the workweek");
            Console.WriteLine();

        }

        struct Author
        {
            public string FirstName;
            public string LastName;
            public string Company;
            public string Title;
        }

        static void UsingStructs()
        {
            Author author1;
            author1.FirstName = "ken";
            author1.LastName = "Getz";
            author1.Title = "Sr. Consultant";
            author1.Company = "MCW Technologies";

            Author author2;
            author2.FirstName = "Robert";
            author2.LastName = "Green";
            author2.Title = "Sr. Consultant";
            author2.Company = "MCW Technologies";

            Console.WriteLine($"{author1.FirstName} {1} is a {2} with {3}", author1.LastName,
                                                           author1.Title, author1.Company);

            Console.WriteLine("{0} {1} is a {2} with {3}", author2.FirstName, author2.LastName,
                                                           author2.Title, author2.Company);
        }

        static void TypeOperators()
        {
            object objectOne = 234.234M;

            if (objectOne is decimal)
            {
                Console.WriteLine("objectOne = {0} is type decimal", objectOne);
            }

            objectOne = 12.12F;
            Console.WriteLine("objectOne is of type {0}", objectOne.GetType());
            
        }
    }
}