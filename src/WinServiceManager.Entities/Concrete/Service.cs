using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WinServiceManager.Entities.Abstract;

namespace WinServiceManager.Entities.Concrete
{
   public class Service:IEntity
    {
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public ServiceControllerStatus State { get; set; }
    }
}
