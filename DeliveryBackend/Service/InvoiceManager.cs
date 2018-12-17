using DeliveryBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace DeliveryBackend.Service
{
    public class InvoiceManager
    {

        public bool Generate(Delivery delivery, string filepath)
        {
            PdfDocument pdf = new PdfDocument();
            PdfPage page = pdf.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height),XStringFormats.Center);
            const string filename = "HelloWorld.pdf";
            pdf.Save(filepath);
            Process.Start(filename);
            return true;
        }

        public void Generate(Delivery delivery, string filepath ,string email)
        {

        }
    }
}
