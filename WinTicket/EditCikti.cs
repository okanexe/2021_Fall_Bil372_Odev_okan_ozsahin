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
    public partial class EditCikti : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? ciktiId;

        public EditCikti(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.ciktiId = id;
        }

        private void EditCikti_Load(object sender, EventArgs e)
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

            if (ciktiId.HasValue)
            {
                CiktiTableAdapter mudahaleTableAdapter = new CiktiTableAdapter();
                mudahaleTableAdapter.Fill(dataSet.Cikti);
                var selectedCikti = dataSet.Cikti.FirstOrDefault(m => m.Id.Equals(ciktiId));
                if (selectedCikti != null)
                {
                    // Text
                    txtCiktiAdi.Text = selectedCikti.CiktiAdi;

                    //Combos
                    ddlAlan.SelectedValue = selectedCikti.AlanId;
                    ddlSinif.SelectedValue = selectedCikti.SinifId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlAlan, ddlSinif, txtCiktiAdi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (ciktiId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Cikti SET CiktiAdi = '{0}', AlanId = {1}, SinifId = {2} WHERE Id = " + ciktiId;
                sqlCommand = string.Format(sqlCommand, txtCiktiAdi.Text, ddlAlan.SelectedValue, ddlSinif.SelectedValue);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Cikti (CiktiAdi, AlanId, SinifId) VALUES ('{0}', {1}, {2})";
                sqlCommand = string.Format(sqlCommand, txtCiktiAdi.Text, ddlAlan.SelectedValue, ddlSinif.SelectedValue);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadCikti();
            this.Close();
        }
    }
}
