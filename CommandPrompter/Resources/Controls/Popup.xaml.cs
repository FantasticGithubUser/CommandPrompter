using CommandPrompter.Helpers;
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

namespace CommandPrompter.Resources.Controls
{
    /// <summary>
    /// Popup.xaml 的交互逻辑
    /// </summary>
    public partial class Popup : UserControl
    {
        public static DependencyProperty ContextStringProperty = DependencyProperty.Register("ContextString", typeof(string), typeof(Popup), new PropertyMetadata(""));

        public static DependencyProperty IsPoppedUpProperty = DependencyProperty.Register("isPoppedUp", typeof(bool), typeof(Popup), new PropertyMetadata(false, IsPoppedUpPropertyChangedCallback));

        public static DependencyProperty InsideContentProperty = DependencyProperty.Register("InsideContent", typeof(object), typeof(Popup), new PropertyMetadata(null));

        public static DependencyProperty HeaderContentProperty = DependencyProperty.Register("HeaderContent", typeof(object), typeof(Popup), new PropertyMetadata(null));
        private static void IsPoppedUpPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var popup = d as Popup;
            if ((bool)e.NewValue == true)
            {
                if (string.IsNullOrEmpty(popup.ContextString) == false)
                {
                    popup.DataContext = PageSwitchHelper.GetContext(popup.ContextString);
                }
                popup.Visibility = Visibility.Visible;
            }
            else
            {
                popup.Visibility = Visibility.Hidden;
                popup.DataContext = null;
            }
        }
 
        public string ContextString 
        { 
            get { return (string)GetValue(ContextStringProperty); } 
            set { SetValue(ContextStringProperty, value); } 
        }

        public bool IsPoppedUp
        {
            get { return (bool)GetValue(IsPoppedUpProperty); }
            set { SetValue(IsPoppedUpProperty, value); }
        }

        public object InsideContent
        {
            get { return (object)GetValue(InsideContentProperty); }
            set { SetValue(InsideContentProperty, value); }
        }

        public object HeaderContent
        {
            get { return (object)GetValue(HeaderContentProperty); }
            set { SetValue(HeaderContentProperty, value); }
        }


        public Popup()
        {
            this.Visibility = Visibility.Hidden;
            InitializeComponent();
        }

        private void Popup_Close(object sender, RoutedEventArgs e)
        {
            this.IsPoppedUp = false;
        }
    }
}
