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
    public partial class FrmKitapDuzenle : Form
    {
        private string databasePath = DatabaseHelper.databasePath;
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

            // Kitap bilgilerini güncelle
            GuncelleKitap(Convert.ToInt32(txtKitapId.Text), YeniKitapAdi, YeniYazar);

            // Değişiklikleri onayla ve formu kapat
            DialogResult = DialogResult.OK;
            Close();
        }
        private void GuncelleKitap(int kitapId, string yeniKitapAdi, string yeniYazar)
        {
            using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
            {
                connection.Open();

                string updateQuery = "UPDATE Kitap SET KitapAdi = @KitapAdi, Yazar = @Yazar WHERE KitapId = @KitapId";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@KitapAdi", yeniKitapAdi);
                    command.Parameters.AddWithValue("@Yazar", yeniYazar);
                    command.Parameters.AddWithValue("@KitapId", kitapId);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void FrmKitapDuzenle_Load(object sender, EventArgs e)
        {

        }
    }
}
