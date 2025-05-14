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
using System.IO;
using System.Drawing.Text;

namespace nazli221103042_klinik
{  
    public partial class Form1 : Form
    {
       string connectionstring = "Server=LAPTOP-520LAU13\\MSSQLSERVER01;Database=klinikotomasyon;Trusted_Connection=True";
        private void Form1_Load(object sender, EventArgs e)
        {
            RandevuListele();
            hastalistele();
            DoktorListele();
            using (SqlConnection conn = new SqlConnection(connectionstring)) {  string sorgu= "select HastaID ,Ad+''+Soyad as AdSoyad from Hastalar";

            SqlDataAdapter dahasta= new SqlDataAdapter(sorgu,conn); 
                DataTable dthasta=new DataTable();
                dahasta.Fill(dthasta);
                cmbhasta.DisplayMember = "AdSoyad"; 
                cmbhasta.ValueMember = "HastaID"; 
                cmbhasta.DataSource = dthasta;

                string sorgu2 = "select DoktorID,Ad+''+Soyad as AdSoyad from Doktorlar";
                SqlDataAdapter dadoktor= new SqlDataAdapter(sorgu2,conn);
                DataTable dtdoktor = new DataTable();
                dadoktor.Fill(dtdoktor);
                cmbdoktor.DisplayMember = "AdSoyad";
                cmbdoktor.ValueMember = "DoktorID";
                cmbdoktor.DataSource = dtdoktor;


                string sorgu3 = "SELECT TedaviID, TedaviAdi + ' - ' + CAST(Ucret AS VARCHAR) + ' ₺' AS Gosterim FROM Tedaviler";
                SqlDataAdapter datedavi=new SqlDataAdapter(sorgu3,conn);
                DataTable dtdavi=new DataTable(); 
                datedavi.Fill(dtdavi);
                cmbtedavi.DisplayMember = "Gosterim";
                cmbtedavi.ValueMember = "TedaviID";
                cmbtedavi.DataSource = dtdavi;  
               




            }


        }
        public Form1()
        {
            try
            {
                using(SqlConnection conn=new SqlConnection(connectionstring))
                {
                    conn.Open();
                    MessageBox.Show("bağlantı başarılı");
                    conn.Close();
                }
            }
            catch(Exception e) { MessageBox.Show(e.Message); }   
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            hastalistele();
        }
        private void hastalistele()
        {

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sorgu = "select  HastaID,Ad, Soyad,TC,DogumTarihi,Cinsiyet,Telefon,Adres from Hastalar";
                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;


            }
        }

        
        private void btnekle_MouseEnter(object sender, EventArgs e)
        {
            btnekle.BackColor = Color.DarkRed;  
        }
        private void btnekle_MouseLeave(object sender, EventArgs e)
        {
            btnekle.BackColor = Color.White;
        }







