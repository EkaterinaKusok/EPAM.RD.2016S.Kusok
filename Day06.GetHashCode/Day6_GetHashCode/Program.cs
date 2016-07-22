using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_GetHashCode
{
    class Program
    {
       

        static void Main(string[] args)
        {
            //Task 1: GetHashCode
            KeyValuePair<int, string> val = new KeyValuePair<int, string>(5, "31");
            KeyValuePair<int, string> val2 = new KeyValuePair<int, string>(5, "30");
            Console.WriteLine(val.GetHashCode());
            Console.WriteLine(val2.GetHashCode());

            KeyValuePair<string, int> val1 = new KeyValuePair<string, int>("30", 5);
            KeyValuePair<string, int> val3 = new KeyValuePair<string, int>("30", 6);
            Console.WriteLine(val1.GetHashCode());
            Console.WriteLine(val3.GetHashCode());

            //Task : string and StringBuilder
            string s1 = null;
            StringBuilder s2 = new StringBuilder();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
                s1 += "1";
            Console.WriteLine(sw.ElapsedMilliseconds);
            Stopwatch sw1 = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
                s2.Append("1");
            Console.WriteLine(sw1.ElapsedMilliseconds);

        }
    }
}
