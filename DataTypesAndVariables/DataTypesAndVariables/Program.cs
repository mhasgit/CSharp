namespace DataTypesAndVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MinMaxValues();

            //FormatingWithToString();

            // DecimalDataType();
        }

        static void MinMaxValues()
        {
            Console.WriteLine("A byte varible can be between {0} and {1}", byte.MinValue, byte.MaxValue);
            Console.WriteLine("A sbyte varible can be between {0} and {1}", sbyte.MinValue, sbyte.MaxValue);
            Console.WriteLine("A short varible can be between {0} and {1}", short.MinValue, short.MaxValue);
            Console.WriteLine("A ushort varible can be between {0} and {1}", ushort.MinValue, ushort.MaxValue);
            Console.WriteLine("A int varible can be between {0} and {1}", int.MinValue, int.MaxValue);
            Console.WriteLine("A uint varible can be between {0} and {1}", uint.MinValue, uint.MaxValue);
        }

        static void FormatingWithToString()
        {
            int totalamount = 1000;
            Console.WriteLine("The value of intVarible is: " + totalamount.ToString());
            Console.WriteLine("intVarible in general format: " + totalamount.ToString("g"));
            Console.WriteLine("intVarible in decimal format: " + totalamount.ToString("d"));
            Console.WriteLine("intVarible in number format: " + totalamount.ToString("n"));
            Console.WriteLine("intVarible in currency format: " + totalamount.ToString("c")); 
            Console.WriteLine("intVarible in hexa format: " + totalamount.ToString("x"));
        }

        static void DecimalDataType()
        {
            decimal totalAmount;
            totalAmount = 45.6M;
            decimal totalDollars, totalCents;

            totalDollars = decimal.Truncate(totalAmount);
            totalCents = totalAmount - totalDollars;

            Console.WriteLine("The restaurant bill is {0:C}", totalAmount);
            Console.WriteLine("You pay the {0:C} and I'll pay the {1:C}", totalDollars, totalCents);
            Console.WriteLine();

            totalAmount = 45.67847387474M;
            Console.WriteLine("The total amount is {0}", totalAmount);
            Console.WriteLine("Rounded to 0 decimal places, this value is {0}", decimal.Round(totalAmount));
            Console.WriteLine("Rounded to 4 decimal places, this value is {0}", decimal.Round(totalAmount, 4));
            Console.WriteLine();

            totalAmount = 45.61M;

            Console.WriteLine("Profit last month was {0}", totalAmount);

            decimal totalDollars1;
            decimal totalDollars2;
            totalDollars1 = decimal.Floor(totalAmount);
            totalDollars2 = decimal.Ceiling(totalAmount);

            Console.WriteLine("Rounding down this number is {0}", totalDollars1);
            Console.WriteLine("Rounding up this number is {0}", totalDollars2);
        }
    }
}




