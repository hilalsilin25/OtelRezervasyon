using System;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;


namespace OtelRezervasyon
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
           
            await HavaDurumuGetir("Igdir"); // T�rk�e karakter sorununa kar�� 'Igdir' kullan�yoruz
                                            // Form arka plan rengini k�rm�z� yapal�m
                                            // Form arka plan rengini lightgreen yap
            this.BackColor = Color.DodgerBlue;

            // Buton rengini ve yaz� rengini ayarla (�rnek: btngiri�)
            btngiri�.BackColor = Color.Red;
            btngiri�.ForeColor = Color.White; // IndianRed �st�nde beyaz yaz� okunur
            btngiri�.FlatStyle = FlatStyle.Flat;
            btngiri�.FlatAppearance.BorderColor = Color.Red;

            // Label renklerini ve arka plan�n� ayarla
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Color.DarkRed;      // Okunabilir koyu k�rm�z�
                    lbl.BackColor = Color.DodgerBlue;   // Arka plan formla uyumlu
                }
                else if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.White;          // TextBox arka plan beyaz
                    txt.ForeColor = Color.DarkRed;      // Yaz� rengi IndianRed
                }
            }


        }

        private async Task HavaDurumuGetir(string sehir)
        {
            try
            {
                string apiKey = "df366f29d4571646654721448f68b898";
                string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={sehir}&appid={apiKey}&units=metric&lang=tr";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        JObject veri = JObject.Parse(json);
                        string sicaklik = veri["main"]["temp"].ToString();
                        string aciklama = veri["weather"][0]["description"].ToString();

                        label4.Text = $"Hava Durumu: {sicaklik}�C, {aciklama}";
                    }
                    else
                    {
                        string hataMesaji = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"API HATASI!\nKod: {response.StatusCode}\nDetay: {hataMesaji}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        label4.Text = "Hava durumu al�namad�!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ba�lant� hatas�: {ex.Message}", "Ba�lant� Hatas�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label4.Text = "Ba�lant� hatas�!";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void btngiri�_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
