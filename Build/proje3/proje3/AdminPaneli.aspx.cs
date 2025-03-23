using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace proje3
{
    public partial class AdminPaneli : System.Web.UI.Page
    {
        // SQL bağlantı dizesi
        private string connectionString = "Data Source=(local);Initial Catalog=kullanici;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Silinecek öğenin ID'sini al
                string adToDelete = GridView1.DataKeys[e.RowIndex].Values["ad"].ToString();

                // Veritabanından silme işlemini gerçekleştir
                DeleteData(adToDelete);

                // GridView'ı tekrar bağla
                BindGridView();

                // Silme işlemi başarılı mesajı
                Response.Write("Veri silindi.");
            }
            catch (Exception ex)
            {
                Response.Write("Hata oluştu: " + ex.Message);
            }
        }

        private void DeleteData(string ad)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL sorgusu
                string query = "DELETE FROM Table_2 WHERE ad = @Ad";

                // SQL komutu ve parametreleri
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Ad", ad);

                    // SQL bağlantısını açın
                    connection.Open();

                    // Komutu yürütün
                    command.ExecuteNonQuery();
                }
            }
        }


        private void BindGridView()
        {
            // Veritabanından veri çekme işlemi (Table_2 tablosundan)
            DataTable dt = GetYourDataFromDatabase();

            // Veri kaynağını GridView ile ilişkilendirme
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private DataTable GetYourDataFromDatabase()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // SQL sorgusu
                string query = "SELECT ad, şifre FROM Table_2";

                // SQL komutu ve parametreleri
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // SQL bağlantısını açın
                    connection.Open();

                    // Verileri çekmek için bir SqlDataAdapter kullanın
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // DataTable'a verileri doldurun
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
    /*
    public partial class adminedit 
    {
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            // Kullanıcının güncellemek istediği verileri aldığınız kontrol adlarına göre değiştirin.
            string eskiAd = Text1.Text;
            string eskiSifre = Text2.Text;
            string yeniAd = Text3.Text;
            string yeniSifre = Text4.Text;

            // Veritabanında güncelleme işlemini gerçekleştiren metodu çağırın
            EditData(eskiAd, eskiSifre, yeniAd, yeniSifre);
        }

        private void EditData(string eskiAd, string eskiSifre, string yeniAd, string yeniSifre)
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
                        
                    }
                }
            
            
        }*/
    }
}
