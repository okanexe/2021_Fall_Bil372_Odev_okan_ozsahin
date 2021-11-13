
namespace WinTicket
{
    partial class EditProblemDurumDegerlendirme
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
            this.ddlProblem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddBirimTitle = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.dtpDegerlendirmeTarihi = new System.Windows.Forms.DateTimePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtOncekiProblemSkoru = new System.Windows.Forms.TextBox();
            this.ddlKullanici = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYeniProblemTanimi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtYeniHedef = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTahminEdilenProblemSkoru = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlProblem
            // 
            this.ddlProblem.FormattingEnabled = true;
            this.ddlProblem.Location = new System.Drawing.Point(17, 105);
            this.ddlProblem.Name = "ddlProblem";
            this.ddlProblem.Size = new System.Drawing.Size(178, 21);
            this.ddlProblem.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Problem";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "Değerlendirme Tarihi";
            // 
            // lblAddBirimTitle
            // 
            this.lblAddBirimTitle.AutoSize = true;
            this.lblAddBirimTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAddBirimTitle.Location = new System.Drawing.Point(12, 9);
            this.lblAddBirimTitle.Name = "lblAddBirimTitle";
            this.lblAddBirimTitle.Size = new System.Drawing.Size(315, 26);
            this.lblAddBirimTitle.TabIndex = 88;
            this.lblAddBirimTitle.Text = "Problem Durum Değerlendirme";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKaydet.Location = new System.Drawing.Point(318, 218);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 87;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // dtpDegerlendirmeTarihi
            // 
            this.dtpDegerlendirmeTarihi.Location = new System.Drawing.Point(17, 185);
            this.dtpDegerlendirmeTarihi.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.dtpDegerlendirmeTarihi.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dtpDegerlendirmeTarihi.Name = "dtpDegerlendirmeTarihi";
            this.dtpDegerlendirmeTarihi.Size = new System.Drawing.Size(178, 20);
            this.dtpDegerlendirmeTarihi.TabIndex = 92;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 94;
            this.label4.Text = "Önceki Problem Skoru";
            // 
            // txtOncekiProblemSkoru
            // 
            this.txtOncekiProblemSkoru.Location = new System.Drawing.Point(215, 106);
            this.txtOncekiProblemSkoru.Name = "txtOncekiProblemSkoru";
            this.txtOncekiProblemSkoru.Size = new System.Drawing.Size(178, 20);
            this.txtOncekiProblemSkoru.TabIndex = 93;
            // 
            // ddlKullanici
            // 
            this.ddlKullanici.FormattingEnabled = true;
            this.ddlKullanici.Location = new System.Drawing.Point(215, 145);
            this.ddlKullanici.Name = "ddlKullanici";
            this.ddlKullanici.Size = new System.Drawing.Size(178, 21);
            this.ddlKullanici.TabIndex = 91;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "Kullanıcı";
            // 
            // txtYeniProblemTanimi
            // 
            this.txtYeniProblemTanimi.Location = new System.Drawing.Point(17, 65);
            this.txtYeniProblemTanimi.Name = "txtYeniProblemTanimi";
            this.txtYeniProblemTanimi.Size = new System.Drawing.Size(178, 20);
            this.txtYeniProblemTanimi.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "Yeni Problem Tanımı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(215, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 98;
            this.label6.Text = "Yeni Hedef";
            // 
            // txtYeniHedef
            // 
            this.txtYeniHedef.Location = new System.Drawing.Point(215, 65);
            this.txtYeniHedef.Name = "txtYeniHedef";
            this.txtYeniHedef.Size = new System.Drawing.Size(178, 20);
            this.txtYeniHedef.TabIndex = 97;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 13);
            this.label7.TabIndex = 100;
            this.label7.Text = "Tahmin Edilen Problem Skoru";
            // 
            // txtTahminEdilenProblemSkoru
            // 
            this.txtTahminEdilenProblemSkoru.Location = new System.Drawing.Point(17, 145);
            this.txtTahminEdilenProblemSkoru.Name = "txtTahminEdilenProblemSkoru";
            this.txtTahminEdilenProblemSkoru.Size = new System.Drawing.Size(178, 20);
            this.txtTahminEdilenProblemSkoru.TabIndex = 99;
            // 
            // EditProblemDurumDegerlendirme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 267);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTahminEdilenProblemSkoru);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtYeniHedef);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtYeniProblemTanimi);
            this.Controls.Add(this.ddlProblem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddBirimTitle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dtpDegerlendirmeTarihi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOncekiProblemSkoru);
            this.Controls.Add(this.ddlKullanici);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProblemDurumDegerlendirme";
            this.Text = "Problem Durum Değerlendirme";
            this.Load += new System.EventHandler(this.EditProblemDurumDegerlendirme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlProblem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddBirimTitle;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.DateTimePicker dtpDegerlendirmeTarihi;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOncekiProblemSkoru;
        private System.Windows.Forms.ComboBox ddlKullanici;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTahminEdilenProblemSkoru;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtYeniHedef;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYeniProblemTanimi;
    }
}