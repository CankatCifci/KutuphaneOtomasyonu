using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using WindowsFormsApp2;
using System.Data.SQLite;

namespace WindowsFormsApp
{
    public partial class FrmKitapEkle : Form
    {

        private List<Kitap> kitaplar;
        private string databasePath = DatabaseHelper.databasePath;

        private void button1_Click(object sender, EventArgs e)
        {
            FrmUyeEkle frm2 = new FrmUyeEkle();
            frm2.Show();
            this.Hide();
        }
        public FrmKitapEkle()
        {
            InitializeComponent();
            kitaplar = new List<Kitap>();
            DosyaOku(); // Mevcut kitapları dosyadan oku
            OtomatikKitapIdAta(); // Otomatik KitapId ataması yap
            txtKitapId.Enabled = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Yeni kitabın adını ve yazarını al
            string kitapAdi = txtKitapAdi.Text;
            string yazar = txtYazar.Text;

            // SQLite veritabanına bağlan
            using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
            {
                connection.Open();

                // Yeni kitabı SQLite veritabanına ekle
                string insertQuery = "INSERT INTO Kitap (KitapAdi, Yazar) VALUES (@KitapAdi, @Yazar)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@KitapAdi", kitapAdi);
                    command.Parameters.AddWithValue("@Yazar", yazar);
                    command.ExecuteNonQuery();
                }
            }

            // Yeni kitabı listeye ekle
            int yeniKitapId = GetSonKitapId() + 1;
            kitaplar.Add(new Kitap { KitapId = yeniKitapId, KitapAdi = kitapAdi, Yazar = yazar });

            // Listeyi JSON dosyasına yaz
            DosyaYaz();

            // Kullanıcıya bilgi mesajı göster
            MessageBox.Show("Kitap başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Otomatik KitapId'i güncelle
            OtomatikKitapIdAta();

            // Text kutularını temizle
            txtKitapAdi.Text = "";
            txtYazar.Text = "";
        }

        private void DosyaOku()
        {
            try
            {
                string dosyaYolu = "kitaplar.json";
                if (File.Exists(dosyaYolu))
                {
                    string json = File.ReadAllText(dosyaYolu);
                    kitaplar = JsonConvert.DeserializeObject<List<Kitap>>(json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okuma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DosyaYaz()
        {
            try
            {
                string dosyaYolu = "kitaplar.json";
                string json = JsonConvert.SerializeObject(kitaplar, Formatting.Indented);
                File.WriteAllText(dosyaYolu, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya yazma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OtomatikKitapIdAta()
        {
            int yeniKitapId = GetSonKitapId() + 1;
            txtKitapId.Text = yeniKitapId.ToString();
        }

        private int GetSonKitapId()
        {
            int maxId = 0;
            foreach (var kitap in kitaplar)
            {
                if (kitap.KitapId > maxId)
                {
                    maxId = kitap.KitapId;
                }
            }
            return maxId;
        }
      
        private void kitapId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKitapAdi_TextChanged(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtYazar_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Seçili kitabın KitapId'sini al
            int kitapId = Convert.ToInt32(selectedRow.Cells["KitapId"].Value);

            // DataGridView'den seçili satırı kaldır
            dataGridView1.Rows.Remove(selectedRow);

            // kitaplar listesinden seçili kitabı sil
            kitaplar.RemoveAll(kitap => kitap.KitapId == kitapId);

            // Dosyayı güncelle
            DosyaYaz();
        }

        private void btnKitapDuzenle_Click(object sender, EventArgs e)
        {
            // Seçili satırı al
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Seçili kitabın KitapId'sini al
            int kitapId = Convert.ToInt32(selectedRow.Cells["KitapId"].Value);

            // Seçili kitabın bilgilerini al
            string kitapAdi = Convert.ToString(selectedRow.Cells["KitapAdi"].Value);
            string yazar = Convert.ToString(selectedRow.Cells["Yazar"].Value);

            // Düzenleme formunu oluştur ve seçili kitabın bilgilerini aktar
            FrmKitapDuzenle frmKitapDuzenle = new FrmKitapDuzenle(kitapId, kitapAdi, yazar);
            DialogResult result = frmKitapDuzenle.ShowDialog();

            // Düzenleme formundan döndüğünde, yapılan değişiklikleri güncelle
            if (result == DialogResult.OK)
            {
                // Yapılan değişiklikleri al
                string yeniKitapAdi = frmKitapDuzenle.YeniKitapAdi;
                string yeniYazar = frmKitapDuzenle.YeniYazar;

                // kitaplar listesinde ilgili kitabın bilgilerini güncelle
                foreach (var kitap in kitaplar)
                {
                    if (kitap.KitapId == kitapId)
                    {
                        kitap.KitapAdi = yeniKitapAdi;
                        kitap.Yazar = yeniYazar;
                        break;
                    }
                }

                // DataGridView'i güncelle
                selectedRow.Cells["KitapAdi"].Value = yeniKitapAdi;
                selectedRow.Cells["Yazar"].Value = yeniYazar;

                // Dosyayı güncelle
                DosyaYaz();
            }
        }

        private void FrmKitapEkle_Load_1(object sender, EventArgs e)
        {

            // DataGridView'e sütunları ekle
            dataGridView1.Columns.Add("KitapId", "Kitap ID");
            dataGridView1.Columns.Add("KitapAdi", "Kitap Adı");
            dataGridView1.Columns.Add("Yazar", "Yazar");

            // Mevcut kitapları DataGridView'e ekle
            foreach (var kitap in kitaplar)
            {
                dataGridView1.Rows.Add(kitap.KitapId, kitap.KitapAdi, kitap.Yazar);
            }

            // DataGridView'de bir kitap seçildiğinde "Kitabı Sil" düğmesini etkinleştir
            dataGridView1.SelectionChanged += (obj, args) =>
            {
                btnKitapSil.Enabled = dataGridView1.SelectedRows.Count > 0;
            };
        }
    }
}