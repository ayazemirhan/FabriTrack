using System;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class MainFormPersonel : Form
    {
        public MainFormPersonel()
        {
            InitializeComponent();
        }

        // Sayfa Değiştirme Metodu
        private void LoadPage(UserControl page)
        {
            pnlContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
        }

        // Dashboard Butonu
        private void btnDash_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Dashboard()); // Admin'deki sayfayı aynen kullanıyoruz
        }

        // Bakım Bildirim Butonu
        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Maintenance()); // Admin'deki sayfayı aynen kullanıyoruz
        }

        // Çıkış Butonu
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Calendar());
        }

        private void btnPerformans_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            // 2. Formu oluştur ama FALSE gönder!
            // FALSE = "Ben Personelim, düzenleme butonlarını gizle" demektir.
            FrmPerformans frm = new FrmPerformans(false);

            // 3. Gömme işlemleri (Standart prosedür)
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // 4. Ekle ve Göster
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            // 2. Formu oluştur (Personel rolüyle)
            // Böylece FrmRaporlar içindeki IF bloğuna girmeyecek, grafikleri gizleyecek.
            FrmRaporlar frm = new FrmRaporlar("Personel");

            // 3. İçine göm
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(frm);
            frm.Show();
        }
    }
}