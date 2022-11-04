using Market.controller;
using Market.dao;
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
    public partial class KullaniciPanel : Form
    {
        Controller controller = new Controller();
        public KullaniciPanel()
        {
            InitializeComponent();
        }

        private void KullaniciPanel_Load(object sender, EventArgs e)
        {
            defaultDegerleriDoldur();
            tumKullanicilariDoldur();
        }
        private void defaultDegerleriDoldur()
        {
            combo_yetki.Items.Add("admin");
            combo_yetki.Items.Add("kasiyer");
            combo_yetki.SelectedIndex = 0;

            combo_bolge.Items.Add("Adalar");
            combo_bolge.Items.Add("Arnavutköy");
            combo_bolge.Items.Add("Ataşehir");
            combo_bolge.Items.Add("Avcılar");
            combo_bolge.Items.Add("Bakırköy");
            combo_bolge.Items.Add("Beyoğlu");
            combo_bolge.Items.Add("Çatalca");
            combo_bolge.Items.Add("Çekmeköy");
            combo_bolge.Items.Add("Sancaktepe");
            combo_bolge.SelectedIndex = 0;

            combo_guvenlikSorusu.Items.Add("Köpeğinizin Adı?");
            combo_guvenlikSorusu.Items.Add("En Sevdiğiniz Araba?");
            combo_guvenlikSorusu.Items.Add("Dayınızın soyadı nedir?");
            combo_guvenlikSorusu.Items.Add("Doğduğunuz şehir?");
            combo_guvenlikSorusu.Items.Add("Adınızın son baş harfi?");
            combo_guvenlikSorusu.Items.Add("En çok torpil yapan şef?");
            combo_guvenlikSorusu.Items.Add("İnönü mü?");
            combo_guvenlikSorusu.Items.Add("IV. Murat mı?");
            combo_guvenlikSorusu.Items.Add("Çocukluk lakabınız nedir?");
            combo_guvenlikSorusu.SelectedIndex = 0;

        }
        private void tumKullanicilariDoldur()
        {
            List<User> userList = controller.tumKullanicilariGetir();
            dataGridView1.DataSource = userList;
        }

        private void btn_kayitEkle_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.kullaniciAdi = txt_kullaniciAdi.Text;
            user.sifre = txt_sifre.Text;
            user.yetki = combo_yetki.Text.ToString();
            user.bolge = combo_bolge.Text.ToString();
            user.emailAdres = txt_emailAdres.Text;
            user.guvenlikSorusu = combo_guvenlikSorusu.Text.ToString();
            user.guvenlikCevabi = txt_guvenlikCevap.Text;


            LoginStatus sonuc = controller.kullaniciEkle(user);

            if(sonuc == LoginStatus.basarili)
            { 
                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = controller.tumKullanicilariGetir(); 
            }
            else
                MessageBox.Show("Kayıt ekleme başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_kullaniciAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_sifre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            combo_yetki.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            combo_bolge.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_emailAdres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            combo_guvenlikSorusu.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txt_guvenlikCevap.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }

        private void btn_kayitGuncelle_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.id = int.Parse(txt_id.Text);
            user.kullaniciAdi = txt_kullaniciAdi.Text;
            user.sifre = txt_sifre.Text;
            user.yetki = combo_yetki.Text.ToString();
            user.bolge = combo_bolge.Text.ToString();
            user.emailAdres = txt_emailAdres.Text;
            user.guvenlikSorusu = combo_guvenlikSorusu.Text.ToString();
            user.guvenlikCevabi = txt_guvenlikCevap.Text;

            LoginStatus sonuc = controller.kullaniciGuncelle(user);

            if (sonuc == LoginStatus.basarili)
            {
                MessageBox.Show("Kayıt başarıyla güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = controller.tumKullanicilariGetir();
            }
            else
                MessageBox.Show("Kayıt güncelleme başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btn_kayitSil_Click(object sender, EventArgs e)
        {

            if(!string.IsNullOrEmpty(txt_id.Text))
            {
                LoginStatus sonuc = controller.kullaniciSil(int.Parse(txt_id.Text));

                if (sonuc == LoginStatus.basarili) 
                { 
                    MessageBox.Show("Kayıt başarıyla silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = controller.tumKullanicilariGetir();
                }
                else if(sonuc == LoginStatus.basarisiz)
                    MessageBox.Show("Kayıt silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Lütfen silmek istediğiniz kaydın ID değerini doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Lütfen silmek istediğiniz kaydın ID değerini doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            AdminPanel admin = new AdminPanel();
            admin.Show();
            this.Hide();
        }
    }
}
