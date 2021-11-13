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
    public partial class EditMudahale : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? mudahaleId;

        public EditMudahale(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.mudahaleId = id;
        }

        private void EditMudahale_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            AlanTableAdapter alanTableAdapter = new AlanTableAdapter();
            alanTableAdapter.Fill(dataSet.Alan);

            SinifTableAdapter sinifTableAdapter = new SinifTableAdapter();
            sinifTableAdapter.Fill(dataSet.Sinif);

            DataRow alanDataRow = dataSet.Alan.NewRow();
            alanDataRow["AlanAdi"] = "Seçiniz";
            alanDataRow["TipId"] = 0;
            dataSet.Alan.Rows.InsertAt(alanDataRow, 0);

            DataRow sinifDataRow = dataSet.Sinif.NewRow();
            sinifDataRow["SinifAdi"] = "Seçiniz";
            sinifDataRow["AlanTipId"] = 0;
            dataSet.Sinif.Rows.InsertAt(sinifDataRow, 0);

            ddlAlan.DataSource = dataSet.Alan;
            ddlAlan.DisplayMember = "AlanAdi";
            ddlAlan.ValueMember = "Id";

            ddlSinif.DataSource = dataSet.Sinif;
            ddlSinif.DisplayMember = "SinifAdi";
            ddlSinif.ValueMember = "Id";

            if (mudahaleId.HasValue)
            {
                MudahaleTableAdapter mudahaleTableAdapter = new MudahaleTableAdapter();
                mudahaleTableAdapter.Fill(dataSet.Mudahale);
                var selectedMudahale = dataSet.Mudahale.FirstOrDefault(m => m.Id.Equals(mudahaleId));
                if (selectedMudahale != null)
                {
                    // Text
                    txtMudahaleAdi.Text = selectedMudahale.MudahaleAdi;

                    //Combos
                    ddlAlan.SelectedValue = selectedMudahale.AlanId;
                    ddlSinif.SelectedValue = selectedMudahale.SinifId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlAlan, ddlSinif, txtMudahaleAdi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (mudahaleId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Mudahale SET MudahaleAdi = '{0}', AlanId = {1}, SinifId = {2} WHERE Id = " + mudahaleId;
                sqlCommand = string.Format(sqlCommand, txtMudahaleAdi.Text, ddlAlan.SelectedValue, ddlSinif.SelectedValue);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Mudahale (MudahaleAdi, AlanId, SinifId) VALUES ('{0}', {1}, {2})";
                sqlCommand = string.Format(sqlCommand, txtMudahaleAdi.Text, ddlAlan.SelectedValue, ddlSinif.SelectedValue);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadMudahale();
            this.Close();
        }
    }
}
