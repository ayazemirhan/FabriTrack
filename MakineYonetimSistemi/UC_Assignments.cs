using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MakineYonetimSistemi
{
    public partial class UC_Assignments : UserControl
    {
        public UC_Assignments()
        {
            InitializeComponent();
        }

        private void UC_Assignments_Load(object sender, EventArgs e)
        {
            ListeyiGetir();
        }

        public void ListeyiGetir()
        {
            try
            {
                string sorgu = @"
                    SELECT 
                        A.AssignmentID, 
                        U.FullName AS 'Sorumlu Amir', 
                        M.Name AS 'Makine Adı', 
                        M.SerialNo AS 'Seri No',
                        M.Status AS 'Makine Durumu'
                    FROM Assignments A
                    JOIN Users U ON A.SupervisorID = U.UserID
                    JOIN Machines M ON A.MachineID = M.MachineID";

                DataTable dt = SqlHelper.GetTable(sorgu);
                dgvAssignments.DataSource = dt;

                if (dgvAssignments.Columns["AssignmentID"] != null)
                    dgvAssignments.Columns["AssignmentID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme Hatası: " + ex.Message);
            }
        }

        // LİSTELE BUTONU
        // Tasarımda butona çift tıklayıp bu kodun oluştuğundan emin ol!
        private void btnListele_Click(object sender, EventArgs e)
        {
            ListeyiGetir();
        }

        // YENİ ATAMA BUTONU
        private void btnAssign_Click(object sender, EventArgs e)
        {
            FrmAssign frm = new FrmAssign(0); // 0 = Yeni Ekle
            frm.ShowDialog();
            ListeyiGetir();
        }

        // DÜZENLE BUTONU
        private void btnEdit_Click(object sender, EventArgs e)
        {
            KayitDuzenle();
        }

        // SİL BUTONU
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAssignments.SelectedRows.Count > 0)
            {
                DialogResult cevap = MessageBox.Show("Bu atamayı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cevap == DialogResult.Yes)
                {
                    try
                    {
                        string id = dgvAssignments.SelectedRows[0].Cells["AssignmentID"].Value.ToString();
                        string sorgu = "DELETE FROM Assignments WHERE AssignmentID = @id";
                        SqlParameter[] p = { new SqlParameter("@id", id) };
                        SqlHelper.ExecuteQuery(sorgu, p);
                        ListeyiGetir();
                    }
                    catch (Exception ex) { MessageBox.Show("Silme Hatası: " + ex.Message); }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }

        // Tabloya Çift Tıklama
        private void dgvAssignments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) KayitDuzenle();
        }

        // Ortak Düzenleme Fonksiyonu
        private void KayitDuzenle()
        {
            if (dgvAssignments.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvAssignments.SelectedRows[0].Cells["AssignmentID"].Value);
                FrmAssign frm = new FrmAssign(id); // ID ile aç = Düzenle
                frm.ShowDialog();
                ListeyiGetir();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir satır seçin.");
            }
        }
    }
}