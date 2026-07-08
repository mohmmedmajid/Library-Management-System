using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Helpers
{
    public class PrintInvoiceLine
    {
        public string ProductName;
        public int Quantity;
        public decimal UnitPrice;
        public decimal DiscountAmount;
        public decimal Total;
    }

    public class PrintInvoiceData
    {
        public string InvoiceNumber;
        public DateTime InvoiceDate;
        public string CustomerName;
        public string PaymentType;
        public string PaymentMethod;
        public string SalesRepName;
        public string CashierName;
        public string Notes;

        public List<PrintInvoiceLine> Lines = new List<PrintInvoiceLine>();

        public decimal SubTotal;
        public decimal DiscountAmount;
        public decimal TaxAmount;
        public decimal TaxPercent;
        public decimal TotalAmount;
        public decimal PaidAmount;
        public decimal RemainingAmount;

        public int TotalDays;
        public DateTime ReturnDate;

        public string StoreName = "Library System";
        public string StoreAddress = "Amman - Jordan";
        public string StorePhone = "+962 7 0000 0000";
    }

    public static class InvoicePrinter
    {
        private static PrintInvoiceData _data;
        private static int _rowIndex;
        private static bool _thermalMode = false;

        private static Font _fontHeader = new Font("Segoe UI", 16f, FontStyle.Bold);
        private static Font _fontSubHeader = new Font("Segoe UI", 9f);
        private static Font _fontBold = new Font("Segoe UI", 10f, FontStyle.Bold);
        private static Font _fontNormal = new Font("Segoe UI", 9.5f);
        private static Font _fontSmall = new Font("Segoe UI", 8f);
        private static Font _fontTableHeader = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        private static Font _fontTotal = new Font("Segoe UI", 13f, FontStyle.Bold);

        private static Font _thFontHeader = new Font("Segoe UI", 11f, FontStyle.Bold);
        private static Font _thFontSub = new Font("Segoe UI", 7f);
        private static Font _thFontBold = new Font("Segoe UI", 8f, FontStyle.Bold);
        private static Font _thFontNormal = new Font("Segoe UI", 7.5f);
        private static Font _thFontSmall = new Font("Segoe UI", 6.5f);
        private static Font _thFontTotal = new Font("Segoe UI", 9f, FontStyle.Bold);

        public static void PrintInvoice(PrintInvoiceData data, bool showPreview = true)
        {
            _data = data;
            _thermalMode = false;

            var doc = new PrintDocument();
            doc.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
            doc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            doc.BeginPrint += (s, e) => { _rowIndex = 0; };
            doc.PrintPage += Doc_PrintPage;

            RunDoc(doc, showPreview);
        }

        public static void PrintInvoiceThermal(PrintInvoiceData data, bool showPreview = true, int paperWidthMM = 80)
        {
            _data = data;
            _thermalMode = true;

            int widthHundredths = (int)(paperWidthMM / 25.4 * 100);
            int estimatedHeight = EstimateThermalHeight();

            var doc = new PrintDocument();
            doc.DefaultPageSettings.Margins = new Margins(8, 8, 8, 8);
            doc.DefaultPageSettings.PaperSize = new PaperSize("Thermal", widthHundredths, estimatedHeight);
            doc.BeginPrint += (s, e) => { _rowIndex = 0; };
            doc.PrintPage += Doc_PrintPageThermal;

            RunDoc(doc, showPreview);
        }

        private static void RunDoc(PrintDocument doc, bool showPreview)
        {
            if (showPreview)
            {
                var preview = new PrintPreviewDialog
                {
                    Document = doc,
                    Width = 500,
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

        private static int EstimateThermalHeight()
        {
            int baseHeight = 420;
            int perLine = 20;
            int notesExtra = string.IsNullOrWhiteSpace(_data.Notes) ? 0 : 40;
            int borrowExtra = _data.PaymentType == "Borrow" ? 24 : 0;
            int total = baseHeight + (_data.Lines.Count * perLine) + notesExtra + borrowExtra;
            return Math.Max(total, 500);
        }

        private static void Doc_PrintPageThermal(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            var bounds = e.MarginBounds;
            int x = bounds.Left;
            int y = bounds.Top;
            int width = bounds.Width;

            var center = new StringFormat { Alignment = StringAlignment.Center };
            var right = new StringFormat { Alignment = StringAlignment.Far };

            g.DrawString(_data.StoreName, _thFontHeader, Brushes.Black, new RectangleF(x, y, width, 18), center);
            y += 18;
            g.DrawString(_data.StoreAddress, _thFontSub, Brushes.Black, new RectangleF(x, y, width, 12), center);
            y += 12;
            g.DrawString(_data.StorePhone, _thFontSub, Brushes.Black, new RectangleF(x, y, width, 12), center);
            y += 16;

            DrawDashedLine(g, x, y, x + width);
            y += 8;

            g.DrawString("SALE INVOICE", _thFontBold, Brushes.Black, new RectangleF(x, y, width, 14), center);
            y += 16;

            g.DrawString("Invoice #: " + _data.InvoiceNumber, _thFontNormal, Brushes.Black, x, y); y += 12;
            g.DrawString("Date: " + _data.InvoiceDate.ToString("yyyy-MM-dd HH:mm"), _thFontNormal, Brushes.Black, x, y); y += 12;
            g.DrawString("Customer: " + _data.CustomerName, _thFontNormal, Brushes.Black, x, y); y += 12;
            g.DrawString("Payment: " + _data.PaymentType + " / " + _data.PaymentMethod, _thFontNormal, Brushes.Black, x, y); y += 12;

            if (!string.IsNullOrWhiteSpace(_data.SalesRepName) && _data.SalesRepName != "-- None --")
            {
                g.DrawString("Rep: " + _data.SalesRepName, _thFontNormal, Brushes.Black, x, y);
                y += 12;
            }

            if (_data.PaymentType == "Borrow")
            {
                g.DrawString("Borrow Days: " + _data.TotalDays, _thFontNormal, Brushes.Black, x, y); y += 12;
                g.DrawString("Return Date: " + _data.ReturnDate.ToString("yyyy-MM-dd"), _thFontNormal, Brushes.Black, x, y); y += 12;
            }

            y += 4;
            DrawDashedLine(g, x, y, x + width);
            y += 8;

            g.DrawString("Item", _thFontBold, Brushes.Black, x, y);
            g.DrawString("Qty x Price", _thFontBold, Brushes.Black, new RectangleF(x, y, width, 12), right);
            y += 14;

            foreach (var line in _data.Lines)
            {
                g.DrawString(line.ProductName, _thFontNormal, Brushes.Black, new RectangleF(x, y, width, 12));
                y += 12;

                string qtyLine = line.Quantity + " x " + line.UnitPrice.ToString("F3");
                if (line.DiscountAmount > 0)
                    qtyLine += "  -" + line.DiscountAmount.ToString("F3");
                g.DrawString(qtyLine, _thFontSmall, Brushes.Gray, x, y);
                g.DrawString(line.Total.ToString("F3"), _thFontNormal, Brushes.Black, new RectangleF(x, y, width, 12), right);
                y += 14;
            }

            y += 4;
            DrawDashedLine(g, x, y, x + width);
            y += 10;

            DrawThermalTotalRow(g, ref y, x, width, "SubTotal:", _data.SubTotal, _thFontNormal);
            DrawThermalTotalRow(g, ref y, x, width, "Discount:", _data.DiscountAmount, _thFontNormal);
            DrawThermalTotalRow(g, ref y, x, width, "Tax (" + _data.TaxPercent.ToString("F0") + "%):", _data.TaxAmount, _thFontNormal);

            y += 2;
            DrawDashedLine(g, x, y, x + width);
            y += 8;

            DrawThermalTotalRow(g, ref y, x, width, "TOTAL:", _data.TotalAmount, _thFontTotal);
            y += 4;
            DrawThermalTotalRow(g, ref y, x, width, "Paid:", _data.PaidAmount, _thFontNormal);

            if (_data.RemainingAmount > 0)
                DrawThermalTotalRow(g, ref y, x, width, "Remaining:", _data.RemainingAmount, _thFontBold, Brushes.Red);
            else if (_data.RemainingAmount < 0)
                DrawThermalTotalRow(g, ref y, x, width, "Change:", Math.Abs(_data.RemainingAmount), _thFontBold, Brushes.Black);
            else
                DrawThermalTotalRow(g, ref y, x, width, "Remaining:", 0, _thFontBold, Brushes.Black);

            if (!string.IsNullOrWhiteSpace(_data.Notes))
            {
                y += 8;
                g.DrawString("Notes: " + _data.Notes, _thFontSmall, Brushes.Gray, new RectangleF(x, y, width, 30));
                y += 24;
            }

            y += 10;
            DrawDashedLine(g, x, y, x + width);
            y += 8;
            g.DrawString("Thank you for your business!", _thFontSmall, Brushes.Black, new RectangleF(x, y, width, 14), center);

            e.HasMorePages = false;
        }

        private static void DrawDashedLine(Graphics g, int x1, int y, int x2)
        {
            var pen = new Pen(Color.Black, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            g.DrawLine(pen, x1, y, x2, y);
        }

        private static void DrawThermalTotalRow(Graphics g, ref int y, int x, int width, string label, decimal value, Font font, Brush valueBrush = null)
        {
            if (valueBrush == null) valueBrush = Brushes.Black;
            g.DrawString(label, font, Brushes.Black, x, y);
            g.DrawString(value.ToString("F3"), font, valueBrush, new RectangleF(x, y, width, 14), new StringFormat { Alignment = StringAlignment.Far });
            y += (int)font.GetHeight() + 4;
        }

        private static void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            var bounds = e.MarginBounds;
            int x = bounds.Left;
            int y = bounds.Top;
            int width = bounds.Width;

            g.DrawString(_data.StoreName, _fontHeader, Brushes.Black, x, y);
            y += 30;
            g.DrawString(_data.StoreAddress + "   |   " + _data.StorePhone, _fontSubHeader, Brushes.Gray, x, y);
            y += 24;

            g.DrawLine(new Pen(Color.FromArgb(22, 32, 50), 2), x, y, x + width, y);
            y += 16;

            g.DrawString("SALE INVOICE", _fontBold, Brushes.Black, x, y);
            string invNum = "Invoice #: " + _data.InvoiceNumber;
            var invNumSize = g.MeasureString(invNum, _fontBold);
            g.DrawString(invNum, _fontBold, Brushes.Black, x + width - invNumSize.Width, y);
            y += 22;

            string dateStr = "Date: " + _data.InvoiceDate.ToString("yyyy-MM-dd HH:mm");
            var dateSize = g.MeasureString(dateStr, _fontNormal);
            g.DrawString(dateStr, _fontNormal, Brushes.Black, x + width - dateSize.Width, y);

            int colY = y;
            g.DrawString("Customer: " + _data.CustomerName, _fontNormal, Brushes.Black, x, colY); colY += 18;
            g.DrawString("Payment Type: " + _data.PaymentType, _fontNormal, Brushes.Black, x, colY); colY += 18;
            g.DrawString("Payment Method: " + _data.PaymentMethod, _fontNormal, Brushes.Black, x, colY); colY += 18;

            if (!string.IsNullOrWhiteSpace(_data.SalesRepName) && _data.SalesRepName != "-- None --")
            {
                g.DrawString("Sales Rep: " + _data.SalesRepName, _fontNormal, Brushes.Black, x, colY);
                colY += 18;
            }

            if (_data.PaymentType == "Borrow")
            {
                g.DrawString("Borrow Days: " + _data.TotalDays, _fontNormal, Brushes.Black, x, colY); colY += 18;
                g.DrawString("Return Date: " + _data.ReturnDate.ToString("yyyy-MM-dd"), _fontNormal, Brushes.Black, x, colY); colY += 18;
            }

            y = colY + 14;
            g.DrawLine(Pens.LightGray, x, y, x + width, y);
            y += 14;

            float[] colWidths = { 0.40f, 0.10f, 0.15f, 0.15f, 0.20f };
            string[] headers = { "Product", "Qty", "Unit Price", "Disc Amt", "Total" };

            int tableTop = y;
            int colX = x;
            for (int i = 0; i < headers.Length; i++)
            {
                int colW = (int)(width * colWidths[i]);
                var format = i == 0 ? new StringFormat() : new StringFormat { Alignment = StringAlignment.Far };
                g.DrawString(headers[i], _fontTableHeader, Brushes.White, new RectangleF(colX, y, colW, 20), format);
                colX += colW;
            }

            g.FillRectangle(new SolidBrush(Color.FromArgb(22, 32, 50)), x, tableTop - 2, width, 22);
            colX = x;
            for (int i = 0; i < headers.Length; i++)
            {
                int colW = (int)(width * colWidths[i]);
                var format = i == 0 ? new StringFormat() : new StringFormat { Alignment = StringAlignment.Far };
                g.DrawString(headers[i], _fontTableHeader, Brushes.White, new RectangleF(colX + 4, tableTop, colW - 8, 20), format);
                colX += colW;
            }
            y = tableTop + 26;

            bool alternate = false;
            while (_rowIndex < _data.Lines.Count)
            {
                var line = _data.Lines[_rowIndex];

                if (y + 24 > bounds.Bottom - 140)
                {
                    e.HasMorePages = true;
                    return;
                }

                if (alternate)
                    g.FillRectangle(new SolidBrush(Color.FromArgb(245, 247, 250)), x, y - 2, width, 22);
                alternate = !alternate;

                colX = x;
                DrawCell(g, line.ProductName, colX, y, (int)(width * colWidths[0]), false);
                colX += (int)(width * colWidths[0]);
                DrawCell(g, line.Quantity.ToString(), colX, y, (int)(width * colWidths[1]), true);
                colX += (int)(width * colWidths[1]);
                DrawCell(g, line.UnitPrice.ToString("F3"), colX, y, (int)(width * colWidths[2]), true);
                colX += (int)(width * colWidths[2]);
                DrawCell(g, line.DiscountAmount.ToString("F3"), colX, y, (int)(width * colWidths[3]), true);
                colX += (int)(width * colWidths[3]);
                DrawCell(g, line.Total.ToString("F3"), colX, y, (int)(width * colWidths[4]), true);

                y += 24;
                _rowIndex++;
            }

            g.DrawLine(Pens.LightGray, x, y, x + width, y);
            y += 16;

            int totalsX = x + width - 240;
            int totalsW = 240;

            DrawTotalRow(g, ref y, totalsX, totalsW, "SubTotal:", _data.SubTotal, _fontNormal);
            DrawTotalRow(g, ref y, totalsX, totalsW, "Discount:", _data.DiscountAmount, _fontNormal);
            DrawTotalRow(g, ref y, totalsX, totalsW, "Tax (" + _data.TaxPercent.ToString("F0") + "%):", _data.TaxAmount, _fontNormal);

            y += 4;
            g.DrawLine(Pens.Black, totalsX, y, totalsX + totalsW, y);
            y += 6;

            DrawTotalRow(g, ref y, totalsX, totalsW, "TOTAL:", _data.TotalAmount, _fontTotal);
            y += 6;
            DrawTotalRow(g, ref y, totalsX, totalsW, "Paid:", _data.PaidAmount, _fontNormal);

            if (_data.RemainingAmount > 0)
            {
                DrawTotalRow(g, ref y, totalsX, totalsW, "Remaining:", _data.RemainingAmount, _fontBold, Brushes.Red);
            }
            else if (_data.RemainingAmount < 0)
            {
                DrawTotalRow(g, ref y, totalsX, totalsW, "Change:", Math.Abs(_data.RemainingAmount), _fontBold, Brushes.Green);
            }
            else
            {
                DrawTotalRow(g, ref y, totalsX, totalsW, "Remaining:", 0, _fontBold, Brushes.Green);
            }

            if (!string.IsNullOrWhiteSpace(_data.Notes))
            {
                y += 20;
                g.DrawString("Notes: " + _data.Notes, _fontSmall, Brushes.Gray, x, y, new StringFormat());
            }

            int footerY = bounds.Bottom - 30;
            g.DrawLine(Pens.LightGray, x, footerY, x + width, footerY);
            g.DrawString("Thank you for your business!", _fontSmall, Brushes.Gray,
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