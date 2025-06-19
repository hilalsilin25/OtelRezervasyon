using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using OtelRezervasyon;
namespace OtelRezervasyon
{
    public partial class Form2 : Form
    {
        private readonly string connectionString = "Server=HILAL\\SQLEXPRESS;Database=OtelRezervasyonDB;Integrated Security=True";
        private object comboIlce;

        private readonly string apiBaseUrl = "http://localhost:5000/api"; // API adresi
        private readonly HttpClient httpClient = new HttpClient();


        public Form2()
        {
            InitializeComponent();
            // Load olayına handler ekle
            this.Load += Form2_Load;
        }



        private async void btnEkle_Click(object sender, EventArgs e)
        {
            // Kontrol - boş alanları kontrol et
            if (string.IsNullOrWhiteSpace(textAd.Text) || string.IsNullOrWhiteSpace(textSoyad.Text) ||
                string.IsNullOrWhiteSpace(textTelefon.Text) || string.IsNullOrWhiteSpace(textAdres.Text) ||
                string.IsNullOrWhiteSpace(textEmail.Text))
            {
                MessageBox.Show("Tüm alanları doldurduğunuzdan emin olun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync(); // <-- Ana trend içinde açıyoruz!

                    string query = "INSERT INTO Musteriler (Ad, Soyad, Telefon, Adres, Email) VALUES (@Ad, @Soyad, @Telefon, @Adres, @Email)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Ad", textAd.Text);
                        command.Parameters.AddWithValue("@Soyad", textSoyad.Text);
                        command.Parameters.AddWithValue("@Telefon", textTelefon.Text);
                        command.Parameters.AddWithValue("@Adres", textAdres.Text);
                        command.Parameters.AddWithValue("@Email", textEmail.Text);


                        await command.ExecuteNonQueryAsync(); // <-- Async çalışıyoruz!

                        MessageBox.Show("Kayıt başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir müşteri seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int musteriID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MusteriID"].Value);

            DialogResult sonuc = MessageBox.Show("Bu kaydı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc != DialogResult.Yes)
                return;

            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Musteriler WHERE MusteriID = @ID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID", musteriID);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                                MessageBox.Show("Kayıt başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Silinecek kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void btnListele_Click(object sender, EventArgs e)
        {
            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT * FROM Musteriler";
                        using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView1.Invoke(new Action(() =>
                            {
                                dataGridView1.DataSource = dt;
                            }));
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kayıt kayıt = new kayıt(); // Form2 nesnesi oluştur
            kayıt.Show(); // Form2'yi aç
            this.Hide(); // Form1'i gizle (eğer tamamen kapanmasını istiyorsan this.Close() kullanabilirsin)
                         // Butonun boyutu ve padding ayarı
            

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            // Label'ların rengi beyaz olsun:
            label1.ForeColor = Color.DarkRed;
            label2.ForeColor = Color.DarkRed;
            label3.ForeColor = Color.DarkRed;
            label4.ForeColor = Color.DarkRed;
            label5.ForeColor = Color.DarkRed;
            label6.ForeColor = Color.DarkRed;
            label7.ForeColor = Color.DarkRed;

            // DataGridView ayarları:
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.BackgroundColor = Color.White; // Beyaz arka plan
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230); // Açık kırmızı ton
            dataGridView1.GridColor = Color.Red;
        }

        private void Sonraki_Click(object sender, EventArgs e)
        {
            // Form2'deki bilgileri alıyoruz
            string ad = textAd.Text;
            string soyad = textSoyad.Text;
            string telefon = textTelefon.Text;
            string email = textEmail.Text;

            // Form3'e veri aktarma
            Form3 form3 = new Form3(ad, soyad, telefon, email);
            form3.Show();
            this.Hide();  // Form2'yi gizle
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide(); //Form1'i aç
        }

        private async void btnGüncelleştrirme_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen güncellenecek müşteriyi seçin.");
                return;
            }

            int musteriID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["MusteriID"].Value);

            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "UPDATE Musteriler SET Ad = @Ad, Soyad = @Soyad, Telefon = @Telefon, Adres = @Adres, Email = @Email WHERE MusteriID = @ID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Ad", textAd.Text);
                            command.Parameters.AddWithValue("@Soyad", textSoyad.Text);
                            command.Parameters.AddWithValue("@Telefon", textTelefon.Text);
                            command.Parameters.AddWithValue("@Adres", textAdres.Text);
                            command.Parameters.AddWithValue("@Email", textEmail.Text);
                            command.Parameters.AddWithValue("@ID", musteriID); // dikkat!

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                                MessageBox.Show("Güncelleme başarılı!");
                            else
                                MessageBox.Show("Güncellenecek kayıt bulunamadı.");
                        }
                    }
                });


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);

            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["MusteriID"].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textAd.Text = row.Cells["Ad"].Value?.ToString();
                textSoyad.Text = row.Cells["Soyad"].Value?.ToString();
                textTelefon.Text = row.Cells["Telefon"].Value?.ToString();
                textAdres.Text = row.Cells["Adres"].Value?.ToString();
                textEmail.Text = row.Cells["Email"].Value?.ToString();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
