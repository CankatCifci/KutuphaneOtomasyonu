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
using System.Data.SQLite;

namespace WindowsFormsApp2
{
    public partial class FrmEmanetIslemleri : Form
    {
        private List<Uye> uyeler;
        private List<Kitap> kitaplar;
        private List<Emanet> emanetler;
        private string databasePath = DatabaseHelper.databasePath;

        public FrmEmanetIslemleri()
        {
            InitializeComponent();
            uyeler = new List<Uye>();
            kitaplar = new List<Kitap>();
            emanetler = new List<Emanet>();
            DosyaOku(); // Mevcut üyeleri, kitapları ve emanetleri dosyadan oku
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void EmanetIslemleri_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
            // Verileri yükleme gibi
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

        private void btnEmanet_Click(object sender, EventArgs e)
        {
            // Seçilen üye ve kitap bilgilerine göre yeni bir emanet oluştur
            Uye selectedUye = (Uye)cmbUyeler.SelectedItem;
            Kitap selectedKitap = (Kitap)lstKitaplar.SelectedItem;
            string ekBilgi = txtEkBilgi.Text;

            if (selectedUye != null && selectedKitap != null)
            {
                Emanet yeniEmanet = new Emanet
                {

                    UyeId = selectedUye.UyeId,
                    KitapId = selectedKitap.KitapId,
                    EmanetTarihi = DateTime.Now,
                    EkBilgi = ekBilgi
                };

                // Yeni emaneti listeye ekle
                emanetler.Add(yeniEmanet);

                // Listeyi JSON dosyasına yaz
                DosyaYaz();

                // Kullanıcıya bilgi mesajı göster
                MessageBox.Show("Kitap başarıyla emanet edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DataGridView'i güncelle
                dgvEmanetler.DataSource = null;
                dgvEmanetler.DataSource = emanetler;
            }
            else
            {
                MessageBox.Show("Lütfen bir üye ve bir kitap seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnIade_Click(object sender, EventArgs e)
        {
            // Seçilen emanetin iade edilmesi işlemi gerçekleştirilir.
            // Örnek olarak DataGridView'dan seçilen satırın bilgileri alınabilir.
            MessageBox.Show("Kitap başarıyla iade edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // İade işlemi gerçekleştiğinde gerekli işlemler yapılır.
            // Örneğin, seçilen emanetin listeden kaldırılması gerekebilir.
        }

        private void DosyaOku()
        {
            try
            {
                // Üyeleri dosyadan değil de veritabanından al
                string selectUyelerQuery = "SELECT * FROM Uye";
                using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(selectUyelerQuery, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Uye uye = new Uye
                                {
                                    UyeId = Convert.ToInt32(reader["UyeId"]),
                                    Ad = Convert.ToString(reader["Ad"]),
                                    Soyad = Convert.ToString(reader["Soyad"]),
                                    
                                };
                                uyeler.Add(uye);
                            }
                        }
                    }
                }

                // Kitapları dosyadan değil de veritabanından al
                string selectKitaplarQuery = "SELECT * FROM Kitap";
                using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(selectKitaplarQuery, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Kitap kitap = new Kitap
                                {
                                    KitapId = Convert.ToInt32(reader["KitapId"]),
                                    KitapAdi = Convert.ToString(reader["KitapAdi"]),
                                    Yazar = Convert.ToString(reader["Yazar"])
                                };
                                kitaplar.Add(kitap);
                            }
                        }
                    }
                }

                // Emanetleri dosyadan değil de veritabanından al
                string selectEmanetlerQuery = "SELECT * FROM Emanet";
                using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(selectEmanetlerQuery, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Emanet emanet = new Emanet
                                {
                                    EmanetId = Convert.ToInt32(reader["EmanetId"]),
                                    UyeId = Convert.ToInt32(reader["UyeId"]),
                                    KitapId = Convert.ToInt32(reader["KitapId"]),
                                  
                                };
                                emanetler.Add(emanet);
                            }
                        }
                    }
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

