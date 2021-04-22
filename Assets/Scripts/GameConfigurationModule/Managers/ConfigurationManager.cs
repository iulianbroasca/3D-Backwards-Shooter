using System;
using System.Collections.Generic;
using System.Linq;
using Globals;
using MonoSingleton;
using UnityEngine;

namespace GameConfigurationModule.Managers
{
    public class ConfigurationManager : MonoSingleton<ConfigurationManager>
    {
        private readonly Dictionary<object, ScriptableObject> configurations = new Dictionary<object, ScriptableObject>();

        public T GetConfiguration<T>() where T : ScriptableObject
        {
            var element = configurations.FirstOrDefault(it => (Type) it.Key == typeof(T)).Value;

            if (element != null) 
                return (T) element;

            element = Resources.Load<T>(Constants.ConfigurationsPath + typeof(T).Name);
            configurations.Add(typeof(T), element);

            return (T) element;
        }
    }
}
