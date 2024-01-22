namespace B2.XpmSharp
{
    internal struct XmpValues
    {
        public string Name { get; internal set; }
        public short Width { get; set; }
        public short Height { get; set; }
        public short ColorsCount { get; set; }
        public byte CharsPerPixle { get; set; }
        public short? HotspotX { get; set; }
        public short? HotspotY { get; set; }
        public string[] Colors { get; internal set; }
        public string[] Pixels { get; internal set; }
    }
}
