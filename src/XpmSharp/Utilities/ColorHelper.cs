using System;
using System.Drawing;
using System.Globalization;

namespace B2.XpmSharp.Utilities
{
    internal class ColorHelper
    {
        internal static Color GetColor(string nameOrHex) => nameOrHex[0] == '#'? GetColorFromHex(nameOrHex) : GetColorFromName(nameOrHex);
        internal static Color GetColorFromName(string name)
        {
            if (name.StartsWith("gray", StringComparison.OrdinalIgnoreCase))
            {
                var tone = int.Parse(name.Remove(0, 4)) / 100 * 255;
                return Color.FromArgb(255, tone, tone, tone);
            }
            return Color.FromName(name);
        }
        internal static Color GetColorFromHex(string hex)
        {
            hex = hex.TrimStart('#');
            if (hex.Length == 6)
                hex = "FF" + hex;
            var argb = int.Parse(hex, NumberStyles.HexNumber);
            return Color.FromArgb(argb);
        }
    }
}
