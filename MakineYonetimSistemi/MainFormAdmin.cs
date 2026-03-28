using MakineYonetimSistemi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MakineYonetimSistemi
{
    public partial class MainFormAdmin : Form
    {
        public MainFormAdmin()
        {
            InitializeComponent();
        }

        private void MainFormAdmin_Load(object sender, EventArgs e)
        {
            // Dashboard sayfasını oluştur
            UC_Dashboard dashboardSayfasi = new UC_Dashboard();

            // Orta paneli (pnlContent) tamamen kaplamasını söyle
            dashboardSayfasi.Dock = DockStyle.Fill;

            // Panelin içine ekle
            pnlContent.Controls.Add(dashboardSayfasi);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UC_Dashboard dashboard = new UC_Dashboard();
            LoadPage(dashboard);
        }

        private void btnMachines_Click(object sender, EventArgs e)
        {
            UC_Machines machines = new UC_Machines();
            LoadPage(machines);
        }

    // Sayfa değiştirmeyi sağlayan yardımcı kod
    private void LoadPage(UserControl page)
    {
        pnlContent.Controls.Clear(); // Eskiyi sil
        page.Dock = DockStyle.Fill;  // Yeniyi doldur
        pnlContent.Controls.Add(page); // Ekrana koy
    }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Users());
        }

        private void btnAssignments_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Assignments());
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Maintenance());
        }

        private void btnPerformans_Click(object sender, EventArgs e)
        {
            // 1. Önce panelin içini temizliyoruz (pnlContent)
            pnlContent.Controls.Clear();

            // 2. Formu oluşturuyoruz (Admin yetkisiyle)
            FrmPerformans frm = new FrmPerformans(true);

            // 3. Formu panel içine gömülecek hale getiriyoruz
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // 4. Panelin içine ekleyip gösteriyoruz
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            // BURAYA DİKKAT: Test etmek için "Amir" yaz, grafikleri gör.
            // Normalde: "Admin" yazacaksın.
            FrmRaporlar frm = new FrmRaporlar("Amir");

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(frm);
            frm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}



