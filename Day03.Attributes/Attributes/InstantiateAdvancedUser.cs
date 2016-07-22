using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class InstantiateAdvancedUser : Attribute
    {
        public int Id { get; }
        public  string FirstName { get; }
        public string LastName { get; }
        public int ExternalId { get; }

        public InstantiateAdvancedUser(int id, string firstName, string lastName, int externalId)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ExternalId = externalId;
        }

        public InstantiateAdvancedUser( string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
