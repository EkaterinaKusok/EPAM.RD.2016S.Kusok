using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashTable = new Hashtable();
            hashTable.Add(1, "one"); //box
            hashTable.Add(2, 2);
            hashTable.Add("three", 3.0025);
            foreach (var key in hashTable.Keys)
            {
                Console.WriteLine(key + " " + hashTable[key] + " " + hashTable[key].GetType());
            }
            Console.WriteLine("----------------");
            Console.ReadKey();

        }
    }
}
