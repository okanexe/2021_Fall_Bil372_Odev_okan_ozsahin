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
    public partial class EditProblemMudahale : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? problemMudahaleId;

        public EditProblemMudahale(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.problemMudahaleId = id;
        }

        private void EditProblemMudahale_Load(object sender, EventArgs e)
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

            DataRow mudahaleDataRow = dataSet.Mudahale.NewRow();
            mudahaleDataRow["MudahaleAdi"] = "Seçiniz";
            mudahaleDataRow["AlanId"] = 0;
            mudahaleDataRow["SinifId"] = 0;
            dataSet.Mudahale.Rows.InsertAt(mudahaleDataRow, 0);

            ddlAlan.DataSource = dataSet.Alan;
            ddlAlan.DisplayMember = "AlanAdi";
            ddlAlan.ValueMember = "Id";

            ddlSinif.DataSource = dataSet.Sinif;
            ddlSinif.DisplayMember = "SinifAdi";
            ddlSinif.ValueMember = "Id";

            ddlMudahale.DataSource = dataSet.Mudahale;
            ddlMudahale.DisplayMember = "MudahaleAdi";
            ddlMudahale.ValueMember = "Id";

            ddlProblem.DataSource = GetProblem();
            ddlProblem.DisplayMember = "HedeflenenAmacTanimi";
            ddlProblem.ValueMember = "Id";

            if (problemMudahaleId.HasValue)
            {
                ProblemMudahaleTableAdapter problemMudahaleTableAdapter = new ProblemMudahaleTableAdapter();
                problemMudahaleTableAdapter.Fill(dataSet.ProblemMudahale);
                var selectedProblemMudahale = dataSet.ProblemMudahale.FirstOrDefault(m => m.Id.Equals(problemMudahaleId));
                if (selectedProblemMudahale != null)
                {
                    //Combos
                    ddlAlan.SelectedValue = selectedProblemMudahale.AlanId;
                    ddlSinif.SelectedValue = selectedProblemMudahale.SinifId;
                    ddlMudahale.SelectedValue = selectedProblemMudahale.MudahaleId;
                    ddlProblem.SelectedValue = selectedProblemMudahale.ProblemId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlAlan, ddlSinif, ddlMudahale, ddlProblem };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (problemMudahaleId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE ProblemMudahale SET AlanId = {0}, SinifId = {1}, MudahaleId = {2}, ProblemId = {3} WHERE Id = " + problemMudahaleId;
                sqlCommand = string.Format(sqlCommand, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlMudahale.SelectedValue, ddlProblem.SelectedValue);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO ProblemMudahale (AlanId, SinifId, MudahaleId, ProblemId) VALUES ({0}, {1}, {2}, {3})";
                sqlCommand = string.Format(sqlCommand, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlMudahale.SelectedValue, ddlProblem.SelectedValue);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadProblemMudahale();
            this.Close();
        }
    }
}
