using System;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class StringValidatorAttribute : Attribute
    {
        private int v;

        public StringValidatorAttribute(int v)
        {
            this.v = v;
        }
    }
}
