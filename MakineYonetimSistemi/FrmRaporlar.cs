using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MakineYonetimSistemi
{
    public partial class FrmRaporlar : Form
    {
        // --- DEĞİŞKENLER ---
        string _rol;

        // --- GİRİŞ KAPISI ---
        public FrmRaporlar(string rol)
        {
            InitializeComponent();
            _rol = rol;
        }

        // --- SAYFA YÜKLENİNCE ---
        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            // 1. Görsel Ayarlar
            cmbRaporTipi.Items.Clear();
            cmbRaporTipi.Items.Add("Genel Durum Raporu");
            cmbRaporTipi.SelectedIndex = 0;

            // 2. Tarih Ayarları (Varsayılan: Son 1 YIL yapalım ki veri görünsün)
            dtBitis.Value = DateTime.Now;
            dtBaslangic.Value = DateTime.Now.AddYears(-1); // Dikkat: Süreyi uzattım

            // 3. Grafik Temizliği
            GrafikTasariminiGuzellestir();

            // 4. ROL KONTROLÜ
            if (_rol == "Amir" || _rol == "Admin")
            {
                // YÖNETİCİ MODU
                pnlDashboard.Visible = true;
                pnlKartlar.Visible = true;
                chartRapor.Visible = true;

                // Verileri Çek
                YoneticiVerileriniGetir();
            }
            else
            {
                // PERSONEL MODU
                pnlKartlar.Visible = false;
                chartRapor.Visible = false;

                // Sadece listeyi çek
                PersonelListesiniGetir();
            }
        }

        // --- GRAFİK GÖRSEL AYARLARI ---
        private void GrafikTasariminiGuzellestir()
        {
            chartRapor.Series.Clear();
            chartRapor.Legends.Clear();
            chartRapor.Titles.Clear();
            chartRapor.Titles.Add("Aylık Bakım Performansı").Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Eğer ChartArea yoksa hata vermesin diye kontrol
            if (chartRapor.ChartAreas.Count > 0)
            {
                chartRapor.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chartRapor.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            }
        }

        // --- BUTON: RAPORLA ---
        private void btnRaporla_Click(object sender, EventArgs e)
        {
            if (_rol == "Personel")
            {
                PersonelListesiniGetir();
            }
            else
            {
                YoneticiVerileriniGetir();
            }
            MessageBox.Show("Rapor güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- YÖNETİCİ İŞLEMLERİ (SqlHelper Kullanarak) ---
        private void YoneticiVerileriniGetir()
        {
            try
            {
                // Tarih formatını SQL'e uygun hale getirelim (YYYY-MM-DD)
                string bas = dtBaslangic.Value.ToString("yyyy-MM-dd");
                string bit = dtBitis.Value.ToString("yyyy-MM-dd");

                // A) KARTLARDAKİ SAYILAR
                // 1. Tamamlanan
                DataTable dtTamam = SqlHelper.GetTable($"SELECT COUNT(*) FROM MaintenanceLogs WHERE Status IN ('Completed', 'Tamamlandı') AND LogDate BETWEEN '{bas}' AND '{bit}'");
                lbl1.Text = dtTamam.Rows[0][0].ToString() + "\nTamamlanan";
                lbl1.ForeColor = Color.DodgerBlue;

                // 2. Geciken (Tarihi geçmiş ve hala bekliyor olanlar)
                DataTable dtGeciken = SqlHelper.GetTable("SELECT COUNT(*) FROM MaintenanceLogs WHERE Status IN ('Pending', 'Bekliyor') AND PlannedDate < GETDATE()");
                lbl2.Text = dtGeciken.Rows[0][0].ToString() + "\nGeciken";
                lbl2.ForeColor = Color.Crimson;

                // 3. Arıza
                DataTable dtAriza = SqlHelper.GetTable($"SELECT COUNT(*) FROM MaintenanceLogs WHERE LogType IN ('Fault', 'Arıza', 'Faulty') AND LogDate BETWEEN '{bas}' AND '{bit}'");
                lbl3.Text = dtAriza.Rows[0][0].ToString() + "\nArıza Kaydı";
                lbl3.ForeColor = Color.Orange;

                // 4. Personel Sayısı
                DataTable dtPers = SqlHelper.GetTable("SELECT COUNT(*) FROM Users WHERE IsActive = 1"); // IsActive sütunu yoksa 'WHERE 1=1' yapabilirsin
                lbl4.Text = dtPers.Rows[0][0].ToString() + "\nPersonel";
                lbl4.ForeColor = Color.SeaGreen;


                // B) GRAFİK DOLDURMA
                chartRapor.Series.Clear();
                Series seri = new Series("Bakımlar");
                seri.ChartType = SeriesChartType.Column;
                seri.Color = Color.FromArgb(65, 140, 240);
                seri.IsValueShownAsLabel = true; // Sütunların üzerine sayı yazsın

                string sqlGrafik = $@"
                    SELECT DATENAME(MONTH, LogDate) AS Ay, COUNT(*) AS Sayi 
                    FROM MaintenanceLogs 
                    WHERE LogDate BETWEEN '{bas}' AND '{bit}'
                    GROUP BY DATENAME(MONTH, LogDate), MONTH(LogDate) 
                    ORDER BY MONTH(LogDate)";

                DataTable dtGrafik = SqlHelper.GetTable(sqlGrafik);

                foreach (DataRow dr in dtGrafik.Rows)
                {
                    // X eksenine Ay ismini (ilk 3 harf), Y eksenine Sayıyı bas
                    string ayAdi = dr["Ay"].ToString();
                    if (ayAdi.Length > 3) ayAdi = ayAdi.Substring(0, 3);

                    seri.Points.AddXY(ayAdi, dr["Sayi"]);
                }
                chartRapor.Series.Add(seri);


                // C) TABLO DOLDURMA (Yönetici Özeti - Kim ne kadar iş yapmış)
                dgvListe.Rows.Clear();
                dgvListe.Columns.Clear();
                dgvListe.Columns.Add("Ad", "Personel Adı");
                dgvListe.Columns.Add("Is", "Tamamlanan İş");
                dgvListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvListe.BackgroundColor = Color.White;

                string sqlTablo = @"
                    SELECT u.FullName, COUNT(m.LogID) as IslemSayisi 
                    FROM Users u 
                    LEFT JOIN MaintenanceLogs m ON u.UserID = m.UserID 
                    WHERE m.Status IN ('Completed', 'Tamamlandı')
                    GROUP BY u.FullName 
                    ORDER BY IslemSayisi DESC";

                DataTable dtTablo = SqlHelper.GetTable(sqlTablo);
                foreach (DataRow dr in dtTablo.Rows)
                {
                    dgvListe.Rows.Add(dr["FullName"], dr["IslemSayisi"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
        }

        // --- PERSONEL İŞLEMLERİ ---
        private void PersonelListesiniGetir()
        {
            try
            {
                dgvListe.Rows.Clear();
                dgvListe.Columns.Clear();

                // Tablo Başlıkları
                dgvListe.Columns.Add("Tarih", "Tarih");
                dgvListe.Columns.Add("Islem", "İşlem Tipi");
                dgvListe.Columns.Add("Aciklama", "Açıklama");
                dgvListe.Columns.Add("Durum", "Durum");
                dgvListe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvListe.BackgroundColor = Color.White;
                dgvListe.RowHeadersVisible = false;

                // Verileri Çek
                string sql = "SELECT LogDate, LogType, Description, Status FROM MaintenanceLogs ORDER BY LogDate DESC";
                DataTable dt = SqlHelper.GetTable(sql);

                foreach (DataRow dr in dt.Rows)
                {
                    dgvListe.Rows.Add(
                        Convert.ToDateTime(dr["LogDate"]).ToShortDateString(),
                        dr["LogType"].ToString(),
                        dr["Description"].ToString(),
                        dr["Status"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liste hatası: " + ex.Message);
            }
        }
    }
}