
namespace WinTicket
{
    partial class EditIlaveCiktiDetay
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtSira = new System.Windows.Forms.TextBox();
            this.ddlProblem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlMudahale = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlSinif = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlBelirtec = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlAlan
            // 
            this.ddlAlan.FormattingEnabled = true;
            this.ddlAlan.Location = new System.Drawing.Point(212, 65);
            this.ddlAlan.Name = "ddlAlan";
            this.ddlAlan.Size = new System.Drawing.Size(178, 21);
            this.ddlAlan.TabIndex = 107;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Alan";
            // 
            // lblAddBirimTitle
            // 
            this.lblAddBirimTitle.AutoSize = true;
            this.lblAddBirimTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAddBirimTitle.Location = new System.Drawing.Point(12, 9);
            this.lblAddBirimTitle.Name = "lblAddBirimTitle";
            this.lblAddBirimTitle.Size = new System.Drawing.Size(170, 26);
            this.lblAddBirimTitle.TabIndex = 106;
            this.lblAddBirimTitle.Text = "İlave Çıktı Detay";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKaydet.Location = new System.Drawing.Point(315, 181);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 105;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 117;
            this.label6.Text = "Sıra";
            // 
            // txtSira
            // 
            this.txtSira.Location = new System.Drawing.Point(212, 145);
            this.txtSira.Name = "txtSira";
            this.txtSira.Size = new System.Drawing.Size(178, 20);
            this.txtSira.TabIndex = 116;
            // 
            // ddlProblem
            // 
            this.ddlProblem.FormattingEnabled = true;
            this.ddlProblem.Location = new System.Drawing.Point(17, 65);
            this.ddlProblem.Name = "ddlProblem";
            this.ddlProblem.Size = new System.Drawing.Size(178, 21);
            this.ddlProblem.TabIndex = 113;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 112;
            this.label4.Text = "Problem";
            // 
            // ddlMudahale
            // 
            this.ddlMudahale.FormattingEnabled = true;
            this.ddlMudahale.Location = new System.Drawing.Point(212, 105);
            this.ddlMudahale.Name = "ddlMudahale";
            this.ddlMudahale.Size = new System.Drawing.Size(178, 21);
            this.ddlMudahale.TabIndex = 111;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 110;
            this.label1.Text = "Müdahale";
            // 
            // ddlSinif
            // 
            this.ddlSinif.FormattingEnabled = true;
            this.ddlSinif.Location = new System.Drawing.Point(17, 105);
            this.ddlSinif.Name = "ddlSinif";
            this.ddlSinif.Size = new System.Drawing.Size(178, 21);
            this.ddlSinif.TabIndex = 109;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Sınıf";
            // 
            // ddlBelirtec
            // 
            this.ddlBelirtec.FormattingEnabled = true;
            this.ddlBelirtec.Location = new System.Drawing.Point(17, 144);
            this.ddlBelirtec.Name = "ddlBelirtec";
            this.ddlBelirtec.Size = new System.Drawing.Size(178, 21);
            this.ddlBelirtec.TabIndex = 119;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 118;
            this.label7.Text = "Belirteç";
            // 
            // EditIlaveCiktiDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 232);
            this.Controls.Add(this.ddlBelirtec);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ddlAlan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAddBirimTitle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSira);
            this.Controls.Add(this.ddlProblem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddlMudahale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlSinif);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditIlaveCiktiDetay";
            this.Text = "İlave Çıktı Detay";
            this.Load += new System.EventHandler(this.EditIlaveCiktiDetay_Load);
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSira;
        private System.Windows.Forms.ComboBox ddlProblem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlMudahale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlSinif;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlBelirtec;
        private System.Windows.Forms.Label label7;
    }
}