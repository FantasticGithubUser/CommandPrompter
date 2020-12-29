using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace CommandPrompter.Resources
{
    class WindowStateToThicknessConverter : BaseValueConverter<WindowStateToThicknessConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((WindowState)value == WindowState.Maximized)
                return new Thickness(3,3,3,3);
            else
                return new Thickness(0,0,0,0);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
