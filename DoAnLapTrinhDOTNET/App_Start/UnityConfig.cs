using DoAnLapTrinhDOTNET.service;
using System.Web.Mvc;
using Unity;

namespace DoAnLapTrinhDOTNET
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IServiceApi, ServiceApi>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
        }
    }
}