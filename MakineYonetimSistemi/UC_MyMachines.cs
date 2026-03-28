using System;
using System.Data;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    public partial class UC_MyMachines : UserControl
    {
        public UC_MyMachines()
        {
            InitializeComponent();
        }

        // Sayfa yüklenirken bu kod çalışır
        private void UC_MyMachines_Load(object sender, EventArgs e)
        {
            ListeyiGetir();
        }

        private void ListeyiGetir()
        {

            int girisYapanAmirID = Program.CurrentUserID;
            // 1. Adım: Giriş yapan kişinin ID'sini hafızadan alıyoruz.
            // 2. Adım: SQL Sorgusu
            // "Assignments" tablosuna git, SupervisorID'si benim ID'm olanları bul.
            // Sonra o makinelerin ismini, modelini Machines tablosundan al.
            string sorgu = $@"
                SELECT 
                    M.Name AS 'Makine Adı',
                    M.SerialNo AS 'Seri No',
                    M.Status AS 'Durum'
                FROM Assignments A
                JOIN Machines M ON A.MachineID = M.MachineID
                WHERE A.SupervisorID = {girisYapanAmirID}";

            // 3. Adım: Tabloya doldur
            DataTable dt = SqlHelper.GetTable(sorgu);
            dgvMyMachines.DataSource = dt;
        }
    }
}