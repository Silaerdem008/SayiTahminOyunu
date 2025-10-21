using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayiTahminOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool oyunBitti = false;
        Random rastgele = new Random();
        private int puan = 100;
        private int sure = 60;
        int tutulanSayi, buyuk = 100, kucuk = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            tutulanSayi = rastgele.Next(100);
            buyuk = 100;
            kucuk = 0;
            puan = 100;
            sure = 60;
            label2.Text = "SAYI " + kucuk + " VE " + buyuk + " ARASINDA ";
            label5.Text = "  " + puan;
            label6.Text = "  " + sure + " sn";

            textBox1.Focus();
            if (textBox1.Focus())
            {
                textBox1.Focus();
            }
            oyunBitti = false; // Yeni oyunda sıfırlıyoruz
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tahmin;
            if (!int.TryParse(textBox1.Text, out tahmin))
            {
                MessageBox.Show("Lütfen sadece sayı giriniz!");
                textBox1.Clear();
                textBox1.Focus();
                return; // Hatalı giriş varsa metottan çık
            }
            timer1.Start();

            if (tahmin == tutulanSayi)
            {
                timer1.Stop();
                label2.Text = "BİLDİNİZ! Sayı: " + tahmin;
                MessageBox.Show("TEBRİKLER!  Doğru Tahmin Ettiniz Puanınız: " + puan);
                oyunBitti = true;
            }
            else if (tahmin > tutulanSayi)
            {
                buyuk = tahmin;
                label2.Text = "Sayı " + kucuk + " Ve " + buyuk + " Arasında ";
                puan -= 10;
                label6.Text = " " + puan;
                
            }
            else if (tahmin < tutulanSayi)
            {
                kucuk = tahmin;
                label2.Text = "Sayı " + kucuk + " Ve " + buyuk + " Arasında ";
                puan -= 10;
                label6.Text = " " + puan;
                
            }
            if (puan <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Puanınız Tükendi! Oyun Sona Erdi Doğru Sayı: " + tutulanSayi);
                oyunBitti = true;
            }
            textBox1.Text = "";
            if (textBox1.Focus())
            {
                textBox1.Focus();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            tutulanSayi = rastgele.Next(100);
            buyuk = 100;
            kucuk = 0;
            label2.Text = "Sayı " + kucuk + " Ve " + buyuk + " Arasında";
            label5.Text = " " + puan;
            label6.Text = " " + sure + " sn";

            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sure--;
            label5.Text = " " + sure + " sn";
            if (sure == 0)
            {
                timer1.Stop();
                MessageBox.Show("Süre Doldu! Doğru Sayı: " + tutulanSayi);
                oyunBitti = true; // Süre doldu, oyun bitti
            }
        }


    }
}
