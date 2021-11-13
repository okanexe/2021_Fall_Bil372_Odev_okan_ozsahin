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
    public partial class EditProblemTipi : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? problemTipiId;

        public EditProblemTipi(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.problemTipiId = id;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { txtTipAdi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (problemTipiId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE ProblemTipi SET TipAdi = '{0}' WHERE Id = " + problemTipiId;
                sqlCommand = string.Format(sqlCommand, txtTipAdi.Text);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO ProblemTipi (TipAdi) VALUES ('{0}')";
                sqlCommand = string.Format(sqlCommand, txtTipAdi.Text);
                _operation.Insert(_connectionString, sqlCommand); 
            }

            dashboard.LoadProblemTipi();
            this.Close();
        }

        private void EditProblemTipi_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            if (problemTipiId.HasValue)
            {
                ProblemTipiTableAdapter problemTipiTableAdapter = new ProblemTipiTableAdapter();
                problemTipiTableAdapter.Fill(dataSet.ProblemTipi);
                var selectedProblemTipi = dataSet.ProblemTipi.FirstOrDefault(m => m.Id.Equals(problemTipiId));
                if (selectedProblemTipi != null)
                {
                    // Text
                    txtTipAdi.Text = selectedProblemTipi.TipAdi;
                }
            }
        }
    }
}
