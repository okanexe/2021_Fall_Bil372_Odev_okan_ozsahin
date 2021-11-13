
namespace WinTicket
{
    partial class EditBirim
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
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtBirimAdi = new System.Windows.Forms.TextBox();
            this.lblAddBirimTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlUstBirim = new System.Windows.Forms.ComboBox();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlIl = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlIlce = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPostaKodu = new System.Windows.Forms.TextBox();
            this.ddlBirimMuduru = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKaydet.Location = new System.Drawing.Point(291, 394);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtBirimAdi
            // 
            this.txtBirimAdi.Location = new System.Drawing.Point(21, 82);
            this.txtBirimAdi.Name = "txtBirimAdi";
            this.txtBirimAdi.Size = new System.Drawing.Size(178, 20);
            this.txtBirimAdi.TabIndex = 1;
            // 
            // lblAddBirimTitle
            // 
            this.lblAddBirimTitle.AutoSize = true;
            this.lblAddBirimTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAddBirimTitle.Location = new System.Drawing.Point(13, 13);
            this.lblAddBirimTitle.Name = "lblAddBirimTitle";
            this.lblAddBirimTitle.Size = new System.Drawing.Size(63, 26);
            this.lblAddBirimTitle.TabIndex = 2;
            this.lblAddBirimTitle.Text = "Birim";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Birim Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Üst Birim";
            // 
            // ddlUstBirim
            // 
            this.ddlUstBirim.FormattingEnabled = true;
            this.ddlUstBirim.Location = new System.Drawing.Point(21, 122);
            this.ddlUstBirim.Name = "ddlUstBirim";
            this.ddlUstBirim.Size = new System.Drawing.Size(178, 21);
            this.ddlUstBirim.TabIndex = 6;
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(21, 164);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(345, 76);
            this.txtAdres.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Adres";
            // 
            // ddlIl
            // 
            this.ddlIl.FormattingEnabled = true;
            this.ddlIl.Location = new System.Drawing.Point(21, 261);
            this.ddlIl.Name = "ddlIl";
            this.ddlIl.Size = new System.Drawing.Size(178, 21);
            this.ddlIl.TabIndex = 10;
            this.ddlIl.SelectedIndexChanged += new System.EventHandler(this.ddlIl_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "İl";
            // 
            // ddlIlce
            // 
            this.ddlIlce.FormattingEnabled = true;
            this.ddlIlce.Location = new System.Drawing.Point(205, 261);
            this.ddlIlce.Name = "ddlIlce";
            this.ddlIlce.Size = new System.Drawing.Size(161, 21);
            this.ddlIlce.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "İlçe";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 287);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Posta Kodu";
            // 
            // txtPostaKodu
            // 
            this.txtPostaKodu.Location = new System.Drawing.Point(21, 303);
            this.txtPostaKodu.Name = "txtPostaKodu";
            this.txtPostaKodu.Size = new System.Drawing.Size(178, 20);
            this.txtPostaKodu.TabIndex = 14;
            // 
            // ddlBirimMuduru
            // 
            this.ddlBirimMuduru.FormattingEnabled = true;
            this.ddlBirimMuduru.Location = new System.Drawing.Point(21, 344);
            this.ddlBirimMuduru.Name = "ddlBirimMuduru";
            this.ddlBirimMuduru.Size = new System.Drawing.Size(178, 21);
            this.ddlBirimMuduru.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Birim Müdürü";
            // 
            // EditBirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 439);
            this.Controls.Add(this.ddlBirimMuduru);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPostaKodu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ddlIlce);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ddlIl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.ddlUstBirim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddBirimTitle);
            this.Controls.Add(this.txtBirimAdi);
            this.Controls.Add(this.btnKaydet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditBirim";
            this.Text = "Birim";
            this.Load += new System.EventHandler(this.AddBirim_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.TextBox txtBirimAdi;
        private System.Windows.Forms.Label lblAddBirimTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlUstBirim;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlIl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlIlce;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPostaKodu;
        private System.Windows.Forms.ComboBox ddlBirimMuduru;
        private System.Windows.Forms.Label label6;
    }
}