using CommandPrompter.Helpers;
using System;
using System.Globalization;

namespace CommandPrompter.Resources
{
    public class PageEnumToStringConverter : BaseValueConverter<PageEnumToStringConverter>
    {
        public override object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var pageEnum = (PageEnum)value;
            switch (pageEnum)
            {
                case PageEnum.Plateform:
                    return "Resources/Pages/PlateformPage.xaml";
                case PageEnum.Command:
                    return "Resources/Pages/CommandPage.xaml";
                case PageEnum.CommandChain:
                    return "Resources/Pages/CommandChainPage.xaml";
                case PageEnum.CommandParameter:
                    return "Resources/Pages/CommandParameterPage.xaml";
                case PageEnum.User:
                    return "Resources/Pages/UserPage.xaml";
                case PageEnum.Error:
                    return "Resources/Pages/ErrorPage.xaml";
                case PageEnum.Welcome:
                default:
                    return "Resources/Pages/WelcomePage.xaml";
            }
        }

        public override object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;
            switch (str)
            {
                case "Resources/Pages/PlateformPage.xaml":
                    return PageEnum.Plateform;
                case "Resources/Pages/CommandPage.xaml":
                    return PageEnum.Command;
                case "Resources/Pages/CommandChain.xaml":
                    return PageEnum.CommandChain;
                case "Resources/Pages/CommandParameterPage.xaml":
                    return PageEnum.CommandParameter;
                case "Resources/Pages/UserPage.xaml":
                    return PageEnum.User;
                case "Resources/Pages/ErrorPage.xaml":
                    return PageEnum.Error;
                case "Resources/Pages/WelcomePage.xaml":
                default:
                    return PageEnum.Welcome;
            }
        }
    }
}
