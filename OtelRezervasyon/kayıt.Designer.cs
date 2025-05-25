namespace OtelRezervasyon
{
    partial class kayıt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPdfOlustur = new Button();
            btnPdfAc = new Button();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnPdfOlustur
            // 
            btnPdfOlustur.BackColor = Color.DarkTurquoise;
            btnPdfOlustur.Location = new Point(12, 82);
            btnPdfOlustur.Name = "btnPdfOlustur";
            btnPdfOlustur.Size = new Size(94, 29);
            btnPdfOlustur.TabIndex = 0;
            btnPdfOlustur.Text = "oluştur";
            btnPdfOlustur.UseVisualStyleBackColor = false;
            btnPdfOlustur.Click += btnPdfOlustur_Click;
            // 
            // btnPdfAc
            // 
            btnPdfAc.BackColor = Color.DarkTurquoise;
            btnPdfAc.Location = new Point(12, 132);
            btnPdfAc.Name = "btnPdfAc";
            btnPdfAc.Size = new Size(94, 29);
            btnPdfAc.TabIndex = 1;
            btnPdfAc.Text = "Görüntüle";
            btnPdfAc.UseVisualStyleBackColor = false;
            btnPdfAc.Click += btnPdfAc_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(200, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(561, 399);
            dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkTurquoise;
            button1.Location = new Point(12, 409);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Geri Dön";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // kayıt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Crimson;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(btnPdfAc);
            Controls.Add(btnPdfOlustur);
            Name = "kayıt";
            Text = "kayıt";
            Load += kayıt_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPdfOlustur;
        private Button btnPdfAc;
        private DataGridView dataGridView1;
        private Button button1;
    }
}