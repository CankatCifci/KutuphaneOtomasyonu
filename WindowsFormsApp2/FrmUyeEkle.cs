using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using WindowsFormsApp2;

namespace WindowsFormsApp
{
    public partial class FrmUyeEkle : Form
    {
        private List<Uye> uyeler;

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
    }
}
