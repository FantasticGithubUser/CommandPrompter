using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using System.Linq;

namespace CommandPrompter.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        /// Already Compressed.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(string location)
        {
            //byte[] image = File.ReadAllBytes(location);
            //return image;

            Image source = Image.FromFile(location);
            Image destination = new Bitmap(128, 128);

            using (var g = Graphics.FromImage(destination))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.DrawImage(source, new Rectangle(0, 0, 128, 128), new Rectangle(0, 0, source.Width, source.Height), GraphicsUnit.Pixel);
            }
            using var ms = new MemoryStream();
            //Save to Desktop
            //destination.Save(@"C:\Users\Jiner\Desktop\output.jpg", ImageFormat.Jpeg);
            destination.Save(ms, ImageFormat.Png);
            return ReadToEnd(ms);
        }

        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
    }
}
