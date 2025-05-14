namespace nazli221103042_klinik
{
    partial class DoktorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoktorForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btndoktorrecete = new System.Windows.Forms.Button();
            this.btndoktorunhastlari = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnnotsil = new System.Windows.Forms.Button();
            this.btnsilrecete = new System.Windows.Forms.Button();
            this.btnreceteekle = new System.Windows.Forms.Button();
            this.rchtxtRecete = new System.Windows.Forms.RichTextBox();
            this.btnnotekle = new System.Windows.Forms.Button();
            this.rchtxtnot = new System.Windows.Forms.RichTextBox();
            this.dataGridViewdoktor = new System.Windows.Forms.DataGridView();
            this.lbldoktorhosgeldin = new System.Windows.Forms.Label();
            this.btnkapatdoktor = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdoktor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(226, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(595, 49);
            this.label1.TabIndex = 2;
            this.label1.Text = "DİŞ KLİNİĞİ OTOMASYONU";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.btnkapatdoktor);
            this.panel1.Controls.Add(this.lbldoktorhosgeldin);
            this.panel1.Controls.Add(this.btndoktorrecete);
            this.panel1.Controls.Add(this.btndoktorunhastlari);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1091, 135);
            this.panel1.TabIndex = 3;
            // 
            // btndoktorrecete
            // 
            this.btndoktorrecete.Location = new System.Drawing.Point(529, 69);
            this.btndoktorrecete.Name = "btndoktorrecete";
            this.btndoktorrecete.Size = new System.Drawing.Size(128, 43);
            this.btndoktorrecete.TabIndex = 5;
            this.btndoktorrecete.Text = "Reçete";
            this.btndoktorrecete.UseVisualStyleBackColor = true;
            this.btndoktorrecete.Click += new System.EventHandler(this.btndoktorrecete_Click);
            // 
            // btndoktorunhastlari
            // 
            this.btndoktorunhastlari.Location = new System.Drawing.Point(395, 69);
            this.btndoktorunhastlari.Name = "btndoktorunhastlari";
            this.btndoktorunhastlari.Size = new System.Drawing.Size(128, 43);
            this.btndoktorunhastlari.TabIndex = 4;
            this.btndoktorunhastlari.Text = "Hastalarım";
            this.btndoktorunhastlari.UseVisualStyleBackColor = true;
            this.btndoktorunhastlari.Click += new System.EventHandler(this.btndoktorunhastlari_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Randevularım";
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(246, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(564, 49);
            this.label2.TabIndex = 1;
            this.label2.Text = "DÜZCE ÖZEL DİŞ KLİNİĞİ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.Controls.Add(this.btnnotsil);
            this.panel2.Controls.Add(this.btnsilrecete);
            this.panel2.Controls.Add(this.btnreceteekle);
            this.panel2.Controls.Add(this.rchtxtRecete);
            this.panel2.Controls.Add(this.btnnotekle);
            this.panel2.Controls.Add(this.rchtxtnot);
            this.panel2.Controls.Add(this.dataGridViewdoktor);
            this.panel2.Location = new System.Drawing.Point(1, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1091, 442);
            this.panel2.TabIndex = 4;
            // 
            // btnnotsil
            // 
            this.btnnotsil.Location = new System.Drawing.Point(847, 275);
            this.btnnotsil.Name = "btnnotsil";
            this.btnnotsil.Size = new System.Drawing.Size(131, 44);
            this.btnnotsil.TabIndex = 6;
            this.btnnotsil.Text = "SİL";
            this.btnnotsil.UseVisualStyleBackColor = true;
            this.btnnotsil.Visible = false;
            this.btnnotsil.Click += new System.EventHandler(this.btnnotsil_Click);
            // 
            // btnsilrecete
            // 
            this.btnsilrecete.Location = new System.Drawing.Point(838, 338);
            this.btnsilrecete.Name = "btnsilrecete";
            this.btnsilrecete.Size = new System.Drawing.Size(131, 46);
            this.btnsilrecete.TabIndex = 5;
            this.btnsilrecete.Text = "SİL";
            this.btnsilrecete.UseVisualStyleBackColor = true;
            this.btnsilrecete.Visible = false;
            this.btnsilrecete.Click += new System.EventHandler(this.btnsilrecete_Click);
            // 
            // btnreceteekle
            // 
            this.btnreceteekle.Location = new System.Drawing.Point(838, 285);
            this.btnreceteekle.Name = "btnreceteekle";
            this.btnreceteekle.Size = new System.Drawing.Size(131, 46);
            this.btnreceteekle.TabIndex = 4;
            this.btnreceteekle.Text = "ReceteEkle";
            this.btnreceteekle.UseVisualStyleBackColor = true;
            this.btnreceteekle.Visible = false;
            this.btnreceteekle.Click += new System.EventHandler(this.btnreceteekle_Click);
            // 
            // rchtxtRecete
            // 
            this.rchtxtRecete.Location = new System.Drawing.Point(716, 76);
            this.rchtxtRecete.Name = "rchtxtRecete";
            this.rchtxtRecete.Size = new System.Drawing.Size(363, 168);
            this.rchtxtRecete.TabIndex = 3;
            this.rchtxtRecete.Text = "";
            this.rchtxtRecete.Visible = false;
            // 
            // btnnotekle
            // 
            this.btnnotekle.BackColor = System.Drawing.Color.SteelBlue;
            this.btnnotekle.Location = new System.Drawing.Point(847, 223);
            this.btnnotekle.Name = "btnnotekle";
            this.btnnotekle.Size = new System.Drawing.Size(131, 46);
            this.btnnotekle.TabIndex = 2;
            this.btnnotekle.Text = "NOT EKLE";
            this.btnnotekle.UseVisualStyleBackColor = false;
            this.btnnotekle.Visible = false;
            this.btnnotekle.Click += new System.EventHandler(this.btnnotekle_Click);
            // 
            // rchtxtnot
            // 
            this.rchtxtnot.BackColor = System.Drawing.Color.LightBlue;
            this.rchtxtnot.Location = new System.Drawing.Point(716, 28);
            this.rchtxtnot.Name = "rchtxtnot";
            this.rchtxtnot.Size = new System.Drawing.Size(363, 168);
            this.rchtxtnot.TabIndex = 1;
            this.rchtxtnot.TabStop = false;
            this.rchtxtnot.Text = "";
            this.rchtxtnot.Visible = false;
            // 
            // dataGridViewdoktor
            // 
            this.dataGridViewdoktor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewdoktor.Location = new System.Drawing.Point(27, 28);
            this.dataGridViewdoktor.Name = "dataGridViewdoktor";
            this.dataGridViewdoktor.RowHeadersWidth = 51;
            this.dataGridViewdoktor.RowTemplate.Height = 24;
            this.dataGridViewdoktor.Size = new System.Drawing.Size(669, 381);
            this.dataGridViewdoktor.StandardTab = true;
            this.dataGridViewdoktor.TabIndex = 0;
            // 
            // lbldoktorhosgeldin
            // 
            this.lbldoktorhosgeldin.AutoSize = true;
            this.lbldoktorhosgeldin.Location = new System.Drawing.Point(304, 110);
            this.lbldoktorhosgeldin.Name = "lbldoktorhosgeldin";
            this.lbldoktorhosgeldin.Size = new System.Drawing.Size(85, 16);
            this.lbldoktorhosgeldin.TabIndex = 6;
            this.lbldoktorhosgeldin.Text = "HOŞGELDİN";
            // 
            // btnkapatdoktor
            // 
            this.btnkapatdoktor.BackColor = System.Drawing.Color.Black;
            this.btnkapatdoktor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnkapatdoktor.Location = new System.Drawing.Point(1065, 0);
            this.btnkapatdoktor.Name = "btnkapatdoktor";
            this.btnkapatdoktor.Size = new System.Drawing.Size(26, 26);
            this.btnkapatdoktor.TabIndex = 7;
            this.btnkapatdoktor.Text = "X";
            this.btnkapatdoktor.UseVisualStyleBackColor = false;
            this.btnkapatdoktor.Click += new System.EventHandler(this.btnkapatdoktor_Click);
            // 
            // DoktorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 575);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "DoktorForm";
            this.Text = "DoktorForm";
            this.Load += new System.EventHandler(this.DoktorForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdoktor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btndoktorrecete;
        private System.Windows.Forms.Button btndoktorunhastlari;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewdoktor;
        private System.Windows.Forms.Button btnnotekle;
        private System.Windows.Forms.RichTextBox rchtxtnot;
        private System.Windows.Forms.Button btnreceteekle;
        private System.Windows.Forms.RichTextBox rchtxtRecete;
        private System.Windows.Forms.Button btnsilrecete;
        private System.Windows.Forms.Button btnnotsil;
        private System.Windows.Forms.Label lbldoktorhosgeldin;
        private System.Windows.Forms.Button btnkapatdoktor;
    }
}