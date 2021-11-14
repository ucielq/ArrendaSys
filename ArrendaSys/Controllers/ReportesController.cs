using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArrendaSysServicios;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ArrendaSys.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult ReporteResenias(int tipoCuenta,int id,string fechaDesde,string fechaHasta)
        {

            ServicioReportes servicio = new ServicioReportes();
            var result = servicio.prueba(tipoCuenta,id,fechaDesde,fechaHasta);

            
            MemoryStream ms = new MemoryStream();
            PdfWriter pw = new PdfWriter(ms);
            PdfDocument pdfDocument = new PdfDocument(pw);
            Document doc = new Document(pdfDocument, PageSize.LETTER);
            doc.SetMargins(75, 35, 70, 35);

            var pathLogo = Server.MapPath("~/assets/img/arrendasys_logo.png");
            Image img = new Image(ImageDataFactory.Create(pathLogo));

            pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler(img));
            pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FooterEventHandler());

            Table table = new Table(1).UseAllAvailableWidth();
            var nombre = "";
            if (result.Count > 0)
            {
                nombre = result[0].nombre;
            }
            Cell cell = new Cell().Add(new Paragraph("Reporte de Reseñas "+nombre).SetFontSize(14))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).
                SetBorder(Border.NO_BORDER);
            table.AddCell(cell);
            cell = new Cell().Add(new Paragraph("Reseñas de Usuarios"))
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).
                SetBorder(Border.NO_BORDER); 
            table.AddCell(cell);
            cell = new Cell().Add(new Paragraph())
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER).
                SetBorder(Border.NO_BORDER);
            table.AddCell(cell);

            doc.Add(table);

            Table _table = new Table(4).UseAllAvailableWidth();
            Cell _cell = new Cell(1,1).Add(new Paragraph("Fecha"));
            _table.AddHeaderCell(_cell);
            _cell = new Cell().Add(new Paragraph("Usuario"));
            _table.AddHeaderCell(_cell);
            _cell = new Cell().Add(new Paragraph("Descripción"));
            _table.AddHeaderCell(_cell);
            _cell = new Cell().Add(new Paragraph("Puntuación"));
            _table.AddHeaderCell(_cell);

            foreach(var item in result)
            {
                _cell = new Cell().Add(new Paragraph(item.fechaResenia.ToString().Split(' ')[0]));
                _table.AddCell(_cell);

                _cell = new Cell().Add(new Paragraph(item.autorResenia));
                _table.AddCell(_cell);
                if (item.descripcion == null)
                {
                    _cell = new Cell().Add(new Paragraph(""));
                }else _cell = new Cell().Add(new Paragraph(item.descripcion));
                _table.AddCell(_cell);
                if (item.puntuacionResenia <= (decimal)3)
                {
                    _cell = new Cell().Add(new Paragraph(item.puntuacionResenia.ToString()));
                    
                    _table.AddCell(_cell.SetFontColor(ColorConstants.RED));
                }
                else
                {
                    _cell = new Cell().Add(new Paragraph(item.puntuacionResenia.ToString()));
                    _table.AddCell(_cell);
                }
                
            }
            doc.Add(_table);
            doc.Close();

            byte[] bytesStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(bytesStream, 0, bytesStream.Length);
            ms.Position = 0;
            return new FileStreamResult(ms, "application/pdf");
        }
        public class HeaderEventHandler : IEventHandler
        {
            Image Img;
            public HeaderEventHandler(Image img)
            {
                Img = img;
            }
            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();

                Rectangle rootArea = new Rectangle(35, page.GetPageSize().GetTop() - 75, page.GetPageSize().GetWidth() - 70, 55);
                PdfCanvas canvas1 = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
                new Canvas(page, rootArea).Add(getTable(docEvent));

                
            }
            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] cellWidth = { 40f, 60f };
                Table tableEvent = new Table(UnitValue.CreatePercentArray(cellWidth)).UseAllAvailableWidth();

                Style styleCell = new Style()
                    .SetBorder(Border.NO_BORDER);

                Style styleText = new Style()
                    .SetTextAlignment(TextAlignment.RIGHT).SetFontSize(10f);

                Cell cell = new Cell().Add(Img.SetMaxWidth(120)).SetBorder(Border.NO_BORDER);

                tableEvent.AddCell(cell
                    .AddStyle(styleCell)
                    .SetTextAlignment(TextAlignment.LEFT));
                PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
                cell = new Cell()
                    .Add(new Paragraph("Reporte diario\n").SetFont(bold))
                    .Add(new Paragraph("Fecha de emisión: " + DateTime.Now.ToShortDateString()))
                    .AddStyle(styleText).AddStyle(styleCell)
                    .SetBorder(Border.NO_BORDER);

                tableEvent.AddCell(cell);
                return tableEvent;
            }

        }

        public class FooterEventHandler : IEventHandler
        {
            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();

                Rectangle rootArea = new Rectangle(36, 20, page.GetPageSize().GetWidth() - 70, 55);
                PdfCanvas canvas1 = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
                new Canvas(page, rootArea).Add(getTable(docEvent));
            }
            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] cellWidth = { 92f, 8f };
                Table tableEvent = new Table(UnitValue.CreatePercentArray(cellWidth)).UseAllAvailableWidth();

                PdfPage page = docEvent.GetPage();
                int pageNum = docEvent.GetDocument().GetPageNumber(page);

                Style styleCell = new Style()
                    .SetPadding(5)
                    .SetBorder(Border.NO_BORDER)
                    .SetBorderTop(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(33, 98, 30)),2));


                Cell cell = new Cell().Add(new Paragraph(DateTime.Now.ToLongDateString()));

                tableEvent.AddCell(cell
                    .AddStyle(styleCell)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontColor(ColorConstants.LIGHT_GRAY));
                cell = new Cell().Add(new Paragraph(pageNum.ToString()));
                cell.AddStyle(styleCell)
                    .SetBackgroundColor(Color.ConvertRgbToCmyk(new DeviceRgb(33, 98, 30)), 2)
                    .SetBorder(Border.NO_BORDER)
                    .SetBorderTop(new SolidBorder(Color.ConvertRgbToCmyk(new DeviceRgb(33, 98, 30)), 2))
                    .SetFontColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    ;
                    
              

                tableEvent.AddCell(cell);
                return tableEvent;
            }
        }
    }
}