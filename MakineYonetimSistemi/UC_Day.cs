using System;
using System.Windows.Forms;
using System.Drawing; // Renkler için

namespace MakineYonetimSistemi
{
    public partial class UC_Day : UserControl
    {
        public UC_Day()
        {
            InitializeComponent();
        }

        // Gün sayısını yazdıran fonksiyon
        public void GunYaz(int gun)
        {
            lblDay.Text = gun.ToString();
        }

        // O gün bir iş varsa ekrana yazan fonksiyon
        public void IsEkle(string isAciklamasi)
        {
            if (string.IsNullOrEmpty(isAciklamasi)) return;

            lblJob.Text = isAciklamasi;
            this.BackColor = Color.LightYellow; // İş varsa kutu sararsın
        }
    }
}