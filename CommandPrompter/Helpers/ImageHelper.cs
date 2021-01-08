using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;

namespace CommandPrompter.Helpers
{
    public static class ImageHelper
    {
        public static byte[] ImageToByteArray(string location)
        {
            byte[] image = File.ReadAllBytes(location);
            return image;
        }
    }
}
