namespace OtelRezervasyon
{
    partial class Form4
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
            lblAd = new Label();
            labelTelefon = new Label();
            labelEmail = new Label();
            labelOtel = new Label();
            labelAdDeger = new Label();
            labelTelefonDeger = new Label();
            labelEmailDeger = new Label();
            labelOtelDeger = new Label();
            btnKapat = new Button();
            labelTarihSaatDeger = new Label();
            panelBilgi = new Panel();
            SuspendLayout();
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.BackColor = Color.DarkTurquoise;
            lblAd.Location = new Point(30, 47);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(73, 20);
            lblAd.TabIndex = 0;
            lblAd.Text = "Ad Soyad";
            // 
            // labelTelefon
            // 
            labelTelefon.AutoSize = true;
            labelTelefon.BackColor = Color.DarkTurquoise;
            labelTelefon.Location = new Point(30, 90);
            labelTelefon.Name = "labelTelefon";
            labelTelefon.Size = new Size(58, 20);
            labelTelefon.TabIndex = 1;
            labelTelefon.Text = "Telefon";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.BackColor = Color.DarkTurquoise;
            labelEmail.Location = new Point(30, 131);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(46, 20);
            labelEmail.TabIndex = 2;
            labelEmail.Text = "Email";
            // 
            // labelOtel
            // 
            labelOtel.AutoSize = true;
            labelOtel.BackColor = Color.DarkTurquoise;
            labelOtel.Location = new Point(30, 177);
            labelOtel.Name = "labelOtel";
            labelOtel.Size = new Size(88, 20);
            labelOtel.TabIndex = 3;
            labelOtel.Text = "Seçilen Otel";
            // 
            // labelAdDeger
            // 
            labelAdDeger.AutoSize = true;
            labelAdDeger.Location = new Point(143, 47);
            labelAdDeger.Name = "labelAdDeger";
            labelAdDeger.Size = new Size(0, 20);
            labelAdDeger.TabIndex = 4;
            // 
            // labelTelefonDeger
            // 
            labelTelefonDeger.AutoSize = true;
            labelTelefonDeger.Location = new Point(143, 90);
            labelTelefonDeger.Name = "labelTelefonDeger";
            labelTelefonDeger.Size = new Size(0, 20);
            labelTelefonDeger.TabIndex = 5;
            // 
            // labelEmailDeger
            // 
            labelEmailDeger.AutoSize = true;
            labelEmailDeger.Location = new Point(143, 131);
            labelEmailDeger.Name = "labelEmailDeger";
            labelEmailDeger.Size = new Size(0, 20);
            labelEmailDeger.TabIndex = 6;
            // 
            // labelOtelDeger
            // 
            labelOtelDeger.AutoSize = true;
            labelOtelDeger.Location = new Point(143, 177);
            labelOtelDeger.Name = "labelOtelDeger";
            labelOtelDeger.Size = new Size(0, 20);
            labelOtelDeger.TabIndex = 7;
            // 
            // btnKapat
            // 
            btnKapat.BackColor = Color.DarkTurquoise;
            btnKapat.Location = new Point(76, 255);
            btnKapat.Name = "btnKapat";
            btnKapat.Size = new Size(94, 29);
            btnKapat.TabIndex = 8;
            btnKapat.Text = "Kapat";
            btnKapat.UseVisualStyleBackColor = false;
            btnKapat.Click += btnKapat_Click_1;
            // 
            // labelTarihSaatDeger
            // 
            labelTarihSaatDeger.AutoSize = true;
            labelTarihSaatDeger.BackColor = Color.DarkTurquoise;
            labelTarihSaatDeger.ForeColor = Color.FromArgb(0, 0, 64);
            labelTarihSaatDeger.Location = new Point(38, 218);
            labelTarihSaatDeger.Name = "labelTarihSaatDeger";
            labelTarihSaatDeger.Size = new Size(79, 20);
            labelTarihSaatDeger.TabIndex = 9;
            labelTarihSaatDeger.Text = "Tarih/ Saat";
            // 
            // panelBilgi
            // 
            panelBilgi.Location = new Point(794, 22);
            panelBilgi.Name = "panelBilgi";
            panelBilgi.Size = new Size(10, 88);
            panelBilgi.TabIndex = 10;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Crimson;
            ClientSize = new Size(800, 450);
            Controls.Add(panelBilgi);
            Controls.Add(labelTarihSaatDeger);
            Controls.Add(btnKapat);
            Controls.Add(labelOtelDeger);
            Controls.Add(labelEmailDeger);
            Controls.Add(labelTelefonDeger);
            Controls.Add(labelAdDeger);
            Controls.Add(labelOtel);
            Controls.Add(labelEmail);
            Controls.Add(labelTelefon);
            Controls.Add(lblAd);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAd;
        private Label labelTelefon;
        private Label labelEmail;
        private Label labelOtel;
        private Label labelAdDeger;
        private Label labelTelefonDeger;
        private Label labelEmailDeger;
        private Label labelOtelDeger;
        private Button btnKapat;
        private Label labelTarihSaatDeger;
        private Panel panelBilgi;
    }
}