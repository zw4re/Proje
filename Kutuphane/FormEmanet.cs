using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class FormEmanet : Form
    {
        public FormEmanet()
        {
            InitializeComponent();
        }

        void comboBoxDoldur()
        {
            string dosyaYolu1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\okuyucular.txt";
            string dosyaYolu2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Kitap Ekle.txt";
            if (File.Exists(dosyaYolu1))
            {
                string[] satirlar = File.ReadAllLines(dosyaYolu1);

                for (int i = 0; i < satirlar.Length; i += 5)
                {
                    try
                    {
                        string ad = satirlar[i].Replace("Ad: ", "").Trim();
                        string soyad = satirlar[i + 1].Replace("Soyad: ", "").Trim();

                        string tamIsim = $"{ad} {soyad}";
                        comboBox1.Items.Add(tamIsim);
                    }
                    catch
                    {
                        continue; // Hatalı kayıt varsa geç
                    }
                }
            }

            if (File.Exists(dosyaYolu2))
            {
                string[] satirlar = File.ReadAllLines(dosyaYolu2);

                for (int i = 0; i < satirlar.Length; i += 6) // Her kayıt 6 satır: 5 veri + 1 boşluk
                {
                    try
                    {
                        string kitapAdi = satirlar[i].Replace("Kitapadi: ", "").Trim();
                        comboBox2.Items.Add(kitapAdi);
                    }
                    catch
                    {
                        continue; // Hatalı kayıt varsa geç
                    }
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string okuyucusec = comboBox1.Text.Trim();
            string kitapsec = comboBox2.Text.Trim();
            string emanet = button2.Text.Trim();

            
            string bilgiler = $"{okuyucusec}\n{kitapsec}\n{emanet}\n\n";

            string dosyaYolu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Emanet Ekle.txt";
            File.AppendAllText(dosyaYolu, bilgiler);

            MessageBox.Show("Bilgiler başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FormEmanet_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string okuyucusec = comboBox1.Text.Trim();
            string kitapsec = comboBox2.Text.Trim();
            string emanet = button1.Text.Trim();

            string bilgiler = $"{okuyucusec}\n{kitapsec}\n{emanet}\n\n";

            string dosyaYolu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Emanet Ekle.txt";
            System.IO.File.AppendAllText(dosyaYolu, bilgiler);
            MessageBox.Show("Bilgiler başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
