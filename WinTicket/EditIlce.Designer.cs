﻿
namespace WinTicket
{
    partial class EditIlce
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
            this.ddlIl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddBirimTitle = new System.Windows.Forms.Label();
            this.txtIlceAdi = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlIl
            // 
            this.ddlIl.FormattingEnabled = true;
            this.ddlIl.Location = new System.Drawing.Point(20, 119);
            this.ddlIl.Name = "ddlIl";
            this.ddlIl.Size = new System.Drawing.Size(178, 21);
            this.ddlIl.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "İl";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "İlçe Adı";
            // 
            // lblAddBirimTitle
            // 
            this.lblAddBirimTitle.AutoSize = true;
            this.lblAddBirimTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAddBirimTitle.Location = new System.Drawing.Point(12, 9);
            this.lblAddBirimTitle.Name = "lblAddBirimTitle";
            this.lblAddBirimTitle.Size = new System.Drawing.Size(46, 26);
            this.lblAddBirimTitle.TabIndex = 30;
            this.lblAddBirimTitle.Text = "İlçe";
            // 
            // txtIlceAdi
            // 
            this.txtIlceAdi.Location = new System.Drawing.Point(20, 78);
            this.txtIlceAdi.Name = "txtIlceAdi";
            this.txtIlceAdi.Size = new System.Drawing.Size(178, 20);
            this.txtIlceAdi.TabIndex = 29;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKaydet.Location = new System.Drawing.Point(123, 157);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 28;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EditIlce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 204);
            this.Controls.Add(this.ddlIl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddBirimTitle);
            this.Controls.Add(this.txtIlceAdi);
            this.Controls.Add(this.btnKaydet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditIlce";
            this.Text = "İlçe";
            this.Load += new System.EventHandler(this.EditIlce_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ddlIl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAddBirimTitle;
        private System.Windows.Forms.TextBox txtIlceAdi;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}