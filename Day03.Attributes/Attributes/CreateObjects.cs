using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    public static class CreateObjects
    {
        public static IEnumerable<User> CreateUsersByAttributesInUserClass()
        {
            var users = new List<User>();
            var instantiateAttrs = typeof(User).GetCustomAttributes<InstantiateUserAttribute>();
            foreach (var instantiateArrt in instantiateAttrs)
            {
                if (instantiateArrt.Id == 0)
                {
                    ConstructorInfo constructorInfoObj = typeof(User).GetConstructor(new Type[] { typeof(int) });
                    if (constructorInfoObj != null)
                    {
                        var ctorAttrs = constructorInfoObj.GetCustomAttributes<MatchParameterWithProperty>().ToArray();
                        foreach (var attr in ctorAttrs)
                        {
                            string property = attr.Property;
                            var userId =
                                typeof(User).GetProperty(property).GetCustomAttribute<DefaultValueAttribute>().Value;

                            User newUser = constructorInfoObj.Invoke(new object[] { userId }) as User;
                            newUser.FirstName = instantiateArrt.FirstName;
                            newUser.LastName = instantiateArrt.LastName;
                            users.Add(newUser);
                        }
                    }
                    else
                        throw new ApplicationException();
                }
                else
                {
                    User newUser = new User(instantiateArrt.Id);
                    newUser.FirstName = instantiateArrt.FirstName;
                    newUser.LastName = instantiateArrt.LastName;
                    users.Add(newUser);
                }
            }
            return users;
        }

        public static IEnumerable<AdvancedUser> CreateAdvancedUsersByAssemblyInfo()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            //currentDomain.Load("Attributes");
            Assembly[] assems = currentDomain.GetAssemblies();
            Console.WriteLine("List of assemblies loaded in current appdomain:");
            var users = new List<AdvancedUser>();
            foreach (Assembly assem in assems)
            {
                if (assem.FullName.Contains("Attributes"))
                {
                    var instantiateAttrs = assem.GetCustomAttributes<InstantiateAdvancedUser>();
                    foreach (var instantiateArrt in instantiateAttrs)
                    {
                        if (instantiateArrt.Id == 0 && instantiateArrt.ExternalId == 0)
                        {
                            var paramsForCtor = new Dictionary<string, object>(); // <parameter, value>

                            ConstructorInfo constructorInfoObj =
                                typeof (AdvancedUser).GetConstructor(new Type[] {typeof (int), typeof (int)});
                            if (constructorInfoObj != null)
                            {
                                var ctorAttrs =
                                    constructorInfoObj.GetCustomAttributes<MatchParameterWithProperty>().ToArray();

                                foreach (var attr in ctorAttrs)
                                {
                                    string parameter = attr.Parameter;
                                    string property = attr.Property;
                                    if (typeof (AdvancedUser).GetProperty(property) != null)
                                        paramsForCtor.Add(parameter,
                                            typeof (AdvancedUser).GetProperty(property)
                                                .GetCustomAttribute<DefaultValueAttribute>()
                                                .Value);
                                }
                            }
                            else
                                throw new ApplicationException();

                            AdvancedUser newUser =
                                constructorInfoObj.Invoke(new object[]
                                {paramsForCtor["id"], paramsForCtor["externalId"]}) as AdvancedUser;
                            newUser.FirstName = instantiateArrt.FirstName;
                            newUser.LastName = instantiateArrt.LastName;
                            users.Add(newUser);
                        }
                        else
                        {
                            AdvancedUser newUser = new AdvancedUser(instantiateArrt.Id, instantiateArrt.ExternalId);
                            newUser.FirstName = instantiateArrt.FirstName;
                            newUser.LastName = instantiateArrt.LastName;
                            users.Add(newUser);
                        }
                    }
                }
            }
            return users;
        }
    }
}
