using Microsoft.Practices.Unity.Configuration;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace AutosWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            UnityContainer container = new UnityContainer();
            container.LoadConfiguration();            

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}