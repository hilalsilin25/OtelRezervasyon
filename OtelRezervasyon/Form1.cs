using System;
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
            await HavaDurumuGetir("Igdir"); // Türkçe karakter sorununa karþý 'Igdir' kullanýyoruz
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

                        label4.Text = $"Hava Durumu: {sicaklik}°C, {aciklama}";
                    }
                    else
                    {
                        string hataMesaji = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"API HATASI!\nKod: {response.StatusCode}\nDetay: {hataMesaji}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        label4.Text = "Hava durumu alýnamadý!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Baðlantý hatasý: {ex.Message}", "Baðlantý Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label4.Text = "Baðlantý hatasý!";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }

        private void btngiriþ_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
