using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ZerasTools.Services
{
    public class PngJpgToIco
    {
        public void Convert(string inputPath, string outputPath)
        {
            using (Bitmap original = new Bitmap(inputPath))
            {
                // Resize to 256x256 for icon
                using (Bitmap resized = new Bitmap(original, new System.Drawing.Size(256, 256)))
                {
                    // Save to .ico using Icon from bitmap handle
                    using (MemoryStream ms = new MemoryStream())
                    {
                        resized.Save(ms, ImageFormat.Png); // Save as PNG in memory
                        ms.Seek(0, SeekOrigin.Begin);

                        using (FileStream fs = new FileStream(outputPath, FileMode.Create))
                        {
                            WriteIco(fs, resized);
                        }
                    }
                }
            }
        }

        private void WriteIco(Stream output, Bitmap bmp)
        {
            // ICO header
            BinaryWriter bw = new BinaryWriter(output);
            bw.Write((short)0);   // reserved
            bw.Write((short)1);   // image type (1 = icon)
            bw.Write((short)1);   // number of images

            // image entry
            bw.Write((byte)bmp.Width);
            bw.Write((byte)bmp.Height);
            bw.Write((byte)0);  // colors
            bw.Write((byte)0);  // reserved
            bw.Write((short)1); // planes
            bw.Write((short)32);// bit count

            // convert bitmap to PNG in memory
            using (MemoryStream pngStream = new MemoryStream())
            {
                bmp.Save(pngStream, ImageFormat.Png);
                byte[] pngData = pngStream.ToArray();

                bw.Write(pngData.Length); // size of image data
                bw.Write(6 + 16);         // offset of image data (header + entry size)

                bw.Write(pngData);        // image data
            }

            bw.Flush();
        }
    }
}
