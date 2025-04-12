using Kutuphane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Listele();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            FormOkuyucuEkle FormOkuyucuEkle = new FormOkuyucuEkle(); // Form2'nin bir örneğini oluştur
            FormOkuyucuEkle.Show();
            this.Hide(); // Yeni formu aç (aynı anda iki form da açık olur)
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Listele()
        {
            // -- Okuyucular --

            dataGridView1.Rows.Clear(); // Önce eski satırları temizle

            string dosyaYolu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Kütüphane Bilgi Kayıt.txt";

            if (File.Exists(dosyaYolu))
            {
                string[] satirlar = File.ReadAllLines(dosyaYolu);

                for (int i = 0; i < satirlar.Length; i += 5) // Her kayıt 5 satırdan oluşuyor
                {
                    try
                    {
                        string ad = satirlar[i].Replace("Ad: ", "").Trim();
                        string soyad = satirlar[i + 1].Replace("Soyad: ", "").Trim();
                        string telefon = satirlar[i + 2].Replace("Telefon: ", "").Trim();
                        string adres = satirlar[i + 3].Replace("Adres: ", "").Trim();

                        // DataGridView'e satır ekle
                        dataGridView1.Rows.Add(ad, soyad, telefon, adres);
                    }
                    catch
                    {
                        continue; // Hatalı kayıt varsa geç
                    }
                }
            }
            else
            {
                MessageBox.Show("Henüz kayıt bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // -- Okuyucular --

            // -- Mevcut Kitaplar --
            dataGridView2.Rows.Clear(); // Önce eski satırları temizle

            string dosyaYolu2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Kitap Ekle.txt";

            if (File.Exists(dosyaYolu2))
            {
                string[] satirlar = File.ReadAllLines(dosyaYolu2);

                for (int i = 0; i < satirlar.Length; i += 6) // Her kayıt 5 satırdan oluşuyor
                {
                    try
                    {
                        string Kitapadi = satirlar[i].Replace("Kitapadi: ", "").Trim();
                        string Yazaradi = satirlar[i + 1].Replace("Yazaradi: ", "").Trim();
                        string Tür = satirlar[i + 2].Replace("Tür: ", "").Trim();
                        string Aciklama = satirlar[i + 3].Replace("Aciklama: ", "").Trim();
                        string Sirano = satirlar[i + 4].Replace("Sirano: ", "".Trim());

                        // DataGridView'e satır ekle
                        dataGridView2.Rows.Add(Kitapadi, Yazaradi, Tür, Aciklama, Sirano);
                    }
                    catch
                    {
                        continue; // Hatalı kayıt varsa geç
                    }
                }
            }
            else
            {
                MessageBox.Show("Henüz kayıt bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // -- Mevcut Kitaplar --

            // -- Emanet Kitaplar --
            dataGridView3.Rows.Clear(); // Önce eski satırları temizle

            string dosyaYolu3 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Emanet Ekle.txt";

            if (File.Exists(dosyaYolu3))
            {
                string[] satirlar = File.ReadAllLines(dosyaYolu3);

                for (int i = 0; i < satirlar.Length; i += 4)
                {
                    try
                    {
                        string okuyucuAdi = satirlar[i].Replace("Okuyucu Adı: ", "").Trim();
                        string kitap = satirlar[i + 1].Replace("Kitap: ", "").Trim();
                        string durum = satirlar[i + 2].Replace("Durum: ", "").Trim();

                        // DataGridView'e satır ekle
                        dataGridView3.Rows.Add(okuyucuAdi, kitap, durum);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Henüz kayıt bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // -- Emanet Kitaplar --
        }

        /**/

        // Taşınabilir Form Ayarları
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void MoveForm(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormEmanet FormEmanet = new FormEmanet(); // Form2'nin bir örneğini oluştur
            FormEmanet.Show();
            this.Hide(); // Yeni formu aç (aynı anda iki form da açık olur)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KitapEkle KitapEkle = new KitapEkle(); // Form2'nin bir örneğini oluştur
            KitapEkle.Show();
            this.Hide(); // Yeni formu aç (aynı anda iki form da açık olur)
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        /**/
    }
}
