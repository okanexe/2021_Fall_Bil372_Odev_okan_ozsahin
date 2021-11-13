using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WinTicket.Util;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class EditProblem : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? problemId;

        public EditProblem(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.problemId = id;
        }

        private void EditProblem_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            ProblemTipiTableAdapter problemTipiTableAdapter = new ProblemTipiTableAdapter();
            problemTipiTableAdapter.Fill(dataSet.ProblemTipi);

            DataRow dataRow = dataSet.ProblemTipi.NewRow();
            dataRow["TipAdi"] = "Seçiniz";
            dataSet.ProblemTipi.Rows.InsertAt(dataRow, 0);

            ddlProblemTip.DataSource = dataSet.ProblemTipi;
            ddlProblemTip.DisplayMember = "TipAdi";
            ddlProblemTip.ValueMember = "Id";

            if (problemId.HasValue)
            {
                ProblemTableAdapter problemTableAdapter = new ProblemTableAdapter();
                problemTableAdapter.Fill(dataSet.Problem);
                var selectedProblem = dataSet.Problem.FirstOrDefault(m => m.Id.Equals(problemId));
                if (selectedProblem != null)
                {
                    // Text
                    txtTanimlayiciAd.Text = selectedProblem.TanimlayiciAd;
                    txtTanimlayiciSoyad.Text = selectedProblem.TanimlayiciSoyad;
                    txtTanimlayiciTCKN.Text = selectedProblem.TanimlayiciTCKN;
                    txtTanimlayiciPasaportNo.Text = selectedProblem.TanimlayiciPasaportNo;
                    txtHedeflenenAmacTanimi.Text = selectedProblem.HedeflenenAmacTanimi;

                    //Combos
                    ddlProblemTip.SelectedValue = selectedProblem.TipId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlProblemTip, txtTanimlayiciAd, txtTanimlayiciSoyad, txtTanimlayiciTCKN, txtTanimlayiciPasaportNo, txtHedeflenenAmacTanimi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (problemId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE Problem SET TipId = {0}, TanimlayiciAd = '{1}', TanimlayiciSoyad = '{2}', TanimlayiciTCKN = '{3}', TanimlayiciPasaportNo = '{4}', HedeflenenAmacTanimi = '{5}' WHERE Id = " + problemId;
                sqlCommand = string.Format(sqlCommand, ddlProblemTip.SelectedValue, txtTanimlayiciAd.Text, txtTanimlayiciSoyad.Text, txtTanimlayiciTCKN.Text, txtTanimlayiciPasaportNo.Text, txtHedeflenenAmacTanimi.Text);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO Problem (TipId, TanimlayiciAd, TanimlayiciSoyad, TanimlayiciTCKN, TanimlayiciPasaportNo, HedeflenenAmacTanimi) VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}')";
                sqlCommand = string.Format(sqlCommand, ddlProblemTip.SelectedValue, txtTanimlayiciAd.Text, txtTanimlayiciSoyad.Text, txtTanimlayiciTCKN.Text, txtTanimlayiciPasaportNo.Text, txtHedeflenenAmacTanimi.Text);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadProblem();
            this.Close();
        }
    }
}
