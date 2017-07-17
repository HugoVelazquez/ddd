using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.DataPersistent;
using Example.Domain.IRepositories;
using Ninject.Modules;

namespace Example.Service
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRepositoryUser>().To<RepositoryUser>();
        }
    }
}
