using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NLog.Conditions;

namespace Pds.Api.Logging.NLogConditions
{
    [ConditionMethods]
    public static class ExceptionConditionMethods
    {
        private static ConcurrentDictionary<(string Sub, string Base), bool> calculatedResultsOfIsSubclass = new();
        [ConditionMethod("subclass")]
        public static bool IsSubclass(string subclassName, string baseclassName)
        {
            if (string.IsNullOrEmpty(subclassName) || string.IsNullOrEmpty(baseclassName))
                return false;
            return calculatedResultsOfIsSubclass.GetOrAdd((subclassName, baseclassName), tuple =>
            {
                var subType = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => !a.IsDynamic)
                    .Select(a => a.GetType(subclassName))
                    .FirstOrDefault(t => t != null);
                if (subType is null)
                    return false;
                var baseType = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => !a.IsDynamic)
                    .Select(a => a.GetType(baseclassName))
                    .FirstOrDefault(t => t != null);
                return baseType is not null && subType.IsSubclassOf(baseType);
            });
        }
    }
}