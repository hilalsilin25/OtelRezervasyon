using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf.draw;
using System.Windows.Forms;
using System.IO;

namespace OtelRezervasyon
{
    public partial class kayıt : Form
    {
        public kayıt()
        {
            InitializeComponent();
        }

        private void kayıt_Load(object sender, EventArgs e)
        {
            // DataGridView ayarları:
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.BackgroundColor = Color.White; // Beyaz arka plan
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230); // Açık kırmızı ton
            dataGridView1.GridColor = Color.Red;

            // Sütunları ekleyelim
            dataGridView1.Columns.Add("Otel", "Otel");
            dataGridView1.Columns.Add("Hizmetler", "Hizmetler");
            dataGridView1.Columns.Add("Oda Sayisi", "Oda Sayisi");
            dataGridView1.Columns.Add("Gidis Tarihi", "Gidis Tarihi");
            dataGridView1.Columns.Add("Fiyat", "Fiyat");

            // Resim sütunu
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "Görsel";
            imgCol.Name = "Gorsel";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.Columns.Add(imgCol);

            // Otel görsellerini yükleyip satırları ekleyelim
            AddRow("Azer", "Kahvaltı,Gezi Turu", "100", "10.04.2025", "Günlük 500Tl", @"C:\Users\HİLAL\Masaüstü\oteller\azer");
            AddRow("Hilton", "Tüm Ögünler, Gezi Turu,Kurslar ", "400", "01.04.2025", "Günlük 1000Tl", @"C:\Users\HİLAL\Masaüstü\oteller\hilton");
            AddRow("Dedeman", "Tüm Ögünler, Spor, Konferanslar", "500", "03.04.2025", "Günlük 950", @"C:\Users\HİLAL\Masaüstü\oteller\dedeman");
            AddRow("Grand", "Tüm Ögünler, Spor, Konferans, Gezi Turu", "600", "07.04.2025", "Günlük 1500", @"C:\Users\HİLAL\Masaüstü\oteller\grand");

            dataGridView1.RowTemplate.Height = 100;
        }

        private void AddRow(string otel, string hizmet, string oda, string tarih, string fiyat, string resimKlasoru)
        {
            System.Drawing.Image resim = null;
            try
            {
                string[] dosyalar = Directory.GetFiles(resimKlasoru, "*.*")
                    .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png")).ToArray();
                if (dosyalar.Length > 0)
                {
                    resim = System.Drawing.Image.FromFile(dosyalar[0]);
                    resim = new Bitmap(resim, new Size(100, 80));
                }
            }
            catch
            {
                // Hata varsa boş bırak
            }

            dataGridView1.Rows.Add(otel, hizmet, oda, tarih, fiyat, resim);
        }

        private void btnPdfOlustur_Click(object sender, EventArgs e)
        {
            string pdfDirectory = @"C:\Users\HİLAL\Masaüstü\Otelkayıt";
            string pdfPath = Path.Combine(pdfDirectory, "Otelkayıt.pdf");

            if (!Directory.Exists(pdfDirectory))
                Directory.CreateDirectory(pdfDirectory);

            Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(dataGridView1.ColumnCount);

            // Renkleri tanımla
            BaseColor kırmızı = new BaseColor(220, 20, 60); // Crimson kırmızısı
            BaseColor beyaz = BaseColor.WHITE;

            // Başlık hücreleri - kırmızı arkaplan, beyaz yazı
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell baslikHucresi = new PdfPCell(new Phrase(column.HeaderText,
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, beyaz)));
                baslikHucresi.BackgroundColor = kırmızı;
                baslikHucresi.HorizontalAlignment = Element.ALIGN_CENTER;
                baslikHucresi.Padding = 5;
                table.AddCell(baslikHucresi);
            }

            // Veri hücreleri - beyaz arkaplan, kırmızı yazı
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell dgvCell in row.Cells)
                    {
                        string hucreMetni = dgvCell.Value?.ToString() ?? "";
                        PdfPCell veriHucresi = new PdfPCell(new Phrase(hucreMetni,
                            FontFactory.GetFont(FontFactory.HELVETICA, 11, kırmızı)));
                        veriHucresi.BackgroundColor = beyaz;
                        veriHucresi.HorizontalAlignment = Element.ALIGN_CENTER;
                        veriHucresi.Padding = 5;
                        table.AddCell(veriHucresi);
                    }
                }
            }

            doc.Add(table);
            doc.Add(new Paragraph("\n"));

            // Otel başlıkları kırmızı renkte
            string[] otelAdlari = { "azer", "hilton", "dedeman", "grand" };
            string baseImagePath = @"C:\Users\HİLAL\Masaüstü\oteller";

            foreach (var otel in otelAdlari)
            {
                string otelKlasoru = Path.Combine(baseImagePath, otel);
                if (Directory.Exists(otelKlasoru))
                {
                    Paragraph otelBaslik = new Paragraph(otel.ToUpper(),
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14f, kırmızı));
                    otelBaslik.Alignment = Element.ALIGN_CENTER;
                    doc.Add(otelBaslik);
                    doc.Add(new Paragraph("\n"));

                    string[] resimler = Directory.GetFiles(otelKlasoru, "*.*")
                        .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png")).ToArray();

                    foreach (string resim in resimler)
                    {
                        try
                        {
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(resim);
                            img.ScaleToFit(200f, 150f);
                            img.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                            doc.Add(img);
                            doc.Add(new Paragraph("\n"));
                        }
                        catch
                        {
                            // Hata varsa atla
                        }
                    }

                    doc.Add(new Paragraph("\n\n"));
                }
            }

            doc.Close();

            MessageBox.Show("PDF başarıyla oluşturuldu! \nMasaüstü\\Otelkayıt klasörünü kontrol et.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnPdfAc_Click(object sender, EventArgs e)
        {
            string pdfPath = @"C:\Users\HİLAL\Masaüstü\Otelkayıt\Otelkayıt.pdf";

            if (File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("PDF bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide(); //Form2'yi aç
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

