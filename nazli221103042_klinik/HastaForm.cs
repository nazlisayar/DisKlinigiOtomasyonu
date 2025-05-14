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
    public partial class HastaForm : Form
    {
        string connectionstring = "Server=LAPTOP-520LAU13\\MSSQLSERVER01;Database=klinikotomasyon;Trusted_Connection=True";
        public HastaForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Randevu AL BUTONU
            pictureBox2.Visible = false;    
            label1.Visible = true; 
            label3.Visible = true; 
            label4.Visible = true;
            label5.Visible = true;
            cmbhastarandevususaat.Visible = true;
            dtphastarandevusal.Visible= true;
            btnhastarandevualıyor.Visible = true;
            cmbhastarandevudoktor.Visible = true;
            cmbhastarandevutedavi.Visible = true;
            dataGridViewHasta.Visible = false;   
           
            int HastaID = GetHastaIDFromKullaniciID(AnaSınıf.KullaniciID);
            using(SqlConnection conn=new SqlConnection(connectionstring))
            {  string sorgu2 = "SELECT DoktorID, Ad + ' ' + Soyad AS AdSoyad FROM Doktorlar";
               
                conn.Open();
                    SqlDataAdapter dadoktor = new SqlDataAdapter(sorgu2, conn);
                    DataTable dtdoktor = new DataTable();
                    dadoktor.Fill(dtdoktor);
                    cmbhastarandevudoktor.DisplayMember = "AdSoyad";
                    cmbhastarandevudoktor.ValueMember = "DoktorID";
                    cmbhastarandevudoktor.DataSource = dtdoktor;

                
              
               


                string sorgu3 = "SELECT TedaviID, TedaviAdi + ' - ' + CAST(Ucret AS VARCHAR) + ' ₺' AS Gosterim FROM Tedaviler";
                SqlDataAdapter datedavi = new SqlDataAdapter(sorgu3, conn);
                DataTable dtdavi = new DataTable();
                datedavi.Fill(dtdavi);
                cmbhastarandevutedavi.DisplayMember = "Gosterim";
                cmbhastarandevutedavi.ValueMember = "TedaviID";
                cmbhastarandevutedavi.DataSource = dtdavi;

            }
        }

        private int GetHastaIDFromKullaniciID(int KullaniciID)
        {
            int hastaID = -1;

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                string sorgu = "SELECT HastaID FROM Hastalar WHERE KullaniciID = @KullaniciID";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@KullaniciID", KullaniciID);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    hastaID = Convert.ToInt32(result);
                }
            }

            return hastaID;
        }

        private void btnrandevuandrecete_Click(object sender, EventArgs e)
        {  pictureBox2.Visible = false; 
            label1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false; 
            btnhastarandevualıyor.Visible = false;
            cmbhastarandevususaat.Visible = false;
            cmbhastarandevudoktor.Visible = false;
            cmbhastarandevutedavi.Visible = false;
            dtphastarandevusal.Visible = false;
            dataGridViewHasta.Visible = true;  
            int HastaID = GetHastaIDFromKullaniciID(AnaSınıf.KullaniciID);
            using (SqlConnection conn = new SqlConnection(connectionstring)) { 
                string sorgu = "SELECT r.Tarih, r.Saat, d.Ad + ' ' + d.Soyad AS DoktorAdSoyad, rc.ReceteMetni FROM Randevular r JOIN Doktorlar d ON r.DoktorID = d.DoktorID JOIN Hastalar h ON r.HastaID = h.HastaID LEFT JOIN Receteler rc ON rc.HastaID = r.HastaID WHERE r.HastaID = @HastaID ORDER BY r.Tarih DESC"; ;
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@HastaID", HastaID); 
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewHasta.DataSource = dt;}
           
        }

        private void btnhastarandevualıyor_Click(object sender, EventArgs e)
        {

            int HastaID = GetHastaIDFromKullaniciID(AnaSınıf.KullaniciID);
            int DoktorID = Convert.ToInt32(cmbhastarandevudoktor.SelectedValue);
            int TedaviID = Convert.ToInt32(cmbhastarandevutedavi.SelectedValue);
            DateTime Tarih = dtphastarandevusal.Value.Date;
            string saat = cmbhastarandevususaat.SelectedItem?.ToString() ?? "";
            string durum = "Aktif";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sorgu = "insert into Randevular (HastaID,DoktorID,Tarih,Saat,TedaviID,Durum) values (@HastaID,@DoktorID,@Tarih,@Saat,@TedaviID,@Durum)";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("HastaID", HastaID);
                cmd.Parameters.AddWithValue("DoktorID", DoktorID);
                cmd.Parameters.AddWithValue("Tarih", Tarih);
                cmd.Parameters.AddWithValue("Saat", saat);
                cmd.Parameters.AddWithValue("TedaviID", TedaviID);
                cmd.Parameters.AddWithValue("Durum", durum);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Randevu Eklendi");
                   

                }
                catch (Exception ex) { MessageBox.Show("Hata" + ex.Message); }
                conn.Close();
            }
        }
        private void hosgeldinyazdir()
        {
            int HastaID = GetHastaIDFromKullaniciID(AnaSınıf.KullaniciID);

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string query = "SELECT Ad, Soyad FROM Hastalar WHERE HastaID = @HastaID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HastaID", HastaID);
              SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string Ad = reader["Ad"].ToString();
                    string Soyad = reader["Soyad"].ToString();
                    lblhosgeldinhasta.Text = $"Hoşgeldin {Ad} {Soyad}";
                }

                reader.Close();

               
                conn.Close();
            }

        }

        private void HastaForm_Load(object sender, EventArgs e)
        {
            hosgeldinyazdir();  
        }

        private void btndoktorcikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
