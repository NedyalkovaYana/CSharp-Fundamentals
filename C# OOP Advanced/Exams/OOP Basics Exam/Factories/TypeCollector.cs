using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using DungeonsAndCodeWizards.Exceptions;

namespace DungeonsAndCodeWizards.Factories
{
    public class TypeCollector
    {
        public Type[] GetAllInheritingTypes<T>()
        where T : class
        {
            Type parentType = typeof(T);

            if (!parentType.IsAbstract && !parentType.IsInterface)
            {
                throw new ArgumentException(String.Format(
                    Messages.InvalidCharacterType, parentType.Name));
            }

            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => parentType.IsAssignableFrom(t) &&
                            !t.IsInterface && !t.IsAbstract)
                .ToArray();
        }

    }
}
