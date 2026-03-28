using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class FrmMaintenanceAdd : Form
    {
        public int _logId = 0; // 0=Yeni Ekle, >0=Düzenle

        public FrmMaintenanceAdd(int id)
        {
            InitializeComponent();
            _logId = id;
        }

        private void FrmMaintenanceAdd_Load(object sender, EventArgs e)
        {
            ListeleriDoldur();
            ComboBoxSecenekleriEkle();

            if (_logId > 0)
            {
                this.Text = "Bakım Düzenle / Tamamla";

                // Eğer giren Personel ise butonda "Onaya Gönder" yazsın, Admin ise "Güncelle"
                if (Program.CurrentUserRole == "Personel")
                    btnSave.Text = "Onaya Gönder";
                else
                    btnSave.Text = "Güncelle";

                BilgileriGetir();
            }
            else
            {
                this.Text = "Yeni Bakım/Arıza Ekle";
                btnSave.Text = "Kaydet";
            }
        }

        void ListeleriDoldur()
        {
            try
            {
                // Makineler
                cmbMachine.DataSource = SqlHelper.GetTable("SELECT MachineID, Name FROM Machines");
                cmbMachine.DisplayMember = "Name";
                cmbMachine.ValueMember = "MachineID";

                // Personeller
                cmbUser.DataSource = SqlHelper.GetTable("SELECT UserID, FullName FROM Users");
                cmbUser.DisplayMember = "FullName";
                cmbUser.ValueMember = "UserID";
            }
            catch (Exception ex) { MessageBox.Show("Liste hatası: " + ex.Message); }
        }

        void ComboBoxSecenekleriEkle()
        {
            if (cmbType.Items.Count == 0)
            {
                cmbType.Items.Add("Bakım");
                cmbType.Items.Add("Arıza");
            }
            if (cmbStatus.Items.Count == 0)
            {
                cmbStatus.Items.Add("Tamamlandı");
                cmbStatus.Items.Add("Devam Ediyor");
                cmbStatus.Items.Add("Beklemede");
                cmbStatus.Items.Add("Onay Bekliyor");
            }
        }

        void BilgileriGetir()
        {
            try
            {
                string sorgu = "SELECT * FROM MaintenanceLogs WHERE LogID = " + _logId;
                DataTable dt = SqlHelper.GetTable(sorgu);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    cmbMachine.SelectedValue = dr["MachineID"];
                    cmbUser.SelectedValue = dr["UserID"];
                    cmbType.Text = dr["LogType"].ToString();
                    txtDesc.Text = dr["Description"].ToString();
                    cmbStatus.Text = dr["Status"].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("Bilgi çekme hatası: " + ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbMachine.SelectedIndex == -1 || cmbUser.SelectedIndex == -1 || txtDesc.Text == "")
            {
                MessageBox.Show("Lütfen makine, personel ve açıklama alanlarını doldurun.");
                return;
            }

            try
            {
                string query = "";
                SqlParameter[] p;

                // --- SENARYO 1: YENİ KAYIT EKLEME ---
                if (_logId == 0)
                {
                    query = "INSERT INTO MaintenanceLogs (MachineID, UserID, LogType, Description, Status, LogDate) VALUES (@mac, @usr, @type, @desc, @stat, GETDATE())";

                    p = new SqlParameter[] {
                        new SqlParameter("@mac", cmbMachine.SelectedValue),
                        new SqlParameter("@usr", cmbUser.SelectedValue),
                        new SqlParameter("@type", cmbType.Text),
                        new SqlParameter("@desc", txtDesc.Text),
                        new SqlParameter("@stat", cmbStatus.Text)
                    };
                }
                // --- SENARYO 2: GÜNCELLEME ---
                else
                {
                    // BURASI EN ÖNEMLİ YER!
                    string kaydedilecekDurum = "";

                    // Eğer giriş yapan PERSONEL ise -> Durumu zorla "Onay Bekliyor" yap.
                    if (Program.CurrentUserRole == "Personel")
                    {
                        kaydedilecekDurum = "Onay Bekliyor";
                    }
                    // Eğer giriş yapan ADMIN veya AMİR ise -> Ekrandan ne seçtiyse o olsun.
                    else
                    {
                        kaydedilecekDurum = cmbStatus.Text;
                    }

                    query = "UPDATE MaintenanceLogs SET MachineID=@mac, UserID=@usr, LogType=@type, Description=@desc, Status=@stat WHERE LogID=@id";

                    p = new SqlParameter[] {
                        new SqlParameter("@mac", cmbMachine.SelectedValue),
                        new SqlParameter("@usr", cmbUser.SelectedValue),
                        new SqlParameter("@type", cmbType.Text),
                        new SqlParameter("@desc", txtDesc.Text),
                        
                        // Burada ayarladığımız durumu kullanıyoruz
                        new SqlParameter("@stat", kaydedilecekDurum),

                        new SqlParameter("@id", _logId)
                    };
                }

                SqlHelper.ExecuteQuery(query, p);

                // Ekstra: Arıza girildiyse makineyi de arızalı yap
                if (cmbType.Text == "Arıza" && _logId == 0)
                {
                    SqlHelper.ExecuteQuery("UPDATE Machines SET Status = 'Arızalı' WHERE MachineID = " + cmbMachine.SelectedValue);
                }

                MessageBox.Show("İşlem Başarılı!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme Hatası: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}