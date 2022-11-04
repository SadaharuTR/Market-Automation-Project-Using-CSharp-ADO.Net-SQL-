using Market.controller;
using Market.enumeration;
using Market.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btn_giris_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();  
            User result = controller.login(txt_kullaniciAdi.Text, txt_sifre.Text);

            if(result != null && result.status == LoginStatus.basarili && result.yetki == "admin")
            {
                AdminPanel admin = new AdminPanel();
                admin.Show();
                this.Hide();
            }
            else if(result != null && result.status == LoginStatus.basarili && result.yetki == "kasiyer")
            {
                KasiyerPanel kasiyer = new KasiyerPanel();
                kasiyer.Show();
                this.Hide();
            }
            else if(result != null && result.status == LoginStatus.basarisiz)
            {
                MessageBox.Show("Girilen bilgilere göre kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Eksik parametre girdiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SifreDegistirmeEkrani SD = new SifreDegistirmeEkrani();
            SD.Show();
            this.Hide();
        }

        
    }
}
