using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Form2 nesnesi oluştur
            this.Hide(); // Form1'i gizle
            form2.ShowDialog(); // Form2'yi aç (modal olarak)
            this.Show(); // Form2 kapandığında Form1 tekrar görünür olur
        }
    }
}
