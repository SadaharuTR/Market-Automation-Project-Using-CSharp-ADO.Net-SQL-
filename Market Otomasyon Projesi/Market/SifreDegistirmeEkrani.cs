using Market.controller;
using Market.enumeration;
using Market.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public partial class SifreDegistirmeEkrani : Form
    {
        int code;
        public SifreDegistirmeEkrani()
        {
            InitializeComponent();
        }

        private void SifreDegistirmeEkrani_Load(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            List<LoginTable> loginTableList = controller.getLoginTable();
            grpbox_sifreDegistirmeAlani.Enabled = false;
            grpBox_mailAlani.Enabled = false;

            foreach(LoginTable lt in loginTableList)
            {
                cmbbox_GuvenlikSoru.Items.Add(lt.guvenlikSorusu.ToString());
            }
            cmbbox_GuvenlikSoru.SelectedIndex = 0;
        }

        private void btn_Sorgula_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            LoginStatus result = controller.doAuthentication(txt_kullaniciAdi.Text.Trim().ToUpper(), cmbbox_GuvenlikSoru.SelectedItem.ToString(), txt_GuvenlikCevap.Text.ToUpper());

            if(result == LoginStatus.basarili)
            {
                grpBox_mailAlani.Enabled=true;
            }
            else if(result == LoginStatus.basarisiz)
            {
                MessageBox.Show("Girdiğiniz Bilgiler hatalı. Lütfen tekrar kontrol ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
                MessageBox.Show("Tüm alanları doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);


        }

        private void btn_Dogrula_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            string emailAdres = controller.checkEmailAddress(txt_kullaniciAdi.Text);

            if (emailAdres == txt_Email.Text)
            {
                Random rdn = new Random();//doğrulama butonuna basıldığı zaman random bir sayı üret.
                code = rdn.Next(111111, 999999);

                MailAddress mailAlan = new MailAddress(txt_Email.Text, txt_kullaniciAdi.Text);//MailAdress sınıfını kullanarak maili alan kişinin mail adresini ve görünecek ismini
                MailAddress mailGonderen = new MailAddress("yoneticiahmet@outlook.com", "Ahmet Yönetici");//burada da maili gönderen kişinin bilgilerini tanımladık.
                MailMessage mesaj = new MailMessage();//burada da MailMessage sınıfı ile mesajın içeriğini tanımlıyoruz.

                mesaj.To.Add(mailAlan);//sınıfın To koleksiyonunun Add metodunu kullanarak yukarıda tanımlamış olduğumuz maili alan kişiyi, alacaklar listesine eklemiş oluyoruz.
                mesaj.From = mailGonderen;//burada da maili göndereni ekliyoruz.
                mesaj.Subject = "Şifre Değişimi.";//mailin başlığını ayarlıyoruz.
                mesaj.Body = "Şifrenizi değiştirmek için doğrulama kodunuz: " + code;//içeriğini tamamlıyoruz. oluşturulan random kodu da ekledik.

                //sunucu ayarlarını yapıyoruz.
                SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);//host,port üzerinden 
                                                                            //yoneticiahmet@outlook.com ve şifresi üzerinden,
                smtp.Credentials = new System.Net.NetworkCredential("yoneticiahmet@outlook.com", "CAQEkyk!:T:BF88");
                smtp.EnableSsl = true;//güvenli bir şekilde 
                smtp.Send(mesaj);//smtp protokolünden ilgili mesajı hedefte belirtilen adrese Send-Gönder
                MessageBox.Show("Doğrulama kodu gönderildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Hesabınıza bağlı mail adresini doğru giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_Onayla_Click(object sender, EventArgs e)
        {
            if(txt_dogrulaKod.Text == code.ToString())
            {
                grpbox_sifreDegistirmeAlani.Enabled = true;
            }
            else
                MessageBox.Show("Hatalı doğrulama kodu girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Degistir_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();

            if(txt_YeniSifre.Text == txt_YeniSifreTekrar.Text)
            {
               LoginStatus result = controller.changePassword(txt_kullaniciAdi.Text, txt_YeniSifre.Text);
               
               if (result == LoginStatus.basarili)
                {
                    MessageBox.Show("Şifreniz başarıyla değiştirildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               else
                {
                    MessageBox.Show("Gerekli alanları eksiksiz doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("Girilen iki şifre aynı değil. Lütfen tekrar giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();

        }
    }
}
