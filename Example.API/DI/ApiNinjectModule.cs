using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Example.Domain;
using Example.Domain.IServices;
using Example.Service;
using Ninject.Modules;

namespace Example.API.DI
{
    public class ApiNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IServiceUser>().To<ServiceUser>();
        }
    }
}