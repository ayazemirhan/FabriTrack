using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakineYonetimSistemi
{
    internal static class Program
    {
        // Giriş yapan kişinin ID'sini burada tutuyoruz
        public static int CurrentUserID = 0;

        // YENİ EKLEDİK: Giriş yapan kişinin Rolünü (Admin/Personel/Amir) burada tutacağız
        public static string CurrentUserRole = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}