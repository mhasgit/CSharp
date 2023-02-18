using System.Text;

namespace WorkingWithStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringFieldsAndProperties();

            StringMethod();

            FormattingStrings();

            DateAndTimeFormat();

            StringBuilderClass();

            DateTimeProperties();

            DateTimeMethods();

            TimeSpanProperties();            
        }

        static void StringFieldsAndProperties()
        {
            string myName = "";
            if (myName == "")
            {
                Console.WriteLine("myName = \"\"");
                Console.WriteLine();
            }
            if (myName == string.Empty)
            {
                Console.WriteLine("myName = string.Empty");
                Console.WriteLine();
            }

            myName = "Rober Green";
            Console.WriteLine("There are {0} characters in the string", myName.Length);
            Console.WriteLine();
            Console.WriteLine("The string is: {0}", myName);
            Console.WriteLine("The first character in the string is: {0}", myName[0]);
            Console.WriteLine("The last character in the string is: {0}", myName[myName.Length - 1]);
            Console.WriteLine();

        }

        static void StringMethod()
        {
            string author1 = "Ashraf Ali";
            string author2 = "Muhammad Hassan";

            if (string.Compare(author1 , author2) < 0)
            {
                Console.WriteLine("The string {0} is less than the string {1}", author1, author2);
            }

            if (string.Equals(author1, author2))
            {
                Console.WriteLine("The string {0} does not equal the string {1}", author1, author2);
            }

            if (author1.CompareTo(author2) < 0)
            {
                Console.WriteLine("The string {0} is less than the string {1}", author1, author2);
            }

            Console.WriteLine();

            if (author1.StartsWith("Ashraf"))
            {
                Console.WriteLine("The first author is Ashraf Ali");
            }

            if (author2.EndsWith("Hassan"))
            {
                Console.WriteLine("The 2nd author is Muhammad Hassan");
            }

            if (author1.Contains("Ali"))
            {
                Console.WriteLine("The 1st author is Ashraf Ali");
            }

            if (author1.IndexOf("Ashraf") > 0)
            {
                Console.WriteLine("The 2nd author is Ashraf Ali");
            }

            Console.WriteLine(author1.Insert(author1.Length, " is the first author"));
            Console.WriteLine(author2.Insert(15, " is the 2nd author"));
            Console.WriteLine();
            Console.WriteLine("author1 is still {0}", author1);
            Console.WriteLine("author2 is still {0}", author2);
            Console.WriteLine(author1.Remove(5));
            Console.WriteLine(author1.Remove(3,1));
            Console.WriteLine();

            author1 = "The 1st author is Ashraf Ali";
            author2 = "The 2nd author is Muhammad Hassan";
            Console.WriteLine(author1.Replace("Ashraf Ali", "Muhammad Hassan"));
            Console.WriteLine(author2.Replace(" is", ":"));
            Console.WriteLine();

            author1 = "     Ashraaf Ali     ";
            author2 = "     Muhammad Hassan     ";
            Console.WriteLine("author1 is '{0}'", author1.Trim());
            Console.WriteLine("author2 is '{0}'", author2.TrimStart());
            Console.WriteLine("author2 is '{0}'", author2.TrimEnd());

            author1 = "Muhammad Hassan";
            author2 = "Ashraf Ali";
            Console.WriteLine("author1 is '{0}'", author1.PadLeft(15));
            Console.WriteLine(author1.PadLeft(20, '-'));
            Console.WriteLine("author2 is '{0}'", author2.PadRight(15));
            Console.WriteLine(author2.PadRight(15, '-'));
            Console.WriteLine();

            Console.WriteLine("author1 is '{0}'", author1.ToUpper());
            Console.WriteLine("author2 is '{0}'", author2.ToLower());
            Console.WriteLine();

            author1 = "The 1st author is Ashraf Ali";
            author2 = "The 2nd author: Muhammad Hassan";
            Console.WriteLine(author1.Substring(20));
            Console.WriteLine(author1.Substring(20, 1));
            Console.WriteLine(author2.Substring(author2.IndexOf(":") + 5));
            Console.WriteLine(author2.Substring(author2.IndexOf(":") + 2, 3));
            Console.WriteLine();

            string courseAuthors = "Ashraf Ali, Muhammad Hassan";
            string[] authorList;
            char[] seperatorList = { ',', '/' };

            authorList = courseAuthors.Split(seperatorList);

            Console.WriteLine("The 1st author is {0}", authorList[0].Trim());
            Console.WriteLine("The 2nd author is {0}", authorList[1].Trim());

        }

        static void FormattingStrings()
        {
            int totalAmount = 12124653;

            Console.WriteLine("Currency: {0:C}", totalAmount);
            Console.WriteLine("Decimal: {0:D}", totalAmount);
            Console.WriteLine("Scientific: {0:E}", totalAmount);
            Console.WriteLine("Fixed Point: {0:F}", totalAmount);
            Console.WriteLine("General: {0:G}", totalAmount);
            Console.WriteLine("Number: {0:N}", totalAmount);
            Console.WriteLine("Percent: {0:P}", totalAmount);
            Console.WriteLine();

            Console.WriteLine(String.Format("Currency: {0:C}", totalAmount));
            Console.WriteLine(String.Format("Decimal: {0:D}", totalAmount));
            Console.WriteLine(String.Format("Scientific: {0:E}", totalAmount));
            Console.WriteLine(String.Format("Fixed Point: {0:F}", totalAmount));
            Console.WriteLine(String.Format("General: {0:G}", totalAmount));
            Console.WriteLine(String.Format("Number: {0:N}", totalAmount));
            Console.WriteLine(String.Format("Percent: {0:P}", totalAmount));
            Console.WriteLine();

            Console.WriteLine("Currency Format: " + totalAmount.ToString("C"));
            Console.WriteLine("Decimal Format: " + totalAmount.ToString("D"));
            Console.WriteLine("Scientific Format: " + totalAmount.ToString("E"));
            Console.WriteLine("Fixed Point Format: " + totalAmount.ToString("F"));
            Console.WriteLine("General Format: " + totalAmount.ToString("G"));
            Console.WriteLine("Number Format: " + totalAmount.ToString("N"));
            Console.WriteLine("Percent Format: " + totalAmount.ToString("P"));
            Console.WriteLine();
        }

        static void DateAndTimeFormat()
        {
            DateTime nextCentury = new DateTime(2100, 1, 1);

            Console.WriteLine("Short date: {0:d}", nextCentury);
            Console.WriteLine("Long date: {0:D}", nextCentury);
            Console.WriteLine("Short time: {0:t}", nextCentury);
            Console.WriteLine("Long time: {0:T}", nextCentury);
            Console.WriteLine("Full date/ Short time: {0:f}", nextCentury);
            Console.WriteLine("Full date/ Long time: {0:F}", nextCentury);
            Console.WriteLine("General date/ Short time: {0:g}", nextCentury);
            Console.WriteLine("General date/ Long time: {0:G}", nextCentury);
            Console.WriteLine("Month day: {0:m}", nextCentury);
            Console.WriteLine("Month year: {0:Y}", nextCentury);
            Console.WriteLine();

            //can also be done using the follwing ways
            Console.WriteLine(string.Format("Month year: {0:Y}", nextCentury));

            Console.WriteLine("Month day: " + nextCentury.ToString("M"));
        }

        static void StringBuilderClass()
        {
            string author1 = "Ashraf Ali";
            string author2 = "Muhammad Hassan";

            //inefficient way to build the string

            //string authors;
            //authors = author1 + " wrote chapter 1" + "\n" +
            //          author2 + " wrote chapter 2" + "\n" +
            //          author2 + " wrote chapter 3" + "\n" +
            //          author1 + " wrote chapter 4" + "\n" +
            //          author1 + " wrote chapter 5" + "\n" +
            //          author2 + " wrote chapter 6";
            //Console.WriteLine(authors);

            //efficient way to build a string

            StringBuilder authors = new StringBuilder();
            authors.Append(author1);
            authors.Append(" wrote chapter 1");
            authors.AppendLine();
            authors.Append(author2);
            authors.Append(" wrote chapter 2");
            authors.AppendLine();
            authors.Append(author1);
            authors.Append(" wrote chapter 3");
            authors.AppendLine();
            authors.Append(author2);
            authors.Append(" wrote chapter 4");
            authors.AppendLine();

            Console.WriteLine(authors);

            authors.Insert(0, "\tCourse Authors" + "\n");
            Console.WriteLine(authors);

            StringBuilder nextChapter = new StringBuilder();
            nextChapter.Append(author2);
            nextChapter.Append(" wrote chapter 5");
            nextChapter.AppendLine();

            authors.Insert(authors.Length, nextChapter);
            Console.WriteLine(authors);

            authors.Replace("Muhammad Hassan", "Hassan");
            authors.Replace("Ashraf Ali", "Ashraf");

            //removes Course Authors
            authors.Remove(0, 16);
            Console.WriteLine(authors);
        }

        static void DateTimeProperties()
        {
            Console.WriteLine("Today: {0}", DateTime.Today);
            Console.WriteLine("Now: {0}", DateTime.Now);
            Console.WriteLine();
            Console.WriteLine("Date: {0}", DateTime.Now.Date);
            Console.WriteLine("Month: {0}", DateTime.Now.Month);
            Console.WriteLine("Day: {0}", DateTime.Now.Day);
            Console.WriteLine("Year: {0}", DateTime.Now.Year);
            Console.WriteLine();
            Console.WriteLine("DaysOfWeek: {0}", DateTime.Now.DayOfWeek);
            Console.WriteLine("DaysOFYear: {0}", DateTime.Now.DayOfYear);
            Console.WriteLine();
            Console.WriteLine("TimeOfDay: {0}", DateTime.Today);
            Console.WriteLine("Hour: {0}", DateTime.Now.Hour);
            Console.WriteLine("Minutes: {0}", DateTime.Now.Minute);
            Console.WriteLine("Seconds: {0}", DateTime.Now.Second);
            Console.WriteLine();

            DateTime nextCentury = new DateTime(2100, 1, 1);

            Console.WriteLine("Date: {0}", nextCentury.Date);
            Console.WriteLine("DayOfWeek: {0}", nextCentury.DayOfWeek);
            Console.WriteLine("Month: {0}", nextCentury.Month);
            Console.WriteLine("Day: {0}", nextCentury.Day);
            Console.WriteLine("year: {0}", nextCentury.Year);
        }

        static void DateTimeMethods()
        {
            Console.WriteLine("Today: {0}", DateTime.Today.ToShortDateString());
            Console.WriteLine("Today: {0}", DateTime.Today.ToLongDateString());
            Console.WriteLine("Now: {0}", DateTime.Now.ToShortTimeString());
            Console.WriteLine("Now: {0}", DateTime.Now.ToLongTimeString());
            Console.WriteLine();

            DateTime otherDateTime;

            otherDateTime = DateTime.Today.AddDays(5);
            Console.WriteLine("5 days from now: {0}", otherDateTime.Date.ToShortDateString());
            otherDateTime = DateTime.Today.AddMonths(-5);
            Console.WriteLine("5 months ago: {0}", otherDateTime.Date.ToShortDateString());
            otherDateTime = DateTime.Today.AddYears(-10);
            Console.WriteLine("10 years ago: {0}", otherDateTime.Date.ToShortDateString());
            Console.WriteLine();

            otherDateTime = DateTime.Now.AddHours(5);
            Console.WriteLine("5 hours from now: {0}", otherDateTime.ToShortTimeString());
            otherDateTime = DateTime.Today.AddMinutes(-5);
            Console.WriteLine("5 minutes ago: {0}", otherDateTime.ToShortTimeString());
            otherDateTime = DateTime.Today.AddSeconds(-1000);
            Console.WriteLine("1000 seconds ago: {0}", otherDateTime.ToLongTimeString());
            Console.WriteLine();



        }

        static void TimeSpanProperties()
        {
            DateTime rightnow = DateTime.Now;

            DateTime nextMinute = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
                                      DateTime.Now.Day, DateTime.Now.AddMinutes(1).Hour, 
                                      DateTime.Now.AddMinutes(1).Minute, 0);

            DateTime nextHour = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                                      DateTime.Now.Day, DateTime.Now.AddHours(1).Hour,
                                      0, 0);
            DateTime nextDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                                            DateTime.Now.AddDays(1).Day, 0, 0, 0);

            Console.WriteLine("Now: {0}", DateTime.Now.ToLongTimeString());

            TimeSpan timeRemainig = nextMinute - rightnow;
            Console.WriteLine("Second left in the minute: {0}", timeRemainig.Seconds);
            timeRemainig = nextHour - rightnow;
            Console.WriteLine("Minutes left in the hour: {0}", timeRemainig.Minutes);
            timeRemainig = nextDay - rightnow;
            Console.WriteLine("Hours left in this day: {0}", timeRemainig.Hours);
            Console.WriteLine();

            DateTime firstDate = DateTime.Today;
            DateTime secondDate = new DateTime(2099, 12, 31);

            //Timespan timeRemaining;

            timeRemainig = secondDate - firstDate;

            Console.WriteLine("Today: {0}", DateTime.Today.ToShortDateString());

            Console.WriteLine("Days left in century: {0:N0}", timeRemainig.TotalDays);
            Console.WriteLine("Hours left in century: {0:N0}", timeRemainig.TotalHours);
            Console.WriteLine("Seconds left in century: {0:N0}", timeRemainig.TotalSeconds);
        }
    }
}