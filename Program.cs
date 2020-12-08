using Aspose.Svg;
using Aspose.Svg.Drawing;
using Aspose.Svg.Rendering;
using Aspose.Svg.Rendering.Pdf;
using Aspose.Svg.Rendering.Xps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGtoPDFxps
{
    class Program
    {
        static String dataDir = Path.GetFullPath(GetDataDir_Data());

        static void Main(string[] args)
        {
            // Convert SVG to PDF file
            ConvertSVGtoPDF();

            // Convert SVG to XPS file
            ConvertSVGtoXPS();

            Console.WriteLine("SVG to PDF and XPS Conversion Examples Executed Successfully!");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }

        static void ConvertSVGtoPDF()
        {
            using (var document = new SVGDocument(Path.Combine(dataDir, "smiley.svg")))
            {
                var options = new PdfRenderingOptions()
                {
                    PageSetup =
                    {
                        Sizing = SizingType.FitContent
                    }
                };
                using (var device = new PdfDevice(options, dataDir + "smiley_out.pdf"))
                {
                    document.RenderTo(device);
                }
            }
        }

        static void ConvertSVGtoXPS()
        {
            // Load input SVG file
            using (var document = new SVGDocument(Path.Combine(dataDir, "smiley.svg")))
            {
                // Specify XPSRenderingOptions
                var options = new XpsRenderingOptions()
                {
                    // Set PDF page size, margins, etc.
                    PageSetup =
                    {
                        AnyPage = new Page(new Size(500, 500))
                    }
                };
                using (var device = new XpsDevice(options, dataDir + "smiley_out.xps"))
                {
                    // Render SVG to XPS
                    document.RenderTo(device);
                }
            }
        }


        public static string GetDataDir_Data()
        {
            var parent = Directory.GetParent(Directory.GetCurrentDirectory());
            string startDirectory = null;
            if (parent != null)
            {
                var directoryInfo = parent.Parent;
                if (directoryInfo != null)
                {
                    startDirectory = directoryInfo.FullName;
                }
            }
            else
            {
                startDirectory = parent.FullName;
            }
            return Path.Combine(startDirectory, "Data\\");
        }

    }
}