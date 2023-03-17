using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace Employee_Report.Repository.Services
{
    public class ExportService
    {
        public MemoryStream CreatePdf()
        {
            //Initialize HTML to PDF converter.
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();
            //Set Blink viewport size.
            blinkConverterSettings.ViewPortSize = new Syncfusion.Drawing.Size(1280, 0);
            //Assign Blink converter settings to HTML converter.
            htmlConverter.ConverterSettings = blinkConverterSettings;
            //Convert URL to PDF document.
            //string baseUrl = @"" + Directory.GetCurrentDirectory() + "/wwwroot/css/";
            //string HTMLBody =  JS.InvokeAsync<string>("", PDFBody);
            //PdfDocument document = htmlConverter.Convert(HTMLBody, baseUrl);
            PdfDocument document = htmlConverter.Convert("https://localhost:7115/EmployeeReport");
            //Create memory stream.
            MemoryStream stream = new MemoryStream();
            //Save the document to memory stream.
            document.Save(stream);
            return stream;
        }
    }
}
