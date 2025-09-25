using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace EZResizeTool
{
    internal class Program
    {
        static int resizeWidth;
        static int resizeHeight;
        static string currentPath;
        static string readQuality;

        static void Main(string[] args)
        {
            currentPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (args.Length != 0)
            {
                // If there is an image as an argument, begin automatically processing them

                // Read the text from resize_info and resize the images to those numbers
                string[] readDimensions = File.ReadAllLines(currentPath.Substring(0, currentPath.IndexOf("EZResizeTool.exe")) + @"ResizeInfo\resize_info.txt");
                Console.WriteLine("Read dimensions: Width {0} - Height {1}", readDimensions[0], readDimensions[1]);
                readQuality = readDimensions[2];

                resizeWidth = Int16.Parse(readDimensions[0]);
                resizeHeight = Int16.Parse(readDimensions[1]);

                ResizeImages(args);

                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("There are no images attached", "Arguments Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
        }

        static void ResizeImages(string[] passedImages)
        {
            // Resize and output every image that is present
            for (int i = 0; i < passedImages.Length - 0; i++)
            {
                Console.WriteLine("Attempting to make pass {0} with {1}", i, passedImages[i].Substring(passedImages[0].LastIndexOf("\\", passedImages[0].Length - 1) + 1));
                Bitmap image = new Bitmap(passedImages[i]);
                var targetRect = new Rectangle(0, 0, resizeWidth, resizeHeight);
                var targetImage = new Bitmap(resizeWidth, resizeHeight);
                targetImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(targetImage))
                {
                    if (readQuality == "HIGH")
                    {
                        graphics.CompositingMode = CompositingMode.SourceCopy;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    }
                    else if (readQuality == "LOW")
                    {
                        graphics.CompositingMode = 0;
                        graphics.CompositingQuality = 0;
                        graphics.InterpolationMode = 0;
                        graphics.SmoothingMode = 0;
                        graphics.PixelOffsetMode = 0;
                    }

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, targetRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                // Save the image as a new image where the exe is located
                targetImage.Save(currentPath.Substring(0, currentPath.IndexOf("EZResizeTool.exe")) + @"Images\" + passedImages[i].Substring(passedImages[0].LastIndexOf("\\", passedImages[0].Length - 1)));
                Console.WriteLine("Pass successful!\n");
            }
        }
    }
}
