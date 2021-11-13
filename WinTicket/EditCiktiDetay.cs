using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinTicket.Util;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class EditCiktiDetay : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? ciktiDetayId;

        public EditCiktiDetay(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.ciktiDetayId = id;
        }

        private void EditCiktiDetay_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            AlanTableAdapter alanTableAdapter = new AlanTableAdapter();
            alanTableAdapter.Fill(dataSet.Alan);

            SinifTableAdapter sinifTableAdapter = new SinifTableAdapter();
            sinifTableAdapter.Fill(dataSet.Sinif);

            CiktiTableAdapter ciktiTableAdapter = new CiktiTableAdapter();
            ciktiTableAdapter.Fill(dataSet.Cikti);

            BelirtecTableAdapter belirtecTableAdapter = new BelirtecTableAdapter();
            belirtecTableAdapter.Fill(dataSet.Belirtec);

            DataRow alanDataRow = dataSet.Alan.NewRow();
            alanDataRow["AlanAdi"] = "Seçiniz";
            alanDataRow["TipId"] = 0;
            dataSet.Alan.Rows.InsertAt(alanDataRow, 0);

            DataRow sinifDataRow = dataSet.Sinif.NewRow();
            sinifDataRow["SinifAdi"] = "Seçiniz";
            sinifDataRow["AlanTipId"] = 0;
            dataSet.Sinif.Rows.InsertAt(sinifDataRow, 0);

            DataRow ciktiDataRow = dataSet.Cikti.NewRow();
            ciktiDataRow["CiktiAdi"] = "Seçiniz";
            ciktiDataRow["AlanId"] = 0;
            ciktiDataRow["SinifId"] = 0;
            dataSet.Cikti.Rows.InsertAt(ciktiDataRow, 0);

            DataRow belirtecDataRow = dataSet.Belirtec.NewRow();
            belirtecDataRow["BelirtecTanimi"] = "Seçiniz";
            dataSet.Belirtec.Rows.InsertAt(belirtecDataRow, 0);

            ddlAlan.DataSource = dataSet.Alan;
            ddlAlan.DisplayMember = "AlanAdi";
            ddlAlan.ValueMember = "Id";

            ddlSinif.DataSource = dataSet.Sinif;
            ddlSinif.DisplayMember = "SinifAdi";
            ddlSinif.ValueMember = "Id";

            ddlCikti.DataSource = dataSet.Cikti;
            ddlCikti.DisplayMember = "CiktiAdi";
            ddlCikti.ValueMember = "Id";

            ddlBelirtec.DataSource = dataSet.Belirtec;
            ddlBelirtec.DisplayMember = "BelirtecTanimi";
            ddlBelirtec.ValueMember = "Id";

            if (ciktiDetayId.HasValue)
            {
                CiktiDetayTableAdapter mudahaleDetayTableAdapter = new CiktiDetayTableAdapter();
                mudahaleDetayTableAdapter.Fill(dataSet.CiktiDetay);
                var selectedCiktiDetay = dataSet.CiktiDetay.FirstOrDefault(m => m.Id.Equals(ciktiDetayId));
                if (selectedCiktiDetay != null)
                {
                    // Text
                    txtSiraNo.Text = selectedCiktiDetay.Sira.ToString();

                    //Combos
                    ddlAlan.SelectedValue = selectedCiktiDetay.AlanId;
                    ddlSinif.SelectedValue = selectedCiktiDetay.SinifId;
                    ddlCikti.SelectedValue = selectedCiktiDetay.CiktiId;
                    ddlBelirtec.SelectedValue = selectedCiktiDetay.BelirtecId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlAlan, ddlSinif, ddlCikti, ddlBelirtec, txtSiraNo };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (ciktiDetayId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE CiktiDetay SET AlanId = {0}, SinifId = {1}, CiktiId = {2}, BelirtecId = {3}, Sira = {4} WHERE Id = " + ciktiDetayId;
                sqlCommand = string.Format(sqlCommand, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlCikti.SelectedValue, ddlBelirtec.SelectedValue, txtSiraNo.Text);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO CiktiDetay (AlanId, SinifId, CiktiId, BelirtecId, Sira) VALUES ({0}, {1}, {2}, {3}, {4})";
                sqlCommand = string.Format(sqlCommand, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlCikti.SelectedValue, ddlBelirtec.SelectedValue, txtSiraNo.Text);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadCiktiDetay();
            this.Close();
        }
    }
}