        private void lstKitaplar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ListBox'ta seçili öğe değiştiğinde yapılacak işlemler
            // Örneğin, seçili kitaba göre ek bilgi ve emanet butonunun etkinleştirilip devre dışı bırakılması
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

        private void btnEmanet_Click_1(object sender, EventArgs e)
        {
            // Seçilen üye ve kitap bilgilerine göre yeni bir emanet oluştur
            Uye selectedUye = (Uye)cmbUyeler.SelectedItem;
            Kitap selectedKitap = (Kitap)lstKitaplar.SelectedItem;
            string ekBilgi = txtEkBilgi.Text;

            if (selectedUye != null && selectedKitap != null)
            {
                // Yeni emanet nesnesi oluştur
                Emanet yeniEmanet = new Emanet
                {
                    UyeId = selectedUye.UyeId,
                    KitapId = selectedKitap.KitapId,
                    EmanetTarihi = DateTime.Now,
                    EkBilgi = ekBilgi
                };

                // Emaneti veritabanına kaydet
                KaydetEmanet(yeniEmanet);

                // Kullanıcıya bilgi mesajı göster
                MessageBox.Show("Kitap başarıyla emanet edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // DataGridView'i güncelle
                dgvEmanetler.DataSource = null;
                dgvEmanetler.DataSource = emanetler;
            }
            else
            {
                MessageBox.Show("Lütfen bir üye ve bir kitap seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void KaydetEmanet(Emanet emanet)
        {
            using (var connection = new SQLiteConnection("Data Source=" + databasePath + ";Version=3;"))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Emanet (UyeId, KitapId, EmanetTarihi, EkBilgi) VALUES (@UyeId, @KitapId, @EmanetTarihi, @EkBilgi)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@UyeId", emanet.UyeId);
                    command.Parameters.AddWithValue("@KitapId", emanet.KitapId);
                    command.Parameters.AddWithValue("@EmanetTarihi", emanet.EmanetTarihi);
                    command.Parameters.AddWithValue("@EkBilgi", emanet.EkBilgi);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnIade_Click_1(object sender, EventArgs e)
        {
            {
                DataGridViewRow selectedRow = dgvEmanetler.SelectedRows[0];

                // Seçili emanetin ID'sini al
                int emanetId = Convert.ToInt32(selectedRow.Cells["EmanetId"].Value);

                // Seçili emaneti listeden kaldır
                Emanet emanetToRemove = emanetler.FirstOrDefault(emanet => emanet.EmanetId == emanetId);
                emanetler.Remove(emanetToRemove);

                // DataGridView'i güncelle
                dgvEmanetler.DataSource = null;
                dgvEmanetler.DataSource = emanetler;

                // İlgili emanetin kitap ve üye bağlantısını kaldır
                emanetToRemove.UyeId = 0;
                emanetToRemove.KitapId = 0;

                // Listeyi JSON dosyasına yaz
                DosyaYaz();

                MessageBox.Show("Kitap başarıyla iade edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dgvEmanetler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedEmanetId = Convert.ToInt32(dgvEmanetler.SelectedRows[0].Cells["EmanetId"].Value);

            // Seçilen emaneti bul
            Emanet selectedEmanet = emanetler.FirstOrDefault(emanet => emanet.EmanetId == selectedEmanetId);

            if (selectedEmanet != null)
            {
                // Düzenleme formunu oluştur ve seçilen emaneti parametre olarak gönder
                FrmEmanetDuzenle frmEmanetDuzenle = new FrmEmanetDuzenle(selectedEmanet);
                frmEmanetDuzenle.ShowDialog();

                // Düzenleme formundan geri dönüldüğünde, güncelleme yapılmış olabilir, bu yüzden listeyi tekrar yükle
                DosyaOku();
                dgvEmanetler.DataSource = null;
                dgvEmanetler.DataSource = emanetler;
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir emanet seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}