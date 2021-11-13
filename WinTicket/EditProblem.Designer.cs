
namespace WinTicket
{
    partial class EditProblem
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
            this.ddlProblemTip = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddBirimTitle = new System.Windows.Forms.Label();
            this.txtTanimlayiciAd = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtTanimlayiciSoyad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTanimlayiciPasaportNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTanimlayiciTCKN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHedeflenenAmacTanimi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlProblemTip
            // 
            this.ddlProblemTip.FormattingEnabled = true;
            this.ddlProblemTip.Location = new System.Drawing.Point(17, 66);
            this.ddlProblemTip.Name = "ddlProblemTip";
            this.ddlProblemTip.Size = new System.Drawing.Size(178, 21);
            this.ddlProblemTip.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Problem Tipi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Tanımlayıcı Ad";
            // 
            // lblAddBirimTitle
            // 
            this.lblAddBirimTitle.AutoSize = true;
            this.lblAddBirimTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAddBirimTitle.Location = new System.Drawing.Point(12, 9);
            this.lblAddBirimTitle.Name = "lblAddBirimTitle";
            this.lblAddBirimTitle.Size = new System.Drawing.Size(165, 26);
            this.lblAddBirimTitle.TabIndex = 36;
            this.lblAddBirimTitle.Text = "Problem Tanımı";
            // 
            // txtTanimlayiciAd
            // 
            this.txtTanimlayiciAd.Location = new System.Drawing.Point(17, 113);
            this.txtTanimlayiciAd.Name = "txtTanimlayiciAd";
            this.txtTanimlayiciAd.Size = new System.Drawing.Size(178, 20);
            this.txtTanimlayiciAd.TabIndex = 35;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKaydet.Location = new System.Drawing.Point(315, 329);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 34;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Tanımlayıcı Soyad";
            // 
            // txtTanimlayiciSoyad
            // 
            this.txtTanimlayiciSoyad.Location = new System.Drawing.Point(212, 113);
            this.txtTanimlayiciSoyad.Name = "txtTanimlayiciSoyad";
            this.txtTanimlayiciSoyad.Size = new System.Drawing.Size(178, 20);
            this.txtTanimlayiciSoyad.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Tanımlayıcı Pasaport No";
            // 
            // txtTanimlayiciPasaportNo
            // 
            this.txtTanimlayiciPasaportNo.Location = new System.Drawing.Point(212, 154);
            this.txtTanimlayiciPasaportNo.Name = "txtTanimlayiciPasaportNo";
            this.txtTanimlayiciPasaportNo.Size = new System.Drawing.Size(178, 20);
            this.txtTanimlayiciPasaportNo.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Tanımlayıcı TCKN";
            // 
            // txtTanimlayiciTCKN
            // 
            this.txtTanimlayiciTCKN.Location = new System.Drawing.Point(17, 154);
            this.txtTanimlayiciTCKN.Name = "txtTanimlayiciTCKN";
            this.txtTanimlayiciTCKN.Size = new System.Drawing.Size(178, 20);
            this.txtTanimlayiciTCKN.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Hedeflenen Amaç Tanımı";
            // 
            // txtHedeflenenAmacTanimi
            // 
            this.txtHedeflenenAmacTanimi.Location = new System.Drawing.Point(17, 193);
            this.txtHedeflenenAmacTanimi.Multiline = true;
            this.txtHedeflenenAmacTanimi.Name = "txtHedeflenenAmacTanimi";
            this.txtHedeflenenAmacTanimi.Size = new System.Drawing.Size(373, 130);
            this.txtHedeflenenAmacTanimi.TabIndex = 45;
            // 
            // EditProblem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 370);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHedeflenenAmacTanimi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTanimlayiciPasaportNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTanimlayiciTCKN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTanimlayiciSoyad);
            this.Controls.Add(this.ddlProblemTip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddBirimTitle);
            this.Controls.Add(this.txtTanimlayiciAd);
            this.Controls.Add(this.btnKaydet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProblem";
            this.Text = "Problem Tanımı";
            this.Load += new System.EventHandler(this.EditProblem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlProblemTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddBirimTitle;
        private System.Windows.Forms.TextBox txtTanimlayiciAd;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHedeflenenAmacTanimi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTanimlayiciPasaportNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTanimlayiciTCKN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTanimlayiciSoyad;
    }
}