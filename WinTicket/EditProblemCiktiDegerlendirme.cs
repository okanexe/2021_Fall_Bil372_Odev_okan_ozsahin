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
    public partial class EditProblemCiktiDegerlendirme : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? problemCiktiDegerlendirmeId;

        public EditProblemCiktiDegerlendirme(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.problemCiktiDegerlendirmeId = id;
        }

        private void EditProblemCiktiDegerlendirme_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            BelirtecTableAdapter belirtecTableAdapter = new BelirtecTableAdapter();
            belirtecTableAdapter.Fill(dataSet.Belirtec);

            DataRow belirtecDataRow = dataSet.Belirtec.NewRow();
            belirtecDataRow["BelirtecTanimi"] = "Seçiniz";
            dataSet.Belirtec.Rows.InsertAt(belirtecDataRow, 0);

            ddlProblem.DataSource = GetProblem();
            ddlProblem.DisplayMember = "HedeflenenAmacTanimi";
            ddlProblem.ValueMember = "Id";

            ddlBelirtec.DataSource = dataSet.Belirtec;
            ddlBelirtec.DisplayMember = "BelirtecTanimi";
            ddlBelirtec.ValueMember = "Id";

            if (problemCiktiDegerlendirmeId.HasValue)
            {
                ProblemCiktiDegerlendirmeTableAdapter problemCiktiDegerlendirmeTableAdapter = new ProblemCiktiDegerlendirmeTableAdapter();
                problemCiktiDegerlendirmeTableAdapter.Fill(dataSet.ProblemCiktiDegerlendirme);
                var selectedProblemCiktiDegerlendirme = dataSet.ProblemCiktiDegerlendirme.FirstOrDefault(m => m.Id.Equals(problemCiktiDegerlendirmeId));
                if (selectedProblemCiktiDegerlendirme != null)
                {
                    //Texts
                    txtSkor.Text = selectedProblemCiktiDegerlendirme.Skor.ToString();

                    //DateTimePicker
                    dtpSkorTarihi.Value = selectedProblemCiktiDegerlendirme.SkorTarihi;

                    //Combos
                    ddlProblem.SelectedValue = selectedProblemCiktiDegerlendirme.ProblemId;
                    ddlBelirtec.SelectedValue = selectedProblemCiktiDegerlendirme.BelirtecId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlProblem, ddlBelirtec, txtSkor, dtpSkorTarihi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (problemCiktiDegerlendirmeId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE ProblemCiktiDegerlendirme SET ProblemId = {0}, BelirtecId = {1}, Skor = {2}, SkorTarihi = CONVERT(DATE, '{3}', 105) WHERE Id = " + problemCiktiDegerlendirmeId;
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlBelirtec.SelectedValue, txtSkor.Text, dtpSkorTarihi.Value.ToShortDateString());
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO ProblemCiktiDegerlendirme (ProblemId, BelirtecId, Skor, SkorTarihi) VALUES ({0}, {1}, {2}, CONVERT(DATE, '{3}', 105))";
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlBelirtec.SelectedValue, txtSkor.Text, dtpSkorTarihi.Value.ToShortDateString());
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadProblemCiktiDegerlendirme();
            this.Close();
        }
    }
}
