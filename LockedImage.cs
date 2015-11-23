using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ConsoleApplication2
{
    /// <summary>inserting a Bitmap in this class will make reading and writing to the image substantially faster.</summary>
    class LockedImage
    {
        Bitmap bitmap;
        BitmapData bitmapData;
        byte[] pixels;

        public LockedImage(Bitmap bitmap)
        {
            bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            int bytesPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            int byteCount = bitmapData.Stride * bitmap.Height;
            pixels = new byte[byteCount];
            IntPtr ptrFirstPixel = bitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, pixels, 0, pixels.Length);
            int heightInPixels = bitmapData.Height;
            int widthInBytes = bitmapData.Width * bytesPerPixel;

            this.bitmap = bitmap;
        }

        public Color getPixel(int x, int y)
        {
            int currentLine = y * bitmapData.Stride;
            return Color.FromArgb(pixels[currentLine + x + 2], pixels[currentLine + x + 1], pixels[currentLine + x]);
        }

        public void setPixel(int x, int y,Color pixel)
        {
            int currentLine = y * bitmapData.Stride;
            pixels[currentLine + x] = pixel.B;
            pixels[currentLine + x + 1] = pixel.G;
            pixels[currentLine + x + 2] = pixel.R;
        }
    }
}
