

namespace TechnicalInterview.App_Start
{
    using Autofac;
    using Autofac.Integration.Mvc;

    using System.Reflection;
    using MasGlobal.Interview;
    using System.Web.Mvc;
    using Dao;
    using MasGlobal.Interview.Interfaces;
    using MasGlobal.Interview.BusinessLogic;

    public static class IocConfiguration
    {
        public static IContainer Container { get; set; }

        public static T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            RegisterControllers(builder);
         
            RegisterServices(builder);

            Container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container)); //Set the MVC DependencyResolver


            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            //Register Servicios
            builder.RegisterType<DaoEmployees>().As<IDaoEmployees>().InstancePerDependency();
            builder.RegisterType<BlEmployees>().As<IBlEmployees>().InstancePerDependency();         
            
        }

    

        private static void RegisterControllers(ContainerBuilder builder)
        {
            ///// MVC Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

        }
    }
}