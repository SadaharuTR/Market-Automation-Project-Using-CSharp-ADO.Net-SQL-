using AForge.Video.DirectShow;
using Market.controller;
using Market.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace Market
{
    public partial class MeyveSebzePanel : Form
    {
        int sayi1, sayi2, islemTip;

        public MeyveSebzePanel()
        {
            InitializeComponent();
            txt_islem.Text = "0"

;        }

        private void btn_toplama_Click(object sender, EventArgs e)
        {
            islemTip = 1; //+'yı temsilen
            sayi1 = Convert.ToInt32(txt_islem.Text);
            txt_islem.Text = "";

        }

        private void btn_esittir_Click(object sender, EventArgs e)
        {
            if(islemTip == 1)
            {
                sayi2 = int.Parse(txt_islem.Text);
                txt_islem.Text = (sayi1 + sayi2).ToString();
            }
            else if(islemTip == 2)
            {
                sayi2 = int.Parse(txt_islem.Text);
                txt_islem.Text = (sayi1 - sayi2).ToString();
            }
            else if (islemTip == 3)
            {
                sayi2 = int.Parse(txt_islem.Text);
                txt_islem.Text = (sayi1 * sayi2).ToString();
            }
            else if (islemTip == 4)
            {
                sayi2 = int.Parse(txt_islem.Text);
                txt_islem.Text = (sayi1 / sayi2).ToString();
            }
        }

        private void btn_cikarma_Click(object sender, EventArgs e)
        {
            islemTip = 2; //-'yı temsilen
            sayi1 = Convert.ToInt32(txt_islem.Text);
            txt_islem.Text = "";
        }

        private void btn_carpma_Click(object sender, EventArgs e)
        {
            islemTip = 3; //*'yı temsilen
            sayi1 = Convert.ToInt32(txt_islem.Text);
            txt_islem.Text = "";
        }

        private void btn_bolme_Click(object sender, EventArgs e)
        {
            islemTip = 4; // bölme'yi temsilen
            sayi1 = Convert.ToInt32(txt_islem.Text);
            txt_islem.Text = "";
        }

        private void btn_gerigel_Click(object sender, EventArgs e)
        {
            if (txt_islem.Text.Length != 0)
            {
                txt_islem.Text = txt_islem.Text.Substring(0, txt_islem.Text.Length - 1);
            }
            else
                txt_islem.Text = "0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pctbox_Kamera.Image != null)
            {
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)pctbox_Kamera.Image);

                if(result != null)
                {
                    textBox1.Text = result.ToString();
                    timer1.Stop();
                }
            }

            lbl_saat.Text = DateTime.Now.Hour.ToString() + " : ";
            lbl_dakika.Text = DateTime.Now.Minute.ToString() + " : ";
            lbl_saniye.Text = DateTime.Now.Second.ToString();
        }

        FilterInfoCollection fic;
        VideoCaptureDevice vcd;
        private void MeyveSebzePanel_Load(object sender, EventArgs e)
        {

            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach(FilterInfo camera in fic)
            {
                cmb_kameraAc.Items.Add(camera.Name);
            }
        }

        private void btn_kameraAc_Click(object sender, EventArgs e)
        {
            vcd = new VideoCaptureDevice(fic[cmb_kameraAc.SelectedIndex].MonikerString);
            vcd.NewFrame += Vcd_NewFrame1;
            vcd.Start();
            timer1.Start();

        }

        private void Vcd_NewFrame1(object sender,AForge.Video.NewFrameEventArgs eventArgs)
        {
            pctbox_Kamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Vcd_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            pctbox_Kamera.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btn_kameraKapa_Click(object sender, EventArgs e)
        {
            vcd.Stop();
            pctbox_Kamera.Image = Image.FromFile("C:\\Users\\Cagatay\\Desktop\\Market Otomasyon\\Görseller\\webcam.ico");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            controller.Controller controller = new controller.Controller();
            Urun targetUrun = controller.urunuGetir(textBox1.Text);
            lbl_urunIsim.Text = targetUrun.urunIsim.ToString();
            txt_islem.Text = targetUrun.fiyat.ToString();

            SoundPlayer ses = new SoundPlayer();
            ses.SoundLocation = "barkod.wav";
            ses.Play();

        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            KasiyerPanel kasiyer = new KasiyerPanel();
            kasiyer.Show();
            this.Hide();
        }

        private void secilenTus(object sender, EventArgs e)
        {
            if(txt_islem.Text == "0")
            {
                txt_islem.Text = "";
            }
            txt_islem.Text += ((Button)sender).Text;
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_islem.Text = "0";
        }
    }
}
