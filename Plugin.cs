using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public class Plugin
    {
        public static void InitializePlugins(Dictionary<string, ITechnicCreator> Factories)
        {
            string[] files = Directory.GetFiles("Plugin", "*.dll");
            
            foreach (string item in files)
            {
                Assembly assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), item));
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (type.GetInterface("ITechnicCreator") != null)
                    {
                        Factories.Add((type.Name).Substring(0, Math.Abs((type.Name).IndexOf("Creator"))), (ITechnicCreator)Activator.CreateInstance(type));
                    }
                }
            }
        }

        public static void InitializeFunctionalPlugins(Dictionary<string, IFuncPlugin> FuncPlugins)
        {
            string[] files = Directory.GetFiles("FunctionalPlugin", "*.dll");

            foreach (string item in files)
            {
                Assembly assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), item));
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    if (type.GetInterface("Interfaces.IFuncPlugin") != null)
                    {
                        var creatorInstance = Activator.CreateInstance(type);
                        FuncPlugins.Add(((IFuncPlugin)creatorInstance).Algorithm, (IFuncPlugin)Activator.CreateInstance(type));
                    }
                }
            }
        }
    }
}
