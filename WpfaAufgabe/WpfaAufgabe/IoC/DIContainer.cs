using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfaAufgabe.IoC
{
    /// <summary>
    /// Simple IOC Container,
    /// Ist recomended for big production to use anothers OpenSource IOC Containers
    /// </summary>
    public class DIContainer
    {

        private readonly Dictionary<Type, Func<object>> types = new Dictionary<Type, Func<object>>();

        public void Register<TKey, TImplementation>() where TImplementation : TKey
        {
            types[typeof(TKey)] = () => ResolveByType(typeof(TImplementation));
        }

        private object ResolveByType(Type type)
        {
            var constructor = type.GetConstructors().Single();
            if (constructor != null)
            {
                var argumnets = constructor.GetParameters()
                                           .Select(parameterInfo => Resolve(parameterInfo.ParameterType))
                                           .ToArray();
                return constructor.Invoke(argumnets);
            }
            var instanceProperty = type.GetProperty("Instance");
            return instanceProperty.GetValue(null, null);
        }

        public void Register<T>(T instance)
        {
            types[typeof(T)] = () => instance;
        }

        internal TKey Resolve<TKey>()
        {
            return (TKey)Resolve(typeof(TKey));
        }

        internal object Resolve(Type type)
        {
            Func<object> provider;
            if (types.TryGetValue(type, out provider))
            {
                return provider();
            }

            return ResolveByType(type);
        }

    }
}
