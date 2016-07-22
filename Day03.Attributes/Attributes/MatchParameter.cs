using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class MatchParameter : Attribute
    {
    }
}
