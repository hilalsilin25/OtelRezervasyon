namespace OtelRezervasyon
{
    partial class Form3
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
            comboIl = new ComboBox();
            comboIlce = new ComboBox();
            comboOtel = new ComboBox();
            btnOlustur = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboIl
            // 
            comboIl.FormattingEnabled = true;
            comboIl.Location = new Point(30, 48);
            comboIl.Name = "comboIl";
            comboIl.Size = new Size(151, 28);
            comboIl.TabIndex = 0;
            comboIl.SelectedIndexChanged += comboIl_SelectedIndexChanged;
            // 
            // comboIlce
            // 
            comboIlce.FormattingEnabled = true;
            comboIlce.Location = new Point(256, 48);
            comboIlce.Name = "comboIlce";
            comboIlce.Size = new Size(151, 28);
            comboIlce.TabIndex = 1;
            comboIlce.SelectedIndexChanged += comboIlce_SelectedIndexChanged;
            // 
            // comboOtel
            // 
            comboOtel.FormattingEnabled = true;
            comboOtel.Location = new Point(451, 48);
            comboOtel.Name = "comboOtel";
            comboOtel.Size = new Size(151, 28);
            comboOtel.TabIndex = 2;
            comboOtel.SelectedIndexChanged += comboOtel_SelectedIndexChanged;
            // 
            // btnOlustur
            // 
            btnOlustur.Location = new Point(266, 199);
            btnOlustur.Name = "btnOlustur";
            btnOlustur.Size = new Size(94, 29);
            btnOlustur.TabIndex = 3;
            btnOlustur.Text = "Oluştur";
            btnOlustur.UseVisualStyleBackColor = true;
            btnOlustur.Click += btnOlustur_Click;
            // 
            // button1
            // 
            button1.Location = new Point(266, 248);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Geri Dön";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(btnOlustur);
            Controls.Add(comboOtel);
            Controls.Add(comboIlce);
            Controls.Add(comboIl);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboIl;
        private ComboBox comboIlce;
        private ComboBox comboOtel;
        private Button btnOlustur;
        private Button button1;
    }
}