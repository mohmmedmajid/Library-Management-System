using LibrarySystem.WinForms.Models.Accounting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Helpers
{
    public static class JournalEntryPrinter
    {
        private static JournalEntry _entry;
        private static List<JournalEntryDetail> _details;
        private static int _rowIndex;
        private static decimal _totalDebit;
        private static decimal _totalCredit;

        private static string _storeName = "Library System";
        private static string _storeAddress = "Amman - Jordan";
        private static string _storePhone = "+962 7 0000 0000";

        private static Font _fontHeader = new Font("Segoe UI", 16f, FontStyle.Bold);
        private static Font _fontSubHeader = new Font("Segoe UI", 9f);
        private static Font _fontBold = new Font("Segoe UI", 10f, FontStyle.Bold);
        private static Font _fontNormal = new Font("Segoe UI", 9.5f);
        private static Font _fontSmall = new Font("Segoe UI", 8f);
        private static Font _fontTableHeader = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        private static Font _fontTotal = new Font("Segoe UI", 13f, FontStyle.Bold);

        public static void Print(JournalEntry entry, List<JournalEntryDetail> details, bool showPreview = true)
        {
            _entry = entry;
            _details = details ?? new List<JournalEntryDetail>();

            _totalDebit = 0;
            _totalCredit = 0;
            foreach (var d in _details)
            {
                if (d.IsDebit) _totalDebit += d.Amount;
                else _totalCredit += d.Amount;
            }

            var doc = new PrintDocument();
            doc.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            doc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            doc.BeginPrint += (s, e) => { _rowIndex = 0; };
            doc.PrintPage += Doc_PrintPage;

            if (showPreview)
            {
                var preview = new PrintPreviewDialog
                {
                    Document = doc,
                    Width = 900,
                    Height = 750,
                    StartPosition = FormStartPosition.CenterScreen
                };
                preview.ShowDialog();
            }
            else
            {
                doc.Print();
            }
        }

        private static void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            var bounds = e.MarginBounds;
            int x = bounds.Left;
            int y = bounds.Top;
            int width = bounds.Width;

            g.DrawString(_storeName, _fontHeader, Brushes.Black, x, y);
            y += 30;
            g.DrawString(_storeAddress + "   |   " + _storePhone, _fontSubHeader, Brushes.Gray, x, y);
            y += 24;

            g.DrawLine(new Pen(Color.FromArgb(22, 32, 50), 2), x, y, x + width, y);
            y += 16;

            g.DrawString("JOURNAL ENTRY", _fontBold, Brushes.Black, x, y);
            string entryNum = "Entry #: " + _entry.JournalEntryNumber;
            var entryNumSize = g.MeasureString(entryNum, _fontBold);
            g.DrawString(entryNum, _fontBold, Brushes.Black, x + width - entryNumSize.Width, y);
            y += 22;

            string dateStr = "Date: " + _entry.EntryDate.ToString("yyyy-MM-dd");
            var dateSize = g.MeasureString(dateStr, _fontNormal);
            g.DrawString(dateStr, _fontNormal, Brushes.Black, x + width - dateSize.Width, y);

            int colY = y;
            g.DrawString("Type: " + _entry.EntryType, _fontNormal, Brushes.Black, x, colY); colY += 18;
            g.DrawString("Status: " + _entry.Status, _fontNormal, Brushes.Black, x, colY); colY += 18;
            g.DrawString("Cost Center: " + _entry.CostCenterName, _fontNormal, Brushes.Black, x, colY); colY += 18;

            if (!string.IsNullOrWhiteSpace(_entry.Description))
            {
                g.DrawString("Description: " + _entry.Description, _fontNormal, Brushes.Black, x, colY);
                colY += 18;
            }

            y = colY + 14;
            g.DrawLine(Pens.LightGray, x, y, x + width, y);
            y += 14;

            float[] colWidths = { 0.10f, 0.20f, 0.35f, 0.175f, 0.175f };
            string[] headers = { "#", "Account Code", "Account Name", "Debit", "Credit" };

            int tableTop = y;
            g.FillRectangle(new SolidBrush(Color.FromArgb(22, 32, 50)), x, tableTop - 2, width, 22);
            int colX = x;
            for (int i = 0; i < headers.Length; i++)
            {
                int colW = (int)(width * colWidths[i]);
                var format = (i == 0 || i == 1 || i == 2) ? new StringFormat() : new StringFormat { Alignment = StringAlignment.Far };
                g.DrawString(headers[i], _fontTableHeader, Brushes.White, new RectangleF(colX + 4, tableTop, colW - 8, 20), format);
                colX += colW;
            }
            y = tableTop + 26;

            bool alternate = false;
            while (_rowIndex < _details.Count)
            {
                var d = _details[_rowIndex];

                if (y + 24 > bounds.Bottom - 140)
                {
                    e.HasMorePages = true;
                    return;
                }

                if (alternate)
                    g.FillRectangle(new SolidBrush(Color.FromArgb(245, 247, 250)), x, y - 2, width, 22);
                alternate = !alternate;

                colX = x;
                DrawCell(g, d.LineNumber.ToString(), colX, y, (int)(width * colWidths[0]), false);
                colX += (int)(width * colWidths[0]);
                DrawCell(g, d.AccountCode, colX, y, (int)(width * colWidths[1]), false);
                colX += (int)(width * colWidths[1]);
                DrawCell(g, d.AccountName, colX, y, (int)(width * colWidths[2]), false);
                colX += (int)(width * colWidths[2]);
                DrawCell(g, d.IsDebit ? d.Amount.ToString("F3") : "-", colX, y, (int)(width * colWidths[3]), true);
                colX += (int)(width * colWidths[3]);
                DrawCell(g, !d.IsDebit ? d.Amount.ToString("F3") : "-", colX, y, (int)(width * colWidths[4]), true);

                y += 24;
                _rowIndex++;
            }

            g.DrawLine(Pens.LightGray, x, y, x + width, y);
            y += 16;

            int totalsX = x + width - 260;
            int totalsW = 260;

            DrawTotalRow(g, ref y, totalsX, totalsW, "Total Debit:", _totalDebit, _fontNormal);
            DrawTotalRow(g, ref y, totalsX, totalsW, "Total Credit:", _totalCredit, _fontNormal);

            y += 4;
            g.DrawLine(Pens.Black, totalsX, y, totalsX + totalsW, y);
            y += 6;

            decimal diff = Math.Abs(_totalDebit - _totalCredit);
            if (diff == 0)
                DrawTotalRow(g, ref y, totalsX, totalsW, "Balanced:", 0, _fontTotal, Brushes.Green);
            else
                DrawTotalRow(g, ref y, totalsX, totalsW, "Difference:", diff, _fontTotal, Brushes.Red);

            int footerY = bounds.Bottom - 30;
            g.DrawLine(Pens.LightGray, x, footerY, x + width, footerY);
            g.DrawString("Printed: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"), _fontSmall, Brushes.Gray,
                new RectangleF(x, footerY + 4, width, 20), new StringFormat { Alignment = StringAlignment.Center });

            e.HasMorePages = false;
        }

        private static void DrawCell(Graphics g, string text, int x, int y, int width, bool right)
        {
            var format = right ? new StringFormat { Alignment = StringAlignment.Far } : new StringFormat();
            g.DrawString(text, _fontNormal, Brushes.Black, new RectangleF(x + 4, y, width - 8, 20), format);
        }

        private static void DrawTotalRow(Graphics g, ref int y, int x, int width, string label, decimal value, Font font, Brush valueBrush = null)
        {
            if (valueBrush == null) valueBrush = Brushes.Black;
            g.DrawString(label, font, Brushes.Black, new RectangleF(x, y, width / 2, 22));
            g.DrawString(value.ToString("F3"), font, valueBrush,
                new RectangleF(x + width / 2, y, width / 2, 22), new StringFormat { Alignment = StringAlignment.Far });
            y += (int)font.GetHeight() + 6;
        }
    }
}