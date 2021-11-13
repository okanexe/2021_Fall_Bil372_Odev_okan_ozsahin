
namespace WinTicket
{
    partial class EditProblemBirim
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ddlBirim = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEslesmeTarihi = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlProblem
            // 
            this.ddlProblem.FormattingEnabled = true;
            this.ddlProblem.Location = new System.Drawing.Point(17, 66);
            this.ddlProblem.Name = "ddlProblem";
            this.ddlProblem.Size = new System.Drawing.Size(178, 21);
            this.ddlProblem.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Problem";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "Eşleşme Tarihi";
            // 
            // lblAddBirimTitle
            // 
            this.lblAddBirimTitle.AutoSize = true;
            this.lblAddBirimTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAddBirimTitle.Location = new System.Drawing.Point(12, 9);
            this.lblAddBirimTitle.Name = "lblAddBirimTitle";
            this.lblAddBirimTitle.Size = new System.Drawing.Size(151, 26);
            this.lblAddBirimTitle.TabIndex = 70;
            this.lblAddBirimTitle.Text = "Problem Birim";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnKaydet.Location = new System.Drawing.Point(120, 174);
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
            // ddlBirim
            // 
            this.ddlBirim.FormattingEnabled = true;
            this.ddlBirim.Location = new System.Drawing.Point(17, 107);
            this.ddlBirim.Name = "ddlBirim";
            this.ddlBirim.Size = new System.Drawing.Size(178, 21);
            this.ddlBirim.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Birim";
            // 
            // dtpEslesmeTarihi
            // 
            this.dtpEslesmeTarihi.Location = new System.Drawing.Point(17, 148);
            this.dtpEslesmeTarihi.MaxDate = new System.DateTime(2022, 12, 31, 0, 0, 0, 0);
            this.dtpEslesmeTarihi.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.dtpEslesmeTarihi.Name = "dtpEslesmeTarihi";
            this.dtpEslesmeTarihi.Size = new System.Drawing.Size(178, 20);
            this.dtpEslesmeTarihi.TabIndex = 74;
            // 
            // EditProblemBirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 224);
            this.Controls.Add(this.dtpEslesmeTarihi);
            this.Controls.Add(this.ddlProblem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAddBirimTitle);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.ddlBirim);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditProblemBirim";
            this.Text = "Problem Birim";
            this.Load += new System.EventHandler(this.EditProblemBirim_Load);
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
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox ddlBirim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEslesmeTarihi;
    }
}