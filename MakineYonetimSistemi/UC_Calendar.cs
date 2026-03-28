using System;
using System.Data;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class UC_Calendar : UserControl
    {
        public UC_Calendar()
        {
            InitializeComponent();
        }

        // Sayfa yüklenince takvimi oluştur
        private void UC_Calendar_Load(object sender, EventArgs e)
        {
            TakvimiDoldur();
        }

        private void TakvimiDoldur()
        {
            flowPanel.Controls.Clear(); // Önce temizle

            // 1. Veritabanından bu ayın bakım kayıtlarını çek
            // (LogDate tarihinin GÜN kısmını alıyoruz)
            string sorgu = @"
                SELECT DAY(LogDate) as Gun, Description 
                FROM MaintenanceLogs 
                WHERE MONTH(LogDate) = MONTH(GETDATE()) 
                AND YEAR(LogDate) = YEAR(GETDATE())";

            DataTable dt = SqlHelper.GetTable(sorgu);

            // 2. 1'den 30'a kadar kutuları oluştur
            int gunSayisi = 30; // Şimdilik standart 30 gün olsun

            for (int i = 1; i <= gunSayisi; i++)
            {
                // Yeni bir gün kutusu yarat
                UC_Day gunKutusu = new UC_Day();
                gunKutusu.GunYaz(i);

                // 3. Veritabanında bugün (i) için bir kayıt var mı?
                foreach (DataRow row in dt.Rows)
                {
                    if (Convert.ToInt32(row["Gun"]) == i)
                    {
                        // Varsa kutuya yaz (Örn: "Yağ Değişimi")
                        gunKutusu.IsEkle(row["Description"].ToString());
                    }
                }

                // Kutuyu ekrana ekle
                flowPanel.Controls.Add(gunKutusu);
            }
        }
    }
}