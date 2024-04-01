using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class FrmEmanetDuzenle : Form
    {
        private List<Uye> uyeler;
        private List<Kitap> kitaplar;
        private List<Emanet> emanetler;

        public FrmEmanetDuzenle(Emanet selectedEmanet)
        {
            InitializeComponent();

            uyeler = new List<Uye>();
            kitaplar = new List<Kitap>();
            emanetler = new List<Emanet>();
            DosyaOku(); // Mevcut üyeleri, kitapları ve emanetleri dosyadan oku
        }

        private void FrmEmanetIslemleriDuzenle_Load(object sender, EventArgs e)
        {
            cmbUyeler.DataSource = uyeler; // Üyeleri liste kutusuna bağla
            cmbUyeler.DisplayMember = "Ad"; // Üyelerin ad ve soyadlarını göster
            lstKitaplar.DataSource = kitaplar; // Kitapları liste kutusuna bağla
            lstKitaplar.DisplayMember = "KitapAdi"; // Kitapların adlarını göster
            dgvEmanetler.Columns.Add("EmanetId", "Emanet ID");
            dgvEmanetler.Columns.Add("KitapAdi", "Kitap Adı");
            dgvEmanetler.Columns.Add("UyeAdi", "Üye Adı");
            dgvEmanetler.Columns.Add("EmanetTarihi", "Emanet Tarihi");
            dgvEmanetler.Columns.Add("EkBilgi", "Ek Bilgi");

            // Emanetleri DataGridView'e ekle
            foreach (var emanet in emanetler)
            {
                Kitap kitap = kitaplar.FirstOrDefault(k => k.KitapId == emanet.KitapId);
                Uye uye = uyeler.FirstOrDefault(u => u.UyeId == emanet.UyeId);

                dgvEmanetler.Rows.Add(emanet.EmanetId, kitap?.KitapAdi, uye?.Ad, emanet.EmanetTarihi, emanet.EkBilgi);
            }
        }
        private void DosyaOku()
        {
            try
            {
                string uyelerDosyaYolu = "uyeler.json";
                if (File.Exists(uyelerDosyaYolu))
                {
                    string jsonUyeler = File.ReadAllText(uyelerDosyaYolu);
                    uyeler = JsonConvert.DeserializeObject<List<Uye>>(jsonUyeler);
                }

                string kitaplarDosyaYolu = "kitaplar.json";
                if (File.Exists(kitaplarDosyaYolu))
                {
                    string jsonKitaplar = File.ReadAllText(kitaplarDosyaYolu);
                    kitaplar = JsonConvert.DeserializeObject<List<Kitap>>(jsonKitaplar);
                }

                string emanetlerDosyaYolu = "emanetler.json";
                if (File.Exists(emanetlerDosyaYolu))
                {
                    string jsonEmanetler = File.ReadAllText(emanetlerDosyaYolu);
                    emanetler = JsonConvert.DeserializeObject<List<Emanet>>(jsonEmanetler);
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
                string uyelerDosyaYolu = "uyeler.json";
                string jsonUyeler = JsonConvert.SerializeObject(uyeler, Formatting.Indented);
                File.WriteAllText(uyelerDosyaYolu, jsonUyeler);

                string kitaplarDosyaYolu = "kitaplar.json";
                string jsonKitaplar = JsonConvert.SerializeObject(kitaplar, Formatting.Indented);
                File.WriteAllText(kitaplarDosyaYolu, jsonKitaplar);

                string emanetlerDosyaYolu = "emanetler.json";
                string jsonEmanetler = JsonConvert.SerializeObject(emanetler, Formatting.Indented);
                File.WriteAllText(emanetlerDosyaYolu, jsonEmanetler);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya yazma hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmEmanetIslemleri frmEmanetIslemleri = new FrmEmanetIslemleri();
            frmEmanetIslemleri.Show();
            this.Hide();
        }

        private void btnEmanet_Click(object sender, EventArgs e)
        {
            Uye selectedUye = (Uye)cmbUyeler.SelectedItem;
            Kitap selectedKitap = (Kitap)lstKitaplar.SelectedItem;
            string ekBilgi = txtEkBilgi.Text;

            if (selectedUye != null && selectedKitap != null)
            {
                // Yeni emanet oluştur
                Emanet yeniEmanet = new Emanet
                {
                    UyeId = selectedUye.UyeId,
                    KitapId = selectedKitap.KitapId,
                    EmanetTarihi = DateTime.Now,
                    EkBilgi = ekBilgi
                };

                // Seçilen emanetin ID'sini al
                int selectedEmanetId = Convert.ToInt32(dgvEmanetler.SelectedRows[0].Cells["EmanetId"].Value);

                // Mevcut listedeki ilgili emaneti bul ve güncelle
                Emanet eskiEmanet = emanetler.FirstOrDefault(emanet => emanet.EmanetId == selectedEmanetId);
                if (eskiEmanet != null)
                {
                    eskiEmanet.UyeId = yeniEmanet.UyeId;
                    eskiEmanet.KitapId = yeniEmanet.KitapId;
                    eskiEmanet.EmanetTarihi = yeniEmanet.EmanetTarihi;
                    eskiEmanet.EkBilgi = yeniEmanet.EkBilgi;
                }

                // Listeyi JSON dosyasına yaz
                DosyaYaz();

                // Kullanıcıya bilgi mesajı göster
                MessageBox.Show("Emanet bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DataGridView'i güncelle
                dgvEmanetler.DataSource = null;
                dgvEmanetler.DataSource = emanetler;
            }
            else
            {
                MessageBox.Show("Lütfen bir üye ve bir kitap seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lstKitaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kitap selectedKitap = (Kitap)lstKitaplar.SelectedItem;

            if (selectedKitap != null)
            {
                txtEkBilgi.Enabled = true;
                btnEmanet.Enabled = true;
            }
            else
            {
                txtEkBilgi.Enabled = false;
                btnEmanet.Enabled = false;
            }
        }
    }
}
