using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace JATotalservice.WPF.Helpers
{
    class PDFHelper
    {

        public void CreatePDF()
        {
            Console.WriteLine("-----------------------Hej med dig, jeg er mega sej-----------------");
            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 42, 35);
            PdfWriter w = PdfWriter.GetInstance(doc, new FileStream("File.pdf", FileMode.Create));

            iTextSharp.text.Paragraph p = new iTextSharp.text.Paragraph("Det her pdf generering virker bare");
            doc.Open();
            doc.AddAuthor("Dennis");
            doc.AddCreator("Visual Studio");
            doc.AddSubject("PDF File");
            doc.AddTitle("Title");
            doc.Add(p);
            doc.Add(p);
            doc.Close();
        }
    }
}
