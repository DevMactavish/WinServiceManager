using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WinServiceManager.Entities.Concrete;

namespace WinServiceManager.Business.Abstract
{
    public interface IServiceManager
    {
        List<Service> LoadServices();
        void StopService(string serviceName);
        void StartService(string serviceName);
        void RestartService(string serviceName);
        ServiceControllerStatus GetStatus(string serviceName);
    }
}
