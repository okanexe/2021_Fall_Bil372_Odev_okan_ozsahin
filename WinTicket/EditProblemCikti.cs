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
    public partial class EditProblemCikti : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? problemCiktiId;

        public EditProblemCikti(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.problemCiktiId = id;
        }

        private void EditProblemCikti_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            AlanTableAdapter alanTableAdapter = new AlanTableAdapter();
            alanTableAdapter.Fill(dataSet.Alan);

            SinifTableAdapter sinifTableAdapter = new SinifTableAdapter();
            sinifTableAdapter.Fill(dataSet.Sinif);

            MudahaleTableAdapter mudahaleTableAdapter = new MudahaleTableAdapter();
            mudahaleTableAdapter.Fill(dataSet.Mudahale);

            ProblemTableAdapter problemTableAdapter = new ProblemTableAdapter();
            problemTableAdapter.Fill(dataSet.Problem);

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

            ddlCikti.DataSource = GetCikti();
            ddlCikti.DisplayMember = "CiktiAdi";
            ddlCikti.ValueMember = "Id";

            ddlProblem.DataSource = GetProblem();
            ddlProblem.DisplayMember = "HedeflenenAmacTanimi";
            ddlProblem.ValueMember = "Id";

            if (problemCiktiId.HasValue)
            {
                ProblemCiktiTableAdapter problemCiktiTableAdapter = new ProblemCiktiTableAdapter();
                problemCiktiTableAdapter.Fill(dataSet.ProblemCikti);
                var selectedProblemCikti = dataSet.ProblemCikti.FirstOrDefault(m => m.Id.Equals(problemCiktiId));
                if (selectedProblemCikti != null)
                {
                    //Combos
                    ddlAlan.SelectedValue = selectedProblemCikti.AlanId;
                    ddlSinif.SelectedValue = selectedProblemCikti.SinifId;
                    ddlCikti.SelectedValue = selectedProblemCikti.CiktiId;
                    ddlProblem.SelectedValue = selectedProblemCikti.ProblemId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlAlan, ddlSinif, ddlCikti, ddlProblem };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (problemCiktiId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE ProblemCikti SET AlanId = {0}, SinifId = {1}, CiktiId = {2}, ProblemId = {3} WHERE Id = " + problemCiktiId;
                sqlCommand = string.Format(sqlCommand, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlCikti.SelectedValue, ddlProblem.SelectedValue);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO ProblemCikti (AlanId, SinifId, CiktiId, ProblemId) VALUES ({0}, {1}, {2}, {3})";
                sqlCommand = string.Format(sqlCommand, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlCikti.SelectedValue, ddlProblem.SelectedValue);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadProblemCikti();
            this.Close();
        }
    }
}
