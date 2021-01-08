using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CommandPrompter.Resources
{
    public class ByteArrayToImageConverter : BaseValueConverter<ByteArrayToImageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var image = new BitmapImage();
            //image.BeginInit();
            //image.UriSource = new Uri(@"Resources/Images/test.jpg", UriKind.RelativeOrAbsolute);
            //image.EndInit();
            //return image;
            var byteArray = (byte[])value;
            using(var ms = new MemoryStream(byteArray))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private void DrawImage()
        {
            //var random = new Random();
            //var pixels = new byte[256 * 256 * 4];
            //random.NextBytes(pixels);
            //BitmapSource bitmapSource = BitmapSource.Create(256, 256, 96, 96, PixelFormats.Pbgra32, null, pixels, 256 * 4);
            //var visual = new DrawingVisual();
            //using (DrawingContext drawingContext = visual.RenderOpen())
            //{
            //    drawingContext.DrawImage(bitmapSource, new Rect(0, 0, 256, 256));
            //    drawingContext.DrawText(
            //        new FormattedText("Hi!", CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
            //            new Typeface("Segoe UI"), 32, Brushes.Black), new Point(0, 0));
            //}
            //var image = new DrawingImage(visual.Drawing);
        }
    }
}
