namespace Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TestingDisplayMessage();
            // TestingSayHello();
            ModifiedTestingSayHello();
        }



        static void TestingDisplayMessage()
        {
            Thread thread = new Thread(DisplayMessage);
            thread.Start("Hello, World");
        }

        static void DisplayMessage(object stateArg)
        {
            string msg = (string)stateArg as string;

            if (msg != null)
            {
                Console.WriteLine(msg);
            }

        }

        static void TestingSayHello()
        {
            Console.WriteLine("[ {0} ] Main start", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("[ {0} ] Processor/cores count = {1} ", Thread.CurrentThread.ManagedThreadId
                                                                       , Environment.ProcessorCount);

            Thread thread = new Thread(SayHello);
            thread.Name = "Hello Thread";
            thread.Priority = ThreadPriority.BelowNormal;
            thread.Start();

            Console.WriteLine("[ {0} ] Main End", Thread.CurrentThread.ManagedThreadId);
        }

        static void SayHello()
        {
            Console.WriteLine("[ {0} ] Hello, World", Thread.CurrentThread.ManagedThreadId);
        }


        static void ModifiedTestingSayHello()
        {
            Console.WriteLine("[ {0} ] Main start", Thread.CurrentThread.ManagedThreadId);

            Thread thread = new Thread(ModifiedSayHello);
            //thread.IsBackground = true;
            thread.Start(10);

            Console.WriteLine("[ {0} ] Main End", Thread.CurrentThread.ManagedThreadId);
        }

        static void ModifiedSayHello(object org)
        {
            int iterations = (int)org;

            for (int i = 0; i < iterations; i++)
            {
                Console.WriteLine("[ {0} ] Hello, World {1}! ({2})", Thread.CurrentThread.ManagedThreadId
                                                                   ,i
                                                                   , Thread.CurrentThread.IsBackground);
            }
        }


    }

}