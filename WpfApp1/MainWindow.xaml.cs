using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private readonly Random _random = new Random();
        private const int StackPanelSecondFirstButtonUID = 4;
        private const int ClearAllButtonUID = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            BasicGeoposition chennaiGeoposition = new BasicGeoposition() { Latitude = 13.0827, Longitude = 80.2707 };
            var center = new Geopoint(chennaiGeoposition);

            await ((MapControl)sender).TrySetViewAsync(center, 12);
        }
        private void Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                Color randomColor = Color.FromRgb((byte)_random.Next(0, 255), (byte)_random.Next(0, 255), (byte)_random.Next(0, 255));
                button.Background = new SolidColorBrush(randomColor);
                MessageBox.Show($"My number is {button.Content}", "Information about button", MessageBoxButton.OK, MessageBoxImage.Information);
                Window1 win1 = new Window1();
                win1.Show();
            }
        }
        private void RightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                Title = $"Button Content  \"{button.Content}\" is Deleted.";
                int buttonUID = Convert.ToInt32(button.Uid);
                if (buttonUID == ClearAllButtonUID)
                {
                    MainGrid.Children.Clear();
                }
                else if (buttonUID < StackPanelSecondFirstButtonUID)
                {
                    StackPanelFirst.Children.Remove(button);
                }
                else
                {
                    StackPanelSecond.Children.Remove(button);
                }
            }
        }
    }
}
