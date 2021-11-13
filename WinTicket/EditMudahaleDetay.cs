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
    public partial class EditMudahaleDetay : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? mudahaleDetayId;

        public EditMudahaleDetay(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.mudahaleDetayId = id;
        }

        private void EditMudahaleDetay_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            AlanTableAdapter alanTableAdapter = new AlanTableAdapter();
            alanTableAdapter.Fill(dataSet.Alan);

            SinifTableAdapter sinifTableAdapter = new SinifTableAdapter();
            sinifTableAdapter.Fill(dataSet.Sinif);

            MudahaleTableAdapter mudahaleTableAdapter = new MudahaleTableAdapter();
            mudahaleTableAdapter.Fill(dataSet.Mudahale);

            AktiviteTableAdapter aktiviteTableAdapter = new AktiviteTableAdapter();
            aktiviteTableAdapter.Fill(dataSet.Aktivite);

            DataRow alanDataRow = dataSet.Alan.NewRow();
            alanDataRow["AlanAdi"] = "Seçiniz";
            alanDataRow["TipId"] = 0;
            dataSet.Alan.Rows.InsertAt(alanDataRow, 0);

            DataRow sinifDataRow = dataSet.Sinif.NewRow();
            sinifDataRow["SinifAdi"] = "Seçiniz";
            sinifDataRow["AlanTipId"] = 0;
            dataSet.Sinif.Rows.InsertAt(sinifDataRow, 0);

            DataRow mudahaleDataRow = dataSet.Mudahale.NewRow();
            mudahaleDataRow["MudahaleAdi"] = "Seçiniz";
            mudahaleDataRow["AlanId"] = 0;
            mudahaleDataRow["SinifId"] = 0;
            dataSet.Mudahale.Rows.InsertAt(mudahaleDataRow, 0);

            DataRow aktiviteDataRow = dataSet.Aktivite.NewRow();
            aktiviteDataRow["AktiviteTanimi"] = "Seçiniz";
            dataSet.Aktivite.Rows.InsertAt(aktiviteDataRow, 0);

            ddlAlan.DataSource = dataSet.Alan;
            ddlAlan.DisplayMember = "AlanAdi";
            ddlAlan.ValueMember = "Id";

            ddlSinif.DataSource = dataSet.Sinif;
            ddlSinif.DisplayMember = "SinifAdi";
            ddlSinif.ValueMember = "Id";

            ddlMudahale.DataSource = dataSet.Mudahale;
            ddlMudahale.DisplayMember = "MudahaleAdi";
            ddlMudahale.ValueMember = "Id";

            ddlAktivite.DataSource = dataSet.Aktivite;
            ddlAktivite.DisplayMember = "AktiviteTanimi";
            ddlAktivite.ValueMember = "Id";

            if (mudahaleDetayId.HasValue)
            {
                MudahaleDetayTableAdapter mudahaleDetayTableAdapter = new MudahaleDetayTableAdapter();
                mudahaleDetayTableAdapter.Fill(dataSet.MudahaleDetay);
                var selectedMudahaleDetay = dataSet.MudahaleDetay.FirstOrDefault(m => m.Id.Equals(mudahaleDetayId));
                if (selectedMudahaleDetay != null)
                {
                    // Text
                    txtSiraNo.Text = selectedMudahaleDetay.Sira.ToString();

                    //Combos
                    ddlAlan.SelectedValue = selectedMudahaleDetay.AlanId;
                    ddlSinif.SelectedValue = selectedMudahaleDetay.SinifId;
                    ddlMudahale.SelectedValue = selectedMudahaleDetay.MudahaleId;
                    ddlAktivite.SelectedValue = selectedMudahaleDetay.AktiviteId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlAlan, ddlSinif, ddlMudahale, ddlAktivite, txtSiraNo };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (mudahaleDetayId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE MudahaleDetay SET AlanId = {0}, SinifId = {1}, MudahaleId = {2}, AktiviteId = {3}, Sira = {4} WHERE Id = " + mudahaleDetayId;
                sqlCommand = string.Format(sqlCommand, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlMudahale.SelectedValue, ddlAktivite.SelectedValue, txtSiraNo.Text);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO MudahaleDetay (AlanId, SinifId, MudahaleId, AktiviteId, Sira) VALUES ({0}, {1}, {2}, {3}, {4})";
                sqlCommand = string.Format(sqlCommand, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlMudahale.SelectedValue, ddlAktivite.SelectedValue, txtSiraNo.Text);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadMudahaleDetay();
            this.Close();
        }
    }
}
