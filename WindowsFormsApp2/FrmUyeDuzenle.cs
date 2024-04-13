using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FrmUyeDuzenle : Form
    {
        private string databasePath = DatabaseHelper.databasePath;
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
            YeniAd = txtAd.Text;
            YeniSoyad = txtSoyad.Text;

            // Üye bilgilerini güncelle
            GuncelleUye(Convert.ToInt32(UyeId.Text), YeniAd, YeniSoyad);

            // Değişiklikleri onayla ve formu kapat
            DialogResult = DialogResult.OK;
            Close();
        }
        private void GuncelleUye(int uyeId, string yeniAd, string yeniSoyad)
        {
            using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
            {
                connection.Open();

                string updateQuery = "UPDATE Uye SET Ad = @Ad, Soyad = @Soyad WHERE UyeId = @UyeId";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Ad", yeniAd);
                    command.Parameters.AddWithValue("@Soyad", yeniSoyad);
                    command.Parameters.AddWithValue("@UyeId", uyeId);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void FrmUyeDuzenle_Load(object sender, EventArgs e)
        {

        }
    }
}
