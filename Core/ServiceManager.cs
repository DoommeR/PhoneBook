using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ServiceManager
    {
        private static  ServiceManager instance;
        private static Dictionary<Type,object> dict;
        protected ServiceManager() { }

        public static ServiceManager getInstance() {

            if (instance==null) {
                instance = new ServiceManager();
                dict = new Dictionary<Type, object>();
            }
            return instance;
        }

        public void Register<T>(T val) {
            if (!dict.ContainsKey(val.GetType())) {
                dict.Add(val.GetType(), val);

                dict.TryGetValue(val.GetType(), out object res);
                Console.WriteLine(res.ToString());
            }
        }

        public static T Resolve<T>() {
            object res;
            
            try
            {
                dict.TryGetValue(typeof(T), out res);

            }
            catch (KeyNotFoundException)
            {
                
                return default;
            }
            return (T)res;
        }
    }
}
