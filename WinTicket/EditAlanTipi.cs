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
    public partial class EditAlanTipi : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? alanTipId;

        public EditAlanTipi(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.alanTipId = id;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtTipAdi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (alanTipId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE AlanTipi SET TipAdi = '{0}' WHERE Id = " + alanTipId;
                sqlCommand = string.Format(sqlCommand, txtTipAdi.Text);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO AlanTipi (TipAdi) VALUES ('{0}')";
                sqlCommand = string.Format(sqlCommand, txtTipAdi.Text);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadAlanTipi();
            this.Close();
        }

        private void EditAlanTipi_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            if (alanTipId.HasValue)
            {
                AlanTipiTableAdapter alanTipiTableAdapter = new AlanTipiTableAdapter();
                alanTipiTableAdapter.Fill(dataSet.AlanTipi);
                var selectedAlanTipi = dataSet.AlanTipi.FirstOrDefault(m => m.Id.Equals(alanTipId));
                if (selectedAlanTipi != null)
                {
                    // Text
                    txtTipAdi.Text = selectedAlanTipi.TipAdi;
                }
            }
        }
    }
}
