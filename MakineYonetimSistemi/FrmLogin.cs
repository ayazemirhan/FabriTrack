using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            // Basit ve garanti yöntem (String Birleştirme)
            string query = $"SELECT * FROM Users WHERE Username='{user}' AND Password='{pass}'";

            try
            {
                DataTable dt = SqlHelper.GetTable(query);

                if (dt.Rows.Count > 0)
                {
                    // 1. ID'yi Hafızaya At
                    Program.CurrentUserID = Convert.ToInt32(dt.Rows[0]["UserID"]);

                    // 2. ROLÜ Hafızaya At (Burayı Ekledik)
                    string rol = dt.Rows[0]["Role"].ToString();
                    Program.CurrentUserRole = rol;

                    string isim = dt.Rows[0]["FullName"].ToString();

                    MessageBox.Show($"Hoş geldin {isim} ({rol})", "Giriş Başarılı");
                    this.Hide(); // Login'i gizle

                    // Admin ise Admin Paneline gönder
                    if (rol == "Admin")
                    {
                        MainFormAdmin frm = new MainFormAdmin();
                        frm.Show();
                    }
                    // Personel ise
                    else if (rol == "Personel")
                    {
                        MainFormPersonel frm = new MainFormPersonel();
                        frm.Show();
                    }
                    // Amir ise 
                    else if (rol == "Amir")
                    {
                        MainFormAmir frm = new MainFormAmir();
                        frm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı Hatası: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}