using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Linq;
using System.Text.Json.Serialization;
using System.Net.Http.Json;


namespace OtelRezervasyon
{
    public partial class Form3 : Form
    {
        private readonly string Ad;
        private readonly string Soyad;
        private readonly string textTelefon;
        private readonly string textEmail;

        private readonly HttpClient httpClient = new HttpClient();
        private readonly string apiBaseUrl = "https://localhost:7237/api/";

        public Form3(string ad, string soyad, string telefon, string email)
        {
            InitializeComponent();

            Ad = ad;
            Soyad = soyad;

            if (!telefon.All(char.IsDigit))
            {
                MessageBox.Show("Telefon numarası sadece rakamlardan oluşmalıdır.");
                return;
            }
            textTelefon = telefon;

            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                textEmail = email;
            }
            catch
            {
                MessageBox.Show("Geçersiz email formatı.");
                return;
            }

            httpClient.BaseAddress = new Uri(apiBaseUrl);

            // Event'ler
            comboIl.SelectedIndexChanged += comboIl_SelectedIndexChanged;
            comboIlce.SelectedIndexChanged += comboIlce_SelectedIndexChanged;
            comboIlce.SelectedIndexChanged += comboOtel_SelectedIndexChanged;
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            await IlleriYukleAsync();
            this.BackColor = Color.DodgerBlue;

            foreach (Control ctl in this.Controls)
            {
                if (ctl is Label)
                    ctl.ForeColor = Color.White; // Label yazıları beyaz
                else if (ctl is ComboBox || ctl is TextBox)
                    ctl.BackColor = Color.White; // Beyaz arka plan
            }
        }
        private async Task IlleriYukleAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("Otel/Iller");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var iller = JsonConvert.DeserializeObject<List<string>>(json);
                    comboIl.Items.Clear();
                    comboIl.Items.AddRange(iller.ToArray());
                }
                else
                {
                    MessageBox.Show("İller yüklenemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İller hatası: " + ex.Message);
            }
        }


        private async void comboIl_SelectedIndexChanged(object sender, EventArgs e)
        {

            string secilenIl = comboIl.SelectedItem?.ToString();

            comboIlce.Items.Clear();
            comboOtel.Items.Clear();

            if (!string.IsNullOrEmpty(secilenIl))
            {
                try
                {
                    var response = await httpClient.GetAsync($"Otel/Ilceler?il={secilenIl}");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var ilceler = JsonConvert.DeserializeObject<List<string>>(json);
                        comboIlce.Items.AddRange(ilceler.ToArray());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İlçeler hatası: " + ex.Message);
                }
            }
        }


        private async void comboIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secilenIlce = comboIlce.SelectedItem?.ToString();

            comboOtel.Items.Clear();

            if (!string.IsNullOrEmpty(secilenIlce))
            {
                try
                {
                    var response = await httpClient.GetAsync($"Otel?ilce={secilenIlce}");
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var oteller = JsonConvert.DeserializeObject<List<Otel>>(json);
                        comboOtel.Items.AddRange(oteller.Select(o => o.Ad).ToArray());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oteller hatası: " + ex.Message);
                }
            }
        }

        private void comboOtel_SelectedIndexChanged(object sender, EventArgs e)
        {


            async Task OtelleriYukleAsync(string ilce)
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync($"Otel/Oteller?ilce={ilce}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var oteller = JsonConvert.DeserializeObject<List<Otel>>(content);
                        comboOtel.Items.Clear();
                        comboOtel.Items.AddRange(oteller.Select(x => x.Ad).ToArray());
                    }
                    else
                    {
                        MessageBox.Show("Oteller API yanıtı başarısız: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oteller yüklenemedi: " + ex.Message);
                }
            }
        }
        private async void btnOlustur_Click(object sender, EventArgs e)
        {
            if (comboOtel.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir otel seçiniz.");
                return;
            }

            var rezervasyon = new
            {
                Ad,
                Soyad,
                Telefon = textTelefon,
                Email = textEmail,
                Il = comboIl.SelectedItem?.ToString(),
                Ilce = comboIlce.SelectedItem?.ToString(),
                Otel = comboOtel.SelectedItem?.ToString()
            };

            try
            {
                var response = await httpClient.PostAsJsonAsync("Otel", rezervasyon);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Rezervasyon başarıyla oluşturuldu!");

                    string secilenOtel = comboOtel.SelectedItem.ToString();
                    Form4 form4 = new Form4(Ad, Soyad, textTelefon, textEmail, secilenOtel);
                    form4.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Rezervasyon oluşturulamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        public class Otel
        {
            public int Id { get; set; }

            [JsonPropertyName("otelAdi")] // JSON'da "otelAdi" olarak görünecek
            public string Ad { get; set; }

            [JsonPropertyName("sehir")]  // JSON'da "sehir" olarak görünecek
            public string Il { get; set; }

            public string Ilce { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide(); //Form2'yi aç
           
        }
    }
}
        