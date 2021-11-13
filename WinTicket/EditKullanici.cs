using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTicket.Util;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class EditKullanici : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? kullaniciId;

        public EditKullanici(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.kullaniciId = id;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtKullaniciAdi, txtSifre, ddlKullaniciRol };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (kullaniciId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Kullanici SET KullaniciAdi = '{0}', Sifre = '{1}', RoleId = {2} WHERE Id = " + kullaniciId;
                sqlCommand = string.Format(sqlCommand, txtKullaniciAdi.Text, Security.Encrypt(txtSifre.Text), ddlKullaniciRol.SelectedValue);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Kullanici (KullaniciAdi, Sifre, RoleId) VALUES ('{0}', '{1}', {2})";
                sqlCommand = string.Format(sqlCommand, txtKullaniciAdi.Text, Security.Encrypt(txtSifre.Text), ddlKullaniciRol.SelectedValue);
                _operation.Insert(_connectionString, sqlCommand);

            }

            dashboard.LoadKullanici();
            this.Close();
        }

        private void EditKullanici_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            KullaniciRolTableAdapter roleTableAdapter = new KullaniciRolTableAdapter();
            roleTableAdapter.Fill(dataSet.KullaniciRol);

            DataRow dataRow = dataSet.KullaniciRol.NewRow();
            dataRow["RoleAdi"] = "Seçiniz";
            dataSet.KullaniciRol.Rows.InsertAt(dataRow, 0);

            ddlKullaniciRol.DataSource = dataSet.KullaniciRol;
            ddlKullaniciRol.DisplayMember = "RoleAdi";
            ddlKullaniciRol.ValueMember = "Id";

            if (kullaniciId.HasValue)
            {
                KullaniciTableAdapter kullaniciTableAdapter = new KullaniciTableAdapter();
                kullaniciTableAdapter.Fill(dataSet.Kullanici);
                var selectedKullanici = dataSet.Kullanici.FirstOrDefault(m => m.Id.Equals(kullaniciId));
                if (selectedKullanici != null)
                {
                    // Text
                    txtKullaniciAdi.Text = selectedKullanici.KullaniciAdi;

                    //Combos
                    ddlKullaniciRol.SelectedValue = selectedKullanici.RoleId;
                }
            }
        }
    }
}
