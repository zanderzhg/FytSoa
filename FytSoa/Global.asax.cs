using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FytSoa.Core;

namespace FytSoa
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            #region 依赖注入
            var builder = new ContainerBuilder();
            //注册DomainServices
            var services = Assembly.Load("FytSoa.Core");
            builder.RegisterAssemblyTypes(services);
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            //注册api容器需要使用HttpConfiguration对象
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion
        }
    }
}
