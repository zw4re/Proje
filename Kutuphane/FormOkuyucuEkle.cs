using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane
{
    public partial class FormOkuyucuEkle : Form
    {
        public FormOkuyucuEkle()
        {
            InitializeComponent();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text.Trim();
            string soyad = textBox2.Text.Trim();
            string telefon = maskedTextBox1.Text.Trim();
            string adres = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad))
            {
                MessageBox.Show("Ad ve soyad boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bilgiler = $"Ad: {ad}\nSoyad: {soyad}\nTelefon: {telefon}\nAdres: {adres}\n";

            try
            {
                // Belgeler klasörüne kaydeder
                string dosyaYolu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Kütüphane Bilgi Kayıt.txt";
                System.IO.File.AppendAllText(dosyaYolu, bilgiler);
                MessageBox.Show("Bilgiler başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Alanları temizle
                textBox1.Clear();
                textBox2.Clear();
                maskedTextBox1.Clear();
                textBox3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void FormOkuyucuEkle_Load(object sender, EventArgs e)
        {

        }
    }
}

