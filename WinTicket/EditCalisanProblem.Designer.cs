
namespace WinTicket
{
    partial class EditCalisanProblem
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
            this.components = new System.ComponentModel.Container();
            this.ddlAlan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAddBirimTitle = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ddlProblem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlMudahale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlSinif = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlAktivite = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlKullanici = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAktiviteAciklama = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlAlan
            // 
            this.ddlAlan.FormattingEnabled = true;
            this.ddlAlan.Location = new System.Drawing.Point(17, 66);
            this.ddlAlan.Name = "ddlAlan";
            this.ddlAlan.Size = new System.Drawing.Size(178, 21);
            this.ddlAlan.TabIndex = 93;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "Alan";
            // 
            // lblAddBirimTitle
            // 
            this.lblAddBirimTitle.AutoSize = true;
            this.lblAddBirimTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAddBirimTitle.Location = new System.Drawing.Point(12, 9);
            this.lblAddBirimTitle.Name = "lblAddBirimTitle";
            this.lblAddBirimTitle.Size = new System.Drawing.Size(173, 26);
            this.lblAddBirimTitle.TabIndex = 92;
            this.lblAddBirimTitle.Text = "Çalışan Problem";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKaydet.Location = new System.Drawing.Point(315, 219);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 91;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ddlProblem
            // 
            this.ddlProblem.FormattingEnabled = true;
            this.ddlProblem.Location = new System.Drawing.Point(212, 105);
            this.ddlProblem.Name = "ddlProblem";
            this.ddlProblem.Size = new System.Drawing.Size(178, 21);
            this.ddlProblem.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "Problem";
            // 
            // ddlMudahale
            // 
            this.ddlMudahale.FormattingEnabled = true;
            this.ddlMudahale.Location = new System.Drawing.Point(17, 105);
            this.ddlMudahale.Name = "ddlMudahale";
            this.ddlMudahale.Size = new System.Drawing.Size(178, 21);
            this.ddlMudahale.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 96;
            this.label1.Text = "Müdahale";
            // 
            // ddlSinif
            // 
            this.ddlSinif.FormattingEnabled = true;
            this.ddlSinif.Location = new System.Drawing.Point(212, 66);
            this.ddlSinif.Name = "ddlSinif";
            this.ddlSinif.Size = new System.Drawing.Size(178, 21);
            this.ddlSinif.TabIndex = 95;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 94;
            this.label3.Text = "Sınıf";
            // 
            // ddlAktivite
            // 
            this.ddlAktivite.FormattingEnabled = true;
            this.ddlAktivite.Location = new System.Drawing.Point(17, 144);
            this.ddlAktivite.Name = "ddlAktivite";
            this.ddlAktivite.Size = new System.Drawing.Size(178, 21);
            this.ddlAktivite.TabIndex = 101;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Aktivite";
            // 
            // ddlKullanici
            // 
            this.ddlKullanici.FormattingEnabled = true;
            this.ddlKullanici.Location = new System.Drawing.Point(17, 183);
            this.ddlKullanici.Name = "ddlKullanici";
            this.ddlKullanici.Size = new System.Drawing.Size(178, 21);
            this.ddlKullanici.TabIndex = 103;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 102;
            this.label6.Text = "Kullanıcı";
            // 
            // txtAktiviteAciklama
            // 
            this.txtAktiviteAciklama.Location = new System.Drawing.Point(212, 145);
            this.txtAktiviteAciklama.Name = "txtAktiviteAciklama";
            this.txtAktiviteAciklama.Size = new System.Drawing.Size(178, 20);
            this.txtAktiviteAciklama.TabIndex = 104;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "Aktivite Açıklama";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 106;
            this.label8.Text = "Tarih";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(212, 184);
            this.dtpTarih.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.dtpTarih.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(178, 20);
            this.dtpTarih.TabIndex = 107;
            // 
            // EditCalisanProblem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 271);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAktiviteAciklama);
            this.Controls.Add(this.ddlKullanici);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ddlAktivite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ddlAlan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAddBirimTitle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.ddlProblem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddlMudahale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlSinif);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCalisanProblem";
            this.Text = "Çalışan Problem";
            this.Load += new System.EventHandler(this.EditCalisanProblem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlAlan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAddBirimTitle;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox ddlProblem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlMudahale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlSinif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlKullanici;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlAktivite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAktiviteAciklama;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTarih;
    }
}