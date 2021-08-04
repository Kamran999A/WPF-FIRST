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
using System.Windows.Shapes;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            var mControl = new MapControl();
            mControl.MapServiceToken = "YyCLZ0tUWEVR5LhmOxU2~N5_DKq3BO09wuiDyyYk7cA~AnIe2DUX0rrV-lMgFs_kXLA5gEViyUs6v0AiM0La8hkXgQ2ydTUYo5mi8VO7koIu";
            mControl.Loaded += mapControl_Loaded;
            mainGrid.Children.Add(mControl);
        }
        private async void mapControl_Loaded(object sender, RoutedEventArgs e)
        {
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 40.41492, Longitude = 49.85320 };
            var cityCenter = new Geopoint(cityPosition);
            await (sender as MapControl).TrySetViewAsync(cityCenter, 19);
        }
    }
}
