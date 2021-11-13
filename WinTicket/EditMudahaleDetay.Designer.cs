
namespace WinTicket
{
    partial class EditMudahaleDetay
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
            this.ddlSinif = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlMudahale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlAktivite = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSiraNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlAlan
            // 
            this.ddlAlan.FormattingEnabled = true;
            this.ddlAlan.Location = new System.Drawing.Point(17, 66);
            this.ddlAlan.Name = "ddlAlan";
            this.ddlAlan.Size = new System.Drawing.Size(178, 21);
            this.ddlAlan.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Alan";
            // 
            // lblAddBirimTitle
            // 
            this.lblAddBirimTitle.AutoSize = true;
            this.lblAddBirimTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAddBirimTitle.Location = new System.Drawing.Point(12, 9);
            this.lblAddBirimTitle.Name = "lblAddBirimTitle";
            this.lblAddBirimTitle.Size = new System.Drawing.Size(146, 26);
            this.lblAddBirimTitle.TabIndex = 70;
            this.lblAddBirimTitle.Text = "Müdale Detay";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKaydet.Location = new System.Drawing.Point(315, 187);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 68;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ddlSinif
            // 
            this.ddlSinif.FormattingEnabled = true;
            this.ddlSinif.Location = new System.Drawing.Point(212, 66);
            this.ddlSinif.Name = "ddlSinif";
            this.ddlSinif.Size = new System.Drawing.Size(178, 21);
            this.ddlSinif.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Sınıf";
            // 
            // ddlMudahale
            // 
            this.ddlMudahale.FormattingEnabled = true;
            this.ddlMudahale.Location = new System.Drawing.Point(17, 105);
            this.ddlMudahale.Name = "ddlMudahale";
            this.ddlMudahale.Size = new System.Drawing.Size(178, 21);
            this.ddlMudahale.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 74;
            this.label1.Text = "Müdahale";
            // 
            // ddlAktivite
            // 
            this.ddlAktivite.FormattingEnabled = true;
            this.ddlAktivite.Location = new System.Drawing.Point(212, 105);
            this.ddlAktivite.Name = "ddlAktivite";
            this.ddlAktivite.Size = new System.Drawing.Size(178, 21);
            this.ddlAktivite.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 76;
            this.label4.Text = "Aktivite";
            // 
            // txtSiraNo
            // 
            this.txtSiraNo.Location = new System.Drawing.Point(17, 145);
            this.txtSiraNo.Name = "txtSiraNo";
            this.txtSiraNo.Size = new System.Drawing.Size(178, 20);
            this.txtSiraNo.TabIndex = 78;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 79;
            this.label5.Text = "Sıra";
            // 
            // EditMudahaleDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 236);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSiraNo);
            this.Controls.Add(this.ddlAktivite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddlMudahale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlAlan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAddBirimTitle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.ddlSinif);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditMudahaleDetay";
            this.Text = "Müdale Detay";
            this.Load += new System.EventHandler(this.EditMudahaleDetay_Load);
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
        private System.Windows.Forms.ComboBox ddlSinif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSiraNo;
        private System.Windows.Forms.ComboBox ddlAktivite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlMudahale;
        private System.Windows.Forms.Label label1;
    }
}