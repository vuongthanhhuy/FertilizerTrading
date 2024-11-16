using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FertilizerTradingApp.Services
{
    public class PdfService
    {
        // Method to generate PDF from DataGridView
        public void ExportDataGridViewToPdf(DataGridView dgv, string filePath)
        {
            // Create a Document object
            Document pdfDoc = new Document(PageSize.A4);

            // Create a file stream to write the PDF document
            FileStream fs = new FileStream(filePath, FileMode.Create);

            // Create a PdfWriter instance to write content to the stream
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);

            // Open the document for writing
            pdfDoc.Open();

            // Add Title to the PDF
            pdfDoc.Add(new Paragraph("Data Exported from DataGridView"));

            // Add Table to the PDF
            PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);

            // Add column headers to the PDF table
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                pdfTable.AddCell(new Phrase(column.HeaderText));
            }

            // Add rows to the PDF table
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow) // Skip the new row if present
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable.AddCell(new Phrase(cell.Value.ToString()));
                    }
                }
            }

            // Add the table to the document
            pdfDoc.Add(pdfTable);

            // Close the document and the file stream
            pdfDoc.Close();
            fs.Close();

            MessageBox.Show("PDF Created Successfully!", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Example method to export multiple DataGridViews into a single PDF
        public void ExportMultipleDataGridsToPdf(List<DataGridView> dgvList, string filePath)
        {
            // Create a Document object
            Document pdfDoc = new Document(PageSize.A4);
            FileStream fs = new FileStream(filePath, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, fs);
            pdfDoc.Open();

            // Iterate through all DataGridViews
            foreach (var dgv in dgvList)
            {
                // Add a title for each table
                pdfDoc.Add(new Paragraph($"Data from DataGridView - {dgv.Name}"));

                PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);

                // Add headers to the table
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    pdfTable.AddCell(new Phrase(column.HeaderText));
                }

                // Add rows to the table
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(new Phrase(cell.Value.ToString()));
                        }
                    }
                }

                // Add the table to the document
                pdfDoc.Add(pdfTable);

                // Add a blank line between tables
                pdfDoc.Add(new Paragraph("\n"));
            }

            // Close the document and file stream
            pdfDoc.Close();
            fs.Close();
            MessageBox.Show("PDF Created Successfully!", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
