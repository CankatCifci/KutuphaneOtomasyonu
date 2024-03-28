using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using WindowsFormsApp2;

namespace WindowsFormsApp
{
    public partial class FrmKitapEkle : Form
    {
       
        private List<Kitap> kitaplar;

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Yeni kitabın adını ve yazarını al
            string kitapAdi = txtKitapAdi.Text;
            string yazar = txtYazar.Text;

            // Otomatik olarak yeni bir KitapId ata
            int yeniKitapId = GetSonKitapId() + 1;

            // Yeni kitabı listeye ekle
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
    }

    public class Kitap
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public string Yazar { get; set; }
    }
}
