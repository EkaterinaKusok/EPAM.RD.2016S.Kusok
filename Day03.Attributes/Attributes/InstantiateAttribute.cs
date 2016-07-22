using System;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Reflection;

namespace Attributes
{
    // Should be applied to classes only.
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class InstantiateUserAttribute : Attribute
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public InstantiateUserAttribute(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

        }

        public InstantiateUserAttribute(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
