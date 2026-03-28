using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class FrmAssign : Form
    {
        public int _assignmentId = 0; // 0 ise Yeni Atama, >0 ise Düzenleme

        // Constructor artık ID alıyor
        public FrmAssign(int id)
        {
            InitializeComponent();
            _assignmentId = id;
        }

        private void FrmAssign_Load(object sender, EventArgs e)
        {
            // Önce listeleri doldur
            AmirleriDoldur();
            MakineleriDoldur();

            // Eğer düzenleme modundaysak, mevcut bilgileri getir ve seçili yap
            if (_assignmentId > 0)
            {
                this.Text = "Atama Düzenle";
                btnSave.Text = "Güncelle";
                BilgileriGetir();
            }
            else
            {
                this.Text = "Yeni Atama";
                btnSave.Text = "Kaydet";
            }
        }

        void AmirleriDoldur()
        {
            try
            {
                string sorgu = "SELECT UserID, FullName FROM Users WHERE Role IN ('Amir', 'Admin')";
                DataTable dt = SqlHelper.GetTable(sorgu);
                cmbSupervisors.DataSource = dt;
                cmbSupervisors.DisplayMember = "FullName";
                cmbSupervisors.ValueMember = "UserID";
            }
            catch (Exception ex) { MessageBox.Show("Amirler yüklenemedi: " + ex.Message); }
        }

        void MakineleriDoldur()
        {
            try
            {
                string sorgu = "SELECT MachineID, Name FROM Machines";
                DataTable dt = SqlHelper.GetTable(sorgu);
                cmbMachines.DataSource = dt;
                cmbMachines.DisplayMember = "Name";
                cmbMachines.ValueMember = "MachineID";
            }
            catch (Exception ex) { MessageBox.Show("Makineler yüklenemedi: " + ex.Message); }
        }

        void BilgileriGetir()
        {
            try
            {
                // Mevcut kaydı çek
                string sorgu = "SELECT * FROM Assignments WHERE AssignmentID = " + _assignmentId;
                DataTable dt = SqlHelper.GetTable(sorgu);

                if (dt.Rows.Count > 0)
                {
                    // ComboBox'larda o ID'ye sahip satırı seçili hale getir
                    // Not: SelectedValue kullanmak için ValueMember'ların doğru ayarlanmış olması şart (yukarıda yaptık)
                    cmbSupervisors.SelectedValue = dt.Rows[0]["SupervisorID"];
                    cmbMachines.SelectedValue = dt.Rows[0]["MachineID"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler getirilemedi: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSupervisors.SelectedIndex == -1 || cmbMachines.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen seçimleri yapınız.");
                return;
            }

            try
            {
                int amirID = Convert.ToInt32(cmbSupervisors.SelectedValue);
                int makineID = Convert.ToInt32(cmbMachines.SelectedValue);
                string query = "";
                SqlParameter[] p;

                if (_assignmentId == 0) // EKLEME
                {
                    query = "INSERT INTO Assignments (SupervisorID, MachineID) VALUES (@amir, @makine)";
                    p = new SqlParameter[] {
                        new SqlParameter("@amir", amirID),
                        new SqlParameter("@makine", makineID)
                    };
                }
                else // GÜNCELLEME
                {
                    query = "UPDATE Assignments SET SupervisorID=@amir, MachineID=@makine WHERE AssignmentID=@id";
                    p = new SqlParameter[] {
                        new SqlParameter("@amir", amirID),
                        new SqlParameter("@makine", makineID),
                        new SqlParameter("@id", _assignmentId)
                    };
                }

                SqlHelper.ExecuteQuery(query, p);
                MessageBox.Show("İşlem Başarılı!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}