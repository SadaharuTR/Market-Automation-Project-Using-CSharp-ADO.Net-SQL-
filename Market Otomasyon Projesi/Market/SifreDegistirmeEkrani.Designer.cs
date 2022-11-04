namespace Market
{
    partial class SifreDegistirmeEkrani
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SifreDegistirmeEkrani));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Sorgula = new System.Windows.Forms.Button();
            this.cmbbox_GuvenlikSoru = new System.Windows.Forms.ComboBox();
            this.txt_kullaniciAdi = new System.Windows.Forms.TextBox();
            this.txt_GuvenlikCevap = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.grpbox_sifreDegistirmeAlani = new System.Windows.Forms.GroupBox();
            this.btn_geri = new System.Windows.Forms.Button();
            this.txt_YeniSifreTekrar = new System.Windows.Forms.TextBox();
            this.btn_Degistir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_YeniSifre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpBox_mailAlani = new System.Windows.Forms.GroupBox();
            this.btn_Onayla = new System.Windows.Forms.Button();
            this.txt_dogrulaKod = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Dogrula = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1.SuspendLayout();
            this.grpbox_sifreDegistirmeAlani.SuspendLayout();
            this.grpBox_mailAlani.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.btn_geri);
            this.groupBox1.Controls.Add(this.btn_Sorgula);
            this.groupBox1.Controls.Add(this.cmbbox_GuvenlikSoru);
            this.groupBox1.Controls.Add(this.txt_kullaniciAdi);
            this.groupBox1.Controls.Add(this.txt_GuvenlikCevap);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Güvenlik Sorusu ile Değiştirme:";
            // 
            // btn_Sorgula
            // 
            this.btn_Sorgula.BackColor = System.Drawing.Color.Yellow;
            this.btn_Sorgula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Sorgula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sorgula.ImageIndex = 2;
            this.btn_Sorgula.ImageList = this.ımageList1;
            this.btn_Sorgula.Location = new System.Drawing.Point(116, 143);
            this.btn_Sorgula.Name = "btn_Sorgula";
            this.btn_Sorgula.Size = new System.Drawing.Size(170, 37);
            this.btn_Sorgula.TabIndex = 3;
            this.btn_Sorgula.Text = "Sorgula";
            this.btn_Sorgula.UseVisualStyleBackColor = false;
            this.btn_Sorgula.Click += new System.EventHandler(this.btn_Sorgula_Click);
            // 
            // cmbbox_GuvenlikSoru
            // 
            this.cmbbox_GuvenlikSoru.FormattingEnabled = true;
            this.cmbbox_GuvenlikSoru.Location = new System.Drawing.Point(116, 70);
            this.cmbbox_GuvenlikSoru.Name = "cmbbox_GuvenlikSoru";
            this.cmbbox_GuvenlikSoru.Size = new System.Drawing.Size(170, 21);
            this.cmbbox_GuvenlikSoru.TabIndex = 1;
            // 
            // txt_kullaniciAdi
            // 
            this.txt_kullaniciAdi.Location = new System.Drawing.Point(116, 34);
            this.txt_kullaniciAdi.Name = "txt_kullaniciAdi";
            this.txt_kullaniciAdi.Size = new System.Drawing.Size(170, 20);
            this.txt_kullaniciAdi.TabIndex = 0;
            // 
            // txt_GuvenlikCevap
            // 
            this.txt_GuvenlikCevap.Location = new System.Drawing.Point(116, 109);
            this.txt_GuvenlikCevap.Name = "txt_GuvenlikCevap";
            this.txt_GuvenlikCevap.Size = new System.Drawing.Size(170, 20);
            this.txt_GuvenlikCevap.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Güvenlik Cevabı:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Güvenlik Sorusu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-Mail Adresiniz:";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(113, 34);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(180, 20);
            this.txt_Email.TabIndex = 0;
            // 
            // grpbox_sifreDegistirmeAlani
            // 
            this.grpbox_sifreDegistirmeAlani.BackColor = System.Drawing.Color.Cyan;
            this.grpbox_sifreDegistirmeAlani.Controls.Add(this.txt_YeniSifreTekrar);
            this.grpbox_sifreDegistirmeAlani.Controls.Add(this.btn_Degistir);
            this.grpbox_sifreDegistirmeAlani.Controls.Add(this.label5);
            this.grpbox_sifreDegistirmeAlani.Controls.Add(this.txt_YeniSifre);
            this.grpbox_sifreDegistirmeAlani.Controls.Add(this.label4);
            this.grpbox_sifreDegistirmeAlani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpbox_sifreDegistirmeAlani.Location = new System.Drawing.Point(643, 12);
            this.grpbox_sifreDegistirmeAlani.Name = "grpbox_sifreDegistirmeAlani";
            this.grpbox_sifreDegistirmeAlani.Size = new System.Drawing.Size(313, 192);
            this.grpbox_sifreDegistirmeAlani.TabIndex = 4;
            this.grpbox_sifreDegistirmeAlani.TabStop = false;
            this.grpbox_sifreDegistirmeAlani.Text = "Şifre Değiştirme Alanı:";
            // 
            // btn_geri
            // 
            this.btn_geri.BackColor = System.Drawing.Color.White;
            this.btn_geri.ImageKey = "back.ico";
            this.btn_geri.ImageList = this.ımageList1;
            this.btn_geri.Location = new System.Drawing.Point(9, 153);
            this.btn_geri.Name = "btn_geri";
            this.btn_geri.Size = new System.Drawing.Size(54, 27);
            this.btn_geri.TabIndex = 6;
            this.btn_geri.UseVisualStyleBackColor = false;
            this.btn_geri.Click += new System.EventHandler(this.btn_geri_Click);
            // 
            // txt_YeniSifreTekrar
            // 
            this.txt_YeniSifreTekrar.Location = new System.Drawing.Point(107, 56);
            this.txt_YeniSifreTekrar.Name = "txt_YeniSifreTekrar";
            this.txt_YeniSifreTekrar.Size = new System.Drawing.Size(160, 20);
            this.txt_YeniSifreTekrar.TabIndex = 1;
            // 
            // btn_Degistir
            // 
            this.btn_Degistir.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_Degistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Degistir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Degistir.ImageIndex = 1;
            this.btn_Degistir.ImageList = this.ımageList1;
            this.btn_Degistir.Location = new System.Drawing.Point(107, 82);
            this.btn_Degistir.Name = "btn_Degistir";
            this.btn_Degistir.Size = new System.Drawing.Size(160, 34);
            this.btn_Degistir.TabIndex = 2;
            this.btn_Degistir.Text = "Değiştir";
            this.btn_Degistir.UseVisualStyleBackColor = false;
            this.btn_Degistir.Click += new System.EventHandler(this.btn_Degistir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Şifre Tekrar:";
            // 
            // txt_YeniSifre
            // 
            this.txt_YeniSifre.Location = new System.Drawing.Point(107, 30);
            this.txt_YeniSifre.Name = "txt_YeniSifre";
            this.txt_YeniSifre.Size = new System.Drawing.Size(160, 20);
            this.txt_YeniSifre.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Yeni Şifre:";
            // 
            // grpBox_mailAlani
            // 
            this.grpBox_mailAlani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grpBox_mailAlani.Controls.Add(this.btn_Onayla);
            this.grpBox_mailAlani.Controls.Add(this.txt_dogrulaKod);
            this.grpBox_mailAlani.Controls.Add(this.txt_Email);
            this.grpBox_mailAlani.Controls.Add(this.label6);
            this.grpBox_mailAlani.Controls.Add(this.btn_Dogrula);
            this.grpBox_mailAlani.Controls.Add(this.label1);
            this.grpBox_mailAlani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpBox_mailAlani.Location = new System.Drawing.Point(326, 12);
            this.grpBox_mailAlani.Name = "grpBox_mailAlani";
            this.grpBox_mailAlani.Size = new System.Drawing.Size(311, 192);
            this.grpBox_mailAlani.TabIndex = 5;
            this.grpBox_mailAlani.TabStop = false;
            this.grpBox_mailAlani.Text = "Mail Alanı:";
            // 
            // btn_Onayla
            // 
            this.btn_Onayla.BackColor = System.Drawing.Color.Gold;
            this.btn_Onayla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Onayla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Onayla.ImageIndex = 0;
            this.btn_Onayla.ImageList = this.ımageList1;
            this.btn_Onayla.Location = new System.Drawing.Point(113, 143);
            this.btn_Onayla.Name = "btn_Onayla";
            this.btn_Onayla.Size = new System.Drawing.Size(180, 37);
            this.btn_Onayla.TabIndex = 3;
            this.btn_Onayla.Text = "Onayla";
            this.btn_Onayla.UseVisualStyleBackColor = false;
            this.btn_Onayla.Click += new System.EventHandler(this.btn_Onayla_Click);
            // 
            // txt_dogrulaKod
            // 
            this.txt_dogrulaKod.Location = new System.Drawing.Point(113, 116);
            this.txt_dogrulaKod.Name = "txt_dogrulaKod";
            this.txt_dogrulaKod.Size = new System.Drawing.Size(180, 20);
            this.txt_dogrulaKod.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Doğrulama Kodu:";
            // 
            // btn_Dogrula
            // 
            this.btn_Dogrula.BackColor = System.Drawing.Color.Gold;
            this.btn_Dogrula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Dogrula.Location = new System.Drawing.Point(113, 60);
            this.btn_Dogrula.Name = "btn_Dogrula";
            this.btn_Dogrula.Size = new System.Drawing.Size(180, 31);
            this.btn_Dogrula.TabIndex = 2;
            this.btn_Dogrula.Text = "Doğrulama Kodu Gönder";
            this.btn_Dogrula.UseVisualStyleBackColor = false;
            this.btn_Dogrula.Click += new System.EventHandler(this.btn_Dogrula_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "check.ico");
            this.ımageList1.Images.SetKeyName(1, "reverse.ico");
            this.ımageList1.Images.SetKeyName(2, "search.ico");
            this.ımageList1.Images.SetKeyName(3, "back.ico");
            // 
            // SifreDegistirmeEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(968, 211);
            this.Controls.Add(this.grpbox_sifreDegistirmeAlani);
            this.Controls.Add(this.grpBox_mailAlani);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SifreDegistirmeEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SifreDegistirmeEkrani";
            this.Load += new System.EventHandler(this.SifreDegistirmeEkrani_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpbox_sifreDegistirmeAlani.ResumeLayout(false);
            this.grpbox_sifreDegistirmeAlani.PerformLayout();
            this.grpBox_mailAlani.ResumeLayout(false);
            this.grpBox_mailAlani.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpbox_sifreDegistirmeAlani;
        private System.Windows.Forms.TextBox txt_YeniSifreTekrar;
        private System.Windows.Forms.Button btn_Degistir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_YeniSifre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Sorgula;
        private System.Windows.Forms.ComboBox cmbbox_GuvenlikSoru;
        private System.Windows.Forms.TextBox txt_GuvenlikCevap;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBox_mailAlani;
        private System.Windows.Forms.TextBox txt_kullaniciAdi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Onayla;
        private System.Windows.Forms.TextBox txt_dogrulaKod;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Dogrula;
        private System.Windows.Forms.Button btn_geri;
        private System.Windows.Forms.ImageList ımageList1;
    }
}