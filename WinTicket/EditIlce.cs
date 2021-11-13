using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinTicket.Util;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class EditIlce : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? ilceId;

        public EditIlce(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.ilceId = id;
        }

        private void EditIlce_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            IlTableAdapter ilTableAdapter = new IlTableAdapter();
            ilTableAdapter.Fill(dataSet.Il);

            DataRow dataRow = dataSet.Il.NewRow();
            dataRow["IlAdi"] = "Seçiniz";
            dataSet.Il.Rows.InsertAt(dataRow, 0);

            ddlIl.DataSource = dataSet.Il;
            ddlIl.DisplayMember = "IlAdi";
            ddlIl.ValueMember = "Id";

            if (ilceId.HasValue)
            {
                IlceTableAdapter ilceTableAdapter = new IlceTableAdapter();
                ilceTableAdapter.Fill(dataSet.Ilce);
                var selectedIlce = dataSet.Ilce.FirstOrDefault(m => m.Id.Equals(ilceId));
                if (selectedIlce != null)
                {
                    // Text
                    txtIlceAdi.Text = selectedIlce.IlceAdi;

                    //Combos
                    ddlIl.SelectedValue = selectedIlce.IlId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtIlceAdi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (ilceId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Ilce SET IlceAdi = '{0}', IlId = {1} WHERE Id = " + ilceId;
                sqlCommand = string.Format(sqlCommand, txtIlceAdi.Text, ddlIl.SelectedValue);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Ilce (IlceAdi, IlId) VALUES ('{0}', {1})";
                sqlCommand = string.Format(sqlCommand, txtIlceAdi.Text);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadIlce();
            this.Close();
        }
    }
}
