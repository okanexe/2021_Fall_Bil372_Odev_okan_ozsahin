using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class EditBirim : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? birimId;

        public EditBirim(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.birimId = id;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (birimId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Birim SET BirimAdi = '{0}', UstBirimId = {1}, Adres = '{2}', IlId = {3}, IlceId = {4}, PostaKodu = '{5}', BirimMudurId = {6} WHERE Id = " + birimId;
                sqlCommand = string.Format(sqlCommand, txtBirimAdi.Text, ddlUstBirim.SelectedValue, txtAdres.Text, ddlIl.SelectedValue, ddlIlce.SelectedValue, txtPostaKodu.Text, ddlBirimMuduru.SelectedValue);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Birim (BirimAdi, UstBirimId, Adres, IlId, IlceId, PostaKodu, BirimMudurId) VALUES ('{0}', {1}, '{2}', {3}, {4}, '{5}', {6})";
                sqlCommand = string.Format(sqlCommand, txtBirimAdi.Text, ddlUstBirim.SelectedValue, txtAdres.Text, ddlIl.SelectedValue, ddlIlce.SelectedValue, txtPostaKodu.Text, ddlBirimMuduru.SelectedValue);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadBirim();
            this.Close();
        }

        private void AddBirim_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            ddlUstBirim.DataSource = GetUstBirim();
            ddlUstBirim.DisplayMember = "BirimAdi";
            ddlUstBirim.ValueMember = "Id";

            ddlBirimMuduru.DataSource = GetBirimMuduru();
            ddlBirimMuduru.DisplayMember = "AdSoyad";
            ddlBirimMuduru.ValueMember = "Id";

            IlTableAdapter ilTableAdapter = new IlTableAdapter();
            ilTableAdapter.Fill(dataSet.Il);

            DataRow ilRow = dataSet.Il.NewRow();
            ilRow["IlAdi"] = "Seçiniz";
            dataSet.Il.Rows.InsertAt(ilRow, 0);

            ddlIl.DataSource = dataSet.Il;
            ddlIl.DisplayMember = "IlAdi";
            ddlIl.ValueMember = "Id";

            if (birimId.HasValue)
            {
                BirimTableAdapter birimTableAdapter = new BirimTableAdapter();
                birimTableAdapter.Fill(dataSet.Birim);
                var selectedBirim = dataSet.Birim.FirstOrDefault(m => m.Id.Equals(birimId));
                if (selectedBirim != null)
                {
                    // Text
                    txtBirimAdi.Text = selectedBirim.BirimAdi;
                    txtAdres.Text = selectedBirim.Adres;
                    txtPostaKodu.Text = selectedBirim.PostaKodu;

                    //Combos
                    ddlUstBirim.SelectedValue = selectedBirim.UstBirimId;
                    ddlBirimMuduru.SelectedValue = selectedBirim.BirimMudurId;
                    ddlIl.SelectedValue = selectedBirim.IlId;
                    ddlIlce.SelectedValue = selectedBirim.IlceId;
                }
            }

        }

        private void ddlIl_SelectedIndexChanged(object sender, EventArgs e)
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
