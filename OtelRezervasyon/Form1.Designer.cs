namespace OtelRezervasyon
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btngiriş = new Button();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(448, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "GİRİŞ YAP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(328, 59);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 1;
            label2.Text = "Kullanıcı Adı:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(319, 102);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 2;
            label3.Text = "Kullanıcı Şifre:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(429, 52);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(162, 27);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(429, 95);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(164, 27);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // btngiriş
            // 
            btngiriş.BackColor = Color.DarkTurquoise;
            btngiriş.ForeColor = SystemColors.ControlText;
            btngiriş.Location = new Point(459, 159);
            btngiriş.Name = "btngiriş";
            btngiriş.Size = new Size(94, 29);
            btngiriş.TabIndex = 5;
            btngiriş.Text = "GİRİŞ ";
            btngiriş.UseVisualStyleBackColor = false;
            btngiriş.Click += btngiriş_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(81, 255);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 7;
            label4.Text = "label4";
            label4.Click += label4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonFace;
            pictureBox1.Image = Properties.Resources._12366377;
            pictureBox1.Location = new Point(2, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(249, 239);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Crimson;
            ClientSize = new Size(1311, 517);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(btngiriş);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giriş";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btngiriş;
        private PictureBox pictureBox1;
        private Label label4;
    }
}
