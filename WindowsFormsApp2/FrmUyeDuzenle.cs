using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FrmUyeDuzenle : Form
    {
        public string YeniAd { get; private set; }
        public string YeniSoyad { get; private set; }

        public FrmUyeDuzenle(int uyeId, string ad, string soyad)
        {
            InitializeComponent();

            // Form üzerindeki kontrolleri ilgili üyenin bilgileri ile doldur
            UyeId.Text = uyeId.ToString();
            txtAd.Text = ad;
            txtSoyad.Text = soyad;
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            // İptal et ve formu kapat
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Yeni adı ve soyadı al
            YeniAd = txtAd.Text;
            YeniSoyad = txtSoyad.Text;

            // Değişiklikleri onayla ve formu kapat
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
