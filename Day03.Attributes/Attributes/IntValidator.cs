using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class IntValidator : Attribute
    {
        private int v1;
        private int v2;

        public IntValidator(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}
