using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace proje3.img
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Sayfa ilk kez yüklendiğinde yapılacak işlemler buraya yazılabilir.
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            // Kullanıcının güncellemek istediği verileri aldığınız kontrol adlarına göre değiştirin.
            string eskiAd = yazi7.Text;
            string eskiSifre = yazi8.Text;
            string yeniAd = yazi9.Text;
            string yeniSifre = yazi10.Text;

            // Veritabanında güncelleme işlemini gerçekleştiren metodu çağırın
            EditData(eskiAd, eskiSifre, yeniAd, yeniSifre);
        }

        private void EditData(string eskiAd, string eskiSifre, string yeniAd, string yeniSifre)
        {
            try
            {
                // Veritabanı bağlantı dizesi
                string connectionString = "Data Source=(local);Initial Catalog=kullanici;Integrated Security=True";

                // SQL bağlantısı oluştur
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL sorgusu
                    string query = "UPDATE [dbo].[Table_2] SET [ad] = @YeniAd, [şifre] = @YeniSifre WHERE [ad] = @EskiAd AND [şifre] = @EskiSifre";

                    // SQL komutu ve parametreleri
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@YeniAd", yeniAd);
                        command.Parameters.AddWithValue("@YeniSifre", yeniSifre);
                        command.Parameters.AddWithValue("@EskiAd", eskiAd);
                        command.Parameters.AddWithValue("@EskiSifre", eskiSifre);

                        // Güncelleme işlemini gerçekleştir
                        int affectedRows = command.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            Response.Write("Veri güncellendi.");
                        }
                        else
                        {
                            Response.Write("Güncellenecek veri bulunamadı veya değerler zaten aynı.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Hata oluştu: " + ex.Message);
            }
        }
    }
}

