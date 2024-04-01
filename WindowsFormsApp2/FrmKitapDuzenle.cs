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
    public partial class FrmKitapDuzenle : Form
    {
        public string YeniKitapAdi { get; private set; }
        public string YeniYazar { get; private set; }

        public FrmKitapDuzenle(int kitapId, string kitapAdi, string yazar)
        {
            InitializeComponent();

            // Düzenlenecek kitabın bilgilerini form kontrollerine doldur
            txtKitapId.Text = kitapId.ToString();
            txtYeniKitapAdi.Text = kitapAdi;
            txtYeniYazar.Text = yazar;
        }


        private void btnIptal_Click(object sender, EventArgs e)
        {
            // İptal butonuna tıklandığında formu kapat
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YeniKitapAdi = txtYeniKitapAdi.Text;
            YeniYazar = txtYeniYazar.Text;

            // Formu kapat
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
