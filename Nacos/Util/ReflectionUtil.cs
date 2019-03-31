using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Com.Alibaba.Nacos.Util
{
    public class ReflectionUtil
    {
        public static Dictionary<string, object> getProperties(object obj)
        {
            var classType = obj.GetType();

            return classType.GetProperties().ToDictionary(pi => pi.Name, pi => pi.GetValue(obj));
        }
    }
}