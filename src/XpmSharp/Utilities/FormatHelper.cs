using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace B2.XpmSharp.Utilities
{
    internal class FormatHelper
    {
        public static XmpValues ParseValues(string data)
        {
            var values = new XmpValues();

            values.Name = GetName(data);
            var dataLines = GetDataLines(data);

            try
            {
                try
                {
                    var header = TrimLine(GetHeader(dataLines));
                    var headerValues = header.Split(' ').Select(x => short.Parse(x)).ToArray();
                    values.Width = headerValues[0];
                    values.Height = headerValues[1];
                    values.ColorsCount = headerValues[2];
                    values.CharsPerPixle = (byte)headerValues[3];
                    if (headerValues.Length > 4)
                        values.HotspotX = headerValues[4];
                    if (headerValues.Length > 5)
                        values.HotspotX = headerValues[5];
                }
                catch (Exception ex) { throw new FormatException("There is a problem with header (values line for sizing and hotspot) in your XMP file.", ex); }

                values.Colors = GetColors(dataLines, values.ColorsCount).ToArray();
                values.Pixels = GetPixels(dataLines, values.ColorsCount).ToArray();
            }
            catch (Exception ex) { throw new FormatException("There is a problem with the values in your XPM file.", ex); }

            return values;
        }

        static string GetName(string data)
        {
            foreach (var line in data.SplitToLines())
                if (line.StartsWith("static"))
                    return GetNameFromDefinition(line);

            throw new FormatException("There is a problem with array definition in your XMP file.");
        }
        static string GetHeader(IEnumerable<string> data)
        {
            return data.FirstOrDefault();
        }
        static IEnumerable<string> GetDataLines(string data)
        {
            var blockStartIndex = data.IndexOf('{') + 1;
            var blockEndIndex = data.LastIndexOf('}');
            data = data.Substring(blockStartIndex, blockEndIndex - blockStartIndex);

            //Fix json tab limitation
            data = data.Replace("\t\t", "TABBED_TABBED")
                       .Replace(" \t", "SPACED_TABBED")
                       .Replace('\t', ' ')
                       .Replace("TABBED_TABBED", "\t ")
                       .Replace("SPACED_TABBED", "  ");

            if (blockStartIndex > blockEndIndex)
                throw new FormatException("Can not parse the data. It might be corrupted.");

            return JsonSerializer.Deserialize<IEnumerable<string>>($"[{data}]", new JsonSerializerOptions { ReadCommentHandling = JsonCommentHandling.Skip})!;
        }
        static IEnumerable<string> GetColors(IEnumerable<string> data, short colorsCount)
        {
            return data.Skip(1).Take(colorsCount);
        }
        static IEnumerable<string> GetPixels(IEnumerable<string> data, short colorsCount)
        {
            return data.Skip(1 + colorsCount);
        }

        public static string GetNameFromDefinition(string definition)
        {
            var starIndex = definition.IndexOf('*');
            return definition.Substring(starIndex + 1, definition.IndexOf('[') - starIndex - 1).Trim();
        }
        public static string TrimLine(string line)
        {
            return line.Trim('"').Trim().Replace(",", "");
        }
    }
}
