using System.Collections.Generic;
using System.IO;
using System.Linq;

using iTextSharp.text;
using iTextSharp.text.pdf;

using MobiStore.Data;
using MobiStore.Data.Contracts;

using MobiStore.Utils.Models;
using MobiStore.Utils.Contracts;

namespace MobiStore.Utils.Reporters
{
    public class PdfReporter : IPdfReporter
    {
        private readonly ISqlServerDb database;

        public PdfReporter(ISqlServerDb database)
        {
            this.database = database;
        }

        public PdfReporter()
            : this(new SqlServerDb())
        {
        }

        public void CreateReport(string outputFilePath)
        {
            int marginLeft = 10;
            int marginRight = 10;
            int marginTop = 40;
            int marginBottom = 35;
            var document = new Document(PageSize.LETTER, marginLeft, marginRight, marginTop, marginBottom);
            var writer = PdfWriter.GetInstance(document, new FileStream(outputFilePath, FileMode.Create));
            var reports = this.GetReportData();

            document.Open();
            this.CreateDocumentHeader(document);
            this.CreateBody(document, reports);
            document.Close();
        }

        private void CreateDocumentHeader(Document document)
        {
            string header = "MobiStore Sales Report";
            PdfPTable titleHeader = new PdfPTable(numColumns: 1);
            var phrase = new Phrase();
            phrase.Add(new Chunk(header, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, size: 14)));

            PdfPCell cellHeader = new PdfPCell(phrase);
            cellHeader.HorizontalAlignment = 1;
            cellHeader.PaddingBottom = 15;
            cellHeader.PaddingTop = 10;
            titleHeader.AddCell(cellHeader);
            document.Add(titleHeader);
        }

        private void CreateBody(Document document, IEnumerable<PdfReport> reports)
        {
            foreach (var report in reports)
            {
                this.CreateTableHeader(document);
                this.CreateReportTable(report, document);
            }
        }

        private void CreateReportTable(PdfReport report, Document document)
        {
            var table = new PdfPTable(numColumns: 6);

            foreach (var sale in report.Sales)
            {
                table.AddCell(sale.Shop);
                table.AddCell(sale.Product);
                table.AddCell(sale.Employee);
                table.AddCell(sale.Quantity.ToString());
                table.AddCell(sale.Currency);
                table.AddCell(sale.TotalValue.ToString());
            }

            this.CreateTableFooter(document);
            document.Add(table);
        }

        private void CreateTableHeader(Document document)
        {
            var tableHeader = new PdfPTable(numColumns: 6);

            var shopCell = new PdfPCell(this.MakeTextBold("Shop"));
            var productCell = new PdfPCell(this.MakeTextBold("Product"));
            var employeeCell = new PdfPCell(this.MakeTextBold("Employee"));
            var quantityCell = new PdfPCell(this.MakeTextBold("Quantity"));
            var currencyCell = new PdfPCell(this.MakeTextBold("Currency"));
            var totalValueCell = new PdfPCell(this.MakeTextBold("Total Value"));

            tableHeader.AddCell(shopCell);
            tableHeader.AddCell(productCell);
            tableHeader.AddCell(employeeCell);
            tableHeader.AddCell(quantityCell);
            tableHeader.AddCell(currencyCell);
            tableHeader.AddCell(totalValueCell);

            document.Add(tableHeader);
        }

        private void CreateTableFooter(Document document)
        {
            var tableFooter = new PdfPTable(6);
            var cell = new PdfPCell(this.MakeTextBold(string.Empty));

            cell.Colspan = 6;
            tableFooter.AddCell(cell);
            document.Add(tableFooter);
        }

        private Phrase MakeTextBold(string text)
        {
            var phrase = new Phrase();
            phrase.Add(new Chunk(text, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, size: 12)));

            return phrase;
        }

        private IEnumerable<PdfReport> GetReportData()
        {
            var data = this.database
                .SalesReports
                .All()
                .Select(r => new PdfReport
                {
                    Sales = r.Sales.Select(s => new PdfReportSale
                    {
                        Currency = s.Currency.ToString(),
                        Employee = s.Employee.Name,
                        Product = s.Product.Model,
                        Quantity = s.Quantity,
                        Shop = s.Shop.Name,
                        TotalValue = s.TotalValue
                    })
                    .ToList()
                })
                .ToList();

            return data;
        }
    }
}