using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinServiceManager.Business.Abstract;
using WinServiceManager.Business.Concrete;

namespace WinServiceManager.Business.DependencyResolver.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IServiceManager>().To<ServiceManager>().InSingletonScope();
        }

    }
}
