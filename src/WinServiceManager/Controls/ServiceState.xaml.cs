using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinServiceManager.Business.Abstract;
using WinServiceManager.Business.Concrete;
using WinServiceManager.Business.DependencyResolver.Ninject;

namespace WinServiceManager.Controls
{
    /// <summary>
    /// Interaction logic for ServiceState.xaml
    /// </summary>
    public partial class ServiceState : UserControl
    {
        private string _serviceName { get; set; }

        private IServiceManager _serviceManager;

        public ServiceState(string serviceNsame, IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _serviceName = serviceNsame;
            InitializeComponent();
            LoadState(_serviceName);
        }

        private void LoadState(string serviceName)
        {
            ServiceControllerStatus status = _serviceManager.GetStatus(serviceName);
            SertServiceProperties(status);
        }

        private void SertServiceProperties(ServiceControllerStatus status)
        {
            if (status == ServiceControllerStatus.Running)
            {
                stopService.IsEnabled = true;
                startService.IsEnabled = false;
                restartService.IsEnabled = true;
                elipseState.Fill = new SolidColorBrush(Colors.Green);
            }
            else if (status == ServiceControllerStatus.Stopped)
            {
                stopService.IsEnabled = false;
                startService.IsEnabled = true;
                restartService.IsEnabled = false;
                elipseState.Fill = new SolidColorBrush(Colors.Red);
            }

            tbStatus.Text = status.ToString();
        }

        private void StartService_Click(object sender, RoutedEventArgs e)
        {
            _serviceManager.StartService(_serviceName);

            LoadState(_serviceName);
        }

        private void StopService_Click(object sender, RoutedEventArgs e)
        {
            _serviceManager.StopService(_serviceName);
            LoadState(_serviceName);
        }

        private void RestartService_Click(object sender, RoutedEventArgs e)
        {
            _serviceManager.RestartService(_serviceName);
            LoadState(_serviceName);
        }
    }
}
