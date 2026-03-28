using System;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class MainFormAmir : Form
    {
        public MainFormAmir()
        {
            InitializeComponent();
        }

        // --- SAYFA DEĞİŞTİRME METODU (Standart) ---
        private void LoadPage(UserControl page)
        {
            pnlContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
        }

        // 1. DASHBOARD BUTONU
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Admin ile aynı Dashboard'u kullanabilir
            LoadPage(new UC_Dashboard());
        }

        // 2. EKİBİM BUTONU (btnMyTeam)
        private void btnMyTeam_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_MyTeam());
            // İleride buraya: LoadPage(new UC_MyTeam()); yazacağız.
        }

        // 3. SORUMLU MAKİNELER BUTONU (btnMyMachines)
        private void btnMyMachines_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_MyMachines());
            // İleride buraya: LoadPage(new UC_MyMachines()); yazacağız.
        }

        // 4. ÇIKIŞ BUTONU (Eğer eklediysen)
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            // 2. Rapor Formunu oluştur
            // ÖNEMLİ: Parantez içine "Amir" yazıyoruz ki grafikler açılsın.
            FrmRaporlar frm = new FrmRaporlar("Amir");

            // 3. İçine göm
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void btnBakim_Click(object sender, EventArgs e)
        {
            // 1. Orta paneldeki eski sayfayı temizle
            // (Senin panelinin adı neyse onu yaz: panelContent, mainPanel vb.)
            pnlContent.Controls.Clear();

            // 2. Bakım Sayfasını (UC_Maintenance) oluştur
            UC_Maintenance uc = new UC_Maintenance();
            uc.Dock = DockStyle.Fill; // Paneli doldur

            // 3. Panele ekle
            pnlContent.Controls.Add(uc);
        }
    }
}