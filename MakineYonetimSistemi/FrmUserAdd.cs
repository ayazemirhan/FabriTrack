using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class FrmUserAdd : Form
    {
        public int _userId = 0; // 0 ise Yeni Ekle, >0 ise Güncelle

        // CONSTRUCTOR (Kurucu Metot)
        public FrmUserAdd(int id)
        {
            InitializeComponent();
            _userId = id;

            // --- DEĞİŞİKLİK BURADA ---
            // Load olayını beklemek yerine direkt burada kontrol ediyoruz.
            // Böylece Event bağlama hatası riski yok oluyor.
            if (_userId > 0)
            {
                this.Text = "Personel Düzenle";
                btnSave.Text = "Güncelle";

                // Bilgileri hemen çek
                BilgileriGetir();
            }
            else
            {
                this.Text = "Yeni Personel Ekle";
                btnSave.Text = "Kaydet";
            }
        }

        // Form Load olayı artık boş kalabilir, yukarıya taşıdık.
        private void FrmUserAdd_Load(object sender, EventArgs e)
        {
            // Burası boş kalsa da olur.
        }

        private void BilgileriGetir()
        {
            try
            {
                // Veritabanından veriyi çek
                string query = "SELECT * FROM Users WHERE UserID = " + _userId;
                DataTable dt = SqlHelper.GetTable(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    // DİKKAT: Buradaki parantez içleri veritabanındaki Sütun Adları ile BİREBİR aynı olmalı.
                    // Eğer veritabanında "AdSoyad" ise buraya boşluksuz yazmalısın.
                    // Mevcut yapıya göre varsayımım:
                    txtFullName.Text = dr["FullName"].ToString();
                    txtUser.Text = dr["Username"].ToString();
                    txtPass.Text = dr["Password"].ToString();
                    cmbRole.Text = dr["Role"].ToString();
                    txtDept.Text = dr["Department"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler getirilirken hata oluştu: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "" || txtUser.Text == "")
            {
                MessageBox.Show("Ad Soyad ve Kullanıcı Adı zorunludur!");
                return;
            }

            try
            {
                string query = "";
                SqlParameter[] p;

                if (_userId == 0) // EKLEME
                {
                    query = "INSERT INTO Users (FullName, Username, Password, Role, Department) VALUES (@name, @user, @pass, @role, @dept)";
                    p = new SqlParameter[] {
                        new SqlParameter("@name", txtFullName.Text),
                        new SqlParameter("@user", txtUser.Text),
                        new SqlParameter("@pass", txtPass.Text),
                        new SqlParameter("@role", cmbRole.Text),
                        new SqlParameter("@dept", txtDept.Text)
                    };
                }
                else // GÜNCELLEME
                {
                    query = "UPDATE Users SET FullName=@name, Username=@user, Password=@pass, Role=@role, Department=@dept WHERE UserID=@id";
                    p = new SqlParameter[] {
                        new SqlParameter("@name", txtFullName.Text),
                        new SqlParameter("@user", txtUser.Text),
                        new SqlParameter("@pass", txtPass.Text),
                        new SqlParameter("@role", cmbRole.Text),
                        new SqlParameter("@dept", txtDept.Text),
                        new SqlParameter("@id", _userId)
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