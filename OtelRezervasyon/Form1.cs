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

        private void btngiri�_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Form2 nesnesi olu�tur
            form2.Show(); // Form2'yi a�
            this.Hide(); // Form1'i gizle (e�er tamamen kapanmas�n� istiyorsan this.Close() kullanabilirsin)
        }
    }




}