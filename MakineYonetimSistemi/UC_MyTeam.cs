using System;
using System.Data;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class UC_MyTeam : UserControl
    {
        public UC_MyTeam()
        {
            InitializeComponent();
        }

        private void UC_MyTeam_Load(object sender, EventArgs e)
        {
            // Sadece 'Personel' rolündekileri getir
            string sorgu = "SELECT FullName AS 'Ad Soyad', Username AS 'Kullanıcı Adı', Department AS 'Departman' FROM Users WHERE Role = 'Personel'";

            DataTable dt = SqlHelper.GetTable(sorgu);
            dgvTeam.DataSource = dt;
        }
    }
}