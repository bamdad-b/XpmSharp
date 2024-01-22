This library loads **XPM v3** files into `XPixMap` objects for reading purposes (writing XPM files might be added later). Currently there are three ways to load a XPM file:
- Call `XPixMap.FromContent(string content)` which takes the content of a XPM file.
- Call `XPixMap.FromFile(string path)` which takes the path to your XPM file.
- Call `XPixMap.FromStream(Stream stream)` which takes a readable stream, setting its position to zero. (Be sure to dispose the stream after calling the method.)

The `XPixMap` then can be used to get meaningful info about the XPM, like `Width`, `Height`, `Hotspot` (if present) and the pixel matrix by calling `GetColors()` returning a `Color[,]`.  
Additionally, the Extensions method `GetBitmap()` can be used to convert the XPM to a `System.Drawing.Common.Bitmap` object.
```cs
var xpm = XPixMap.FromFile(@"C:\path\to\image.xpm");
var bmp = xpm.GetBitmap();
//Edit the image
bmp.SetPixel(0, 0, Color.Black);
bmp.SetPixel(0, 1, Color.White);
//Save it
bmp.Save(@"C:\path\to\image.png", System.Drawing.Imaging.ImageFormat.Png);
```
There is also a `DrawOn()` extension method which allows you to draw the XPM on a surface. (For example, a windows form handle)
```cs
using var stream = openFileDialog.OpenFile();
var xpm = XPixMap.FromStream(stream);
xpm.DrawOn(Handle);
```
![image](https://github.com/bamdad-b/XpmSharp/assets/33001312/19ff90e4-ea91-4d52-91b9-2545f5e80b5d)

---
The library is on .netstandard so it's usable on .net and .net Framework. However I have not tested it on linux and it might not work as expected.
