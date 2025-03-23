using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proje3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void bnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog = kullanici;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Table_2] ([ad], [şifre]) VALUES (@Ad, @Şifre)", con);
            cmd.Parameters.AddWithValue("@Ad", yazi5.Text);
            cmd.Parameters.AddWithValue("@Şifre", yazi6.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("Kaydedildi");
            con.Close();
        }

        protected void bnlogin_Click(object sender, EventArgs e)
        {
            // bnlogin butonuna tıklandığında yapılacak işlemler
            string username = yazi5.Text;
            string password = yazi6.Text;

            // Kullanıcı doğrulama işlemini gerçekleştir
            LoginController loginController = new LoginController();

            if (loginController.AuthenticateAndRedirect(username, password))
            {
                // Kullanıcı doğrulandıysa home.aspx sayfasına yönlendir
                Response.Redirect("Home/Home.aspx");
            }
            else
            {
                Response.Write("Böyle bir kullanıcı yok!");// Kullanıcı doğrulanamadıysa giriş sayfasında kalabilir veya hata mesajını gösterebilirsiniz.
            }
        }

        public void Button8_Click(object sender, EventArgs e)
        {
            string ad = yazi5.Text;
            string şifre = yazi6.Text;

            // Veritabanında silme işlemini gerçekleştiren metodu çağırın
            

            string connectionString = "Data Source=(local);Initial Catalog=kullanici;Integrated Security=True";

            // SQL bağlantısı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL sorgusu
                string query = "DELETE FROM [dbo].[Table_2] WHERE [ad] = @ad AND [şifre] = @şifre";

                // SQL komutu ve parametreleri
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ad", ad);
                    command.Parameters.AddWithValue("@şifre", şifre);

                    // Silme işlemini gerçekleştir
                    int affectedRows = command.ExecuteNonQuery();


                }
            }
        }

        public class LoginController
        {
            private static string connectionString = "Data Source=(local);Initial Catalog=kullanici;Integrated Security=True";

            public bool AuthenticateAndRedirect(string ad, string şifre)
            {
                // SQL sorgusunu oluşturun
                string query = "SELECT * FROM [dbo].[Table_2] WHERE [ad] = @Ad AND [şifre] = @Şifre";

                // SQL bağlantısını oluşturun
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Parametreleri ekleyin
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Ad", ad);
                        command.Parameters.AddWithValue("@Şifre", şifre);

                        // Bağlantıyı açın
                        connection.Open();

                        // Sorguyu yürütün
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Kullanıcı adı ve şifre doğruysa reader'da bir kayıt olacak
                            if (reader.HasRows)
                            {
                                // Kullanıcı doğrulandıysa true döndür
                                return true;
                            }
                            else
                            {
                                // Kullanıcı doğrulanamadıysa false döndür
                                return false;
                            }
                        }
                    }
                }
            }
        }

        private void DeleteDataClick(string ad, string şifre)
        {

            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=(local);Initial Catalog=kullanici;Integrated Security=True";

            // SQL bağlantısı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // SQL sorgusu
                string query = "DELETE FROM [dbo].[Table_2] WHERE [ad] = @ad AND [şifre] = @şifre";

                // SQL komutu ve parametreleri
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ad", ad);
                    command.Parameters.AddWithValue("@şifre", şifre);

                    // Silme işlemini gerçekleştir
                    int affectedRows = command.ExecuteNonQuery();


                }
            }


        }


    }
}

