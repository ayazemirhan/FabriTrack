using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class FrmMachineAdd : Form
    {
        // Bu değişken 0 ise "Ekleme Modu", 0'dan büyükse "Güncelleme Modu" demektir.
        public int guncellenecekId = 0;

        public FrmMachineAdd()
        {
            InitializeComponent();
        }

        // Dışarıdan verileri bu formun içine doldurmak için kullanacağımız metot
        public void BilgileriDoldur(string ad, string seriNo, string tur, string durum)
        {
            txtName.Text = ad;
            txtSerial.Text = seriNo;
            cmbType.Text = tur;     // Combobox'ta bu değeri seçili yapar
            cmbStatus.Text = durum; // Combobox'ta bu değeri seçili yapar

            // Butonun yazısını değiştirelim ki kullanıcı anlasın
            btnSave.Text = "Güncelle";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Boş alan kontrolü
            if (txtName.Text == "" || txtSerial.Text == "")
            {
                MessageBox.Show("Lütfen Makine Adı ve Seri No giriniz!", "Uyarı");
                return;
            }

            try
            {
                string query = "";
                SqlParameter[] parameters;

                // 2. Karar Anı: Ekleme mi yapacağız, Güncelleme mi?
                if (guncellenecekId == 0)
                {
                    // --- EKLEME MODU (INSERT) ---
                    query = "INSERT INTO Machines (Name, SerialNo, Type, Status) VALUES (@name, @serial, @type, @status)";

                    parameters = new SqlParameter[] {
                        new SqlParameter("@name", txtName.Text),
                        new SqlParameter("@serial", txtSerial.Text),
                        new SqlParameter("@type", cmbType.Text),
                        new SqlParameter("@status", cmbStatus.Text)
                    };
                }
                else
                {
                    // --- GÜNCELLEME MODU (UPDATE) ---
                    // Burada WHERE MachineID = @id çok önemli! Yoksa hepsini değiştirir.
                    query = "UPDATE Machines SET Name=@name, SerialNo=@serial, Type=@type, Status=@status WHERE MachineID=@id";

                    parameters = new SqlParameter[] {
                        new SqlParameter("@name", txtName.Text),
                        new SqlParameter("@serial", txtSerial.Text),
                        new SqlParameter("@type", cmbType.Text),
                        new SqlParameter("@status", cmbStatus.Text),
                        new SqlParameter("@id", guncellenecekId) // Hangi kaydı güncelleyeceğimizi belirtiyoruz
                    };
                }

                // 3. Veritabanına gönder
                SqlHelper.ExecuteQuery(query, parameters);

                MessageBox.Show(guncellenecekId == 0 ? "Makine başarıyla eklendi!" : "Makine başarıyla güncellendi!", "Bilgi");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}