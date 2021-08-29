using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace odata_poc.Helpers
{
    public static class PropertyValueHelpers
    {
        public static bool HasProperty(this object instance, string propertyName)
        {
            var propertyInfo = instance.GetType().GetProperty(propertyName);
            return (propertyInfo != null);
        }

        public static object GetValue(this object instance, string propertyName)
        {
            var propertyInfo = instance.GetType().GetProperty(propertyName);
            if (propertyInfo == null)
            {
                throw new Exception("Property Doesn't Exist " + propertyName);
            }
            return propertyInfo.GetValue(instance, new object[] { }); 
        }
    } 
}
