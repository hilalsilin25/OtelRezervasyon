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
using System.Windows.Forms;

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
            // DataGridView'e isim, soyisim ve takım sütunlarını ekleyelim
            dataGridView1.Columns.Add("Otel", "Otel");
            dataGridView1.Columns.Add("Hizmetler", "Hizmetler");
            dataGridView1.Columns.Add("Oda Sayisi", "Oda Sayisi");
            dataGridView1.Columns.Add("Gidis Tarihi", "Gidis Tarihi");
            dataGridView1.Columns.Add("Fiyat", "Fiyat");


            // DataGridView'e örnek veriler ekleyelim
            dataGridView1.Rows.Add("Azer", "Kahvaltı,Gezi Turu", "100", "10.04.2025","Günlük 500Tl");
            dataGridView1.Rows.Add("GoldYildirim", "Kahvaltı,Akşam Yemegi, Spor", "200", "05.04.2025","Günlük 600Tl");
            dataGridView1.Rows.Add("Hilton", "Tüm Ögünler, Gezi Turu,Kurslar ", "400", "01.04.2025","Günlük 1000Tl");
            dataGridView1.Rows.Add("Dedeman", "Tüm Ögünler, Spor, Konferanslar", "500", "03.04.2025", "Günlük 950");
            dataGridView1.Rows.Add("Grand", "Tüm Ögünler, Spor, Konferans, Gezi Turu", "600", "07.04.2025", "Günlük 1500");
           
        }

        private void btnPdfOlustur_Click(object sender, EventArgs e)
        {

            string pdfDirectory = @"C:\Users\HİLAL\Masaüstü\Otelkayıt";
            string pdfPath = Path.Combine(pdfDirectory, "Otelkayıt.pdf");
            string resimKlasoru = @"C:\Users\HİLAL\Masaüstü\oteller"; // Ana otel klasör yolu

            if (!Directory.Exists(pdfDirectory))
            {
                Directory.CreateDirectory(pdfDirectory);
            }

            Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(dataGridView1.ColumnCount);
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                table.AddCell(column.HeaderText);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string otelAdi = "";

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        string cellValue = row.Cells[i].Value?.ToString() ?? "";
                        table.AddCell(cellValue);

                        if (i == 0) // Otel adı
                            otelAdi = cellValue;
                    }

                    // Otel klasörlerinin yolları
                    string otelKlasoru = "";
                    switch (otelAdi.ToLower())
                    {
                        case "azer":
                            otelKlasoru = @"C:\Users\HİLAL\Masaüstü\oteller\azer";
                            break;
                        case "dedeman":
                            otelKlasoru = @"C:\Users\HİLAL\Masaüstü\oteller\dedeman";
                            break;
                        case "goldyıldırım":
                            otelKlasoru = @"C:\Users\HİLAL\Masaüstü\oteller\goldyıldırım";
                            break;
                        case "grand":
                            otelKlasoru = @"C:\Users\HİLAL\Masaüstü\oteller\grand";
                            break;
                        case "hilton":
                            otelKlasoru = @"C:\Users\HİLAL\Masaüstü\oteller\hilton";
                            break;
                    }

                    if (Directory.Exists(otelKlasoru))
                    {
                        // Otel ismini başlık olarak ekleyelim
                        Paragraph otelBaslik = new Paragraph(otelAdi, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16f));
                        otelBaslik.Alignment = Element.ALIGN_CENTER;
                        doc.Add(otelBaslik);  // Otel ismini ekle

                        string[] resimler = Directory.GetFiles(otelKlasoru, "*.*").Where(f => f.EndsWith(".jpg") || f.EndsWith(".png")).ToArray(); // JPG ve PNG resimlerini al

                        foreach (string resim in resimler)
                        {
                            try
                            {
                                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(resim);
                                img.ScaleToFit(400f, 300f); // Resmi boyutlandır
                                img.Alignment = Element.ALIGN_CENTER; // Ortala
                                doc.Add(img);  // Resmi PDF'e ekle
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Resim eklerken hata: {ex.Message}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Klasör bulunamadı: {otelKlasoru}");
                    }

                    doc.Add(table); // Tabloyu ekle
                    table = new PdfPTable(dataGridView1.ColumnCount); // Yeni tablo başlat
                }
            }

            doc.Add(table); // Son tabloyu ekle (görsel yoksa)
            doc.Close();

            MessageBox.Show("PDF başarıyla oluşturuldu! \nMasaüstü\\Otelkayıt klasörünü kontrol et.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddLogoToPdf(object inputPdfPath, object outputPdfPath, string logoPath)
        {
            throw new NotImplementedException();
        }

        private void btnPdfAc_Click_1(object sender, EventArgs e)
        {
            string pdfPath = @"C:\Users\HİLAL\Masaüstü\Otelkayıt\Otelkayıt.pdf"; // Logolu PDF açılacak

            if (File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Hata: PDF dosyası bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }


}

