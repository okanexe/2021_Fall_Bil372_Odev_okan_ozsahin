using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinTicket.Util;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class EditAlan : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? alanId;

        public EditAlan(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.alanId = id;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlAlanTipi, txtAlanAdi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (alanId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Alan SET TipId = {0}, AlanAdi = '{1}' WHERE Id = " + alanId;
                sqlCommand = string.Format(sqlCommand, ddlAlanTipi.SelectedValue, txtAlanAdi.Text);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Alan (TipId, AlanAdi) VALUES ({0}, '{1}')";
                sqlCommand = string.Format(sqlCommand, ddlAlanTipi.SelectedValue, txtAlanAdi.Text);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadAlan();
            this.Close();
        }

        private void EditAlan_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            AlanTipiTableAdapter alanTipiTableAdapter = new AlanTipiTableAdapter();
            alanTipiTableAdapter.Fill(dataSet.AlanTipi);

            DataRow dataRow = dataSet.AlanTipi.NewRow();
            dataRow["TipAdi"] = "Seçiniz";
            dataSet.AlanTipi.Rows.InsertAt(dataRow, 0);

            ddlAlanTipi.DataSource = dataSet.AlanTipi;
            ddlAlanTipi.DisplayMember = "TipAdi";
            ddlAlanTipi.ValueMember = "Id";

            if (alanId.HasValue)
            {
                AlanTableAdapter alanTableAdapter = new AlanTableAdapter();
                alanTableAdapter.Fill(dataSet.Alan);
                var selectedAlan = dataSet.Alan.FirstOrDefault(m => m.Id.Equals(alanId));
                if (selectedAlan != null)
                {
                    // Text
                    txtAlanAdi.Text = selectedAlan.AlanAdi;

                    //Combos
                    ddlAlanTipi.SelectedValue = selectedAlan.TipId;
                }
            }
        }
    }
}
