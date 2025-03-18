using System;
using System.Windows.Forms;

namespace OtelRezervasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btngiriþ_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Form2 nesnesi oluþtur
            form2.Show(); // Form2'yi aç
            this.Hide(); // Form1'i gizle (eðer tamamen kapanmasýný istiyorsan this.Close() kullanabilirsin)
        }
    }




}