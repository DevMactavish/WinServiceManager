using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WinServiceManager.Business.Abstract;
using WinServiceManager.Entities;
using WinServiceManager.Entities.Concrete;

namespace WinServiceManager.Business.Concrete
{
    public class ServiceManager : IServiceManager
    {
        ServiceController[] services = ServiceController.GetServices(Environment.MachineName);
        public List<Service> LoadServices()
        {
            List<Service> entities = new List<Service>();

            foreach (ServiceController service in services)
            {
                entities.Add(
                    new Service
                    {
                        DisplayName = service.DisplayName,
                        Name = service.ServiceName,
                        State = service.Status
                    });
            }

            return entities;
        }

        public void StopService(string serviceName)
        {
            ServiceController serviceController = services.FirstOrDefault(row => row.ServiceName.Equals(serviceName));
            serviceController.Stop();
            serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
        }
        public void StartService(string serviceName)
        {
            ServiceController serviceController = services.FirstOrDefault(row => row.ServiceName.Equals(serviceName));
            serviceController.Start();
            serviceController.WaitForStatus(ServiceControllerStatus.Running);
        }

        public void RestartService(string serviceName)
        {
            ServiceController serviceController = services.FirstOrDefault(row => row.ServiceName.Equals(serviceName));
            serviceController.Stop();
            serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
            serviceController.Start();
            serviceController.WaitForStatus(ServiceControllerStatus.Running);
        }
        public ServiceControllerStatus GetStatus(string serviceName)
        {
            return services.FirstOrDefault(row => row.ServiceName.Equals(serviceName)).Status;
        }
    }
}
