using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintNumbers();

            //Thread[] threads = new Thread[20];
            //for (int i = 0; i<threads.Length; i++)
            //{
            //    threads[i] = new Thread(new ThreadStart(PrintNumbers));
            //}

            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Start();
            //}

            //var demon = new Thread(Sum); можно так
            //var demon = new Thread(new ParameterizedThreadStart(Sum)); или так

            var demon = new Thread(sumArguments =>
            {
                Thread.Sleep(3000);
                var arguments = sumArguments as SumArguments;
                Console.WriteLine(arguments.X + arguments.Y);
            });
            demon.IsBackground = false;
            demon.Start(new SumArguments { X = 1, Y = 5});

            //Console.ReadLine();
        }

        private static void PrintNumbers()
        {
            var currentThread = Thread.CurrentThread;
            Console.WriteLine($"***Поток с Id {currentThread.ManagedThreadId} начал работу***");

            for (int i = 0; i<10; i++)
            {
                Console.Write(i + " ");
                Thread.Sleep(500);
            }
            Console.WriteLine($"\n***Поток с Id {currentThread.ManagedThreadId} закончил работу***");
        }

        private static void Sum(object sumArguments)
        {
            Thread.Sleep(3000);
            var arguments = sumArguments as SumArguments;
            Console.WriteLine(arguments.X + arguments.Y);
        }
    }
}
