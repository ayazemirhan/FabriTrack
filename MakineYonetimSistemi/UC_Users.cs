using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MakineYonetimSistemi
{
    public partial class UC_Users : UserControl
    {
        public UC_Users()
        {
            InitializeComponent();
        }

        // Sayfa ilk açıldığında çalışır
        private void UC_Users_Load(object sender, EventArgs e)
        {
            ListeyiGetir();
        }

        // Verileri Grid'e dolduran metot
        public void ListeyiGetir()
        {
            try
            {
                // Veritabanından verileri çek
                string sorgu = "SELECT UserID, FullName AS 'Ad Soyad', Username AS 'Kullanıcı Adı', Role AS 'Yetki', Department AS 'Departman' FROM Users";
                DataTable dt = SqlHelper.GetTable(sorgu);
                dgvUsers.DataSource = dt;

                // ID sütununu gizle (Kullanıcı görmesin ama biz silebilesin diye lazım)
                if (dgvUsers.Columns["UserID"] != null)
                {
                    dgvUsers.Columns["UserID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme Hatası: " + ex.Message);
            }
        }

        // YENİ EKLE BUTONU
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            FrmUserAdd frm = new FrmUserAdd(0); // 0 = Yeni Ekle Modu
            frm.ShowDialog(); // Pencereyi aç
            ListeyiGetir();   // Kapanınca listeyi yenile
        }

        // DÜZENLE BUTONU
        private void btnEdit_Click(object sender, EventArgs e)
        {
            KayitDuzenle();
        }

        // SİL BUTONU
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DialogResult cevap = MessageBox.Show("Seçili personeli silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (cevap == DialogResult.Yes)
                {
                    try
                    {
                        // Seçili satırın ID'sini al
                        string id = dgvUsers.SelectedRows[0].Cells["UserID"].Value.ToString();

                        string sorgu = "DELETE FROM Users WHERE UserID = @id";
                        SqlParameter[] p = { new SqlParameter("@id", id) };

                        SqlHelper.ExecuteQuery(sorgu, p);

                        MessageBox.Show("Personel başarıyla silindi.");
                        ListeyiGetir();
                    }
                    catch (SqlException ex)
                    {
                        // Hata numarası 547 ise bu bir "Foreign Key" (İlişkili Kayıt) hatasıdır
                        if (ex.Number == 547)
                        {
                            MessageBox.Show("BU PERSONEL SİLİNEMEZ!\n\nSebep: Bu personele atanmış görevler veya bakımlar var.\n\nÇözüm: Önce 'Atama İşlemleri' sayfasından bu kişiye ait görevleri silmelisiniz.", "Silme Engellendi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            MessageBox.Show("Veritabanı Hatası: " + ex.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Genel Hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir satır seçin.");
            }
        }

        // Tabloda çift tıklayınca da düzenleme açılsın
        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Başlığa tıklanmadıysa
            {
                KayitDuzenle();
            }
        }

        // Ortak Düzenleme Fonksiyonu
        private void KayitDuzenle()
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                // Seçili satırın ID'sini al
                int seciliId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);

                // Formu ID ile aç (Güncelleme modu)
                FrmUserAdd frm = new FrmUserAdd(seciliId);
                frm.ShowDialog();

                // İşlem bitince listeyi güncelle
                ListeyiGetir();
            }
            else
            {
                MessageBox.Show("Lütfen düzenlemek için bir satır seçin.");
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ListeyiGetir();
        }
    }
}