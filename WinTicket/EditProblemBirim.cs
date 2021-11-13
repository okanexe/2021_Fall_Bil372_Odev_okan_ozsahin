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
    public partial class EditProblemBirim : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? problemBirimId;

        public EditProblemBirim(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.problemBirimId = id;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlProblem, ddlBirim, dtpEslesmeTarihi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (problemBirimId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE ProblemBirim SET ProblemId = {0}, BirimId = {1}, EslesmeTarihi = '{2}' WHERE Id = " + problemBirimId;
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlBirim.SelectedValue, dtpEslesmeTarihi.Value);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO ProblemBirim (ProblemId, BirimId, EslesmeTarihi) VALUES ({0}, {1}, CONVERT(DATE, '{2}', 105))";
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlBirim.SelectedValue, dtpEslesmeTarihi.Value.ToShortDateString());
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadProblemBirim();
            this.Close();
        }

        private void EditProblemBirim_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            ddlBirim.DataSource = GetBirim();
            ddlBirim.DisplayMember = "BirimAdi";
            ddlBirim.ValueMember = "Id";

            ddlProblem.DataSource = GetProblem();
            ddlProblem.DisplayMember = "HedeflenenAmacTanimi";
            ddlProblem.ValueMember = "Id";

            if (problemBirimId.HasValue)
            {
                ProblemBirimTableAdapter problemBirimTableAdapter = new ProblemBirimTableAdapter();
                problemBirimTableAdapter.Fill(dataSet.ProblemBirim);
                var selectedProblemBirim = dataSet.ProblemBirim.FirstOrDefault(m => m.Id.Equals(problemBirimId));
                if (selectedProblemBirim != null)
                {
                    //DateTimePicker
                    dtpEslesmeTarihi.Value = selectedProblemBirim.EslesmeTarihi;

                    //Combos
                    ddlProblem.SelectedValue = selectedProblemBirim.ProblemId;
                    ddlBirim.SelectedValue = selectedProblemBirim.BirimId;
                }
            }
        }
    }
}