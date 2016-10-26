﻿using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Ninject;


namespace TaskWebApp.Repository
{
   
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IRepository>().To<TaxRepository>();
        }



      
    }
}