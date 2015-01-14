using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairFlights.Configuration
{
    public sealed class IoC
    {
        private static IoC instance = null;
        private IUnityContainer container;

        private static readonly object padlock = new object();

        public IoC()
        {
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            container = new UnityContainer().LoadConfiguration(section);
        }

        public static IoC GetInstance {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new IoC();
                    }
                    return instance;
                }
            }
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
