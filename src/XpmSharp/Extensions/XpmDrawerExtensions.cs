using System;
using System.Drawing;

namespace B2.XpmSharp.Drawing
{
    public static class XpmDrawerExtensions
    {
        public static void DrawOn(this XPixMap xpm, IntPtr handle)
        {
            using var g = Graphics.FromHwnd(handle);
            using var bmp = xpm.GetBitmap();
            g.DrawImage(bmp, Point.Empty);
        }

        public static Bitmap GetBitmap(this XPixMap xpm)
        {
            var width = xpm.Width;
            var height = xpm.Height;
            var bmp = new Bitmap(width, height);
            var colors = xpm.GetColors();
            for (var i = 0; i < height; i++)
                for (var j = 0; j < width; j++)
                    bmp.SetPixel(j, i, colors[i, j]);
            return bmp;
        }
    }
}
