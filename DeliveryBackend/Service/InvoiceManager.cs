using DeliveryBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DeliveryBackend.Helpers;
using MigraDoc.Rendering;
using CartBackend.Common.DTO;
using System.Net;
using System.IO;

namespace DeliveryBackend.Service
{
    public class InvoiceManager
    {

        public bool Create(int delivery_id, string invoice_name)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://127.0.0.1:8080/server/api/invoices/");
            request.Method = "POST";
            request.ContentType = "application/json";

            string nw = $"{{\"name\": {invoice_name},\"delivery\": {{\"id\": {delivery_id}}}}}";

            //Delivery del = new Delivery(address, option, order);

            //var json = JsonConvert.SerializeObject(del);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(nw);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
            }
            return false;
        }
        public void Generate(List<ProductDTO> dw, string filepath, int delivery_id1, string invoice_name1, User.Model.User user)
        {

            Create(delivery_id1, invoice_name1);

            DocumentHelper helper = new DocumentHelper();
            // Create a renderer for the MigraDoc document.
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();

            // Associate the MigraDoc document with a renderer
            pdfRenderer.Document = helper.CreateDocument(dw, user, invoice_name1);

            // Layout and render document to PDF
            pdfRenderer.RenderDocument();

            // Save the document...
            pdfRenderer.PdfDocument.Save(filepath);
            Process.Start(filepath);
            //return true;
        }
        //Genera and send e-mail
        public void GenerateAndSend(List<ProductDTO> dw /*Delivery delivery*/, string filepath ,string email,int delivery_id1, string invoice_name1, User.Model.User user)
        {
            Create(delivery_id1, invoice_name1);

            DocumentHelper helper = new DocumentHelper();
            MailHelper mail = new MailHelper();

            // Create a renderer for the MigraDoc document.
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer();

            // Associate the MigraDoc document with a renderer
            pdfRenderer.Document = helper.CreateDocument(dw,user,invoice_name1);

            // Layout and render document to PDF
            pdfRenderer.RenderDocument();

            // Save the document...
            pdfRenderer.PdfDocument.Save(filepath);

            mail.SendMail(email, filepath);
        }
    }
}