        private void btnekle_Click(object sender, EventArgs e)
         {
            if(!string.IsNullOrWhiteSpace(txthadi.Text)&& !string.IsNullOrWhiteSpace(txthsoyad.Text)&& !string.IsNullOrWhiteSpace(txthtc.Text))
            {
                HastaEkle();
            }
            else
            {
                MessageBox.Show("Lütfen Hasta Adı,Soyadı,TC'sini kesinlikle giriniz");
            }


        }
        private void HastaEkle()
        {
            string Ad = txthadi.Text;
            string Soyad = txthsoyad.Text;
            string TC = txthtc.Text;
            string Cinsiyet = cmbhcinsiyet.SelectedItem?.ToString() ?? "";
            string Telefon = txthtelno.Text;
            DateTime DogumTarihi = dtphdogumt.Value.Date;
            string Adres = rtxthadres.Text;


            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sorgu = "insert into Hastalar  (Ad,Soyad,TC,DogumTarihi,Cinsiyet,Telefon,Adres)  values (@Ad,@Soyad,@TC,@DogumTarihi,@Cinsiyet,@Telefon,@Adres)";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@Ad", Ad);
                cmd.Parameters.AddWithValue("@Soyad", Soyad);
                cmd.Parameters.AddWithValue("@TC", TC);
                cmd.Parameters.AddWithValue("@DogumTarihi", DogumTarihi);
                cmd.Parameters.AddWithValue("@Cinsiyet", Cinsiyet);
                cmd.Parameters.AddWithValue("@Telefon", Telefon);
                cmd.Parameters.AddWithValue("@Adres", Adres);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Hasta Eklendi");
                    txthadi.Clear();
                    txthsoyad.Clear();
                    txthtc.Clear();
                    txthtelno.Clear();
                    rtxthadres.Clear(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("HATA!!!!" + ex.Message);
                }
                conn.Close();
                hastalistele();
            }

        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int HastaID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["HastaID"].Value);
                

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    string sorgu = "update Hastalar set Ad=@Ad,Soyad=@Soyad,TC=@TC,DogumTarihi=@DogumTarihi,Cinsiyet=@Cinsiyet,Telefon=@Telefon,Adres=@Adres where HastaID=@HastaID";
                    SqlCommand cmd=new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@HastaID",HastaID);
                    cmd.Parameters.AddWithValue("@Ad", txthadi.Text);
                    cmd.Parameters.AddWithValue("@Soyad", txthsoyad.Text);
                    cmd.Parameters.AddWithValue("@TC", txthtc.Text);
                    cmd.Parameters.AddWithValue("@DogumTarihi", dtphdogumt.Value.Date);
                    cmd.Parameters.AddWithValue("@Cinsiyet", cmbhcinsiyet.SelectedItem?.ToString()??"");
                    cmd.Parameters.AddWithValue("@Telefon", txthtelno.Text);
                    cmd.Parameters.AddWithValue("@Adres", rtxthadres.Text);
                    try
                    {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                        MessageBox.Show("Güncellendi!!");
                        txthadi.Clear();    
                        txthsoyad.Clear();  
                        txthtc.Clear(); 
                        txthtelno.Clear();  
                        rtxthadres.Clear();

                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }
                    hastalistele();
                   
                    conn.Close();   
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txthadi.Text = row.Cells["Ad"].Value?.ToString();
                txthsoyad.Text = row.Cells["Soyad"].Value?.ToString();
                txthtc.Text = row.Cells["TC"].Value?.ToString();
                txthtelno.Text = row.Cells["Telefon"].Value?.ToString();
                rtxthadres.Text = row.Cells["Adres"].Value?.ToString();
                if (DateTime.TryParse(row.Cells["DogumTarihi"].Value?.ToString(), out DateTime dt)) { dtphdogumt.Value = dt; }
                cmbhcinsiyet.SelectedIndex = cmbhcinsiyet.FindStringExact(row.Cells["Cinsiyet"].Value?.ToString());
            }


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            
        }




        private void btndsil_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            { string DoktorID=dataGridView2.CurrentRow.Cells["DoktorID"].Value.ToString();
               using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sorgu = "DELETE FROM Doktorlar WHERE DoktorID=@DoktorID";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@DoktorID",DoktorID);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doktor Silindi!!");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
             
                conn.Close();
               DoktorListele();
            }
               

            }
            else {
                 MessageBox.Show("lütfen silmek istediğiniz satırı seçiniz");
                return;
              
            }
        }
        private void DoktorEkle()
        {
            string Ad = txtdad.Text;
            string Soyad = txtdsoyad.Text;
            string TC = txtdtc.Text;
            string Cinsiyet = cmbdcinsiyet.SelectedItem?.ToString() ?? "";
            string Telefon = txtdtelno.Text;
            DateTime DogumTarihi = dtpddogumt.Value.Date;
            string Adres = rtxtdadres.Text;
           
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sorgu = "insert into Doktorlar (Ad,Soyad,TC,DogumTarihi,Cinsiyet,Telefon,Adres)  values (@Ad,@Soyad,@TC,@DogumTarihi,@Cinsiyet,@Telefon,@Adres)";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@Ad", Ad);
                cmd.Parameters.AddWithValue("@Soyad", Soyad);
                cmd.Parameters.AddWithValue("@TC", TC);
                cmd.Parameters.AddWithValue("@DogumTarihi", DogumTarihi);
                cmd.Parameters.AddWithValue("@Cinsiyet", Cinsiyet);
                cmd.Parameters.AddWithValue("@Telefon", Telefon);
                cmd.Parameters.AddWithValue("@Adres", Adres);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Doktor Eklendi");
                    txtdad.Clear();
                    txtdsoyad.Clear();
                    txtdtc.Clear();
                    cmbdcinsiyet.Items.Clear();
                    rtxtdadres.Clear(); 
                    txtdtelno.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("HATA!!!!" + ex.Message);
                }
                conn.Close();
                DoktorListele();

            }
        }
        private void btndekle_Click(object sender, EventArgs e)
        {

                DoktorEkle();



        }
        private void DoktorListele()
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sorgu = "select  DoktorID,Ad, Soyad,TC,DogumTarihi,Cinsiyet,Telefon,Adres from Doktorlar";
                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;


            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btndlistele_Click(object sender, EventArgs e)
        {
            DoktorListele();
        }
        private void btndgüncelle_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {

                int DoktorID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["DoktorID"].Value);


                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    string sorgu = "update Doktorlar set Ad=@Ad,Soyad=@Soyad,TC=@TC,DogumTarihi=@DogumTarihi,Cinsiyet=@Cinsiyet,Telefon=@Telefon,Adres=@Adres where DoktorID=@DoktorID";
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@DoktorID", DoktorID);
                    cmd.Parameters.AddWithValue("@Ad", txtdad.Text);
                    cmd.Parameters.AddWithValue("@Soyad", txtdsoyad.Text);   
                    cmd.Parameters.AddWithValue("@TC", txtdtc.Text);
                    cmd.Parameters.AddWithValue("@DogumTarihi", dtpddogumt.Value.Date);
                    cmd.Parameters.AddWithValue("@Cinsiyet", cmbdcinsiyet.SelectedItem?.ToString() ?? "");
                    cmd.Parameters.AddWithValue("@Telefon", txtdtelno.Text);
                    cmd.Parameters.AddWithValue("@Adres", rtxtdadres.Text);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Güncellendi!!");
                        txtdad.Clear();
                        txtdsoyad.Clear();
                        txtdtc.Clear();
                        rtxtdadres.Clear();
                        txtdtelno.Clear();

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    DoktorListele();

                    conn.Close();
                }

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                txtdad.Text = row.Cells["Ad"].Value?.ToString();
                txtdsoyad.Text = row.Cells["Soyad"].Value?.ToString();             
                txtdtc.Text = row.Cells["TC"].Value?.ToString();
                txtdtelno.Text = row.Cells["Telefon"].Value?.ToString();
                rtxtdadres.Text = row.Cells["Adres"].Value?.ToString();
                if (DateTime.TryParse(row.Cells["DogumTarihi"].Value?.ToString(), out DateTime dt)) { dtpddogumt.Value = dt; }
                cmbdcinsiyet.SelectedIndex = cmbdcinsiyet.FindStringExact(row.Cells["Cinsiyet"].Value?.ToString());
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string HastaID = dataGridView1.CurrentRow.Cells["HastaID"].Value.ToString();
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    string sorgu = "DELETE FROM Hastalar WHERE HastaID=@HastaID";
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@HastaID", HastaID);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Hasta Silindi!!");

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    conn.Close();
                    hastalistele();
                }


            }
            else
            {
                MessageBox.Show("lütfen silmek istediğiniz satırı seçiniz");
                return;

            }

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow != null)
            {
                string RandevuID = dataGridView3.CurrentRow.Cells["RandevuID"].Value.ToString();
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    string sorgu = "DELETE FROM Randevular WHERE RandevuID=@RandevuID";
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.AddWithValue("@RandevuID", RandevuID);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Randevu Silindi!!");
                        RandevuListele();

                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                    conn.Close();
                    
                }
            }
        }

        private void btnrandevuekle_Click(object sender, EventArgs e)
        {
            int HastaID =Convert.ToInt32(cmbhasta.SelectedValue);
            int DoktorID = Convert.ToInt32(cmbdoktor.SelectedValue);
            int TedaviID=Convert.ToInt32(cmbtedavi.SelectedValue);
            DateTime Tarih = dtprandevu.Value.Date;
           string saat = cmbsaat.SelectedItem?.ToString() ?? "";
            string durum = "Aktif";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sorgu = "insert into Randevular (HastaID,DoktorID,Tarih,Saat,TedaviID,Durum) values (@HastaID,@DoktorID,@Tarih,@Saat,@TedaviID,@Durum)";
                SqlCommand cmd = new SqlCommand(sorgu,conn);
                cmd.Parameters.AddWithValue("HastaID", HastaID);
                cmd.Parameters.AddWithValue("DoktorID", DoktorID);
                cmd.Parameters.AddWithValue("Tarih", Tarih);
                cmd.Parameters.AddWithValue("Saat", saat);
                cmd.Parameters.AddWithValue ("TedaviID", TedaviID);  
                cmd.Parameters.AddWithValue("Durum", durum);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Randevu Eklendi");
                    RandevuListele();

                }
                catch (Exception ex) { MessageBox.Show("Hata" + ex.Message); }
                conn.Close();   
            }


        }

        private void btnrandevulistele_Click(object sender, EventArgs e)
        {
            RandevuListele();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                cmbhasta.SelectedValue = row.Cells["HastaID"].Value;
                cmbdoktor.SelectedValue = row.Cells["DoktorID"].Value;
                dtprandevu.Value = Convert.ToDateTime(row.Cells["Tarih"].Value);
                cmbsaat.SelectedIndex = cmbsaat.FindStringExact(row.Cells["Saat"].Value?.ToString());
                cmbtedavi.SelectedValue = row.Cells["TedaviID"].Value;
                  
               

            }
        }

        private void RandevuListele()
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sorgu = "SELECT  R.RandevuID,R.HastaID,R.DoktorID,H.Ad+ ' ' + H.Soyad AS HastaAdıSoyadı,D.Ad + ' ' + D.Soyad AS DoktorAdıSoyadı,R.Tarih,R.Saat,T.TedaviID,T.TedaviAdi,R.Durum FROM  Randevular R JOIN   Hastalar H ON R.HastaID = H.HastaID JOIN Doktorlar D ON R.DoktorID = D.DoktorID JOIN  Tedaviler T ON R.TedaviID = T.TedaviID";
                SqlDataAdapter adapter = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                dataGridView3.DataSource = dt;  
                adapter.Fill(dt);

                dataGridView3.Columns["HastaID"].Visible = false;
                dataGridView3.Columns["DoktorID"].Visible = false;
                dataGridView3.Columns["TedaviID"].Visible = false;






            }
        }
        private void btndüncellerandevu_Click(object sender, EventArgs e)
        {

            if (dataGridView3.SelectedRows.Count > 0)
            {

                int RandevuID = Convert.ToInt32(dataGridView3.CurrentRow.Cells["RandevuID"].Value); int HastaID = Convert.ToInt32(cmbhasta.SelectedValue);
                int DoktorID = Convert.ToInt32(cmbdoktor.SelectedValue);
                DateTime Tarih = dtprandevu.Value.Date;
                string saat = cmbsaat.SelectedItem?.ToString() ?? "";
                string durum = "Aktif";

                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    string sorgu = "update Randevular set( HastaID=@HastaID,DoktorID=@DoktorID,Tarih=@Tarih,Saat=@saat,Durum=@durum) where RandevuID=@RandevuID";
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                   
                    cmd.Parameters.AddWithValue("@HastaID", HastaID);
                    cmd.Parameters.AddWithValue("@DoktorID", DoktorID);
                    cmd.Parameters.AddWithValue("@Tarih", Tarih);
                    cmd.Parameters.AddWithValue("@Saat", saat);
                    cmd.Parameters.AddWithValue("@Durum", durum);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Güncellendi!!");
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    DoktorListele();

                    conn.Close();
                }
            }
        }
        // ComboBox'a hastaları yükle


        /*   private void button1_Click(object sender, EventArgs e)
           {
               //kullanıcı-şifre kısmındaki kaydet butonununun click kodu
               string kullaniciAdi = txtkullaniciadi.Text;
               string sifre = txtsifre.Text;
               string rol = cmbRol.SelectedItem.ToString();  
               string TC= txttc.Text;
               using (SqlConnection conn = new SqlConnection(connectionstring)) 
               {
                   string sorgu = "INSERT INTO Kullanicilar (KullaniciAdi, Sifre,TC,Rol) OUTPUT INSERTED.KullaniciID VALUES (@KullaniciAdi, @Sifre,@TC,@Rol)";
                   SqlCommand cmd = new SqlCommand(sorgu, conn);
                   cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                   cmd.Parameters.AddWithValue("@Sifre", sifre);
                   cmd.Parameters.AddWithValue("@TC", TC);
                   cmd.Parameters.AddWithValue("@Rol", rol);
                   try
                   {
                       conn.Open();    
                       cmd.ExecuteNonQuery();
                       MessageBox.Show("Kullanici EKlendi");
                       txtkullaniciadi.Clear();
                       txtsifre.Clear();
                       txttc.Clear();
                       int kullaniciID = (int)cmd.ExecuteScalar();
                       kullaniciIDyialvetabloyaekle(kullaniciID,rol,TC);

                   }
                   catch(Exception ex)
                   {
                       MessageBox.Show(ex.Message);    
                   }

               }

           }
           private void kullaniciIDyialvetabloyaekle(int kullaniciID, string rol, string TC)
           {
               using (SqlConnection conn = new SqlConnection(connectionstring))
               {
                   conn.Open(); // Bağlantıyı sadece 1 kere aç

                   bool kayitVarMi = false;

                   if (rol == "Hasta")
                   {
                       string hastaSorgu = "SELECT HastaID FROM Hastalar WHERE TC = @TC";
                       SqlCommand cmd = new SqlCommand(hastaSorgu, conn);
                       cmd.Parameters.AddWithValue("@TC", TC);

                       object result = cmd.ExecuteScalar();
                       if (result != null)
                       {
                           int hastaID = Convert.ToInt32(result);

                           string updateSorgu = "UPDATE Hastalar SET KullaniciID = @KullaniciID WHERE HastaID = @HastaID";
                           SqlCommand updateCmd = new SqlCommand(updateSorgu, conn);
                           updateCmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                           updateCmd.Parameters.AddWithValue("@HastaID", hastaID);

                           int affected = updateCmd.ExecuteNonQuery();
                           if (affected > 0)
                           {
                               MessageBox.Show("Hasta için kullanıcı ID atandı.");
                               kayitVarMi = true;
                           }
                       }
                   }

                   if (!kayitVarMi && rol == "Doktor")
                   {
                       string doktorSorgu = "SELECT DoktorID FROM Doktorlar WHERE TC = @TC";
                       SqlCommand cmd = new SqlCommand(doktorSorgu, conn);
                       cmd.Parameters.AddWithValue("@TC", TC);

                       object result = cmd.ExecuteScalar();
                       if (result != null)
                       {
                           int doktorID = Convert.ToInt32(result);

                           string updateSorgu = "UPDATE Doktorlar SET KullaniciID = @KullaniciID WHERE DoktorID = @DoktorID";
                           SqlCommand updateCmd = new SqlCommand(updateSorgu, conn);
                           updateCmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                           updateCmd.Parameters.AddWithValue("@DoktorID", doktorID);

                           int affected = updateCmd.ExecuteNonQuery();
                           if (affected > 0)
                           {
                               MessageBox.Show("Doktor için kullanıcı ID atandı.");
                               kayitVarMi = true;
                           }
                       }
                   }

                   if (!kayitVarMi)
                   {
                       MessageBox.Show("Bu TC'ye sahip bir hasta ya da doktor kaydı bulunamadı.");
                   }
               }
           }*/
        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcı-şifre kısmındaki kaydet butonununun click kodu
            string kullaniciAdi = txtkullaniciadi.Text;
            string sifre = txtsifre.Text;
            string rol = cmbRol.SelectedItem.ToString();
            string TC = txttc.Text;

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                string sorgu = "INSERT INTO Kullanicilar (KullaniciAdi, Sifre, TC, Rol) OUTPUT INSERTED.KullaniciID VALUES (@KullaniciAdi, @Sifre, @TC, @Rol)";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@Sifre", sifre);
                cmd.Parameters.AddWithValue("@TC", TC);
                cmd.Parameters.AddWithValue("@Rol", rol);

                try
                {
                    conn.Open();
                    // Kullanıcıyı ekliyoruz ve ID'sini alıyoruz.
                    int kullaniciID = (int)cmd.ExecuteScalar();

                    // Bu kullaniciID'yi, hasta ya da doktor kaydına ekliyoruz
                    kullaniciIDyialvetabloyaekle(kullaniciID, rol, TC);

                    MessageBox.Show("Kullanıcı Eklendi");
                    txtkullaniciadi.Clear();
                    txtsifre.Clear();
                    txttc.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void kullaniciIDyialvetabloyaekle(int kullaniciID, string rol, string TC)
        {
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open(); // Bağlantıyı sadece 1 kere aç

                bool kayitVarMi = false;

                if (rol == "Hasta")
                {
                    string hastaSorgu = "SELECT HastaID FROM Hastalar WHERE TC = @TC";
                    SqlCommand cmd = new SqlCommand(hastaSorgu, conn);
                    cmd.Parameters.AddWithValue("@TC", TC);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        int hastaID = Convert.ToInt32(result);

                        string updateSorgu = "UPDATE Hastalar SET KullaniciID = @KullaniciID WHERE HastaID = @HastaID";
                        SqlCommand updateCmd = new SqlCommand(updateSorgu, conn);
                        updateCmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                        updateCmd.Parameters.AddWithValue("@HastaID", hastaID);

                        int affected = updateCmd.ExecuteNonQuery();
                        if (affected > 0)
                        {
                            MessageBox.Show("Hasta için kullanıcı ID atandı.");
                            kayitVarMi = true;
                        }
                    }
                }

                if (!kayitVarMi && rol == "Doktor")
                {
                    string doktorSorgu = "SELECT DoktorID FROM Doktorlar WHERE TC = @TC";
                    SqlCommand cmd = new SqlCommand(doktorSorgu, conn);
                    cmd.Parameters.AddWithValue("@TC", TC);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        int doktorID = Convert.ToInt32(result);

                        string updateSorgu = "UPDATE Doktorlar SET KullaniciID = @KullaniciID WHERE DoktorID = @DoktorID";
                        SqlCommand updateCmd = new SqlCommand(updateSorgu, conn);
                        updateCmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                        updateCmd.Parameters.AddWithValue("@DoktorID", doktorID);

                        int affected = updateCmd.ExecuteNonQuery();
                        if (affected > 0)
                        {
                            MessageBox.Show("Doktor için kullanıcı ID atandı.");
                            kayitVarMi = true;
                        }
                    }
                }

                if (!kayitVarMi)
                {
                    MessageBox.Show("Bu TC'ye sahip bir hasta ya da doktor kaydı bulunamadı.");
                }
            }
        }


    }
}
