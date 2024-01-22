using B2.XpmSharp.Utilities;
using System.Collections.Generic;
using System.Drawing;

namespace B2.XpmSharp
{
    /// <summary>The main object containing describing the XPM graphics.</summary>
    public partial class XPixMap
    {
        private string RawData { get; }
        private XmpValues XmpValues { get; }
        IDictionary<char, Color> ColorChars { get; set; }
        char[,] CharData { get; set; }

        public short Width => XmpValues.Width;
        public short Height => XmpValues.Height;
        public Point? Hotspot => XmpValues.HotspotX.HasValue && XmpValues.HotspotY.HasValue ? new Point(XmpValues.HotspotX.Value, XmpValues.HotspotY.Value) : null;

        internal XPixMap(string data)
        {
            RawData = data;
            XmpValues = FormatHelper.ParseValues(data);
            ColorChars = XpmHelper.AssignColors(XmpValues);
            CharData = XpmHelper.AssignPixels(XmpValues);
        }

        Color[,]? _colors;
        public Color[,] GetColors()
        {
            if (_colors != null)
                return _colors;

            _colors = new Color[XmpValues.Height, XmpValues.Width];
            for (var i = 0; i < XmpValues.Height; i++)
                for (var j = 0; j < XmpValues.Width; j++)
                    _colors[i, j] = ColorChars[CharData[i, j]];
            return _colors;
        }
    }
}
