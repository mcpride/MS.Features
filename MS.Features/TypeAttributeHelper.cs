using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MS.Features
{
    internal class TypeAttributeHelper
    {
        public static IEnumerable<Type> GetTypesChildOf<T>()
        {
            var allTypes = new List<Type>();
            foreach (var assembly in GetAssemblies())
            {
                allTypes.AddRange(GetTypesChildOfInAssembly(typeof(T), assembly));
            }

            return allTypes;
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }

        private static IEnumerable<Type> GetTypesChildOfInAssembly(Type type, Assembly assembly)
        {
            try
            {
                return assembly.GetTypes().Where(t => type.IsAssignableFrom(t) && !t.IsAbstract);
            }
            catch (Exception)
            {
                return new List<Type>();
            }
        }
    }
}
