using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
using UnityEngine;

namespace Utilities
{
    public static class TypeExtensions
    {
        public static IEnumerable<TypeInfo> GetDerivedTypes<T>()
        {
            //Get all types that derive from the abstract class System Behaviour
            var definedTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.DefinedTypes);

            return definedTypes.Where(definedType => definedType.IsSubclassOf(typeof(T)) && !definedType.IsAbstract);
        }

        public static List<Transform> GetChildren(this Transform transform)
        {
            List<Transform> output = new();
            for (int i = 0; i < transform.childCount; i++)
            {
                output.Add(transform.GetChild(i));
            }
            return output;
        }

        public static void DestroyChildren(this GameObject gameObject)
        {
            foreach (Transform transform in gameObject.transform.GetChildren())
            {
                UnityEngine.Object.Destroy(transform.gameObject);
            }
        }
    }
}