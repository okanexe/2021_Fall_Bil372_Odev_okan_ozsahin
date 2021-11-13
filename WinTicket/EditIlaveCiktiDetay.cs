using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinTicket.Model;
using WinTicket.Util;
using WinTicket.WinTicketDataSetTableAdapters;

namespace WinTicket
{
    public partial class EditIlaveCiktiDetay : BaseForm
    {
        private readonly Dashboard dashboard;
        private int? ilaveCiktiDetayId;

        public EditIlaveCiktiDetay(Dashboard dashboard, int? id)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.ilaveCiktiDetayId = id;
        }

        private void EditIlaveCiktiDetay_Load(object sender, EventArgs e)
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

            BelirtecTableAdapter belirtecTableAdapter = new BelirtecTableAdapter();
            belirtecTableAdapter.Fill(dataSet.Belirtec);

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

            DataRow belirtecDataRow = dataSet.Belirtec.NewRow();
            belirtecDataRow["BelirtecTanimi"] = "Seçiniz";
            dataSet.Belirtec.Rows.InsertAt(belirtecDataRow, 0);

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

            ddlBelirtec.DataSource = dataSet.Belirtec;
            ddlBelirtec.DisplayMember = "BelirtecTanimi";
            ddlBelirtec.ValueMember = "Id";

            if (ilaveCiktiDetayId.HasValue)
            {
                IlaveCiktiDetayTableAdapter ilaveCiktiDetayTableAdapter = new IlaveCiktiDetayTableAdapter();
                ilaveCiktiDetayTableAdapter.Fill(dataSet.IlaveCiktiDetay);
                var selectedIlaveCiktiDetay = dataSet.IlaveCiktiDetay.FirstOrDefault(m => m.Id.Equals(ilaveCiktiDetayId));
                if (selectedIlaveCiktiDetay != null)
                {
                    //Texts
                    txtSira.Text = selectedIlaveCiktiDetay.Sira.ToString();

                    //Combos
                    ddlAlan.SelectedValue = selectedIlaveCiktiDetay.AlanId;
                    ddlSinif.SelectedValue = selectedIlaveCiktiDetay.SinifId;
                    ddlMudahale.SelectedValue = selectedIlaveCiktiDetay.MudahaleId;
                    ddlProblem.SelectedValue = selectedIlaveCiktiDetay.ProblemId;
                    ddlBelirtec.SelectedValue = selectedIlaveCiktiDetay.BelirtecId;
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Control[] controls = { ddlProblem, ddlAlan, ddlSinif, ddlMudahale, ddlBelirtec, txtSira };

            if (!FormValidator.Validate(controls.ToList(), errorProvider))
            {
                return;
            }

            if (ilaveCiktiDetayId.HasValue)
            {
                //UPDATE
                string sqlCommand = "UPDATE IlaveCiktiDetay SET ProblemId = {0}, AlanId = {1}, SinifId = {2}, MudahaleId = {3}, BelirtecId = {4}, Sira = {5}, EkleyenKullaniciAdi = '{6}' WHERE Id = " + ilaveCiktiDetayId;
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlMudahale.SelectedValue, ddlBelirtec.SelectedValue, txtSira.Text, Global.Username);
                _operation.Update(_connectionString, sqlCommand);
            }
            else
            {
                //INSERT
                string sqlCommand = "INSERT INTO IlaveCiktiDetay (ProblemId, AlanId, SinifId, MudahaleId, BelirtecId, Sira, EkleyenKullaniciAdi) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, '{6}')";
                sqlCommand = string.Format(sqlCommand, ddlProblem.SelectedValue, ddlAlan.SelectedValue, ddlSinif.SelectedValue, ddlMudahale.SelectedValue, ddlBelirtec.SelectedValue, txtSira.Text, Global.Username);
                _operation.Insert(_connectionString, sqlCommand);
            }

            dashboard.LoadIlaveCiktiDetay();
            this.Close();

        }
    }
}
