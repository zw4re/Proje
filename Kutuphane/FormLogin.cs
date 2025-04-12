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
    public partial class FormLogin: Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim(); // Boşlukları temizle
            string sifre = txtSifre.Text;

            if (kullaniciAdi == "1" && sifre == "1")
            {
                MessageBox.Show("Giriş başarılı! Ana sayfaya yönlendiriliyorsunuz.", "Başarılı",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                Menu form1 = new Menu();
                form1.Show();         // Form1’i aç
                this.Hide();          // LoginForm’u gizle

                // Ana formu aç: new MainForm().Show();
            }
            else
            {
                MessageBox.Show("Şifre veya kullanıcı adı yanlış!", "Hata",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSifre.Clear(); // Şifreyi temizle
                txtKullaniciAdi.Focus(); // Kullanıcı adına odaklan
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
