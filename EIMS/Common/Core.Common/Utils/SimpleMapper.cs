using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Core.Common.Utils
{
    public static class SimpleMapper
    {
        public static void PropertyMap<T, U>(T source, U destination, List<string> ignoredProperties = null)
            where T : class, new()
            where U : class, new()
        {
            List<PropertyInfo> sourceProperties = source.GetType().GetProperties().Where(p => ignoredProperties == null || !ignoredProperties.Contains(p.Name)).ToList<PropertyInfo>();
            List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);

                if (destinationProperty != null)
                {
                    try
                    {
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                    }
                    catch (ArgumentException)
                    {
                    }
                }
            }
        }
    }
}
