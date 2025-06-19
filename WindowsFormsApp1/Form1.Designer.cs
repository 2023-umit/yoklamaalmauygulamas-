namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.giris = new System.Windows.Forms.Button();
            this.txt_kullanıcı = new System.Windows.Forms.TextBox();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.lbl_kullanıcı = new System.Windows.Forms.Label();
            this.lbl_sifre = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // giris
            // 
            this.giris.Location = new System.Drawing.Point(332, 368);
            this.giris.Name = "giris";
            this.giris.Size = new System.Drawing.Size(185, 45);
            this.giris.TabIndex = 0;
            this.giris.Text = "giris";
            this.giris.UseVisualStyleBackColor = true;
            this.giris.Click += new System.EventHandler(this.giris_Click);
            // 
            // txt_kullanıcı
            // 
            this.txt_kullanıcı.Location = new System.Drawing.Point(332, 206);
            this.txt_kullanıcı.Multiline = true;
            this.txt_kullanıcı.Name = "txt_kullanıcı";
            this.txt_kullanıcı.Size = new System.Drawing.Size(185, 34);
            this.txt_kullanıcı.TabIndex = 1;
            this.txt_kullanıcı.TextChanged += new System.EventHandler(this.txt_kullanıcı_TextChanged);
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(332, 285);
            this.txt_sifre.Multiline = true;
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(185, 38);
            this.txt_sifre.TabIndex = 2;
            // 
            // lbl_kullanıcı
            // 
            this.lbl_kullanıcı.AutoSize = true;
            this.lbl_kullanıcı.Location = new System.Drawing.Point(329, 178);
            this.lbl_kullanıcı.Name = "lbl_kullanıcı";
            this.lbl_kullanıcı.Size = new System.Drawing.Size(80, 16);
            this.lbl_kullanıcı.TabIndex = 3;
            this.lbl_kullanıcı.Text = "kullanıcı adı ";
            // 
            // lbl_sifre
            // 
            this.lbl_sifre.AutoSize = true;
            this.lbl_sifre.Location = new System.Drawing.Point(329, 255);
            this.lbl_sifre.Name = "lbl_sifre";
            this.lbl_sifre.Size = new System.Drawing.Size(32, 16);
            this.lbl_sifre.TabIndex = 4;
            this.lbl_sifre.Text = "sifre";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.ığdırlogo;
            this.pictureBox1.Location = new System.Drawing.Point(696, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.ıgdır_üniversitesi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_sifre);
            this.Controls.Add(this.lbl_kullanıcı);
            this.Controls.Add(this.txt_sifre);
            this.Controls.Add(this.txt_kullanıcı);
            this.Controls.Add(this.giris);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "yoklama";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button giris;
        private System.Windows.Forms.TextBox txt_kullanıcı;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.Label lbl_kullanıcı;
        private System.Windows.Forms.Label lbl_sifre;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

