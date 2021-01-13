using CommandPrompter.Models.ViewModels;
using System.Windows.Controls;

namespace CommandPrompter.Resources.Controls
{
    /// <summary>
    /// SideMenu.xaml 的交互逻辑
    /// </summary>
    public partial class SideMenu : UserControl
    {
        public SideMenu()
        {
            InitializeComponent();
            this.DataContext = new SideMenuViewModel(this);
        }
    }
}
