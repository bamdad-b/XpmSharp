using System.IO;

namespace B2.XpmSharp
{
    public partial class XPixMap
    {
        public static XPixMap FromContent(string data) => new XPixMap(data);

        public static XPixMap FromFile(string path)
        {
            using var stream = File.OpenRead(path);
            return FromStream(stream);
        }

        public static XPixMap FromStream(Stream stream)
        {
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            return new XPixMap(reader.ReadToEnd());
        }
    }
}
