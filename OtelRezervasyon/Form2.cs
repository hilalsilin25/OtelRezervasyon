using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyon
{
    public partial class Form2 : Form
    {
        private readonly string connectionString = "Server=HILAL\\SQLEXPRESS;Database=OtelRezervasyonDB;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
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
            if (string.IsNullOrWhiteSpace(textAd.Text))
            {
                MessageBox.Show("Silmek için bir ad giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Musteriler WHERE Ad = @Ad";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Ad", textAd.Text);
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

        private async void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textid.Text))
            {
                MessageBox.Show("Güncelleme için bir ID giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await Task.Run(() =>
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE Musteriler SET Ad = @Ad, Soyad = @Soyad, Telefon = @Telefon, Adres = @Adres, Email = @Email WHERE Id = @Id";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", Convert.ToInt32(textid.Text));
                            command.Parameters.AddWithValue("@Ad", textAd.Text);
                            command.Parameters.AddWithValue("@Soyad", textSoyad.Text);
                            command.Parameters.AddWithValue("@Telefon", textTelefon.Text);
                            command.Parameters.AddWithValue("@Adres", textAdres.Text);
                            command.Parameters.AddWithValue("@Email", textEmail.Text);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                                MessageBox.Show("Güncelleme başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Güncellenecek kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
    }
}
