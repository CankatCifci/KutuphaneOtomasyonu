﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using WindowsFormsApp2;
using System.Data.SQLite;

namespace WindowsFormsApp
{
    public partial class FrmUyeEkle : Form
    {
        private List<Uye> uyeler;
        private string databasePath = DatabaseHelper.databasePath;
        public FrmUyeEkle()
        {
            InitializeComponent();
            uyeler = new List<Uye>();
            DosyaOku(); // Mevcut üyeleri dosyadan oku
            OtomatikUyeIdAta(); // Otomatik UyeId ataması yap
           UyeId.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Yeni üyenin adını ve soyadını al
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;

            //SQLite veritabanına bağlan
            using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
            {
                connection.Open();


                string insertQuery = "INSERT INTO Uye (Ad, Soyad) VALUES (@Ad, @Soyad)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Ad",ad);
                    command.Parameters.AddWithValue("@Soyad", soyad);
                    command.ExecuteNonQuery();
                }
            }
            // Otomatik olarak yeni bir UyeId ata
            int yeniUyeId = GetSonUyeId() + 1;

            // Yeni üyeyi listeye ekle
            uyeler.Add(new Uye { UyeId = yeniUyeId, Ad = ad, Soyad = soyad });

            // Listeyi JSON dosyasına yaz
            DosyaYaz();

            // Kullanıcıya bilgi mesajı göster
            MessageBox.Show("Üye başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Otomatik UyeId'i güncelle
            OtomatikUyeIdAta();

            // Text kutularını temizle
            txtAd.Text = "";
            txtSoyad.Text = "";
        }

        private void DosyaOku()
        {
            try
            {
                string dosyaYolu = "uyeler.json";
                if (File.Exists(dosyaYolu))
                {
                    string json = File.ReadAllText(dosyaYolu);
                    uyeler = JsonConvert.DeserializeObject<List<Uye>>(json);
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
                string dosyaYolu = "uyeler.json";
                string json = JsonConvert.SerializeObject(uyeler, Formatting.Indented);
                File.WriteAllText(dosyaYolu, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya yazma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OtomatikUyeIdAta()
        {
            int yeniUyeId = GetSonUyeId() + 1;
            UyeId.Text = yeniUyeId.ToString();
        }

        private int GetSonUyeId()
        {
            int maxId = 0;
            foreach (var uye in uyeler)
            {
                if (uye.UyeId > maxId)
                {
                    maxId = uye.UyeId;
                }
            }
            return maxId;
        }

        private void FrmUyeEkle_Load(object sender, EventArgs e)
        {

            // DataGridView'e sütunları ekle
            dataGridView1.Columns.Add("UyeId", "Üye ID");
            dataGridView1.Columns.Add("Ad", "Adı");
            dataGridView1.Columns.Add("Soyad", "Soyadı");

            // SQLite veritabanına bağlan
            using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
            {
                connection.Open();

                // Veritabanından üyeleri seç
                string selectQuery = "SELECT * FROM Uye";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        // Her bir satırı DataGridView'e ekle
                        while (reader.Read())
                        {
                            int uyeId = reader.GetInt32(reader.GetOrdinal("UyeId"));
                            string ad = reader.GetString(reader.GetOrdinal("Ad"));
                            string soyad = reader.GetString(reader.GetOrdinal("Soyad"));
                            dataGridView1.Rows.Add(uyeId, ad, soyad);
                        }
                    }
                }
            }

            // DataGridView'de bir üye seçildiğinde "Üyeyi Sil" düğmesini etkinleştir
            dataGridView1.SelectionChanged += (obj, args) =>
            {
                UyeSil.Enabled = dataGridView1.SelectedRows.Count > 0;
            };
        }

        private void UyeSil_Click(object sender, EventArgs e)
        {
            // Seçili satırı al
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Seçili üyenin UyeId'sini al
            int uyeId = Convert.ToInt32(selectedRow.Cells["UyeId"].Value);

            // DataGridView'den seçili satırı kaldır
            dataGridView1.Rows.Remove(selectedRow);

            // JSON dosyasından seçili üyeyi sil
            uyeler.RemoveAll(uye => uye.UyeId == uyeId);
            DosyaYaz();

            // SQLite veritabanından seçili üyeyi sil
            using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Uye WHERE UyeId = @UyeId";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@UyeId", uyeId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UyeDuzenle_Click(object sender, EventArgs e)
        {
            // Seçili satırı al
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Seçili üyenin UyeId'sini al
            int uyeId = Convert.ToInt32(selectedRow.Cells["UyeId"].Value);

            // Seçili üyenin bilgilerini al
            string ad = Convert.ToString(selectedRow.Cells["Ad"].Value);
            string soyad = Convert.ToString(selectedRow.Cells["Soyad"].Value);

            // Düzenleme formunu oluştur ve seçili üyenin bilgilerini aktar
            FrmUyeDuzenle frmUyeDuzenle = new FrmUyeDuzenle(uyeId, ad, soyad);
            DialogResult result = frmUyeDuzenle.ShowDialog();

            // Düzenleme formundan döndüğünde, yapılan değişiklikleri güncelle
            if (result == DialogResult.OK)
            {
                // Yapılan değişiklikleri al
                string yeniAd = frmUyeDuzenle.YeniAd;
                string yeniSoyad = frmUyeDuzenle.YeniSoyad;

                // uyeler listesinde ilgili üyenin bilgilerini güncelle
                foreach (var uye in uyeler)
                {
                    if (uye.UyeId == uyeId)
                    {
                        uye.Ad = yeniAd;
                        uye.Soyad = yeniSoyad;
                        break;
                    }
                }

                // DataGridView'i güncelle
                selectedRow.Cells["Ad"].Value = yeniAd;
                selectedRow.Cells["Soyad"].Value = yeniSoyad;

                // Dosyayı güncelle
                DosyaYaz();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
