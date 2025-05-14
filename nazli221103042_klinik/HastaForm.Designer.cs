namespace nazli221103042_klinik
{
    partial class HastaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HastaForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbhastarandevususaat = new System.Windows.Forms.ComboBox();
            this.btnhastarandevualıyor = new System.Windows.Forms.Button();
            this.dataGridViewHasta = new System.Windows.Forms.DataGridView();
            this.dtphastarandevusal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbhastarandevutedavi = new System.Windows.Forms.ComboBox();
            this.cmbhastarandevudoktor = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnrandevuandrecete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblhosgeldinhasta = new System.Windows.Forms.Label();
            this.btndoktorcikis = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHasta)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cmbhastarandevususaat);
            this.panel2.Controls.Add(this.btnhastarandevualıyor);
            this.panel2.Controls.Add(this.dataGridViewHasta);
            this.panel2.Controls.Add(this.dtphastarandevusal);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbhastarandevutedavi);
            this.panel2.Controls.Add(this.cmbhastarandevudoktor);
            this.panel2.Location = new System.Drawing.Point(2, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1194, 455);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(10, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1170, 443);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Saat Seçiniz:";
            this.label5.Visible = false;
            // 
            // cmbhastarandevususaat
            // 
            this.cmbhastarandevususaat.FormattingEnabled = true;
            this.cmbhastarandevususaat.Items.AddRange(new object[] {
            "8:00",
            "8:30",
            "8:45",
            "9:00",
            "9:15",
            "9:30",
            "9:45",
            "10:00",
            "10:30",
            "12:00",
            "14:00",
            "14:15",
            "14:30",
            "2:45",
            "15:00",
            "15:30",
            "16:00",
            "16:15",
            "16:30",
            "16:45",
            "17:00",
            "17:30",
            "18:00",
            "18:15",
            "18:30",
            "18:45",
            "19:00",
            "19:30",
            "20:00"});
            this.cmbhastarandevususaat.Location = new System.Drawing.Point(147, 228);
            this.cmbhastarandevususaat.Name = "cmbhastarandevususaat";
            this.cmbhastarandevususaat.Size = new System.Drawing.Size(224, 24);
            this.cmbhastarandevususaat.TabIndex = 8;
            this.cmbhastarandevususaat.Visible = false;
            // 
            // btnhastarandevualıyor
            // 
            this.btnhastarandevualıyor.Location = new System.Drawing.Point(147, 314);
            this.btnhastarandevualıyor.Name = "btnhastarandevualıyor";
            this.btnhastarandevualıyor.Size = new System.Drawing.Size(121, 55);
            this.btnhastarandevualıyor.TabIndex = 7;
            this.btnhastarandevualıyor.Text = "RANDEVU AL";
            this.btnhastarandevualıyor.UseVisualStyleBackColor = true;
            this.btnhastarandevualıyor.Visible = false;
            this.btnhastarandevualıyor.Click += new System.EventHandler(this.btnhastarandevualıyor_Click);
            // 
            // dataGridViewHasta
            // 
            this.dataGridViewHasta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHasta.Location = new System.Drawing.Point(204, 31);
            this.dataGridViewHasta.Name = "dataGridViewHasta";
            this.dataGridViewHasta.RowHeadersWidth = 51;
            this.dataGridViewHasta.RowTemplate.Height = 24;
            this.dataGridViewHasta.Size = new System.Drawing.Size(730, 386);
            this.dataGridViewHasta.TabIndex = 6;
            this.dataGridViewHasta.Visible = false;
            // 
            // dtphastarandevusal
            // 
            this.dtphastarandevusal.Location = new System.Drawing.Point(148, 176);
            this.dtphastarandevusal.Name = "dtphastarandevusal";
            this.dtphastarandevusal.Size = new System.Drawing.Size(223, 22);
            this.dtphastarandevusal.TabIndex = 5;
            this.dtphastarandevusal.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tarih Seçiniz:";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tedavi Seçiniz:";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Doktor Seçiniz:";
            this.label1.Visible = false;
            // 
            // cmbhastarandevutedavi
            // 
            this.cmbhastarandevutedavi.FormattingEnabled = true;
            this.cmbhastarandevutedavi.Location = new System.Drawing.Point(148, 119);
            this.cmbhastarandevutedavi.Name = "cmbhastarandevutedavi";
            this.cmbhastarandevutedavi.Size = new System.Drawing.Size(223, 24);
            this.cmbhastarandevutedavi.TabIndex = 1;
            this.cmbhastarandevutedavi.Visible = false;
            // 
            // cmbhastarandevudoktor
            // 
            this.cmbhastarandevudoktor.FormattingEnabled = true;
            this.cmbhastarandevudoktor.Location = new System.Drawing.Point(147, 61);
            this.cmbhastarandevudoktor.Name = "cmbhastarandevudoktor";
            this.cmbhastarandevudoktor.Size = new System.Drawing.Size(224, 24);
            this.cmbhastarandevudoktor.TabIndex = 0;
            this.cmbhastarandevudoktor.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.btndoktorcikis);
            this.panel1.Controls.Add(this.lblhosgeldinhasta);
            this.panel1.Controls.Add(this.btnrandevuandrecete);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 135);
            this.panel1.TabIndex = 6;
            // 
            // btnrandevuandrecete
            // 
            this.btnrandevuandrecete.Location = new System.Drawing.Point(775, 69);
            this.btnrandevuandrecete.Name = "btnrandevuandrecete";
            this.btnrandevuandrecete.Size = new System.Drawing.Size(216, 43);
            this.btnrandevuandrecete.TabIndex = 4;
            this.btnrandevuandrecete.Text = "Randevularım-Reçetelerim";
            this.btnrandevuandrecete.UseVisualStyleBackColor = true;
            this.btnrandevuandrecete.Click += new System.EventHandler(this.btnrandevuandrecete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(641, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Randevu Al";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(256, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(564, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "DÜZCE ÖZEL DİŞ KLİNİĞİ";
            // 
            // lblhosgeldinhasta
            // 
            this.lblhosgeldinhasta.AutoSize = true;
            this.lblhosgeldinhasta.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhosgeldinhasta.Location = new System.Drawing.Point(271, 75);
            this.lblhosgeldinhasta.Name = "lblhosgeldinhasta";
            this.lblhosgeldinhasta.Size = new System.Drawing.Size(142, 25);
            this.lblhosgeldinhasta.TabIndex = 5;
            this.lblhosgeldinhasta.Text = "HOŞGELDİN";
            // 
            // btndoktorcikis
            // 
            this.btndoktorcikis.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btndoktorcikis.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btndoktorcikis.Location = new System.Drawing.Point(1164, 0);
            this.btndoktorcikis.Name = "btndoktorcikis";
            this.btndoktorcikis.Size = new System.Drawing.Size(27, 28);
            this.btndoktorcikis.TabIndex = 6;
            this.btndoktorcikis.Text = "X";
            this.btndoktorcikis.UseVisualStyleBackColor = false;
            this.btndoktorcikis.Click += new System.EventHandler(this.btndoktorcikis_Click);
            // 
            // HastaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 583);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "HastaForm";
            this.Text = "HastaForm";
            this.Load += new System.EventHandler(this.HastaForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHasta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnrandevuandrecete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtphastarandevusal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbhastarandevutedavi;
        private System.Windows.Forms.ComboBox cmbhastarandevudoktor;
        private System.Windows.Forms.DataGridView dataGridViewHasta;
        private System.Windows.Forms.Button btnhastarandevualıyor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbhastarandevususaat;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblhosgeldinhasta;
        private System.Windows.Forms.Button btndoktorcikis;
    }
}