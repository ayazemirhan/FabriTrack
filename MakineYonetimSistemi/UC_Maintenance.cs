using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MakineYonetimSistemi
{
    public partial class UC_Maintenance : UserControl
    {
        public UC_Maintenance()
        {
            InitializeComponent();
        }

        private void UC_Maintenance_Load(object sender, EventArgs e)
        {
            ListeyiGetir();

            // --- BU SATIRI TEST İÇİN EKLE ---
            //MessageBox.Show("Gelen Rol: -" + Program.CurrentUserRole + "-");
            // (Tire işaretlerini bilerek koydum ki başında/sonunda boşluk varsa görelim)
            // --------------------------------

            if (Program.CurrentUserRole == "Amir" || Program.CurrentUserRole == "Admin")
            {
                btnApprove.Visible = true;
            }
            else
            {
                btnApprove.Visible = false;
            }
        }

        public void ListeyiGetir()
        {
            try
            {
                // JOIN İŞLEMİ:
                // ID'leri değil, Makine Adını ve Personel Adını gösteriyoruz.
                string sorgu = @"
                    SELECT 
                        L.LogID, 
                        M.Name AS 'Makine', 
                        U.FullName AS 'Personel', 
                        L.LogType AS 'Tür', 
                        L.Description AS 'Açıklama', 
                        L.Status AS 'Durum',
                        L.LogDate AS 'Tarih'
                    FROM MaintenanceLogs L
                    JOIN Machines M ON L.MachineID = M.MachineID
                    JOIN Users U ON L.UserID = U.UserID
                    ORDER BY L.LogDate DESC"; // En yeniler en üstte

                DataTable dt = SqlHelper.GetTable(sorgu);
                dgvMaintenance.DataSource = dt;

                // LogID'yi gizle (Kullanıcı görmesin ama arkada işimize yarayacak)
                if (dgvMaintenance.Columns["LogID"] != null)
                    dgvMaintenance.Columns["LogID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme Hatası: " + ex.Message);
            }
        }

        // --- BUTON İŞLEMLERİ ---

        // 1. LİSTELE BUTONU
        private void btnListele_Click(object sender, EventArgs e)
        {
            ListeyiGetir();
        }

        // 2. YENİ EKLE BUTONU
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmMaintenanceAdd frm = new FrmMaintenanceAdd(0); // 0 = Yeni Ekle
            frm.ShowDialog();
            ListeyiGetir();
        }

        // 3. DÜZENLE BUTONU
        private void btnEdit_Click(object sender, EventArgs e)
        {
            KayitDuzenle();
        }

        // 4. SİL BUTONU
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.SelectedRows.Count > 0)
            {
                DialogResult cevap = MessageBox.Show("Bu bakım kaydını silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (cevap == DialogResult.Yes)
                {
                    try
                    {
                        string id = dgvMaintenance.SelectedRows[0].Cells["LogID"].Value.ToString();
                        string sorgu = "DELETE FROM MaintenanceLogs WHERE LogID = @id";
                        SqlParameter[] p = { new SqlParameter("@id", id) };

                        SqlHelper.ExecuteQuery(sorgu, p);
                        ListeyiGetir();
                    }
                    catch (Exception ex) { MessageBox.Show("Silme Hatası: " + ex.Message); }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir kayıt seçin.");
            }
        }

        // 5. ONAYLA BUTONU (AMİR İÇİN YENİ EKLENEN KISIM)
        // Tasarım ekranında 'btnApprove' butonuna çift tıklayarak bu event'i oluşturmalısın.
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvMaintenance.SelectedRows.Count > 0)
            {
                string mevcutDurum = dgvMaintenance.SelectedRows[0].Cells["Durum"].Value.ToString();

                if (mevcutDurum == "Tamamlandı")
                {
                    MessageBox.Show("Bu iş zaten tamamlanmış.");
                    return;
                }

                DialogResult cevap = MessageBox.Show("Bu işi onaylayıp 'Tamamlandı' olarak işaretlemek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(dgvMaintenance.SelectedRows[0].Cells["LogID"].Value);

                        // Durumu 'Tamamlandı' yapıyoruz
                        string sorgu = "UPDATE MaintenanceLogs SET Status = 'Tamamlandı' WHERE LogID = @id";
                        SqlParameter[] p = { new SqlParameter("@id", id) };

                        SqlHelper.ExecuteQuery(sorgu, p);

                        MessageBox.Show("İş onaylandı ve başarıyla tamamlandı!");
                        ListeyiGetir(); // Listeyi yenile
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen onaylamak için listeden bir kayıt seçin.");
            }
        }

        // Tabloya Çift Tıklayınca Düzenle
        private void dgvMaintenance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) KayitDuzenle();
        }

        private void KayitDuzenle()
        {
            if (dgvMaintenance.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvMaintenance.SelectedRows[0].Cells["LogID"].Value);
                FrmMaintenanceAdd frm = new FrmMaintenanceAdd(id); // ID gönderiyoruz
                frm.ShowDialog();
                ListeyiGetir();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir kayıt seçin.");
            }
        }
    }
}