using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Attributes;

namespace ConsoleTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateObjects.CreateUsersByAttributesInUserClass();
            CreateObjects.CreateAdvancedUsersByAssemblyInfo();

            Console.ReadKey();
        }
    }
}
