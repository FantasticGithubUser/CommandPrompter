using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CommandPrompter.Resources
{
    public class PopupPanelWidthAdjustConverter : BaseValueConverter<PopupPanelWidthAdjustConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((double)value - 500) / 2;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
