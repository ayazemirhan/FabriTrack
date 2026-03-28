using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class UC_Machines : UserControl
    {
        public UC_Machines()
        {
            InitializeComponent();
        }

        private void UC_Machines_Load(object sender, EventArgs e)
        {
            // 1. Senin projedeki metodun adı bu:
            ListeyiYenile();

            // 2. Senin projedeki tablonun adı bu:
            dgvMachines.Visible = true;
        }

        public void ListeyiYenile()
        {
            // SQL'den makineleri çekiyoruz
            string sorgu = "SELECT MachineID, Name AS 'Makine Adı', SerialNo AS 'Seri No', Type AS 'Tür', Status AS 'Durum' FROM Machines";
            DataTable dt = SqlHelper.GetTable(sorgu);
            dgvMachines.DataSource = dt;
        }

        // SİLME BUTONU (Şimdiden ekleyelim, lazım olacak)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMachines.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Silmek istiyor musun?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvMachines.SelectedRows[0].Cells["MachineID"].Value);
                    SqlHelper.ExecuteQuery("DELETE FROM Machines WHERE MachineID = " + id);
                    ListeyiYenile();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Yeni formu oluştur
            FrmMachineAdd frm = new FrmMachineAdd();

            // Formu "Pop-up" olarak aç (ShowDialog programı durdurur)
            frm.ShowDialog();

            // Form kapanınca listeyi yenile (ki yeni eklenen görünsün)
            ListeyiYenile();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ListeyiYenile();

            // Tabloyu görünür yap
            dgvMachines.Visible = true;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvMachines.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bu makineyi ve ONA AİT TÜM KAYITLARI (Atamalar, Bakımlar) silmek istediğinize emin misiniz?", "Kritik Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int secilenId = Convert.ToInt32(dgvMachines.SelectedRows[0].Cells["MachineID"].Value);

                        // GÜNCELLENMİŞ SQL SORGUSU:
                        string sql = "DELETE FROM Assignments WHERE MachineID = @id; DELETE FROM MaintenanceLogs WHERE MachineID = @id; DELETE FROM Machines WHERE MachineID = @id";

                        SqlParameter[] parametreler = { new SqlParameter("@id", secilenId) };

                        SqlHelper.ExecuteQuery(sql, parametreler);

                        ListeyiYenile();
                        MessageBox.Show("Makine ve tüm geçmiş verileri temizlendi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir makine seçiniz.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMachines.SelectedRows.Count > 0)
            {
                // Seçilen satırı al
                DataGridViewRow row = dgvMachines.SelectedRows[0];

                // 2. Formu oluştur
                FrmMachineAdd frm = new FrmMachineAdd();

                // 3. Formun içine ID'yi veriyoruz ki Güncelleme Moduna geçsin
                // DİKKAT: Cells["MachineID"] kısmının senin tablondakiyle aynı olduğundan eminsin artık :)
                frm.guncellenecekId = Convert.ToInt32(row.Cells["MachineID"].Value);

                // 4. Tablodaki verileri alıp formdaki kutucuklara dolduruyoruz
                // DİKKAT: Köşeli parantez içlerine veritabanındaki sütun adlarını (veya DataGridView sütun adlarını) yazmalısın.
                // Eğer hata alırsan bu isimleri kontrol et (Name, SerialNo, Type, Status vb.)
                string ad = row.Cells[1].Value.ToString();      // 1. Sütun: Makine Adı
                string seri = row.Cells[2].Value.ToString();    // 2. Sütun: Seri No
                string tur = row.Cells[3].Value.ToString();     // 3. Sütun: Tür
                string durum = row.Cells[4].Value.ToString();   // 4. Sütun: Durum

                // Verileri gönder
                frm.BilgileriDoldur(ad, seri, tur, durum);

                // 5. Formu aç
                frm.ShowDialog();

                // 6. Form kapanınca listeyi yenile ki değişiklik görünsün
                ListeyiYenile();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir makine seçiniz.");
            }
        }
    }
}