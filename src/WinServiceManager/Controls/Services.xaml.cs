using System;
using System.Collections.Generic;
using System.Linq;
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
using WinServiceManager.Entities.Concrete;

namespace WinServiceManager.Controls
{
    /// <summary>
    /// Interaction logic for Services.xaml
    /// </summary>
    public partial class Services : UserControl
    {
        private IServiceManager _serviceManager;
        public Services(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            InitializeComponent();
            LoadServices();
        }

        private void LoadServices()
        {
            lbServices.ItemsSource = _serviceManager.LoadServices();
            lbServices.DisplayMemberPath = "DisplayName";
            lbServices.SelectedValuePath = "Name";
        }

        private void LoadServiceState(string serviceName)
        {
            spState.Children.Clear();
            spState.Children.Add(new ServiceState(serviceName,_serviceManager));
        }

        private void LbServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadServiceState(lbServices.SelectedValue.ToString());
        }
    }
}
