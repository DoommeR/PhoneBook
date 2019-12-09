using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class ServiceManager
    {
        private static  ServiceManager instance;
        private Dictionary<Type,object> dict;
        private ServiceManager() { }

        public ServiceManager getInstance() {

            if (instance==null) {
                instance = new ServiceManager();
                dict = new Dictionary<Type, object>();
            }
            return instance;
        }

        public void Register<T>(T val) {
            if (!dict.ContainsKey(val.GetType())) {
                dict.Add(val.GetType(), val);
            }
        }

        public object Resolve<T>(T val) {
            object res;
            try
            {
                dict.TryGetValue(val.GetType(), out res);
                
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
            return res;
        }
    }
}
