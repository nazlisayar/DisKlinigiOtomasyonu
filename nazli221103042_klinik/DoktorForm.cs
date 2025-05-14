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
    public partial class DoktorForm : Form
    {
        string connectionstring = "Server=LAPTOP-520LAU13\\MSSQLSERVER01;Database=klinikotomasyon;Trusted_Connection=True";
    
        public DoktorForm()
        {
            InitializeComponent();
            
        }


        private void DoktorForm_Load(object sender, EventArgs e)
        {
            hosgeldinyazdirdoktor();

        }
        private void hosgeldinyazdirdoktor()
        {
            int DoktorID=GetDoktorIDFromKullaniciID(AnaSınıf.KullaniciID);

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string query = "SELECT Ad, Soyad FROM Doktorlar WHERE DoktorID = @DoktorID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DoktorID", DoktorID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string ad = reader["Ad"].ToString();
                    string soyad = reader["Soyad"].ToString();
                    lbldoktorhosgeldin.Text = $"Hoşgeldin Dr.{ad} {soyad}";
                }

                reader.Close();
                conn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        { //RANDEVY BUTONU
            rchtxtRecete.Visible = false;
            btnreceteekle.Visible = false;
            rchtxtnot.Visible = false;
            btnnotekle.Visible = false;
            btnsilrecete.Visible = false;
            btnnotsil.Visible = false;  
            int KullaniciID = AnaSınıf.KullaniciID;
            int DoktorID=GetDoktorIDFromKullaniciID(KullaniciID);
           

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                

                string query = @"SELECT R.RandevuID, H.Ad + ' ' + H.Soyad AS HastaAdi, R.Tarih, R.Saat
                     FROM Randevular R
                     JOIN Hastalar H ON R.HastaID = H.HastaID
                     WHERE R.DoktorID = @DoktorID";
              
                SqlCommand cmd2=new SqlCommand(query,conn);
                cmd2.Parameters.AddWithValue("@DoktorID", DoktorID);

                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewdoktor.DataSource = dt; 
            }



        }

        private void btndoktorunhastlari_Click(object sender, EventArgs e)
        {
            rchtxtRecete.Visible = false;
            btnreceteekle.Visible = false;
            rchtxtnot.Visible = true;
            btnnotekle.Visible = true;
          btnnotsil.Visible=true;   
            btnsilrecete.Visible = false;
            
            DoktorunHastalariniListele();
            



        }
        private void DoktorunHastalariniListele()
        {
            int KullaniciID = AnaSınıf.KullaniciID;
            int DoktorID = GetDoktorIDFromKullaniciID(KullaniciID);

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();


             
                string sorgu = "SELECT DISTINCT h.HastaID, h.Ad, h.Soyad,h.DoktorNotu FROM Randevular r JOIN Hastalar h ON r.HastaID = h.HastaID WHERE r.DoktorID = @DoktorID";

                try
                {
                    SqlCommand cmd2 = new SqlCommand(sorgu, conn);
                    cmd2.Parameters.AddWithValue("@DoktorID", DoktorID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    
                    dataGridViewdoktor.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                conn.Close();
            }
        }
        private int GetDoktorIDFromKullaniciID(int KullaniciID)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                string query = "SELECT DoktorID FROM Doktorlar WHERE KullaniciID = @KullaniciID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@KullaniciID", KullaniciID);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1; 
            }
        }

        private void btnnotekle_Click(object sender, EventArgs e)
        {
            if(dataGridViewdoktor.SelectedRows.Count>0)
            {
            string DoktorNotu=rchtxtnot.Text;
            int KullaniciID=AnaSınıf.KullaniciID;
            int DoktorID = GetDoktorIDFromKullaniciID(KullaniciID);
                int HastaID = Convert.ToInt32(dataGridViewdoktor.CurrentRow.Cells["HastaID"].Value);
                using (SqlConnection conn = new SqlConnection(connectionstring)) 
            { 
               
                string sorgu = "UPDATE Hastalar SET DoktorNotu = @DoktorNotu WHERE HastaID = @HastaID";
                SqlCommand cmd=new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@DoktorNotu",DoktorNotu);
                cmd.Parameters.AddWithValue("@HastaID",HastaID);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        DoktorunHastalariniListele();
                        MessageBox.Show("Notunuz Eklendi");
                        rchtxtnot.Clear();
                        rchtxtnot.Visible = false;
                        btnnotekle.Visible = false;
                    }
               
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    conn.Close();
            
            }
            
            
            }
            

        }

        private void receteekleyeozellistele()
        {
            int KullaniciID = AnaSınıf.KullaniciID;
            int DoktorID = GetDoktorIDFromKullaniciID(KullaniciID);

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();



                string sorgu = "SELECT DISTINCT h.HastaID, h.Ad, h.Soyad, h.DoktorNotu, r.ReceteMetni,r.Tarih FROM Randevular rd JOIN Hastalar h ON rd.HastaID = h.HastaID LEFT JOIN Receteler r ON h.HastaID = r.HastaID WHERE rd.DoktorID = @DoktorID";

                try
                {
                    SqlCommand cmd2 = new SqlCommand(sorgu, conn);
                    cmd2.Parameters.AddWithValue("@DoktorID", DoktorID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    dataGridViewdoktor.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                conn.Close();
            }
        }
        private void btndoktorrecete_Click(object sender, EventArgs e)
        {
            rchtxtnot.Visible = false;
            btnnotekle.Visible = false;
            rchtxtRecete.Visible = true;
            btnreceteekle.Visible = true;
            btnsilrecete.Visible = true;
            btnnotsil.Visible = false;

            receteekleyeozellistele();
           
        }

        private void btnreceteekle_Click(object sender, EventArgs e)
        {
                if (dataGridViewdoktor.SelectedRows.Count > 0)
                {
                    string reçete = rchtxtRecete.Text;
                  
                    int HastaID = Convert.ToInt32(dataGridViewdoktor.CurrentRow.Cells["HastaID"].Value);
                    int DoktorID = GetDoktorIDFromKullaniciID(AnaSınıf.KullaniciID);
                    DateTime tarih = DateTime.Now;

                    using (SqlConnection conn = new SqlConnection(connectionstring))
                    {
                        string sorgu = "INSERT INTO Receteler (HastaID, DoktorID, ReceteMetni, Tarih) VALUES (@HastaID, @DoktorID, @ReceteMetni, @Tarih)";
                        SqlCommand cmd = new SqlCommand(sorgu, conn);
                        cmd.Parameters.AddWithValue("@HastaID", HastaID);
                        cmd.Parameters.AddWithValue("@DoktorID", DoktorID);
                        cmd.Parameters.AddWithValue("@ReceteMetni", reçete);
                        cmd.Parameters.AddWithValue("@Tarih", tarih);

                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Reçete başarıyla eklendi.");
                        receteekleyeozellistele();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        conn.Close();
                    }
                }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnsilrecete_Click(object sender, EventArgs e)
        {

            if (dataGridViewdoktor.SelectedRows.Count > 0)
            {
                string reçete = rchtxtRecete.Text;

                int HastaID = Convert.ToInt32(dataGridViewdoktor.CurrentRow.Cells["HastaID"].Value);
                int DoktorID = GetDoktorIDFromKullaniciID(AnaSınıf.KullaniciID);
                

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    string sorgu = "delete from receteler where HastaID=@HastaID";
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@HastaID", HastaID);
                   

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Reçete başarıyla silindi.");
                        receteekleyeozellistele();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    conn.Close();
                }
            }
        }

        private void btnnotsil_Click(object sender, EventArgs e)
        {
            if (dataGridViewdoktor.SelectedRows.Count > 0)
            {

                int KullaniciID = AnaSınıf.KullaniciID;
                int DoktorID = GetDoktorIDFromKullaniciID(KullaniciID);
                int HastaID = Convert.ToInt32(dataGridViewdoktor.CurrentRow.Cells["HastaID"].Value);
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {

                    string sorgu = "UPDATE Hastalar SET DoktorNotu = NULL WHERE HastaID = @HastaID";
                    SqlCommand cmd = new SqlCommand(sorgu, conn);

                    cmd.Parameters.AddWithValue("@HastaID", HastaID);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        DoktorunHastalariniListele();
                        MessageBox.Show("Notunuz Silindi!!");
                        rchtxtnot.Clear();

                    }

                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    conn.Close();

                }
            } 
        }

        private void btnkapatdoktor_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
