using System;
using System.Collections.Concurrent;

namespace GreenLeaf4._1.Helpers
{

   // Not sure if this is used. Dont think it is since we already have the singleton classes
   // It was generated in the template studio and im not sure how to implement it.
    internal static class Singleton<T>
        where T : new()
    {
        private static ConcurrentDictionary<Type, T> _instances = new ConcurrentDictionary<Type, T>();

        public static T Instance
        {
            get
            {
                return _instances.GetOrAdd(typeof(T), (t) => new T());
            }
        }
    }
}
