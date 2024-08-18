/*
8.Create a Class Hierarchy with Interfaces and Method Implementation
   - Task: Create an interface `IExportable` with a method `Export()`. Create a base class `Document` that implements `IExportable` and has a method `Save()`. Derive classes `PDFDocument` and `WordDocument` from `Document`.
   - Requirements:
     - `PDFDocument` should implement `Export()` to export as PDF and `Save()` to save the document.
     - `WordDocument` should implement `Export()` to export as Word format and `Save()` to save the document.
   - Example:
     ```csharp
     Document pdfDoc = new PDFDocument();
pdfDoc.Save();
pdfDoc.Export();

Document wordDoc = new WordDocument();
wordDoc.Save();
wordDoc.Export();
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Export
{
    interface IExportable
    {
        void Export();
    }

    public abstract class Document : IExportable
    {
        public abstract void Save();
        public abstract void Export();
    } 

    public class PdfDocument :Document
    {
        public override void Save()
        {
            Console.WriteLine("PDF is saved successfully....");
        }
        public override void Export()
        {
            Console.WriteLine("PDF is Exported successfully....");
        }
    }
    public class WordDocument : Document
    {
        public override void Save()
        {
            Console.WriteLine("WORD  is saved successfully....");
        }
        public override void Export()
        {
            Console.WriteLine("WORD is Exported successfully....");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Document pdf = new PdfDocument();
            pdf.Save();
            pdf.Export();

            Document word = new WordDocument();
            word.Save();
            word.Export();
        }
    }
}
