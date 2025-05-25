using System;
using System.Windows.Forms;

namespace OtelRezervasyon
{
    public partial class Form4 : Form
    {
        public Form4(string ad, string soyad, string telefon, string email, string otel)
        {
            InitializeComponent();

            labelAdDeger.Text = $"{ad} {soyad}";
            labelTelefonDeger.Text = telefon;
            labelEmailDeger.Text = email;
            labelOtelDeger.Text = otel;
        }



        private void btnKapat_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Rezervasyon başarıyla oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Form arka plan kırmızı
            this.BackColor = Color.FromArgb(220, 20, 60); // Crimson

            // Panel arka plan beyaz olsun
            panelBilgi.BackColor = Color.White;

            // Label yazı renkleri koyu (siyah) olsun ki beyaz panel üzerinde okunur
            labelAdDeger.ForeColor = Color.Black;
            labelTelefonDeger.ForeColor = Color.Black;
            labelEmailDeger.ForeColor = Color.Black;
            labelOtelDeger.ForeColor = Color.Black;
            labelTarihSaatDeger.ForeColor = Color.Black;

            // Tarih-saat labelına güncel tarih ve saat atama
            labelTarihSaatDeger.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }
    }
}