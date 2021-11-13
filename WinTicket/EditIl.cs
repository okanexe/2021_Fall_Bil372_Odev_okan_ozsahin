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
    public partial class EditIl : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? ilId;

        public EditIl(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.ilId = id;
        }

        private void EditIl_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            if (ilId.HasValue)
            {
                IlTableAdapter ilTableAdapter = new IlTableAdapter();
                ilTableAdapter.Fill(dataSet.Il);
                var selectedIl = dataSet.Il.FirstOrDefault(m => m.Id.Equals(ilId));
                if (selectedIl != null)
                {
                    // Text
                    txtIlAdi.Text = selectedIl.IlAdi;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtIlAdi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (ilId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Il SET IlAdi = '{0}' WHERE Id = " + ilId;
                sqlCommand = string.Format(sqlCommand, txtIlAdi.Text);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Il (IlAdi) VALUES ('{0}')";
                sqlCommand = string.Format(sqlCommand, txtIlAdi.Text);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadIl();
            this.Close();
        }
    }
}
