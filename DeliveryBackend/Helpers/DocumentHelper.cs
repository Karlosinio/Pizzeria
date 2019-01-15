using CartBackend.Common.DTO;
using DeliveryBackend.Model;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.XPath;
using User.Model;

namespace DeliveryBackend.Helpers
{
    class DocumentHelper
    {
        public Document document { get; set; }
        public TextFrame addressFrame { get; set; }
        public TextFrame userFrame { get; set; }


        public Table table { get; set; }

        public List<ProductDTO> list { get; set; }

        void DefineStyles()
        {
            // Get the predefined style Normal.
            Style style = this.document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            // Create a new style called Reference based on style Normal
            style = this.document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        void CreatePage()
        {
            // Each MigraDoc document needs at least one section.
            Section section = this.document.AddSection();
            // Create footer
            Paragraph paragraph = section.Footers.Primary.AddParagraph();
            paragraph.AddText("Pizzeria \"Dobra Pizza\"");
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Create the text frame for the address
            this.addressFrame = section.AddTextFrame();
            this.addressFrame.Height = "3.0cm";
            this.addressFrame.Width = "3.0cm";
            this.addressFrame.Left = ShapePosition.Right;
            this.addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            this.addressFrame.Top = "2.0cm";
            this.addressFrame.RelativeVertical = RelativeVertical.Page;
            //Create the text frame for user principles
            this.userFrame = section.AddTextFrame();
            this.userFrame.Height = "3.0cm";
            this.userFrame.Width = "7.0cm";
            this.userFrame.Left =  ShapePosition.Left;
            this.userFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            this.userFrame.Top = "5.0cm";
            this.userFrame.RelativeVertical = RelativeVertical.Page;


            // Put sender in address frame
            paragraph = this.addressFrame.AddParagraph($"Numer faktury:{DocumentData.delNb} \r\n\r\nPizzeria \"Dobra Pizza\"\r\nAdres:\r\n");
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 14;
            paragraph.Format.SpaceAfter = 3;

            //Put some user info
            paragraph = this.userFrame.AddParagraph($"Klient:\r\n {UserData.name}\r\n{UserData.email}\r\n{DocumentData.UserAdd.city} {DocumentData.UserAdd.postalCode}\r\n{DocumentData.UserAdd.street} {DocumentData.UserAdd.nip}");
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 14;
            paragraph.Format.SpaceAfter = 3;

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "8cm";
            paragraph.Style = "Reference";
            paragraph.AddFormattedText("Rachunek", TextFormat.Bold);

            // Create the item table
            this.table = section.AddTable();
            this.table.Style = "Table";
            //this.table.Borders.Color = TableBorder;
            this.table.Borders.Width = 0.25;
            this.table.Borders.Left.Width = 0.5;
            this.table.Borders.Right.Width = 0.5;
            this.table.Rows.LeftIndent = 0;

            // Before you can add a row, you must define the columns
            Column column = this.table.AddColumn("1cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = this.table.AddColumn("10cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("3cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            column = this.table.AddColumn("3.5cm");
            column.Format.Alignment = ParagraphAlignment.Right;
            // Create the header of the table
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Cells[0].AddParagraph("Nb.");
            row.Cells[0].Format.Font.Bold = false;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[1].AddParagraph("Nazwa");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[2].AddParagraph("Rozmiar");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[3].AddParagraph("Cena");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            table.SetEdge(0, 0, 4, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
        }
        void FillContent()
        {

            // Iterate the invoice items
            int count = 0; ;
            foreach(ProductDTO dt in DocumentData.products)
            {
                count++;
                Row row1 = table.AddRow();
                //row1.TopPadding = 1.5;
                row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                row1.Cells[0].AddParagraph(count.ToString());
                row1.Cells[1].AddParagraph(dt.Name);
                row1.Cells[2].AddParagraph(dt.ComponentToDisplay);
                row1.Cells[3].AddParagraph(dt.Price.ToString());
                table.SetEdge(0, this.table.Rows.Count - 1, 4, 1, Edge.Box, BorderStyle.Single, 0.75);

            }
            if (DocumentData.delivery ==3)
            {
                Row row2 = this.table.AddRow();
                row2.Borders.Visible = false;
                row2 = this.table.AddRow();
                row2.Cells[0].Borders.Visible = false;
                row2.Cells[0].AddParagraph("Dostawa");
                row2.Cells[0].Format.Font.Bold = true;
                row2.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                row2.Cells[0].MergeRight = 2;
                row2.Cells[3].AddParagraph("+4");
            }

            Row row = this.table.AddRow();
            row.Borders.Visible = false;
            row = this.table.AddRow();
            row.Cells[0].Borders.Visible = false;
            row.Cells[0].AddParagraph("Netto");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[0].MergeRight = 2;
            row.Cells[3].AddParagraph(string.Format("{0:N2}", DocumentData.PriceVat));
            row.Cells[0].AddParagraph("Brutto");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[0].MergeRight = 2;
            row.Cells[3].AddParagraph(string.Format("{0:N2}", DocumentData.Price));
        }

        public Document CreateDocument()
        {
            // Create a new MigraDoc document
            this.document = new Document();
            this.document.Info.Title = "A sample invoice";
            this.document.Info.Subject = "Demonstrates how to create an invoice.";
            this.document.Info.Author = "Stefan Lange";

            DefineStyles();

            CreatePage();

            FillContent();

            return this.document;
        }
    }
}
