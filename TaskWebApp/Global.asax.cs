using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TaskWebApp.ModelBinderHelper;
using TaskWebApp.Models;
using TaskWebApp.Repository;

namespace TaskWebApp
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
            ModelBinderProviders.BinderProviders.Insert(0, new GlobalModelBinderProvider());
            ModelBinders.Binders.Add(typeof(List<TaxViewModel>), new MVModelBinder());
            var dbContext = new TaxTransactionContext();
            Database.SetInitializer(new DataInitialization());
            dbContext.Database.Initialize(true);

        }
    }
}
