using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nazli221103042_klinik
{
    public partial class GirisFormcs : Form
    {
        string connectionstring = "Server=LAPTOP-520LAU13\\MSSQLSERVER01;Database=klinikotomasyon;Trusted_Connection=True";
        public GirisFormcs()
        {
            InitializeComponent();
        }

        private void btnkullanicigiris_Click(object sender, EventArgs e)
        {
            string KullaniciAdi = txtgirisKullaniciAdi.Text;
            string Sifre = txtgirissifre.Text;
            int KullaniciID=KullaniciGiris(KullaniciAdi,Sifre);
            if (KullaniciID != -1)
            {
                // Başarılı giriş
               AnaSınıf.KullaniciID = KullaniciID;
                AnaSınıf.KullaniciAdi = KullaniciAdi;

                // Kullanıcı rolüne göre yönlendirme yap
                if (AnaSınıf.KullaniciRol == "Doktor")
                {
                  
                    DoktorForm doktor = new DoktorForm();
                    doktor.Show();  
                    this.Hide(); 
                    
                }
                else if (AnaSınıf.KullaniciRol == "Hasta")
                {
                    HastaForm hastaFormu = new HastaForm();
                    hastaFormu.Show();
                    this.Hide();
                }
                else if(AnaSınıf.KullaniciRol=="Admin")
                {     
                    Form1 adminform = new Form1();
                    adminform.Show();
                    this.Hide();    
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
            }

        }
        private int KullaniciGiris(string KullaniciAdi, string Sifre)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                // Kullanıcı adı ve şifreyi veritabanında kontrol ediyoruz
                string sorgu = "SELECT KullaniciID, Rol FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";

                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@KullaniciAdi",KullaniciAdi);
                cmd.Parameters.AddWithValue("@Sifre", Sifre);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    // Eğer kullanıcı adı ve şifre doğruysa
                    reader.Read(); // Veriyi okuyoruz
                    int kullaniciID = Convert.ToInt32(reader["KullaniciID"]);
                    string rol = reader["Rol"].ToString();

                    // Global değişkenlere kullanıcı bilgilerini atıyoruz
                    AnaSınıf.KullaniciID = kullaniciID;
                    AnaSınıf.KullaniciAdi = KullaniciAdi;
                    AnaSınıf.KullaniciRol = rol;

                    return kullaniciID; 
                }
                else
                {
                   
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                    return -1;
                }
            }
        }

    }
}
