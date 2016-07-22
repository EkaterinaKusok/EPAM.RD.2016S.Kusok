﻿using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Threading;

namespace ReadWrite
{
    class Program
    {
        // TODO: replace Object type with appropriate type for slim version of manual reset event.
        private static IList<Thread> CreateWorkers(ManualResetEventSlim mres, Action action, int threadsNum, int cycles)
        {
            var threads = new Thread[threadsNum];

            for (int i = 0; i < threadsNum; i++)
            {
                Action d = () =>
                {
                    // TODO: Wait for signal.
                    mres.Wait();

                    for (int j = 0; j < cycles; j++)
                    {
                        action();
                    }
                };

                Thread thread = new Thread(d.Invoke); // TODO: Create a new thread that will run the delegate above here.

                threads[i] = thread;
            }

            return threads;
        }

        static void Main(string[] args)
        {
            var list = new MyList();

            // TODO: Replace Object type with slim version of manual reset event here.
            ManualResetEventSlim mres = new ManualResetEventSlim(false);

            var threads = new List<Thread>();

            threads.AddRange(CreateWorkers(mres, () => { list.Add(1); }, 3, 10));
            threads.AddRange(CreateWorkers(mres, () => { list.Get(); }, 3, 10));
            threads.AddRange(CreateWorkers(mres, () => { list.Remove(); }, 3, 10));

            foreach (var thread in threads)
            {
                thread.Start();
                Console.WriteLine(thread.Name + " start.");
                // TODO: Start all threads.
            }

            Console.WriteLine("Press any key to run unblock working threads.");
            Console.ReadKey();

            // NOTE: When an user presses the key all waiting worker threads should begin their work.
            // TODO: Send a signal to all worker threads that they can run.
            mres.Set();

            foreach (var thread in threads)
            {
                // TODO: Wait for all working threads
                thread.Join();
            }

            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
    }
}
