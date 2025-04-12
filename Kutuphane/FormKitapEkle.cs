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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string Kitapadi = txtKitapAdı.Text.Trim();
            string Yazaradi = txtyazaradi.Text.Trim();
            string Tür = txttür.Text.Trim();
            string Aciklama = txtAciklama.Text.Trim();
            string Sirano = txtSiraNo.Text.Trim();

            string bilgiler = $"Kitapadi: {Kitapadi}\nYazaradi: {Yazaradi}\nTür: {Tür}\nAciklama: {Aciklama}\nSirano: {Sirano}\n";

            string dosyaYolu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Kitap Ekle.txt";
            System.IO.File.AppendAllText(dosyaYolu, bilgiler);
            MessageBox.Show("Bilgiler başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtKitapAdı.Text = "";
            txtyazaradi.Text = "";
            txttür.Text = "";
            txtAciklama.Text = "";
            txtSiraNo.Text = "";
        }
    }
}
