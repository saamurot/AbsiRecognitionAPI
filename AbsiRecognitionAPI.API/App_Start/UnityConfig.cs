using System.Web.Http;
using Unity;
using Unity.WebApi;
namespace AbsiRecognitionAPI.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
  
            // Regestering the Interfaces and class for unit dependency injuction        
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}