using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
//using cipher_plugin_lfsr;
//using cezar_lib;

namespace oop_crud
{
    internal class CipherControl
    {
        //есть lfsr и цезарь(для примера)
        private List<string> plugins_formats;
        private List<Assembly> all_plugins;
        private object curr_manager;
        private Type curr_class;
        public List<string> GetAllPlugins()
        {
            plugins_formats = new List<string>();
            all_plugins = new List<Assembly>();
            
            var all = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in all)
                if (assembly.GetName().Name.Contains("plugin") || assembly.GetName().Name.Contains("lib"))
                    all_plugins.Add(assembly);
            //здесь получаем все плагины
            foreach(var plugin in all_plugins)
            {
                plugin.GetType(plugin.GetName().Name);
            }
            plugins_formats.Add(".lfsr");//это если не сработает
            plugins_formats.Add(".cez");
            return plugins_formats;
        }

        public Type GetClassNameCipher(string ext)
        {
            Type res;
            string extension = ext.Substring(1);
            List<Type> types = new List<Type>();
            foreach (var plugin in all_plugins)
                types.AddRange(plugin.GetTypes());
            List<Type> public_types = new List<Type>();
            foreach(var type in types)
                if(type.Name.Contains("Manager"))
                    public_types.Add(type);
            for(int i = 0; i < public_types.Count; i++)
            {
                if (public_types[i].Name.ToLower().Contains(extension))
                {
                    res = public_types[i];
                    return res;
                }
            }
            return null;
        }

        public void cipher_file(string filename, string ext)
        {
            GetAllPlugins();
            curr_class = GetClassNameCipher(ext);
            
            var constr = curr_class.GetConstructors();
            object[] parameters = new object[1];
            parameters[0] = filename;
            var obj = constr[0].Invoke(parameters);
            var method = curr_class.GetMethod("CipherFile");
            method.Invoke(obj, null);

        }

        public void decipher_file(string filename, string ext)
        {
            GetAllPlugins();
            curr_class = GetClassNameCipher(ext);
            var constr = curr_class.GetConstructors();
            object[] parameters = new object[1];
            parameters[0] = filename;
            var obj = constr[0].Invoke(parameters);
            var method = curr_class.GetMethod("DecipherFile");
            method.Invoke(obj, null);
        }
    }
}
