using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, bool>> lambda = num => num < 5;
            Console.WriteLine(lambda.ToString());
            Console.WriteLine(lambda.Compile().Invoke(4));

            Func<int, bool> d1 = num => num < 5;
            Console.WriteLine(d1.Invoke(4));
            Console.ReadKey();

        }
    }
}
