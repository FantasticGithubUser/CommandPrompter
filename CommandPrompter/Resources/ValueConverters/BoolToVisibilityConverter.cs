using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;

namespace CommandPrompter.Resources
{
    public class BoolToVisibilityConverter : BaseValueConverter<BoolToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = (bool)value;
            if (flag)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (Visibility)value;
            if(visibility == Visibility.Visible)
            {
                return true;
            }else if(visibility == Visibility.Collapsed)
            {
                return false;
            }
            return false;
        }
    }
}
