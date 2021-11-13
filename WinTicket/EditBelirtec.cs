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
    public partial class EditBelirtec : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? belirtecId;

        public EditBelirtec(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.belirtecId = id;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtBelirtecTanimi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (belirtecId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Belirtec SET BelirtecTanimi = '{0}' WHERE Id = " + belirtecId;
                sqlCommand = string.Format(sqlCommand, txtBelirtecTanimi.Text);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Belirtec (BelirtecTanimi) VALUES ('{0}')";
                sqlCommand = string.Format(sqlCommand, txtBelirtecTanimi.Text);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadBelirtec();
            this.Close();
        }

        private void EditBelirtec_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            if (belirtecId.HasValue)
            {
                BelirtecTableAdapter belirtecTableAdapter = new BelirtecTableAdapter();
                belirtecTableAdapter.Fill(dataSet.Belirtec);
                var selectedBelirtec = dataSet.Belirtec.FirstOrDefault(m => m.Id.Equals(belirtecId));
                if (selectedBelirtec != null)
                {
                    // Text
                    txtBelirtecTanimi.Text = selectedBelirtec.BelirtecTanimi;
                }
            }
        }
    }
}
