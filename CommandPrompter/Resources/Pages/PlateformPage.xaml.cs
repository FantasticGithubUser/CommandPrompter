using CommandPrompter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandPrompter.Resources.Pages
{
    /// <summary>
    /// PlateformPage.xaml 的交互逻辑
    /// </summary>
    public partial class PlateformPage : Page
    {
        public PlateformPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new PlateformPageViewModel(this);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
        }
    }
}
