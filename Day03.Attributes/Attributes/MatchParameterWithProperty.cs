using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class MatchParameterWithProperty : Attribute
    {
        public string Parameter { get; }
        public string Property { get; }

        public MatchParameterWithProperty(string parameter, string property)
        {
            this.Parameter = parameter;
            this.Property = property;
        }
    }
}
