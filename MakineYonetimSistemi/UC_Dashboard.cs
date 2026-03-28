using System.Data;
using System.Windows.Forms;
using System;

namespace MakineYonetimSistemi
{
    public partial class UC_Dashboard : UserControl
    {
        // BURASI CONSTRUCTOR (YAPICI METOT)
        public UC_Dashboard()
        {
            InitializeComponent();

            // --- EKLEMEN GEREKEN SATIR BU ---
            // Sayfa oluşur oluşmaz verileri çek diyoruz.
            DashboardVerileriniGetir();
        }

        // Bu kısım boş kalsa da olur artık, yukarıya taşıdık.
        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            // DashboardVerileriniGetir(); // Burayı silebilirsin veya yorum satırı yapabilirsin
        }

        public void DashboardVerileriniGetir()
        {
            try
            {
                // 1. TOPLAM MAKİNE (Bu zaten çalışıyordu)
                DataTable dtTotal = SqlHelper.GetTable("SELECT COUNT(*) FROM Machines");
                lblTotalMachine.Text = dtTotal.Rows[0][0].ToString();

                // 2. AKTİF MAKİNE
                // DÜZELTME: Veritabanında 'Aktif' değil 'Active' yazıyormuş.
                DataTable dtActive = SqlHelper.GetTable("SELECT COUNT(*) FROM Machines WHERE Status = 'Active'");
                lblActiveMachine.Text = dtActive.Rows[0][0].ToString();

                // 3. BAKIMDAKİ MAKİNE
                // Dedektif sonucuna göre: [Bakımda]
                DataTable dtMaintenance = SqlHelper.GetTable("SELECT COUNT(*) FROM Machines WHERE Status = 'Bakımda'");
                lblMaintenanceMachine.Text = dtMaintenance.Rows[0][0].ToString();

                // 4. ARIZALI MAKİNE
                // Dedektif sonucuna göre: [Arızalı]
                DataTable dtFaulty = SqlHelper.GetTable("SELECT COUNT(*) FROM Machines WHERE Status = 'Arızalı'");
                lblFaultyMachine.Text = dtFaulty.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}