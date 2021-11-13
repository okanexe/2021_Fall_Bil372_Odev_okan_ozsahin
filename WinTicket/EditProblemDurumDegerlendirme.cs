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
    public partial class EditProblemDurumDegerlendirme : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? problemDurumDegerlendirmeId;

        public EditProblemDurumDegerlendirme(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.problemDurumDegerlendirmeId = id;
        }

        private void EditProblemDurumDegerlendirme_Load(object sender, EventArgs e)
        {
            WinTicketDataSet dataSet = new WinTicketDataSet();

            ddlProblem.DataSource = GetProblem();
            ddlProblem.DisplayMember = "HedeflenenAmacTanimi";
            ddlProblem.ValueMember = "Id";

            ddlKullanici.DataSource = GetKullanici();
            ddlKullanici.DisplayMember = "KullaniciAdi";
            ddlKullanici.ValueMember = "Id";

            if (problemDurumDegerlendirmeId.HasValue)
            {
                ProblemDurumDegerlendirmeTableAdapter problemDurumDegerlendirmeTableAdapter = new ProblemDurumDegerlendirmeTableAdapter();
                problemDurumDegerlendirmeTableAdapter.Fill(dataSet.ProblemDurumDegerlendirme);
                var selectedProblemDurumDegerlendirme = dataSet.ProblemDurumDegerlendirme.FirstOrDefault(m => m.Id.Equals(problemDurumDegerlendirmeId));
                if (selectedProblemDurumDegerlendirme != null)
                {
                    //Texts
                    txtYeniProblemTanimi.Text = selectedProblemDurumDegerlendirme.YeniProblemTanimi;
                    txtYeniHedef.Text = selectedProblemDurumDegerlendirme.YeniHedef;
                    txtOncekiProblemSkoru.Text = selectedProblemDurumDegerlendirme.OncekiProblemSkoru.ToString();
                    txtTahminEdilenProblemSkoru.Text = selectedProblemDurumDegerlendirme.TahminEdilenProblemSkoru.ToString();

                    //DateTimePicker
                    dtpDegerlendirmeTarihi.Value = selectedProblemDurumDegerlendirme.DegerlendirmeTarihi;

                    //Combos
                    ddlProblem.SelectedValue = selectedProblemDurumDegerlendirme.ProblemId;
                    ddlKullanici.SelectedValue = selectedProblemDurumDegerlendirme.KullaniciId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlProblem, ddlKullanici, txtYeniProblemTanimi, txtYeniHedef, txtOncekiProblemSkoru, txtTahminEdilenProblemSkoru, dtpDegerlendirmeTarihi };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (problemDurumDegerlendirmeId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE ProblemDurumDegerlendirme SET YeniProblemTanimi = '{0}', YeniHedef = '{1}', ProblemId = {2}, OncekiProblemSkoru = {3}, TahminEdilenProblemSkoru = {4}, KullaniciId = {5}, DegerlendirmeTarihi = CONVERT(DATE, '{6}', 105) WHERE Id = " + problemDurumDegerlendirmeId;
                sqlCommand = string.Format(sqlCommand, txtYeniProblemTanimi.Text, txtYeniHedef.Text, ddlProblem.SelectedValue, txtOncekiProblemSkoru.Text, txtTahminEdilenProblemSkoru.Text, ddlKullanici.SelectedValue, dtpDegerlendirmeTarihi.Value.ToShortDateString());
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO ProblemDurumDegerlendirme (YeniProblemTanimi, YeniHedef, ProblemId, OncekiProblemSkoru, TahminEdilenProblemSkoru, KullaniciId, DegerlendirmeTarihi) VALUES ('{0}', '{1}', {2}, {3}, {4}, {5}, CONVERT(DATE, '{6}', 105))";
                sqlCommand = string.Format(sqlCommand, txtYeniProblemTanimi.Text, txtYeniHedef.Text, ddlProblem.SelectedValue, txtOncekiProblemSkoru.Text, txtTahminEdilenProblemSkoru.Text, ddlKullanici.SelectedValue, dtpDegerlendirmeTarihi.Value.ToShortDateString());
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadProblemDurumDegerlendirme();
            this.Close();
        }
    }
}
