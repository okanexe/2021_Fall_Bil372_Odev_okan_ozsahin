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
    public partial class EditPersonel : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? personelId;

        public EditPersonel(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.personelId = id;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (personelId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Personel SET SicilNo = '{0}', Ad = '{1}', Soyad = '{2}', KullaniciAdi = '{3}', Email = '{4}', Telefon = '{5}', Adres = '{6}', IlId = {7}, IlceId = {8}, PostaKodu = '{9}', UstPersonelId = {10}, BirimId = {11} WHERE Id = " + personelId;
                sqlCommand = string.Format(sqlCommand, txtSicilNo.Text, txtAd.Text, txtSoyad.Text, txtKullaniciAdi.Text, txtEmail.Text, txtTelefon.Text, txtAdres.Text, ddlIl.SelectedValue, ddlIlce.SelectedValue, txtPostaKodu.Text, ddlUstPersonel.SelectedValue, ddlBirim.SelectedValue);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Personel (SicilNo, Ad, Soyad, KullaniciAdi, Email, Telefon, Adres, IlId, IlceId, PostaKodu, UstPersonelId, BirimId) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}, {8},'{9}', {10}, {11})";
                sqlCommand = string.Format(sqlCommand, txtSicilNo.Text, txtAd.Text, txtSoyad.Text, txtKullaniciAdi.Text, txtEmail.Text, txtTelefon.Text, txtAdres.Text, ddlIl.SelectedValue, ddlIlce.SelectedValue, txtPostaKodu.Text, ddlUstPersonel.SelectedValue, ddlBirim.SelectedValue);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadPersonel();
            this.Close();
        }

        private void EditPersonel_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            ddlBirim.DataSource = GetUstBirim();
            ddlBirim.DisplayMember = "BirimAdi";
            ddlBirim.ValueMember = "Id";

            ddlUstPersonel.DataSource = GetUstPersonel();
            ddlUstPersonel.DisplayMember = "AdSoyad";
            ddlUstPersonel.ValueMember = "Id";

            IlTableAdapter ilTableAdapter = new IlTableAdapter();
            ilTableAdapter.Fill(dataSet.Il);

            DataRow ilRow = dataSet.Il.NewRow();
            ilRow["IlAdi"] = "Seçiniz";
            dataSet.Il.Rows.InsertAt(ilRow, 0);

            ddlIl.DataSource = dataSet.Il;
            ddlIl.DisplayMember = "IlAdi";
            ddlIl.ValueMember = "Id";

            if (personelId.HasValue)
            {
                PersonelTableAdapter personelTableAdapter = new PersonelTableAdapter();
                personelTableAdapter.Fill(dataSet.Personel);
                var selectedPersonel = dataSet.Personel.FirstOrDefault(m => m.Id.Equals(personelId));
                if (selectedPersonel != null)
                {
                    // Text
                    txtSicilNo.Text = selectedPersonel.SicilNo;
                    txtAd.Text = selectedPersonel.Ad;
                    txtSoyad.Text = selectedPersonel.Soyad;
                    txtKullaniciAdi.Text = selectedPersonel.KullaniciAdi;
                    txtEmail.Text = selectedPersonel.Email;
                    txtTelefon.Text = selectedPersonel.Telefon;
                    txtAdres.Text = selectedPersonel.Adres;
                    txtPostaKodu.Text = selectedPersonel.PostaKodu;

                    //Combos
                    ddlIl.SelectedValue = selectedPersonel.IlId;
                    ddlIlce.SelectedValue = selectedPersonel.IlceId;
                    ddlUstPersonel.SelectedValue = selectedPersonel.UstPersonelId;
                    ddlBirim.SelectedValue = selectedPersonel.BirimId;
                }
            }
        }

        private void ddlIl_SelectedValueChanged(object sender, EventArgs e)
        {
            var thisObj = ((ComboBox)sender);
            if (thisObj.SelectedIndex != 0)
            {
                ddlIlce.DataSource = GetIlce(Convert.ToInt32(thisObj.SelectedValue));
                ddlIlce.DisplayMember = "IlceAdi";
                ddlIlce.ValueMember = "Id";
            }
        }
    }
}
