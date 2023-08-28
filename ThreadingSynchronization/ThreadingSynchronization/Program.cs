using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSynchronization
{
    public class SynchronizationBasics
    {
        private object _sync = new object();
        int x = 10;

        public void SumAndPrint()
        {
            lock (_sync) // Critical Section
            {
                x = x + 1;
                Console.WriteLine(x);
            }

            // syntactic sugar

            Monitor.Enter(_sync);
            x = x + 1;
            Console.WriteLine(x);
            Monitor.Exit(_sync);

            try
            {
                Monitor.Enter(_sync);
                x = x + 1;
                Console.WriteLine(x);
            }
            // catch (Exception e) { }
            finally
            {
                Monitor.Exit(_sync);
            }

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using (Mutex instanceMutex = new Mutex(false, "skype.microsof.com"))
            {
                if (!instanceMutex.WaitOne(1000))
                {
                    Environment.Exit(0);
                }
            }


            SynchronizationBasics program = new SynchronizationBasics();

            Thread[] threads = new Thread[3];

            threads[0] = new Thread(program.SumAndPrint);
            threads[1] = new Thread(program.SumAndPrint);
            threads[2] = new Thread(program.SumAndPrint);
            threads[0].Start();
            threads[1].Start();
            threads[2].Start();

            ThreadBasics();
        }

        private static void ThreadBasics()
        {
            // Thread thread = new Thread(new ThreadStart(Print));
            Thread thread = new Thread(new ParameterizedThreadStart(Print));
            thread.Name = "Test";
            // thread.CurrentCulture
            // thread.CurrentUICulture
            thread.Priority = ThreadPriority.Highest;
            // thread.ApartmentState
            // thread.ExecutionContext
            // thread.IsAlive;
            // thread.IsBackground
            // thread.IsThreadPoolThread
            // thread.ManagedThreadId
            // thread.ThreadState
            // ThreadState.Running


            //Thread thread = new Thread(delegate ()
            //{
            //    Console.WriteLine($"Hello from Print: {Thread.CurrentThread.ManagedThreadId}");
            //});

            string webpageLink = Console.ReadLine();


            //Thread thread = new Thread(() => Console.WriteLine($"Hello from Print: {Thread.CurrentThread.ManagedThreadId}"));
            thread.Start(webpageLink);

            Thread currentThread = Thread.CurrentThread;
        }

        static void Print(object webpageUrl)
        {
            string webpage = webpageUrl.ToString();
            Console.WriteLine($"Hello from Print: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
