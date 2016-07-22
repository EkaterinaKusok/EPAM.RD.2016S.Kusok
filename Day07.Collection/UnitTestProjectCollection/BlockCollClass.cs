using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;


namespace UnitTestProjectCollection
{
    public class BlockCollClass
    {
        protected BlockingCollection<int> bc;

        private void producer()
        {
            for (int i = 0; i < 100; i++)
            {
                bc.TryAdd(i*i);
                Debug.WriteLine("Create " + i*i);
            }
        }

        private void consumer()
        {

            foreach (var i1 in bc)
            {
                int temp;
                while (!bc.TryTake(out temp, i1))
                {
                }
                Debug.WriteLine("Take: " + temp);
            }
        }

        public void Start()
        {
            bc = new BlockingCollection<int>();

            Task Pr = new Task(producer);
            Task Cn = new Task(consumer);

            Pr.Start();
            Cn.Start();

            try
            {
                Task.WaitAll(Cn, Pr);
            }
            finally
            {
                Cn.Dispose();
                Pr.Dispose();
            }
        }
    }
}
