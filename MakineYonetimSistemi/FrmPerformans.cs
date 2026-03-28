using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MakineYonetimSistemi // Proje adınla aynı olduğundan emin ol!
{
    public partial class FrmPerformans : Form
    {
        private bool _isAdmin;
        // Sunucu adresin (Başına @ koyduk)
        string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=FabriTrack;Integrated Security=True";

        public FrmPerformans(bool adminMi)
        {
            InitializeComponent();
            _isAdmin = adminMi;
            TabloyuHazirla();
            MakineleriGetirSQL();
        }

        private void TabloyuHazirla()
        {
            dgvMetrikler.Columns.Clear();
            dgvMetrikler.Columns.Add("Metrik", "Metrik");
            dgvMetrikler.Columns.Add("Deger", "Değer");
            dgvMetrikler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMetrikler.BackgroundColor = Color.White;
            dgvMetrikler.RowHeadersVisible = false;
            dgvMetrikler.AllowUserToAddRows = false;
        }

        private void MakineleriGetirSQL()
        {
            flowMakineler.Controls.Clear(); // Ekranı temizle

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                try
                {
                    baglanti.Open();
                    string sorgu = "SELECT MachineID, Name, Status FROM Machines";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);
                    SqlDataReader dr = komut.ExecuteReader();

                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr["MachineID"]);
                        string ad = dr["Name"].ToString();
                        string dbDurum = dr["Status"].ToString(); // Veritabanından gelen ham veri (İngilizce)

                        // --- KUTU TASARIMI ---
                        Panel pnl = new Panel();
                        pnl.Size = new Size(240, 140);
                        pnl.Margin = new Padding(15);
                        pnl.BorderStyle = BorderStyle.FixedSingle;
                        pnl.Cursor = Cursors.Hand;
                        pnl.Tag = id;

                        // --- ÇEVİRİ VE RENK MANTIĞI (DÜZELTİLEN KISIM) ---
                        string gorunenYazi = "";

                        // 1. ARIZALI DURUMU
                        if (dbDurum == "Faulty" || dbDurum == "Arızalı")
                        {
                            pnl.BackColor = Color.Crimson; // Kırmızı
                            gorunenYazi = "ARIZALI";
                        }
                        // 2. BAKIM DURUMU (Maintenance kelimesini burada yakalıyoruz)
                        else if (dbDurum == "Maintenance" || dbDurum == "Bakımda")
                        {
                            pnl.BackColor = Color.Orange; // Sarı/Turuncu
                            gorunenYazi = "BAKIMDA";
                        }
                        // 3. AKTİF DURUMU (Diğer her şey)
                        else
                        {
                            pnl.BackColor = Color.SeaGreen; // Yeşil
                            gorunenYazi = "AKTİF";
                        }

                        // MAKİNE ADI
                        Label lblAd = new Label();
                        lblAd.Text = ad;
                        lblAd.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                        lblAd.ForeColor = Color.White;
                        lblAd.Location = new Point(10, 10);
                        lblAd.AutoSize = true;
                        pnl.Controls.Add(lblAd);

                        // DURUM YAZISI (Artık Türkçeye çevrilmiş hali yazacak)
                        Label lblDurum = new Label();
                        lblDurum.Text = gorunenYazi;
                        lblDurum.ForeColor = Color.WhiteSmoke;
                        lblDurum.Location = new Point(10, 40);
                        pnl.Controls.Add(lblDurum);

                        // --- ADMİN İŞLEMLERİ ---
                        if (_isAdmin)
                        {
                            Label lblEdit = new Label();
                            lblEdit.Text = "Sil / Düzenle ⚙️";
                            lblEdit.Font = new Font("Segoe UI", 9, FontStyle.Italic);
                            lblEdit.ForeColor = Color.Yellow;
                            lblEdit.Location = new Point(10, 100);
                            lblEdit.Cursor = Cursors.Hand;

                            lblEdit.Click += (s, e) => AdminMenusuAc(id, ad, lblEdit);

                            pnl.Controls.Add(lblEdit);
                        }

                        // TIKLAMA
                        pnl.Click += Kart_Click;
                        lblAd.Click += (s, e) => Kart_Click(pnl, e);
                        lblDurum.Click += (s, e) => Kart_Click(pnl, e);

                        flowMakineler.Controls.Add(pnl);
                    }
                    baglanti.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        // --- YENİ EKLENEN: ADMİN MENÜSÜ ---
        private void AdminMenusuAc(int id, string ad, Control tiklananYer)
        {
            // Sağ tık menüsü (Context Menu) oluşturuyoruz
            ContextMenuStrip menu = new ContextMenuStrip();

            // 1. Seçenek: Durum Değiştir
            ToolStripMenuItem durumItem = new ToolStripMenuItem("Durum Değiştir");
            durumItem.DropDownItems.Add("Aktif Yap", null, (s, e) => DurumGuncelle(id, "Active"));
            durumItem.DropDownItems.Add("Arızaya Çek", null, (s, e) => DurumGuncelle(id, "Faulty"));
            durumItem.DropDownItems.Add("Bakıma Al", null, (s, e) => DurumGuncelle(id, "Maintenance"));
            menu.Items.Add(durumItem);

            // 2. Seçenek: Sil
            menu.Items.Add("Makineyi Sil 🗑️", null, (s, e) => MakineSil(id, ad));

            // Menüyü farenin olduğu yerde aç
            menu.Show(tiklananYer, new Point(0, tiklananYer.Height));
        }

        // --- SQL GÜNCELLEME (UPDATE) ---
        private void DurumGuncelle(int id, string yeniDurum)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Machines SET Status = @st WHERE MachineID = @id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@st", yeniDurum);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();

                    // Ekranı yenile ki renk değişsin
                    MakineleriGetirSQL();
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

        // --- SQL SİLME (DELETE) ---
        private void MakineSil(int id, string ad)
        {
            DialogResult cevap = MessageBox.Show(ad + " adlı makineyi silmek istediğine emin misin?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM Machines WHERE MachineID = @id";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();

                        // Ekranı yenile
                        MakineleriGetirSQL();
                        MessageBox.Show("Makine silindi.");
                    }
                    catch (Exception ex) { MessageBox.Show("Silinemedi (Başka verilerle ilişkili olabilir).\nHata: " + ex.Message); }
                }
            }
        }

        private void Kart_Click(object sender, EventArgs e)
        {
            // 1. Tıklanan makinenin ID'sini al
            Panel pnl = (sender as Panel);
            int id = Convert.ToInt32(pnl.Tag);

            lblSecilenMakine.Text = "Seçilen Makine ID: " + id;

            // Listeleri ve Tabloyu Temizle
            dgvMetrikler.Rows.Clear();
            listBakimYapan.Items.Clear();
            listBakimTarih.Items.Clear();

            // 2. SQL'DEN VERİLERİ ÇEK (DURUM + TARİH)
            string durum = "";
            string sonBakimTarihi = "Kayıt Yok"; // Varsayılan

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Sadece Status değil, LastMaintenanceDate sütununu da istiyoruz
                    SqlCommand cmd = new SqlCommand("SELECT Status, LastMaintenanceDate FROM Machines WHERE MachineID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        // Durumu al
                        if (dr["Status"] != DBNull.Value)
                            durum = dr["Status"].ToString();

                        // Tarihi al (Eğer boş değilse)
                        if (dr["LastMaintenanceDate"] != DBNull.Value)
                        {
                            DateTime tarih = Convert.ToDateTime(dr["LastMaintenanceDate"]);
                            sonBakimTarihi = tarih.ToShortDateString(); // Sadece tarih kısmı (Saat yok)
                        }
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri okuma hatası: " + ex.Message);
                }
            }

            // 3. LİSTELERİ DOLDUR (Bakım Bilgileri)

            // Tarihi Listeye Ekle (SQL'den gelen gerçek tarih)
            listBakimTarih.Items.Add(sonBakimTarihi);

            // Bakım Yapan Kişiyi Simüle Et (Tabloda sütun olmadığı için)
            // Eğer ileride 'TechnicianName' gibi bir sütun eklersen burayı SQL'den çekersin.
            string[] ustalar = { "Ahmet Yılmaz (Usta)", "Mehmet Demir (Şef)", "Ali Veli (Tekniker)", "Ayşe Kaya (Müh.)" };
            Random rnd = new Random();

            // Her tıklamada rastgele bir isim seçsin ki dolu gözüksün
            int ustaIndex = rnd.Next(0, ustalar.Length);
            listBakimYapan.Items.Add(ustalar[ustaIndex]);


            // 4. SCADA SİMÜLASYONU (Sıcaklık/Basınç Değerleri)
            if (durum == "Faulty" || durum == "Arızalı" || durum == "ARIZALI")
            {
                // ARIZALIYSA
                int sicaklik = rnd.Next(95, 120);
                double basinc = rnd.Next(80, 100) / 10.0;

                dgvMetrikler.Rows.Add("Motor Sıcaklığı", sicaklik + " °C", "KRİTİK");
                dgvMetrikler.Rows.Add("Yağ Basıncı", basinc + " Bar", "YÜKSEK");
                dgvMetrikler.Rows.Add("Titreşim", "15 mm/s", "TEHLİKELİ");

                dgvMetrikler.Rows[0].DefaultCellStyle.ForeColor = Color.Red;
                dgvMetrikler.Rows[1].DefaultCellStyle.ForeColor = Color.Red;
            }
            else if (durum == "Maintenance" || durum == "Bakımda" || durum == "BAKIMDA")
            {
                // BAKIMDAYSA
                dgvMetrikler.Rows.Add("Motor Sıcaklığı", "25 °C", "Soğuk");
                dgvMetrikler.Rows.Add("Yağ Basıncı", "0 Bar", "Kapalı");
                dgvMetrikler.Rows.Add("Durum", "Bakım Modu", "Güvenli");

                dgvMetrikler.Rows[0].DefaultCellStyle.ForeColor = Color.Orange;
            }
            else
            {
                // AKTİFSE
                int sicaklik = rnd.Next(55, 75);
                double basinc = rnd.Next(30, 50) / 10.0;

                dgvMetrikler.Rows.Add("Motor Sıcaklığı", sicaklik + " °C", "Normal");
                dgvMetrikler.Rows.Add("Yağ Basıncı", basinc + " Bar", "Stabil");
                dgvMetrikler.Rows.Add("Üretim Hızı", rnd.Next(100, 150) + " adet/dk", "İyi");

                dgvMetrikler.Rows[0].DefaultCellStyle.ForeColor = Color.Green;
            }
        }
    }

}