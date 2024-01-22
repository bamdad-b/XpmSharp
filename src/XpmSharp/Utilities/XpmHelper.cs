using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace B2.XpmSharp.Utilities
{
    internal class XpmHelper
    {
        internal static IDictionary<char, Color> AssignColors(XmpValues xmpValues)
        {
            return xmpValues.Colors.Select(x =>
            {
                var parts = x.Split(new string[] { " c " }, StringSplitOptions.None);
                return new KeyValuePair<char, Color>(parts[0][0], ColorHelper.GetColor(parts[1]));
            }).ToDictionary(x => x.Key, x => x.Value);
        }
        internal static char[,] AssignPixels(XmpValues xmpValues)
        {
            var data = new char[xmpValues.Height, xmpValues.Width];
            for (int i = 0; i < xmpValues.Height; i++)
            {
                string row = xmpValues.Pixels[i];
                for (int j = 0; j < xmpValues.Width; j++)
                {
                    data[i, j] = row[j];
                }
            }
            return data;
        }
    }
}
