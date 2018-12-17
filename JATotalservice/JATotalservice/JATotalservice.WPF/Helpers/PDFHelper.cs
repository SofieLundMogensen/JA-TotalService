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
        
        public void CreatePDF(ModelLayer.Task task)
        {
            if (task != null)
            {
                Document doc = new Document(PageSize.A4, 20, 20, 42, 35);
                PdfWriter w = PdfWriter.GetInstance(doc, new FileStream(task.name + ".pdf", FileMode.Create));
                
                doc.Open();
                doc.AddAuthor("?");
                doc.AddCreator("Visual Studio");
                doc.AddSubject("PDF File");
                doc.AddTitle(task.name);

                Paragraph name = new Paragraph("Opgave: " + task.name);
                doc.Add(name);
                doc.Add(Chunk.NEWLINE);

                Paragraph isComplete = new Paragraph("Færdig: " + task.isComplete);
                doc.Add(isComplete);
                doc.Add(Chunk.NEWLINE);

                if (task.timeRegistrations != null && task.timeRegistrations.Count > 0)
                {
                    foreach (var item in task.timeRegistrations)
                    {
                        Paragraph p = new Paragraph("Starttid: " + item.startTime.ToString() + "   Sluttid: " + item.endTime.ToString());
                        doc.Add(p);
                    }
                    doc.Add(Chunk.NEWLINE);
                }
                
                if (task.materials != null && task.materials.Count > 0)
                {
                    foreach (var item in task.materials)
                    {
                        Paragraph p = new Paragraph("Type: " + item.Item1.name + "   antal: " + item.Item2);
                        doc.Add(p);
                    }
                }
                
                doc.Close();
            }
            
        }
    }
}
