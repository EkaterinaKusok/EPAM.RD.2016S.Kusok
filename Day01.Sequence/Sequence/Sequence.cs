using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    public class Sequence
    {
        public static int[] GetSequence(int limit)
        {
            if (limit < 0)
            {
                throw new ArgumentException("Limit is below zero");
            }

            var list = new int[limit];

            for (int i = 0; i < limit; i++)
            {
                list[i] = i + 1;
            }

            return list;
        }
    }
}
