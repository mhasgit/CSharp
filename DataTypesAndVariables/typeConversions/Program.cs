namespace typeConversions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WideningConversion();

            ConversionOperators();

            ConvertClass();

            parseMethod();
        }

        static void ImplicitExplicitConversions()
        {
            //implicit converion of int to decimal
            //int unitsOrder = 100;
            //decimal unitPrice = 24.5M;
            //decimal total;
            //total = unitsOrder * unitPrice;
            //Console.WriteLine("total amoount is {0}", total);

            //implicit converion of int to decimal
            int unitsOrder = 100;
            decimal unitPrice = 24.5M;
            int total;
            total = (int)(unitsOrder * unitPrice);
            Console.WriteLine("total amoount is {0}", total);

        }

        static void WideningConversion()
        {
            ConversionOperators();

            Console.WriteLine();
            Console.WriteLine("Do the same with convert class");
            Console.ReadKey();

            ConvertClass();
            Console.WriteLine();
            Console.WriteLine("Do the same with convert class");
            Console.ReadKey();

            parseMethod();

        }
        static void ConversionOperators()
        {
            byte byteValue;
            short shortValue;
            int intValue;
            long longValue;
            float floatValue;
            double doubleValue;
            decimal decimalValue;
            char charValue;
            string stringValue;

            byteValue = 2;
            shortValue = 1000;
            Console.WriteLine("byteValue is {0}, shortValue is {1}", byteValue, shortValue);
            shortValue = (short)(shortValue + byteValue);
            Console.WriteLine("Add them and shortvalue is {0}", shortValue);
            Console.WriteLine();

            shortValue = 100;
            intValue = 1000;
            Console.WriteLine("shortValue is {0}, intValue is {1}", shortValue, intValue);
            intValue = intValue + shortValue;
            Console.WriteLine("Add them and intValue is {0}", intValue);
            Console.WriteLine();


            intValue = 1000;
            longValue = 3000000;
            Console.WriteLine("intValue is {0}, longValue is {1}", intValue, longValue);
            longValue = longValue + intValue;
            Console.WriteLine("Add them and longValue is {0}", longValue);
            Console.WriteLine();

            longValue = 300000000000000000;
            floatValue = 200.12341F;
            Console.WriteLine("longValue is {0}, floatValue is {1}", longValue, floatValue);
            floatValue = floatValue + longValue;
            Console.WriteLine("Add them and floatValue is {0}", floatValue);
            Console.WriteLine();

            floatValue = 200.12341F;
            doubleValue = 50000.1234;
            Console.WriteLine("floatValue is {0}, doubleValue is {1}", floatValue, doubleValue);
            doubleValue = doubleValue + (double)floatValue;
            Console.WriteLine("Add them and doubleValue is {0}", doubleValue);
            Console.WriteLine();


            doubleValue = 50000.1234; ;
            decimalValue = 6000000.1234M;
            Console.WriteLine("doubleValue is {0}, decimalValue is {1}", doubleValue, decimalValue);
            decimalValue = decimalValue + (decimal)doubleValue;
            Console.WriteLine("Add them and decimalValue is {0}", decimalValue);
            Console.WriteLine();

            decimalValue = 6000000.1234M;
            stringValue = "ABC";
            Console.WriteLine("decimalValue is {0}, stringValue is {1}", decimalValue, stringValue);
            stringValue = stringValue + decimalValue.ToString();
            Console.WriteLine("Add them and stringValue is {0}", stringValue);
            Console.WriteLine();

            charValue = 'A';
            stringValue = "ABC";
            Console.WriteLine("stringValue is {0}, charValue is {1}", stringValue, charValue);
            stringValue = stringValue + charValue.ToString();
            Console.WriteLine("Add them and stringValue is {0}", stringValue);
            Console.WriteLine();

        }

        static void ConvertClass()
        {
            byte byteValue;
            short shortValue;
            int intValue;
            long longValue;
            float floatValue;
            double doubleValue;
            decimal decimalValue;
            

            byteValue = 2;
            shortValue = 100;
            Console.WriteLine("byteValue is {0}, shortValue is {1}", byteValue, shortValue);
            shortValue = Convert.ToInt16(shortValue + byteValue);
            Console.WriteLine("Add them and shortvalue is {0}", shortValue);
            Console.WriteLine();

            shortValue = 100;
            intValue = 1000;
            Console.WriteLine("shortValue is {0}, intValue is {1}", shortValue, intValue);
            intValue = intValue + Convert.ToInt32(shortValue);
            Console.WriteLine("Add them and intValue is {0}", intValue);
            Console.WriteLine();


            intValue = 1000;
            longValue = 3000000;
            Console.WriteLine("intValue is {0}, longValue is {1}", intValue, longValue);
            longValue = longValue + Convert.ToInt64(intValue);
            Console.WriteLine("Add them and longValue is {0}", longValue);
            Console.WriteLine();

            longValue = 3000000;
            floatValue = 200.12341F;
            Console.WriteLine("longValue is {0}, floatValue is {1}", longValue, floatValue);
            floatValue = floatValue + Convert.ToSingle(longValue);
            Console.WriteLine("Add them and floatValue is {0}", floatValue);
            Console.WriteLine();

            floatValue = 200.12341F;
            doubleValue = 50000.1234;
            Console.WriteLine("floatValue is {0}, doubleValue is {1}", floatValue, doubleValue);
            doubleValue = doubleValue + Convert.ToDouble(floatValue);
            Console.WriteLine("Add them and doubleValue is {0}", doubleValue);
            Console.WriteLine();


            doubleValue = 50000.1234; ;
            decimalValue = 6000000.1234M;
            Console.WriteLine("doubleValue is {0}, decimalValue is {1}", doubleValue, decimalValue);
            decimalValue = decimalValue + Convert.ToDecimal(doubleValue);
            Console.WriteLine("Add them and decimalValue is {0}", decimalValue);
            Console.WriteLine();

        }

        static void parseMethod()
        {
            byte byteValue;
            short shortValue;
            int intValue;
            long longValue;
            float floatValue;
            double doubleValue;
            decimal decimalValue;

            byteValue = 2;
            shortValue = (short)100;
            Console.WriteLine("byteValue is {0}, shortValue is {1}", byteValue, shortValue);
            shortValue = Int16.Parse((shortValue + byteValue).ToString());
            Console.WriteLine("Add them and shortvalue is {0}", shortValue);
            Console.WriteLine();

            shortValue = 100;
            intValue = 1000;
            Console.WriteLine("shortValue is {0}, intValue is {1}", shortValue, intValue);
            intValue = intValue + Int32.Parse(shortValue.ToString());
            Console.WriteLine("Add them and intValue is {0}", intValue);
            Console.WriteLine();


            intValue = 1000;
            longValue = 3000000;
            Console.WriteLine("intValue is {0}, longValue is {1}", intValue, longValue);
            longValue = longValue + Int64.Parse(intValue.ToString());
            Console.WriteLine("Add them and longValue is {0}", longValue);
            Console.WriteLine();

            longValue = 3000000;
            floatValue = 200.12341F;
            Console.WriteLine("longValue is {0}, floatValue is {1}", longValue, floatValue);
            floatValue = floatValue + Single.Parse(longValue.ToString());
            Console.WriteLine("Add them and floatValue is {0}", floatValue);
            Console.WriteLine();

            floatValue = 200.12341F;
            doubleValue = 50000.1234;
            Console.WriteLine("floatValue is {0}, doubleValue is {1}", floatValue, doubleValue);
            doubleValue = doubleValue + double.Parse(floatValue.ToString());
            Console.WriteLine("Add them and doubleValue is {0}", doubleValue);
            Console.WriteLine();


            doubleValue = 50000.1234; ;
            decimalValue = 6000000.1234M;
            Console.WriteLine("doubleValue is {0}, decimalValue is {1}", doubleValue, decimalValue);
            decimalValue = decimalValue + decimal.Parse(doubleValue.ToString());
            Console.WriteLine("Add them and decimalValue is {0}", decimalValue);
            Console.WriteLine();


        }
    }
}