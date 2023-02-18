namespace Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ValRefParameters();
            StaticVariable();
        }

        static void ValRefParameters()
        {
            int amount = 25;
            string greeting = "Hello";

            Console.WriteLine("Passing parameters by value:");
            Console.WriteLine("The value of amount is {0}", amount);
            Console.WriteLine("The value of greeting is {0}", greeting);

            ModifyParamPassByValue(amount, greeting);
            Console.WriteLine("The value of amount is {0}", amount);
            Console.WriteLine("The value of greeting is {0}", greeting);

            Console.WriteLine("Passing parameters by refrence:");
            Console.WriteLine("The value of amount is {0}", amount);
            Console.WriteLine("The value of greeting is {0}", greeting);

            ModifyParamPassByRef(ref amount, ref greeting);
            Console.WriteLine("The value of amount is {0}", amount);
            Console.WriteLine("The value of greeting is {0}", greeting);
        }

        static void ModifyParamPassByValue(int param1, string param2)
        {
            param1 += 25;
            param2 += " World";

            Console.WriteLine("The value of param1 is {0}", param1);
            Console.WriteLine("The value of param2 is {0}", param2);

        }

        static void ModifyParamPassByRef(ref int param1, ref string param2)
        {
            param1 += 25;
            param2 += " World";

            Console.WriteLine("The value of param1 is {0}", param1);
            Console.WriteLine("The value of param2 is {0}", param2);
        }

        static void OutParam()
        {
            int amount;
            string greeting;

            Console.WriteLine("Passing parameters by value:");
            ModifyOutParam(out amount, out greeting);
            Console.WriteLine("The value of amount is {0}", amount);
            Console.WriteLine("The value of greeting is {0}", greeting);
        }

        static void ModifyOutParam(out int param1, out string param2)
        {
            param1 = 25;
            param2 = "Hello";

            param1 += 25;
            param2 += " World";

            Console.WriteLine("The value of param1 is {0}", param1);
            Console.WriteLine("The value of param2 is {0}", param2);
        }

        static void StaticVariable()
        {
            for (int counter = 1; counter <= 3; counter++)
            {
                WhatTimeIsIt();
            }
        }

        private static int counter = 0;
        static void WhatTimeIsIt()
        {
            counter += 1;

            Console.WriteLine("It is {0} and you asked {1}",
                    DateTime.Now.ToLongTimeString(), counter);

        }
    }
}